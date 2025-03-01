using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using Graphics;

namespace Assets;

public class Tiles
{
    private Texture2D _tilemap;

    public Tiles(ContentManager contentManager)
    {
        _tilemap = contentManager.Load<Texture2D>("textures/tilemaps/tilemap");

        DrawTile(_tilemap, new Vector2(5, 3), 0, 0, 6, 3);
    }

    public void DrawTile(Texture2D tilemap, Vector2 tilePosition, int tileIndexX, int tileIndexY, int tileSizeX, int tileSizeY)
    {
        tilePosition = tilePosition * 8;

        tileIndexX = tileIndexX * 8;
        tileIndexY = tileIndexY * 8;

        tileSizeX = tileSizeX * 8;
        tileSizeY = tileSizeY * 8;

        Draw.AddDrawItem(tilemap, tilePosition, new Rectangle(tileIndexX, tileIndexY, tileSizeX, tileSizeY), Color.White, 1.0f, 0.0f);
    }
}