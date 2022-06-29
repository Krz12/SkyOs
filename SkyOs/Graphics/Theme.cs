namespace SkyOs.Graphics
{
    public class Theme
    {
        public static Theme DefaultLight = new()
        {
            Background = Color.White,
            BackgroundClick = Color.DeepGray,
            BackgroundHover = Color.LightGray,
            BackgroundLight = Color.LightGray,
            Foreground = Color.Black,
            ForegroundClick = Color.White,
            ForegroundHover = Color.Black,
            ForegroundLight = Color.LighterBlack,
            Accent = Color.Blue,
            Font = Canvas.Font.Default,
            Radius = 0,
        };
        public static Theme DefaultDark = new()
        {
            Background = Color.LightBlack,
            BackgroundClick = Color.White,
            BackgroundHover = Color.LighterBlack,
            BackgroundLight = Color.LighterBlack,
            Foreground = Color.White,
            ForegroundClick = Color.Black,
            ForegroundHover = Color.White,
            ForegroundLight = Color.LightGray,
            Accent = Color.Blue,
            Font = Canvas.Font.Default,
            Radius = 0,
        };
        public static Theme Default = new()
        {
            Background = Color.LightBlack,
            BackgroundClick = Color.White,
            BackgroundHover = Color.LighterBlack,
            BackgroundLight = Color.LighterBlack,
            Foreground = Color.White,
            ForegroundClick = Color.Black,
            ForegroundHover = Color.White,
            ForegroundLight = Color.LightGray,
            Accent = Color.Blue,
            Font = Theme.DefaultLight.Font,
            Radius = Theme.DefaultLight.Radius,
        };

        public Color BackgroundClick, ForegroundClick;
        public Color BackgroundHover, ForegroundHover;
        public Color BackgroundLight, ForegroundLight;
        public Color Background, Foreground;
        public Color Accent;
        public Canvas.Font Font;
        public int Radius;
    }
}