using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace TGPGame
{
	public class ObstacleB
	{
		
		//Private variables
		private SpriteUV	sprite;

		private TextureInfo	textureInfoBottom;

		private float width;
		private float height;
		
		public Rectangle Extents
		{
			get {return new Rectangle(X, Y, 200, 206);}
		}
		
		public float X {get { return sprite.Position.X;}}
		public float Y {get { return sprite.Position.Y;}}
		
		
		//Public functions
		public ObstacleB (float startX, Scene scene)
		{

			textureInfoBottom = new TextureInfo("/Application/textures/bottom.png");
			

			
			//Bottom
			sprite = new SpriteUV(textureInfoBottom);	
			sprite.Quad.S = textureInfoBottom.TextureSizef;		
			//Add to the current scene
			scene.AddChild(sprite);

			
			//Get sprite bounds
			Bounds2 b = sprite.Quad.Bounds2();
			width  = b.Point10.X;
			height = b.Point01.Y;
			
			//Position objects	
		sprite.Position = new Vector2(500, -10);		
			//sprites[0].Position.Y-height-200 used in Y
		}
		
		public void Update(float deltaTime)
		{			
//speed
			sprite.Position = new Vector2(sprite.Position.X - 3, sprite.Position.Y);
			
			Random rnd = new Random();
			int one = rnd.Next(1, 600);
			if(sprite.Position.X <= -200)
				sprite.Position = new Vector2(960 + one, -10);
			
		}
			
		public void Dispose()
		{
			textureInfoBottom.Dispose();
		}
		
		public bool HasCollidedWith(SpriteUV sprite)
		{
			return false;
		}
	}
}

