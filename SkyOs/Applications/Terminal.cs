using SkyOs.Graphics.GUI;
using SkyOs.Graphics;
using System.Collections.Generic;
using SkyOs;

namespace SkyOs.Applications
{
    public class Terminal : Runtime.Application
    {
        public Button Button1 = new();
        public Button Button2 = new();
        public Window Window = new();
        public Label Label1 = new();
        public Textbox TextBox1 = new();
        public string Input = "";

        public override void OnCreate()
        {
            // Main window
            Window.Position = new(256, 256);
            Window.Size = new(500, 375);
            Window.Theme = Theme.DefaultDark;
            Window.Text = "Terminal";

            // Main text
            Label1.Position = new(0, 0);
            Label1.Size = new(1, 1);
            Label1.Text = "> ";
            Label1.Center = false;
            Window.Elements.Add(Label1);

            // Close button
            Button1.Position = new(Window.Size.Width - 15, -15);
            Button1.Size = new(15, 15);
            Button1.Text = "X";
            Button1.OnClick = new System.Action(() => { Button1_Click(); });
            Window.Elements.Add(Button1);

            // TextBox1
            TextBox1.Position = new(0, Window.Size.Height - Canvas.Font.Default.Height * 2);
            TextBox1.Size = new(Window.Size.Width, Canvas.Font.Default.Height);
            Window.Elements.Add(TextBox1);
            Runtime.Windows.Add(Window);

            // Execute Button
            Button2.Position = new(Window.Size.Width - 80, Window.Size.Height - 30);
            Button2.Size = new(80, 15);
            Button2.Text = "Execute";
            Button2.OnClick = new System.Action(() => { Button2_Click(); });
            Window.Elements.Add(Button2);
        }

        public override void OnDestroy()
        {

        }

        public override void OnUpdate()
        {
            if (Cosmos.System.KeyboardManager.TryReadKey(out var Key))
            {
                switch (Key.Key)
                {
                    case Cosmos.System.ConsoleKeyEx.Enter:
                        Label1.Text += "\n";
                        Label1.Text += Kernel.UserName+ Kernel.path +"> ";
                        Input = TextBox1.Text;
                        //if (Input.Length == 0)
                        //{
                        //    Label1.Text += "> ";
                        //    return;
                        //}
                        string response = Kernel.commandManger.processInput(Input);
                        Label1.Text += response;
                        break;
                }
            }
            // Trim the string to fit within the window
            //while (Label1.Text.Remove(0, Label1.Text.LastIndexOf('\n')).Length * Theme.DefaultDark.Font.Width > Window.Size.Width)
            //{
            //Label1.Text = Label1.Text[0..(Label1.Text.Length - 1)];
            //  Input = Input[0..(Input.Length - 1)];
            //}
            while (Label1.Text.Split('\n').Length * Canvas.Font.Default.Height > Window.Size.Height * 2)
            {
                string[] Temp = Label1.Text.Split('\n');
                Label1.Text = "";
                for (int I = 1; I < Temp.Length; I++)
                {
                    Label1.Text += Temp[I] + '\n';
                }
            }
        }

        private void Button1_Click()
        {
            Runtime.Windows.RemoveAt(Runtime.Windows.IndexOf(Window)); Runtime.Applications.RemoveAt(Runtime.Applications.IndexOf(this));
        }
        private void Button2_Click()
        {
            Label1.Text += "\n";
            Label1.Text += Kernel.UserName + Kernel.path + "> ";
            Input = TextBox1.Text;
            string response = Kernel.commandManger.processInput(Input);
            Label1.Text += response;
        }
    }
}