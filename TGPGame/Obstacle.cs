using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace TGPGame
{
	public class Obstacle
	{
		const float kGap = 200.0f;
		
		//Private variables
		private SpriteUV[] 	sprites;
		private TextureInfo	textureInfoTop;
		private TextureInfo	textureInfoBottom;
		private TextureInfo textureInfoMiddle;
		private float width;
		private float height;
		
		//Accessors
		//public SpriteUV SpriteTop { get{return sprites[0];} }
		//public SpriteUV SpriteBottom { get{return sprites[1];} }
		//public SpriteUV SpriteMiddle { get{return sprites[2];} }
		
		//Public functions
		public Obstacle (float startX, Scene scene)
		{
			textureInfoTop = new TextureInfo("/Application/textures/top2.png");
			textureInfoBottom = new TextureInfo("/Application/textures/bottom.png");
			textureInfoMiddle = new TextureInfo("/Application/textures/log.png");
			
			sprites	= new SpriteUV[3];
			
			//Top
			sprites[0] = new SpriteUV(textureInfoTop);	
			sprites[0].Quad.S = textureInfoTop.TextureSizef;
			//Add to the current scene
			scene.AddChild(sprites[0]);
			
			//Bottom
			sprites[1] = new SpriteUV(textureInfoBottom);	
			sprites[1].Quad.S = textureInfoBottom.TextureSizef;		
			//Add to the current scene
			scene.AddChild(sprites[1]);
			
			//middle
			sprites[2] = new SpriteUV(textureInfoMiddle);
			sprites[2].Quad.S = textureInfoMiddle.TextureSizef;
			//add to scene
			scene.AddChild (sprites[2]);
			
			//Get sprite bounds
			Bounds2 b = sprites[0].Quad.Bounds2();
			width  = b.Point10.X;
			height = b.Point01.Y;
			
			//Position objects
		sprites[0].Position = new Vector2(-200, Director.Instance.GL.Context.GetViewport().Height -220);		
		sprites[1].Position = new Vector2(500, -10);		
			//sprites[0].Position.Y-height-kGap used in Y
		sprites[2].Position = new Vector2(-200, 200);
			
		}
		
		public void Update(float deltaTime)
		{			
			sprites[0].Position = new Vector2(sprites[0].Position.X - 3, sprites[0].Position.Y); //speed
			sprites[1].Position = new Vector2(sprites[1].Position.X - 3, sprites[1].Position.Y);
			sprites[2].Position = new Vector2(sprites[2].Position.X - 3, sprites[2].Position.Y);
			
			Random rnd = new Random();
			int zero = rnd.Next(1, 700);
			int one = rnd.Next(1, 600);
			int two = rnd.Next(1, 700);
			
			if(sprites[0].Position.X <= -200)//If off the left of the viewport, loop them around
				sprites[0].Position = new Vector2(960 + zero, Director.Instance.GL.Context.GetViewport().Height - 220); //randomise distance(x)

			if(sprites[1].Position.X <= -200)
				sprites[1].Position = new Vector2(960 + one, -10);

			if(sprites[2].Position.X <= -200)
				sprites[2].Position = new Vector2(960 + two, 200);
			
			//sprites[2].Rotate(0.02f);
			
		}
			
		public void Dispose()
		{
			textureInfoTop.Dispose();
			textureInfoBottom.Dispose();
			textureInfoMiddle.Dispose();
		}
		
		public bool HasCollidedWith(SpriteUV sprite)
		{
			return false;
		}
	}
}

