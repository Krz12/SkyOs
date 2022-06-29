using SkyOs;
using SkyOs.Graphics;
using SkyOs.Graphics.GUI;

namespace SkyOs.Applications
{
    public class Settings : Runtime.Application
    {
        public Button Button1 = new();
        public Button Button2 = new();
        public Button Button3 = new();
        public Button Button4 = new();
        public Label Label1 = new();
        public Button CloseButton = new();
        public Button MaximizeButton = new();
        public Button MinimizeButton = new();
        public Window SettingsWindow = new();
        public Window Preferences = new();

        public override void OnCreate()
        {
            // Main window
            SettingsWindow.Position = new(156, 156);
            SettingsWindow.Size = new(500, 375);
            SettingsWindow.Theme = Theme.Default;
            SettingsWindow.Text = "Settings";

            // Button1
            Button1.Position = new(0, 0);
            Button1.Size = new(100, 23);
            Button1.Text = "User";
            Button1.OnClick = new System.Action(() => { Button1_Click(); });

            // Button2
            Button2.Position = new(0, 25);
            Button2.Size = new(100, 23);
            Button2.Text = "System";
            Button2.OnClick = new System.Action(() => { Button2_Click(); });

            // Button3
            Button3.Position = new(0, 48);
            Button3.Size = new(100, 23);
            Button3.Text = "Preferences";
            Button3.OnClick = new System.Action(() => { Button3_Click(); });

            // CloseButton
            CloseButton.Position = new(SettingsWindow.Size.Width - 20, -20);
            CloseButton.Size = new(20, 20);
            CloseButton.Text = "X";
            CloseButton.OnClick = new System.Action(() => { CloseButton_Click(); });

            // MaximizeButton
            MaximizeButton.Position = new(SettingsWindow.Size.Width - 40, -20);
            MaximizeButton.Size = new(20, 20);
            MaximizeButton.Text = "[]";
            MaximizeButton.OnClick = new System.Action(() => { MaximizeButton_Click(); });

            // MinimizeButton
            MinimizeButton.Position = new(SettingsWindow.Size.Width - 60, -20);
            MinimizeButton.Size = new(20, 20);
            MinimizeButton.Text = "_";
            MinimizeButton.OnClick = new System.Action(() => { MinimizeButton_Click(); });

            SettingsWindow.Elements.Add(Button1);
            SettingsWindow.Elements.Add(Button2);
            SettingsWindow.Elements.Add(Button3);
            SettingsWindow.Elements.Add(CloseButton);
            SettingsWindow.Elements.Add(MaximizeButton);
            SettingsWindow.Elements.Add(MinimizeButton);

            //Preferences

            // Preferences Window
            Preferences.Position = new(SettingsWindow.Position.X + 100, SettingsWindow.Position.Y+20);
            Preferences.Size = new(SettingsWindow.Size.Width - 100, SettingsWindow.Size.Height-20);
            Preferences.Theme = Theme.Default;
            Preferences.Text = "Preferences";
            Preferences.Visible = true;

            // Button4
            Button4.Position = new(Preferences.Size.Width-100, 0);
            Button4.Size = new(100, 23);
            Button4.Text = Varibles.theme;
            Button4.OnClick = new System.Action(() => { Button4_Click(); });

            // Label1
            Label1.Position = new(0, 0);
            Label1.Size = new(1, 1);
            Label1.Text = "Theme:";
            Label1.Center = false;

            Preferences.Elements.Add(Label1);
            Preferences.Elements.Add(Button4);
            Runtime.Windows.Add(SettingsWindow);
            Runtime.Windows.Add(Preferences);
        }

        public override void OnDestroy()
        {

        }

        public override void OnUpdate()
        {
            Preferences.Position = new(SettingsWindow.Position.X + 100, SettingsWindow.Position.Y + 20);
            Button4.Text = Varibles.theme;
            if(Preferences.Visible && Runtime.Windows.IndexOf(SettingsWindow) ==Runtime.Windows.Count)
            {
                Runtime.Windows.Remove(Preferences);
                Runtime.Windows.Add(Preferences);
            }
        }

        private void Button1_Click()
        {
            
        }

        private void Button2_Click()
        {
            
        }
        private void Button3_Click()
        {
            Preferences.Visible = true;
        }
        private void Button4_Click()
        {
            if(Varibles.theme=="Light")
            {
                Varibles.theme = "Dark";
            }
            else
            {
                Varibles.theme = "Light";
            }
        }
        private void CloseButton_Click()
        {
            Runtime.Windows.RemoveAt(Runtime.Windows.IndexOf(SettingsWindow));
            Runtime.Windows.RemoveAt(Runtime.Windows.IndexOf(Preferences));
            Runtime.Applications.RemoveAt(Runtime.Applications.IndexOf(this));
        }
        private void MaximizeButton_Click()
        {
            if(SettingsWindow.Size.Width==Canvas.Current.Width && SettingsWindow.Size.Height==Canvas.Current.Height-50 && SettingsWindow.Position.X==0 && SettingsWindow.Position.Y == 20)
            {
                SettingsWindow.Position = new(156, 156);
                SettingsWindow.Size = new(500, 375);
                Preferences.Size = new(SettingsWindow.Size.Width - 100, SettingsWindow.Size.Height - 20);
                Button4.Position = new(Preferences.Size.Width - 100, 0);
                MinimizeButton.Position = new(SettingsWindow.Size.Width - 60, -20);
                MaximizeButton.Position = new(SettingsWindow.Size.Width - 40, -20);
                CloseButton.Position = new(SettingsWindow.Size.Width - 20, -20);
            }
            else
            {
                SettingsWindow.Size = new((int)Canvas.Current.Width, (int)Canvas.Current.Height - 50);
                Preferences.Size = new(SettingsWindow.Size.Width - 100, SettingsWindow.Size.Height - 20);
                Button4.Position = new(Preferences.Size.Width - 100, 0);
                SettingsWindow.Position = new(0, 20);
                MinimizeButton.Position = new(SettingsWindow.Size.Width - 60, -20);
                MaximizeButton.Position = new(SettingsWindow.Size.Width - 40, -20);
                CloseButton.Position = new(SettingsWindow.Size.Width - 20, -20);
            }
        }
        private void MinimizeButton_Click()
        {
            Runtime.Windows.RemoveAt(Runtime.Windows.IndexOf(SettingsWindow));
            Runtime.Windows.RemoveAt(Runtime.Windows.IndexOf(Preferences));
        }
    }
}