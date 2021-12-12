using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Conflux.Core.Render
{
    public struct RenderData2D
    {
        public readonly Vector2 position;

        public readonly Texture2D texture;

        public readonly Rectangle sourceRectangle;

        public readonly float rotation;

        public readonly Vector2 scale;

        public readonly Vector2 origin;

        public readonly SpriteEffects spriteEffects;

        public readonly Color color;

        public RenderData2D(Texture2D tex, Vector2 pos, Rectangle? src, Color clr, float rot, Vector2 orig, Vector2 _scale, SpriteEffects fx = SpriteEffects.None)
        {
            texture = tex;
            position = pos;
            sourceRectangle = src ?? new Rectangle(0, 0, texture.Width, texture.Height);
            rotation = rot;
            origin = orig;
            spriteEffects = fx;
            color = clr;
            scale = _scale;
        }
    }
}
