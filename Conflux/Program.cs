using Conflux.Core;
using Conflux.Core.Render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class ConfluxEngine : Game
{
    private GraphicsDeviceManager gdm;

    private List<RenderLayer2D> renderLayers2D;

    private SpriteBatch batch;

    internal static ConfluxEngine currentGameInstance;

    internal static GraphicsDevice GetGraphicsDevice()
    {
        return currentGameInstance.GraphicsDevice;
    }

    public static RenderLayer2D CreateRenderLayer2D()
    {
        RenderLayer2D layer = new RenderLayer2D(currentGameInstance.GraphicsDevice);
        currentGameInstance.renderLayers2D.Add(layer);
        return layer;
    }

    static void Main(string[] args)
    {
        using (ConfluxEngine g = new ConfluxEngine())
        {
            currentGameInstance = g;
            g.Run();
        }

        currentGameInstance = null;
    }

    private ConfluxEngine()
    {
        gdm = new GraphicsDeviceManager(this);
        renderLayers2D = new List<RenderLayer2D>();

        LoadConfig();
    }

    private void LoadConfig()
    {
        // TO-DO: Load config
        gdm.PreferredBackBufferWidth = 1280;
        gdm.PreferredBackBufferHeight = 720;
        gdm.IsFullScreen = false;
        gdm.SynchronizeWithVerticalRetrace = true;
        this.IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        batch = new SpriteBatch(GraphicsDevice);

        base.LoadContent();
    }

    protected override void UnloadContent()
    {
        base.UnloadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        foreach (RenderLayer2D layer in renderLayers2D)
        {
            GraphicsDevice.SetRenderTarget(layer.target);

            batch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
            layer.Draw(batch);
            batch.End();

            GraphicsDevice.SetRenderTarget(null);

            batch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
            layer.DrawLayer(batch);
            batch.End();
        }

        base.Draw(gameTime);
    }
}
