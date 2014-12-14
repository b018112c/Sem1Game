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
		
		private static bool	alive;
		private static bool	jump;
		private static bool dive;
		private static bool	left;
		private static bool	right;		
		public bool Alive { get{return alive;} set{alive = value;} }
		
		public Rectangle Extents
		{
			get {return new Rectangle(X + 5, Y + 5, 104, 79);} // X + 5 moves back line in by 5// Y + 5//width is 124 - 20, 104 +5 // height 89 -10 overall, 79 +5
		}
		
		public float X {get { return sprite.Position.X;}}
		public float Y {get { return sprite.Position.Y;}}
		
		//Public functions
		public Player (Scene scene)
		{
			textureInfo = new TextureInfo("/Application/textures/eggy.png");
			sprite = new SpriteUV(textureInfo);	
			sprite.Quad.S = textureInfo.TextureSizef;
			sprite.Position = new Vector2(50.0f,(Director.Instance.GL.Context.GetViewport().Height*0.5f)-30.0f);
			sprite.Visible = true;

			
			jump  = false;
			dive = false;
			left = false;
			right = false;
			alive = true;			
			//Add to scene
			scene.AddChild(sprite);
		
			
		//	Bounds2 b = sprite.Quad.Bounds2();
		//	width  = b.Point10.X;
		//	height = b.Point01.Y;
		}
		
		public void Remove()
		{
			sprite.Visible = false;
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
				if( (sprite.Position.Y < 392))
				{
					sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y + 3.5f);
				}
				else
					jump = false;
			}
			else if(sprite.Position.Y > 242 & !dive)
			{
				sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y - 3.5f);
			}
			
			if(dive & !jump)
			{
				if(sprite.Position.Y > 92)
				{
					sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y - 3.5f);
				}
				else
					dive = false;
			}
			else if(sprite.Position.Y < 242 & !jump) //moves back to centre
			{
				sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y + 3.5f);
			}
			//
			
			
			//
			if(left) 
			{
				if((sprite.Position.X > 0))
				{
					sprite.Position = new Vector2(sprite.Position.X -1f, sprite.Position.Y);
				}
				else
					left=false;
			}
				if(right) //replicate for right
				{
					if((sprite.Position.X < Director.Instance.GL.Context.GetViewport().Width - 130))
					{
						sprite.Position = new Vector2(sprite.Position.X + 1f, sprite.Position.Y);
					}
					else
						right=false;
						
				}	
				
			
			if(!left & !right)
			{
				left = false;
				right = false;
			}
					
		}	
		
		public void pressedCross()
		{
			if(!jump)
			{
				jump = true;
				dive = false;
			}
		}
		public void pressedCircle()
		{
			if(!dive)
			{
				dive = true;
				jump = false;		
			}
		}
		
		
		public void pressedLeft()
		{
			if(!left)
			{
				left = true;
				right = false;
			}
		}
		
			public void pressedRight()
		{
			if(!right)
			{
				right = true;
				left = false;
			}
		}
		
	}
}

