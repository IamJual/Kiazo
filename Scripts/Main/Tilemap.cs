using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kiazo;
public class Tilemap 
{
    public void DrawTile(int tileMapX, int tileMapY, int tileSizeX, int tileSizeY, SpriteBatch spriteBatch, Texture2D tileMapTexture)
    {
        Rectangle tileMapMask = new Rectangle(tileMapX, tileMapY, tileSizeX, tileSizeY);
        spriteBatch.Draw(tileMapTexture, new Vector2(100, 100), tileMapMask, Color.White);
    }

    void GetTile(int tileMapX, int tileMapY, int tileSizeX, int tileSizeY)
    {
        Rectangle tileMapMask = new Rectangle(tileMapX, tileMapY, tileSizeX, tileSizeY);
    }

}