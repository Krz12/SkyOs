﻿using VBEDriver = Cosmos.HAL.Drivers.VBEDriver;
using Mouse = Cosmos.System.MouseManager;
using static SkyOs.Assets;
using SkyOs.Numerics;
using SkyOs.Formats;
using Cosmos.Core;
using System.IO;
using System;

namespace SkyOs.Graphics
{
    public unsafe class Canvas
    {
        public Canvas(uint Width, uint Height)
        {
            VBE = new((ushort)Width, (ushort)Height, 32);
            this.Width = Width;
            this.Height = Height;
            Buffer = new uint*[Width * Height];
            Wallpaper = Wallpaper.Resize((int)Width, (int)Height);
            Update(false);

            Mouse.ScreenWidth = Width;
            Mouse.ScreenHeight = Height;
            Mouse.X = Width / 2;
            Mouse.Y = Height / 2;
            Current = this;
        }

        public uint Width, Height, FPS;
        public static Canvas Current;
        public VBEDriver VBE;
        public uint*[] Buffer;
        private DateTime LT;
        private uint Frames;

        #region Pixel

        public void SetPixel(int X, int Y, Color Color)
        {
            if (X < 0 || Y < 0 || X >= Width || Y >= Height || Color.A == 0)
            {
                return;
            }
            if (Color.A < 255)
            {
                Color = Color.AlphaBlend(Color, GetPixel(X, Y));
            }

            // Draw main pixel
            Buffer[(Width * Y) + X] = (uint*)Color.ARGB;
        }
        public Color GetPixel(int X, int Y)
        {
            if (X < 0 || Y < 0 || X >= Width || Y >= Height)
            {
                return Color.Black;
            }

            return Color.FromARGB((uint)Buffer[(Width * Y) + X]);
        }

        #endregion

        #region Line

        public void DrawLine(int X1, int Y1, int X2, int Y2, Color Color)
        {
            int DX = Math.Abs(X2 - X1), SX = X1 < X2 ? 1 : -1;
            int DY = Math.Abs(Y2 - Y1), SY = Y1 < Y2 ? 1 : -1;
            int err = (DX > DY ? DX : -DY) / 2;

            while (X1 != X2 || Y1 != Y2)
            {
                SetPixel(X1, Y1, Color);
                int e2 = err;
                if (e2 > -DX) { err -= DY; X1 += SX; }
                if (e2 < DY) { err += DX; Y1 += SY; }
            }
        }
        public void DrawAngledLine(int X, int Y, int Angle, int Radius, Color Color)
        {
            int IX = (int)(Radius * Math.Cos(Math.PI * Angle / 180));
            int IY = (int)(Radius * Math.Sin(Math.PI * Angle / 180));
            DrawLine(X, Y, X + IX, Y + IY, Color);
        }
        public void DrawAngledLine(int X, int Y, int Angle, int Radius, Gradient Gradient)
        {
            int IX = (int)(Radius * Math.Cos(Math.PI * Angle / 180));
            int IY = (int)(Radius * Math.Sin(Math.PI * Angle / 180));
            DrawLine(X, Y, X + IX, Y + IY, Gradient[IX][IY]);
        }
        public void DrawQuadraticBezierLine(int X1, int Y1, int X2, int Y2, int X3, int Y3, Color Color, int N = 6)
        {
            // X2 and Y2 is where the curve should bend to.
            if (N > 0)
            {
                int X12 = (X1 + X2) / 2;
                int Y12 = (Y1 + Y2) / 2;
                int X23 = (X2 + X3) / 2;
                int Y23 = (Y2 + Y3) / 2;
                int X123 = (X12 + X23) / 2;
                int Y123 = (Y12 + Y23) / 2;

                DrawQuadraticBezierLine(X1, Y1, X12, Y12, X123, Y123, Color, N - 1);
                DrawQuadraticBezierLine(X123, Y123, X23, Y23, X3, Y3, Color, N - 1);
            }
            else
            {
                DrawLine(X1, Y1, X2, Y2, Color);
                DrawLine(X2, Y2, X3, Y3, Color);
            }
        }
        public void DrawCubicBezierLine(int X0, int Y0, int X1, int Y1, int X2, int Y2, int X3, int Y3, Color Color)
        {
            for (double U = 0.0; U <= 1.0; U += 0.0001)
            {
                double Power3V1 = (1 - U) * (1 - U) * (1 - U);
                double Power2V1 = (1 - U) * (1 - U);
                double Power3V2 = U * U * U;
                double Power2V2 = U * U;

                double XU = Power3V1 * X0 + 3 * U * Power2V1 * X1 + 3 * Power2V2 * (1 - U) * X2 + Power3V2 * X3;
                double YU = Power3V1 * Y0 + 3 * U * Power2V1 * Y1 + 3 * Power2V2 * (1 - U) * Y2 + Power3V2 * Y3;
                SetPixel((int)XU, (int)YU, Color);
            }
        }

        #endregion

        #region Rectangle

        public void DrawRectangle(int X, int Y, int Width, int Height, int Radius, Color Color)
        {
            if (Radius > 0)
            {
                DrawCircle(Radius + X, Radius + Y, Radius, Color, 180, 270); // Top left
                DrawCircle(X + Width - Radius, Y + Height - Radius, Radius, Color, 0, 90); // Bottom right
                DrawCircle(Radius + X, Y + Height - Radius, Radius, Color, 90, 180); // Bottom left
                DrawCircle(X + Width - Radius, Radius + Y, Radius, Color, 270, 360);
            }
            DrawLine(X + Radius, Y, X + Width - Radius, Y, Color); // Top Line
            DrawLine(X + Radius, Y + Height, X + Width - Radius, Height + Y, Color); // Bottom Line
            DrawLine(X, Y + Radius, X, Y + Height - Radius, Color); // Left Line
            DrawLine(X + Width, Y + Radius, Width + X, Y + Height - Radius, Color); // Right Line
        }
        public void DrawFilledRectangle(int X, int Y, int Width, int Height, int Radius, Color Color)
        {
            if (Radius == 0)
            {
                for (int IX = X; IX < X + Width; IX++)
                {
                    for (int IY = Y; IY < Y + Height; IY++)
                    {
                        SetPixel(IX, IY, Color);
                    }
                }
            }
            else
            {
                DrawFilledRectangle(X + Radius, Y, Width - Radius * 2, Height, 0, Color);
                DrawFilledRectangle(X, Y + Radius, Width, Height - Radius * 2, 0, Color);

                DrawFilledCircle(X + Radius, Y + Radius, Radius, Color);
                DrawFilledCircle(X + Width - Radius - 1, Y + Radius, Radius, Color);

                DrawFilledCircle(X + Radius, Y + Height - Radius - 1, Radius, Color);
                DrawFilledCircle(X + Width - Radius - 1, Y + Height - Radius - 1, Radius, Color);
            }
        }

        public void DrawRectangleGrid(int X, int Y, int BlockCountX, int BlockCountY, int BlockSize, Color BlockType1, Color BlockType2)
        {
            for (int IX = 0; IX < BlockCountX; IX++)
            {
                for (int IY = 0; IY < BlockCountY; IY++)
                {
                    if ((IX + IY) % 2 == 0)
                    {
                        DrawFilledRectangle(X + IX * BlockSize, Y + IY * BlockSize, BlockSize, BlockSize, 0, BlockType1);
                    }
                    else
                    {
                        DrawFilledRectangle(X + IX * BlockSize, Y + IY * BlockSize, BlockSize, BlockSize, 0, BlockType2);
                    }
                }
            }
        }

        #endregion

        #region Circle

        public void DrawCircle(int X, int Y, int Radius, Color Color, int StartAngle = 0, int EndAngle = 360)
        {
            if (Radius == 0)
            {
                return;
            }

            for (double Angle = StartAngle; Angle < EndAngle; Angle += 0.5)
            {
                double Angle1 = Math.PI * Angle / 180;
                int IX = (int)(Radius * Math.Cos(Angle1));
                int IY = (int)(Radius * Math.Sin(Angle1));
                SetPixel(X + IX, Y + IY, Color);
            }
        }
        public void DrawFilledCircle(int X, int Y, int Radius, Color Color, int StartAngle = 0, int EndAngle = 360)
        {
            if (Radius == 0)
            {
                return;
            }

            for (int I = 0; I < Radius; I++)
            {
                DrawCircle(X, Y, I, Color, StartAngle, EndAngle);
            }
        }

        #endregion

        #region Triangle

        public void DrawTriangle(int X1, int Y1, int X2, int Y2, int X3, int Y3, Color Color)
        {
            DrawLine(X1, Y1, X2, Y2, Color);
            DrawLine(X1, Y1, X3, Y3, Color);
            DrawLine(X2, Y2, X3, Y3, Color);
        }
        public void DrawTriangle(Triangle<float> Triangle, Color Color)
        {
            DrawTriangle((int)Triangle.P1.X, (int)Triangle.P1.Y, (int)Triangle.P2.X, (int)Triangle.P2.Y, (int)Triangle.P3.X, (int)Triangle.P3.Y, Color);
        }
        public void DrawTriangle(Triangle<int> Triangle, Color Color)
        {
            DrawTriangle(Triangle.P1.X, Triangle.P1.Y, Triangle.P2.X, Triangle.P2.Y, Triangle.P3.X, Triangle.P3.Y, Color);
        }

        #endregion

        #region Image

        public void DrawImage(int X, int Y, Image Image)
        {
            if (Image == null)
            {
                throw new Exception("Cannot draw a null image file.");
            }
            for (int IX = 0; IX < Image.Width; IX++)
            {
                for (int IY = 0; IY < Image.Height; IY++)
                {
                    SetPixel(X + IX, Y + IY, Color.FromARGB((uint)Image.Buffer[(Image.Width * IY) + IX]));
                }
            }
        }
        public void DrawImage(int X, int Y, int Width, int Height, Image Image)
        {
            if (Image == null)
            {
                throw new Exception("Cannot draw a null image file.");
            }
            for (int IX = 0; IX < Image.Width; IX++)
            {
                for (int IY = 0; IY < Image.Height; IY++)
                {
                    SetPixel(
                        X + IX / (Image.Width / Width),
                        Y + IY / (Image.Height / Height),
                        Color.FromARGB((uint)Image.Buffer[(Image.Width * IY) + IX]));
                }
            }
        }

        #endregion

        #region Text

        public class Font
        {
            public Font(string Charset, MemoryStream MS, int Width, int Height)
            {
                this.Charset = Charset;
                this.MS = MS;
                this.Width = Width;
                this.Height = Height;
            }

            public static string DefaultCharset = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
            public static Font Default = new(DefaultCharset, new(Font1), 8, 16);

            public string Charset;
            public MemoryStream MS;
            public int Width;
            public int Height;
        }

        public void DrawString(int X, int Y, string Text, Font Font, Color Color, bool Center = false, int Padding = 2)
        {
            if (Text == null || Text.Length == 0)
            {
                return;
            }
            string[] Lines = Text.Split('\n');

            for (int Line = 0; Line < Lines.Length; Line++)
            {
                for (int Char = 0; Char < Lines[Line].Length; Char++)
                {
                    // draw character in the middle of x and y
                    int IX = X + (Font.Width * Char);
                    int IY = Y + (Font.Height * Line);

                    // If center, move ix and iy to the center
                    if (Center)
                    {
                        IX -= Font.Width * (Lines[Line].Length / 2);
                        IY -= Font.Height * (Lines.Length / 2);
                    }

                    DrawChar(IX, IY, Lines[Line][Char], Font, Color);
                }
            }
        }

        public int DrawChar(int X, int Y, char Char, Font Font, Color Color)
        {
            int Index = Font.Charset.IndexOf(Char);
            if (Index == -1) return Font.Height / 2;

            int MaxX = 0;

            bool LastPixelIsNotDrawn = false;

            int SizePerFont = Font.Height * (Font.Height / Font.Width);
            byte[] BFont = new byte[SizePerFont];
            Font.MS.Seek(SizePerFont * Index, SeekOrigin.Begin);
            Font.MS.Read(BFont, 0, BFont.Length);

            for (int h = 0; h < Font.Height; h++)
            {
                for (int aw = 0; aw < Font.Height / Font.Width; aw++)
                {

                    for (int ww = 0; ww < 8; ww++)
                    {
                        if ((BFont[(h * (Font.Height / 8)) + aw] & (0x80 >> ww)) != 0)
                        {
                            SetPixel(X + (aw * 8) + ww, Y + h, Color);

                            if ((aw * 8) + ww > MaxX)
                            {
                                MaxX = (aw * 8) + ww;
                            }

                            if (LastPixelIsNotDrawn)
                            {
                                SetPixel(X + (aw * 8) + ww - 1, Y + h, Color.FromARGB(255, (byte)(Color.R / 2), (byte)(Color.G / 2), (byte)(Color.B / 2)));
                                LastPixelIsNotDrawn = false;
                            }
                        }
                        else
                        {
                            LastPixelIsNotDrawn = true;
                        }
                    }
                }
            }

            return MaxX;
        }

        #endregion

        #region Misc

        public void Clear(Color? Color = null)
        {
            if (Color == null)
                Color = Graphics.Color.Black;

            MemoryOperations.Fill((uint[])(object)Buffer, Color.Value.ARGB);
        }

        public void Update(bool ShowMouse)
        {
            Frames++;
            if ((DateTime.Now - LT).TotalSeconds >= 1)
            {
                Cosmos.Core.Memory.Heap.Collect();
                FPS = Frames;
                Frames = 0;
                LT = DateTime.Now;
            }
            if (ShowMouse)
            {
                DrawImage((int)Mouse.X, (int)Mouse.Y, Cursor);
            }

            Global.BaseIOGroups.VBE.LinearFrameBuffer.Copy((uint[])(object)Buffer);
            MemoryOperations.Copy((uint[])(object)Buffer, (uint[])(object)Wallpaper.Buffer);
        }

        #endregion
    }
}