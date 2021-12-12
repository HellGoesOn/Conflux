using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Conflux.Core.Render
{
    public class RenderLayer2D
    {
        private GraphicsDevice device;

        internal RenderTarget2D target;

        private List<RenderData2D> renderData;

        private bool clearTarget;

        private Color clearColor;

        public RenderLayer2D(GraphicsDevice _device)
        {
            clearColor = Color.CornflowerBlue;
            renderData = new List<RenderData2D>();
            device = _device;
            target = new RenderTarget2D(device, device.Viewport.Width, device.Viewport.Height);
        }

        public void Render(Texture2D tex, Vector2 position, Rectangle? sourceRect, Color clr, float rotation, Vector2 orig, Vector2 scale, SpriteEffects fx = SpriteEffects.None)
        {
            RenderOnLayer(this, tex, position, sourceRect, clr, rotation, orig, scale, fx);
        }

        public static void ClearLayer(RenderLayer2D layer, Color clearClr = default)
        { 
            layer.clearTarget = true;
            if (clearClr != default)
                layer.clearColor = clearClr;
        }

        public static void RenderOnLayer(RenderLayer2D layer, Texture2D tex, Vector2 position, Rectangle? sourceRect, Color clr, float rotation, Vector2 orig, Vector2 scale, SpriteEffects fx = SpriteEffects.None)
        {
            layer.renderData.Add(new RenderData2D(tex, position, sourceRect, clr, rotation, orig, scale, fx));
        }

        internal void Draw(SpriteBatch batch)
        {
            if (clearTarget)
            {
                device.Clear(clearColor);
                clearTarget = false;
            }

            foreach (RenderData2D data in renderData)
                batch.Draw(data.texture, data.position, data.sourceRectangle, data.color, data.rotation, data.origin, data.scale, data.spriteEffects, 1f);

            renderData.Clear();
        }

        internal void DrawLayer(SpriteBatch batch)
        {
            batch.Draw(target, new Rectangle(0, 0, target.Width, target.Height), Color.White);
        }
    }
}
