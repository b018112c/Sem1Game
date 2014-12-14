using System;


using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using Sce.PlayStation.HighLevel.UI;

namespace TGPGame
{
	public class UI
	{
		//Private variables
		
		private static Sce.PlayStation.HighLevel.UI.Label scoreLabel;
		private int dist;
		//Public functions
		public UI (Panel panel)
		{
			scoreLabel = new Sce.PlayStation.HighLevel.UI.Label(); //make a UI class file
			scoreLabel.HorizontalAlignment = HorizontalAlignment.Center;
			scoreLabel.VerticalAlignment = VerticalAlignment.Top;
			scoreLabel.SetPosition(20,20);
			dist = 0;
			scoreLabel.Text = "Distance: " + dist;
			
			panel.AddChildLast(scoreLabel);

		}
		
		public void Dispose()
		{
			
		}
		
		public void Update(float deltaTime)
		{			
			dist = dist + 1; 
			scoreLabel.Text = "Distance: " + dist/50; //this works instead of a timer
		}	
	
	}
}

