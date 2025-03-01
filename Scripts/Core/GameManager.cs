using Microsoft.Xna.Framework;

using Assets;
using Graphics;

namespace Core;

public class GameManager : Game
{
    private GraphicsDeviceManager _graphics;
    private GraphicsManager _graphicsManager;
    private InputManager _inputManager;

    public GameManager()
    {
        _graphics = new GraphicsDeviceManager(this);
        Resolution.ApplyBorderlessFullscreen(_graphics, this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphicsManager = new GraphicsManager(_graphics, this);
        _inputManager = new InputManager(this, _graphicsManager);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _graphicsManager.LoadContent(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        new Tiles(Content);

        _inputManager.HandleInput();
        _graphicsManager.UpdateCanvas();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _graphicsManager.Render();
    }
}
