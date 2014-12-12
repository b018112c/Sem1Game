using System;


using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace TGPGame
{
	public class Player
	{
		//Private variables
		private static SpriteUV sprite;
		private static TextureInfo textureInfo;
		private static int pushAmount = 100;
		private static float yPositionBeforePush;
		private static float yPositionAfterDive;
		private static bool	jump;
		private static bool	alive;
		private static bool dive;
		
		public bool Alive { get{return alive;} set{alive = value;} }
		
		//Public functions
		public Player (Scene scene)
		{
			textureInfo = new TextureInfo("/Application/textures/eggy.png");
			
			sprite = new SpriteUV();
			sprite = new SpriteUV(textureInfo);	
			sprite.Quad.S = textureInfo.TextureSizef;
			
			sprite.Position = new Vector2(50.0f,(Director.Instance.GL.Context.GetViewport().Height*0.5f)-30.0f);
			
			jump  = false;
			dive = false;
			alive = true;
			
			//Add to scene
			scene.AddChild(sprite);
		}
		
		public void Dispose()
		{
			textureInfo.Dispose();
		}
		
		public void Update(float deltaTime)
		{			
			//adjust the push
			if(jump & !dive)
			{
				if( (sprite.Position.Y-yPositionBeforePush) < pushAmount)
					sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y + 3f);
				else
					jump = false;
			}
			else if(sprite.Position.Y > 242 & !dive)
			{
				sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y - 3f);
			}
			
			if(dive & !jump)
			{
				if(sprite.Position.Y > 130)
				{
					sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y - 3f);
				}
				else
					dive = false;
			}
			else if(sprite.Position.Y < 242 & !jump)
			{
				sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y + 3f);
				dive = false;
			}
		}	
		
		public void pressedCross()
		{
			if(!jump)
			{
				jump = true;
				yPositionBeforePush = sprite.Position.Y;
			}
		}
		public void pressedTriangle()
		{
			if(!dive)
			{
				dive = true;
				yPositionAfterDive = sprite.Position.Y;
			}
		}
	}
}

