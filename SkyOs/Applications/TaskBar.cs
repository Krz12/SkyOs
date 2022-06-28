using SkyOs;
using SkyOs.Graphics;
using SkyOs.Graphics.GUI;
using System;

namespace SkyOs.Applications
{
    public class TaskBar : Runtime.Application
    {
        public Button Button1 = new();
        public Window Window = new();

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
            Runtime.Windows.Add(Window);
        }

        public override void OnDestroy()
        {

        }

        public override void OnUpdate()
        {

        }

        private void Button1_Click()
        {
            if(Varibles.menu)
            {
                Varibles.menu = false;
            }
            else
            {
                Varibles.menu = true;
            }
        }
    }
}