using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using Sce.PlayStation.HighLevel.UI;

namespace TGPGame
{
	public class AppMain
	{
		private static Sce.PlayStation.HighLevel.GameEngine2D.Scene gameScene;
		private static Sce.PlayStation.HighLevel.UI.Scene uiScene;
		private static Sce.PlayStation.HighLevel.UI.Label scoreLabel;
		
		private static Foreground foreground;
		private static ObstacleT spike;
		private static ObstacleM log;
		private static ObstacleB rock;
		private static Player player;
		private static Background background;
		private static GamePadData gamePadData;
		
		public static void Main (string[] args)
		{

			Initialize();

			bool quitGame = false;
			while (!quitGame) 
			{
				Update ();
				
				Director.Instance.Update();
				Director.Instance.Render();
				UISystem.Render();
				
				Director.Instance.GL.Context.SwapBuffers();
				Director.Instance.PostSwap();
			}		
			foreground.Dispose();
			player.Dispose();
				spike.Dispose();
			log.Dispose();
			rock.Dispose();
			background.Dispose();
			
			Director.Terminate ();		
		}

		public static void Initialize ()
		{
			Director.Initialize ();
			UISystem.Initialize(Director.Instance.GL.Context);
			
			//Set game scene
			gameScene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			gameScene.Camera.SetViewFromViewport();
			
			
			//Set ui scene
			uiScene = new Sce.PlayStation.HighLevel.UI.Scene();
			Panel panel  = new Panel();
			panel.Width  = Director.Instance.GL.Context.GetViewport().Width;
			panel.Height = Director.Instance.GL.Context.GetViewport().Height;
			scoreLabel = new Sce.PlayStation.HighLevel.UI.Label();
			scoreLabel.HorizontalAlignment = HorizontalAlignment.Center;
			scoreLabel.VerticalAlignment = VerticalAlignment.Top;
			scoreLabel.SetPosition(20,20);
			int lives = 0;
			scoreLabel.Text = "Distance: " + lives;
			panel.AddChildLast(scoreLabel);
			uiScene.RootWidget.AddChildLast(panel);
			UISystem.SetScene(uiScene);
			
			//Create objects
			background = new Background(gameScene);
			
			player = new Player(gameScene);
			
			spike = new ObstacleT(200, gameScene);	
			rock = new ObstacleB(450, gameScene);
			log = new ObstacleM(700, gameScene);
			Director.Instance.RunWithScene(gameScene, true);
			
			foreground = new Foreground(gameScene);
		}	

		public static void Update ()
		{
			
			// Query gamepad for current state
			gamePadData = GamePad.GetData(0);
			
			//If Cross is pressed the player jumps

			if(gamePadData.Buttons.HasFlag(GamePadButtons.Cross))
			{
				Console.WriteLine("Cross");	
				player.pressedCross();
			}
			else if(gamePadData.Buttons.HasFlag(GamePadButtons.Circle))
			{
				Console.WriteLine("Circle");	
				player.pressedCircle();
			}
			
        

        if(gamePadData.Buttons.HasFlag(GamePadButtons.Left))
        {
                Console.WriteLine("Left");	
				player.pressedLeft();
        }
        else if(gamePadData.Buttons.HasFlag(GamePadButtons.Right))
        {
              	Console.WriteLine("Right");	
				player.pressedRight();
        }

			
			
			CheckForCollision();

			//Update
			player.Update(0.0f);
			
			if(player.Alive)
			{
				foreground.Update(0.0f);
				background.Update(0.0f);
				
				spike.Update(0.0f);
				log.Update(0.0f);
				rock.Update(0.0f);
			}
		}
		
		public static void CheckForCollision()
		{
			Rectangle playerExtents = player.Extents;
			Rectangle spikeExtents = spike.Extents;
			Rectangle rockExtents = rock.Extents;
			Rectangle logExtents = log.Extents;
			//int lives = 3;
			
			if(Overlaps(playerExtents, spikeExtents) == true)
			{
				//lives = lives - 1;
				//if (lives <= 0)
				//{
					player.Alive = false;
					//}
			}

			if(Overlaps(playerExtents, rockExtents) == true)
			{
					player.Alive = false;
			}

			if(Overlaps(playerExtents, logExtents) == true)
			{
				player.Alive = false;
			}
			
			
			if (player.Alive == false)
				player.Remove();
			
		}
		
		private static bool Overlaps(Rectangle r1, Rectangle r2)
		{
			if (r1.X + r1.Width < r2.X)
				return false;
			if (r1.X > r2.X + r2.Width)
				return false;
			if (r1.Y + r1.Height < r2.Y)
				return false;
			if (r1.Y > r2.Y + r2.Height)
				return false;
			
			return true;
		}
	}
}













