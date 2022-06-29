using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyOs.Graphics;
using var = SkyOs.Graphics.Varibles;

namespace SkyOs.Graphics
{
    public class UpdateTheme
    {
        public static void updateTheme()
        {
            if(var.theme=="Light")
            {
                Theme.Default.Background = Theme.DefaultLight.Background;
                Theme.Default.BackgroundClick = Theme.DefaultLight.BackgroundClick;
                Theme.Default.BackgroundHover = Theme.DefaultLight.BackgroundHover;
                Theme.Default.BackgroundLight = Theme.DefaultLight.BackgroundLight;
                Theme.Default.Foreground = Theme.DefaultLight.Foreground;
                Theme.Default.ForegroundClick = Theme.DefaultLight.ForegroundClick;
                Theme.Default.ForegroundHover = Theme.DefaultLight.ForegroundHover;
                Theme.Default.ForegroundLight = Theme.DefaultLight.ForegroundLight;
                Theme.Default.Accent = Theme.DefaultLight.Accent;
                Theme.Default.Font = Canvas.Font.Default;
                Theme.Default.Radius = Theme.DefaultLight.Radius;
            }
            if (var.theme == "Dark")
            {
                Theme.Default.Background = Theme.DefaultDark.Background;
                Theme.Default.BackgroundClick = Theme.DefaultDark.BackgroundClick;
                Theme.Default.BackgroundHover = Theme.DefaultDark.BackgroundHover;
                Theme.Default.BackgroundLight = Theme.DefaultDark.BackgroundLight;
                Theme.Default.Foreground = Theme.DefaultDark.Foreground;
                Theme.Default.ForegroundClick = Theme.DefaultDark.ForegroundClick;
                Theme.Default.ForegroundHover = Theme.DefaultDark.ForegroundHover;
                Theme.Default.ForegroundLight = Theme.DefaultDark.ForegroundLight;
                Theme.Default.Accent = Theme.DefaultDark.Accent;
                Theme.Default.Font = Canvas.Font.Default;
                Theme.Default.Radius = Theme.DefaultDark.Radius;
            }
        }
    }
}
