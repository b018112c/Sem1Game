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
		
		public Rectangle Extents
		{
			get {return new Rectangle(X, Y, 140, 206);}//reduced width from 200
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
			
			//Position objects	
		sprite.Position = new Vector2(500, -10);	
		}
		
		public void Update(float deltaTime)
		{	
			sprite.Position = new Vector2(sprite.Position.X - 4, sprite.Position.Y);//speed
			Random rnd = new Random();
			int one = rnd.Next(200, 700);
			
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

