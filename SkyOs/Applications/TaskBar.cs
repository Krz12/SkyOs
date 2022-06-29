using SkyOs;
using SkyOs.Graphics;
using SkyOs.Graphics.GUI;
using System;
using System.Collections.Generic;

namespace SkyOs.Applications
{
    public class TaskBar : Runtime.Application
    {
        public Button Button1 = new();
        public Window Window = new();
        //Menu
        public Button MenuButton1 = new();
        public Button RestartButton = new();
        public Button ConsoleButton = new();
        public Button SettingsButton = new();
        public Window MenuWindow = new();
        public override void OnCreate()
        {
            // Main window
            Window.Position = new(0, Convert.ToInt32(Canvas.Current.Height)-50);
            Window.Size = new(Convert.ToInt32(Canvas.Current.Width), 50);
            Window.Theme = Theme.Default;
            Window.Text = "Taskbar";
            Window.Draggable = false;
            Window.TitleVisible = false;
            Window.TopMost = true;

            // Button1
            Button1.Position = new(0, 0);
            Button1.Size = new(50, 50);
            Button1.Text = "S";
            Button1.OnClick = new System.Action(() => { Button1_Click(); });
            Window.Elements.Add(Button1);

            //Menu

            // Main MenuWindow
            MenuWindow.Position = new(0, Convert.ToInt32(Kernel.Canvas.Height) - 300);
            MenuWindow.Size = new(300, 250);
            MenuWindow.Text = "Menu";
            MenuWindow.Theme = Theme.Default;
            MenuWindow.Draggable = false;
            MenuWindow.TitleVisible = false;
            MenuWindow.TopMost = true;

            // Button1
            MenuButton1.Position = new(0, 220);
            MenuButton1.Size = new(70, 30);
            MenuButton1.Text = "Shutdown";
            MenuButton1.OnClick = new System.Action(() => { MenuButton1_Click(); });
            MenuWindow.Elements.Add(MenuButton1);

            //RestartButton
            RestartButton.Position = new(0, 190);
            RestartButton.Size = new(70, 30);
            RestartButton.Text = "Restart";
            RestartButton.OnClick = new System.Action(() => { RestartButton_Click(); });
            MenuWindow.Elements.Add(RestartButton);

            //ConsoleButton
            ConsoleButton.Position = new(0, 160);
            ConsoleButton.Size = new(70, 30);
            ConsoleButton.Text = "Console";
            ConsoleButton.OnClick = new System.Action(() => { ConsoleButton_Click(); });
            MenuWindow.Elements.Add(ConsoleButton);
            Runtime.Windows.Add(MenuWindow);

            //SettingsButton
            SettingsButton.Position = new(0, 130);
            SettingsButton.Size = new(70, 30);
            SettingsButton.Text = "Settings";
            SettingsButton.OnClick = new System.Action(() => { SettingsButton_Click(); });
            MenuWindow.Elements.Add(SettingsButton);
            Runtime.Windows.Add(MenuWindow);

            Runtime.Windows.Add(Window);
        }

        public override void OnDestroy()
        {

        }
        int oC = 0;
        public override void OnUpdate()
        {
            if (Runtime.Windows.Count != oC)
            {
                Window.Elements.Clear();
                foreach(Window window in Runtime.Windows)
                {
                    // Button2
                    Button Button2 = new();
                    Button2.Position = new(Runtime.Windows.IndexOf(window)*50, (int)Canvas.Current.Height-50);
                    Button2.Size = new(50, 50);
                    Button2.Text = window.Text;
                    Button2.Visible = true;
                    Button2.OnClick = new System.Action(() => { Button2_Click(); });
                    Window.Elements.Add(Button2);
                }
                oC = Runtime.Windows.Count;
            }
        }

        private void Button1_Click()
        {
            if(Varibles.menu)
            {
                Varibles.menu = false;
                MenuWindow.Visible = false;
            }
            else
            {
                Varibles.menu = true;
                MenuWindow.Visible = true;
            }
        }
        private void Button2_Click()
        {
            
        }
        private void MenuButton1_Click()
        {
            Runtime.Stop();
        }
        private void RestartButton_Click()
        {
            Runtime.Restart();
        }
        private void ConsoleButton_Click()
        {
            _ = new Applications.Terminal();
        }
        private void SettingsButton_Click()
        {
            _ = new Applications.Settings();
        }
        private static void AppButton_Click(Window window)
        {
            Runtime.Windows.Remove(window);
            Runtime.Windows.Insert(Runtime.Windows.Count, window);
        }
    }
}