using IL2CPU.API.Attribs;
using SkyOs.Formats;

namespace SkyOs
{
    public static class Files
    {
        public const string Base = "SkyOs.Files.";
        [ManifestResourceStream(ResourceName = Base + "Wallpaper.bmp")] public readonly static byte[] WallpaperB;
        [ManifestResourceStream(ResourceName = Base + "Cursor.bmp")] public readonly static byte[] CursorB;
        [ManifestResourceStream(ResourceName = Base + "Logo.bmp")] public readonly static byte[] LogoB;

        public static Image Cursor = new(CursorB);
        public static Image Logo = new(LogoB);
        public static Image Wallpaper = new(WallpaperB);
    }
}
