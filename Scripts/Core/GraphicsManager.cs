using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using Graphics;

namespace Core;

public class GraphicsManager
{
    private GraphicsDeviceManager _graphics;
    private Game _game;
    private Canvas _canvas;
    private SpriteBatch _spriteBatch;

    public GraphicsManager(GraphicsDeviceManager graphics, Game game)
    {
        _graphics = graphics;
        _game = game;
        _canvas = new Canvas(game.GraphicsDevice, 256, 240);
    }

    public void LoadContent(ContentManager content)
    {
        _spriteBatch = new SpriteBatch(_game.GraphicsDevice);
    }

    public void UpdateCanvas()
    {
        _canvas.UpdateBounds();
    }

    public void Render()
    {
        _game.GraphicsDevice.Clear(new Color(170, 0, 255));
        _canvas.BeginDrawing();

        _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

        Draw.Render(_spriteBatch);

        _spriteBatch.End();
        _canvas.Draw(_spriteBatch);
    }

    public void ApplyWindowed(int width, int height)
    {
        Resolution.ApplyWindowed(_graphics, _game, width, height);
    }

    public void ApplyBorderlessFullscreen()
    {
        Resolution.ApplyBorderlessFullscreen(_graphics, _game);
    }

    public void ApplyFullscreen()
    {
        Resolution.ApplyFullscreen(_graphics, _game);
    }
}

