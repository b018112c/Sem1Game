using System;


using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace TGPGame
{
	public class Gameover
	{
		//Private variables

		private static SpriteUV spriteGG;
		private static TextureInfo textureGG;

		//Public functions
		public Gameover (Scene scene)
		{
			textureGG = new TextureInfo("/Application/textures/gameover.png");
			spriteGG = new SpriteUV(textureGG);
			spriteGG.Quad.S = textureGG.TextureSizef;
			spriteGG.Position = new Vector2(0,0);
			spriteGG.Visible = false;
			
			//Add to scene
			scene.AddChild(spriteGG);
		}

		public void GG()
		{
			spriteGG.Visible = true;
		}
		
		public void Dispose()
		{
			textureGG.Dispose();
		}
		
		public void Update(float deltaTime)
		{			
			
		}	
	
	}
}

