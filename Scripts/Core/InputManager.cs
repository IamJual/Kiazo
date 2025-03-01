using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Core;

public class InputManager
{
    private Game _game;
    private GraphicsManager _graphicsManager;

    public InputManager(Game game, GraphicsManager graphicsManager)
    {
        _game = game;
        _graphicsManager = graphicsManager;
    }

    public void HandleInput()
    {
        var keyboardState = Keyboard.GetState();

        if (keyboardState.IsKeyDown(Keys.Escape)) _game.Exit();
        if (keyboardState.IsKeyDown(Keys.F9)) _graphicsManager.ApplyWindowed(256, 240);
        if (keyboardState.IsKeyDown(Keys.F10)) _graphicsManager.ApplyBorderlessFullscreen();
        if (keyboardState.IsKeyDown(Keys.F11)) _graphicsManager.ApplyFullscreen();
    }
}
