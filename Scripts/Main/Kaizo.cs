using Kiazo.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Kiazo;

public class Kaizo : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Canvas _canvas;
    private Texture2D _texture;

    public Kaizo()
    {
        _graphics = new GraphicsDeviceManager(this);
        SetResolution(256, 240);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    private void SetResolution(int width, int height)
    {
        _graphics.PreferredBackBufferWidth = width;
        _graphics.PreferredBackBufferHeight = height;
        _graphics.ApplyChanges();
        _canvas?.UpdateBounds();
    }

    protected override void Initialize()
    {
        _canvas = new Canvas(GraphicsDevice, 256, 240);
        _canvas.UpdateBounds();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _texture = Content.Load<Texture2D>("textures/debug/banana");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }
        if (Keyboard.GetState().IsKeyDown(Keys.F11))
        {
            SetResolution(1000, 1000);
        }

        base.Update(gameTime);
    }


    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _canvas.BeginDrawing();

        DrawTexture();

        _canvas.Draw(_spriteBatch);
    }

    private void DrawTexture()
    {
        _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

        var scale = _canvas.ScaleFactor;
        var position = new Vector2(0, 0);
        var size = new Vector2(_texture.Width, _texture.Height) * scale;
        
        _spriteBatch.Draw(_texture, position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        _spriteBatch.End();
    }
}