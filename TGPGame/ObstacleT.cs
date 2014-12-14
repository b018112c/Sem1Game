using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace TGPGame
{
	public class ObstacleT
	{		
		//Private variables
		private SpriteUV 	sprite;
		private TextureInfo	textureInfoTop;
		
		public Rectangle Extents
		{
			get {return new Rectangle(X+5, Y, 60, 242);} //reduced width from 160
		}
		
		public float X {get { return sprite.Position.X;}}
		public float Y {get { return sprite.Position.Y;}}
		
		//Public functions
		public ObstacleT (float startX, Scene scene)
		{
			textureInfoTop = new TextureInfo("/Application/textures/top2.png");
			
			//Top
			sprite = new SpriteUV(textureInfoTop);	
			sprite.Quad.S = textureInfoTop.TextureSizef;
			//Add to the current scene
			scene.AddChild(sprite);
			
			//Position objects
		sprite.Position = new Vector2(-200, Director.Instance.GL.Context.GetViewport().Height -220);		
			
		}
		
		public void Update(float deltaTime)
		{			
			sprite.Position = new Vector2(sprite.Position.X - 4, sprite.Position.Y); //speed
			Random rnd = new Random();
			int zero = rnd.Next(200, 1000);
			//Console.WriteLine(zero);
			if(sprite.Position.X <= -200)//If off the left of the viewport, loop them around
				sprite.Position = new Vector2(960 + zero, Director.Instance.GL.Context.GetViewport().Height - 190); //randomise distance(x)
			
		}
			
		public void Dispose()
		{
			textureInfoTop.Dispose();
		}
		
		public bool HasCollidedWith(SpriteUV sprite)
		{
			return false;
		}
	}
}

