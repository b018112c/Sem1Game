using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace TGPGame
{
	public class ObstacleM
	{		
		//Private variables
		private SpriteUV	sprite;
		private TextureInfo textureInfoMiddle;
		private float width;
		private float height;
		
		public Rectangle Extents
		{
			get {return new Rectangle(X, Y, 150, 148);}
		}
		
		public float X {get { return sprite.Position.X;}}
		public float Y {get { return sprite.Position.Y;}}
		
		
		//Public functions
		public ObstacleM (float startX, Scene scene)
		{
			textureInfoMiddle = new TextureInfo("/Application/textures/log.png");
			
			//middle
			sprite= new SpriteUV(textureInfoMiddle);
			sprite.Quad.S = textureInfoMiddle.TextureSizef;
			//add to scene
			scene.AddChild (sprite);
			
			//Get sprite bounds
			Bounds2 b = sprite.Quad.Bounds2();
			width  = b.Point10.X;
			height = b.Point01.Y;
			
			//Position objects	
		sprite.Position = new Vector2(-200, 200);
			
		}
		
		public void Update(float deltaTime)
		{			

			sprite.Position = new Vector2(sprite.Position.X - 3, sprite.Position.Y);
			
			Random rnd = new Random();
			int two = rnd.Next(1, 700);

			if(sprite.Position.X <= -200)
				sprite.Position = new Vector2(960 + two, 200);
			//sprites[2].Rotate(0.02f);
			
		}
			
		public void Dispose()
		{
			textureInfoMiddle.Dispose();
		}
		
		public bool HasCollidedWith(SpriteUV sprite)
		{
			return false;
		}
	}
}

