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
		
		public Rectangle Extents
		{
			get {return new Rectangle(X +5, Y +5, 120, 138);} //150 width, 148 height
		}
		
		public float X {get { return sprite.Position.X;}}
		public float Y {get { return sprite.Position.Y;}}
		
		//Public functions
		public ObstacleM (float startX, Scene scene)
		{
			textureInfoMiddle = new TextureInfo("/Application/textures/log2.png");
			
			//middle
			sprite= new SpriteUV(textureInfoMiddle);
			sprite.Quad.S = textureInfoMiddle.TextureSizef;
			//add to scene
			scene.AddChild (sprite);

			//Position objects	
		sprite.Position = new Vector2(-200, 200);
			
		}
		
		public void Update(float deltaTime)
		{			
			sprite.Position = new Vector2(sprite.Position.X - 2.8f, sprite.Position.Y);
			Random rnd = new Random();
			int two = rnd.Next(1, 300);

			if(sprite.Position.X <= -200)
				sprite.Position = new Vector2(960 + two, 200);
			
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

