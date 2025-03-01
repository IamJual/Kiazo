using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Graphics;

public static class Resolution
{
    private static void SetDisplayMode(GraphicsDeviceManager graphics, Game game, int width, int height, bool isFullScreen, bool isBorderless)
    {
        graphics.PreferredBackBufferWidth = width;
        graphics.PreferredBackBufferHeight = height;
        game.Window.IsBorderless = isBorderless;
        graphics.IsFullScreen = isFullScreen;
        graphics.ApplyChanges();
    }

    public static void ApplyWindowed(GraphicsDeviceManager graphics, Game game, int width, int height)
    {
        SetDisplayMode(graphics, game, width, height, false, false);
    }

    public static void ApplyBorderlessFullscreen(GraphicsDeviceManager graphics, Game game)
    {
        var displayMode = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
        SetDisplayMode(graphics, game, displayMode.Width, displayMode.Height, false, true);
    }

    public static void ApplyFullscreen(GraphicsDeviceManager graphics, Game game)
    {
        var displayMode = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
        SetDisplayMode(graphics, game, displayMode.Width, displayMode.Height, true, false);
    }
}
