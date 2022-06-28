using SkyOs;
using SkyOs.Graphics;
using SkyOs.Graphics.GUI;
using System;

namespace SkyOs.Applications
{
    public class Menu : Runtime.Application
    {
        public Button Button1 = new();
        public Button RestartButton = new();
        public Button ConsoleButton = new();
        public Window MenuWindow = new();

        public override void OnCreate()
        {
            // Main MenuWindow
            MenuWindow.Position = new(0, Convert.ToInt32(Kernel.Canvas.Height) - 300);
            MenuWindow.Size = new(300, 250);
            MenuWindow.Text = "Menu";
            MenuWindow.Theme = Theme.Default;
            MenuWindow.Draggable = false;
            MenuWindow.TitleVisible = false;
            MenuWindow.TopMost = true;

            // Button1
            Button1.Position = new(0, 220);
            Button1.Size = new(70, 30);
            Button1.Text = "Shutdown";
            Button1.OnClick = new System.Action(() => { Button1_Click(); });
            MenuWindow.Elements.Add(Button1);

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
        }

        public override void OnDestroy()
        {

        }

        public override void OnUpdate()
        {
            if(Varibles.menu)
            {
                MenuWindow.Visible = true;
            }
            else
            {
                MenuWindow.Visible = false;
            }
        }

        private void Button1_Click()
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
    }
}