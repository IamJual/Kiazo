using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Graphics;

public class Canvas
{
    private readonly GraphicsDevice _graphicsDevice;
    private readonly RenderTarget2D _renderTarget;
    private Rectangle _renderBounds;
    private float _scaleFactor;

    public float ScaleFactor => _scaleFactor;

    public Canvas(GraphicsDevice graphicsDevice, int width, int height)
    {
        _graphicsDevice = graphicsDevice;
        _renderTarget = new RenderTarget2D(graphicsDevice, width, height);
        _renderBounds = new Rectangle(0, 0, width, height);
        _scaleFactor = 1.0f;
    }

    public void UpdateBounds()
    {
        var screenBounds = _graphicsDevice.PresentationParameters.Bounds;

        _scaleFactor = Math.Min(
            (float)screenBounds.Width / _renderBounds.Width,
            (float)screenBounds.Height / _renderBounds.Height
        );

        int newWidth = (int)(_renderBounds.Width * _scaleFactor);
        int newHeight = (int)(_renderBounds.Height * _scaleFactor);

        int offsetX = (screenBounds.Width - newWidth) / 2;
        int offsetY = (screenBounds.Height - newHeight) / 2;

        _renderBounds = new Rectangle(offsetX, offsetY, newWidth, newHeight);
    }

    public void BeginDrawing()
    {
        _graphicsDevice.SetRenderTarget(_renderTarget);
        _graphicsDevice.Clear(Color.Black);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _graphicsDevice.SetRenderTarget(null);
        spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
        spriteBatch.Draw(_renderTarget, _renderBounds, Color.White);
        spriteBatch.End();
    }
}
