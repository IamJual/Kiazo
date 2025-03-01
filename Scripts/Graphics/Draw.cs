using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Graphics;

public class Draw
{
    public Texture2D Texture { get; set; }
    public Vector2 Position { get; set; }
    public Rectangle Mask { get; set; }
    public Color Color { get; set; }
    public float Scale { get; set; }
    public float Rotation { get; set; }

    private static List<Draw> drawList = new List<Draw>();

    public Draw(Texture2D texture, Vector2 position, Rectangle mask, Color color, float scale, float rotation)
    {
        Texture = texture;
        Position = position;
        Mask = mask;
        Color = color;
        Scale = scale;
        Rotation = rotation;
    }

    public static void AddDrawItem(Texture2D texture, Vector2 position, Rectangle mask, Color color, float scale, float rotation)
    {
        var drawItem = new Draw(texture, position, mask, color, scale, rotation);
        drawList.Add(drawItem);
    }

    public static void Render(SpriteBatch spriteBatch)
    {
        foreach (var item in drawList)
        {
            item.RenderItem(spriteBatch);
        }
    }

    private void RenderItem(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, Mask, Color, Rotation, Vector2.Zero, Scale, SpriteEffects.None, 0f);
    }
}

