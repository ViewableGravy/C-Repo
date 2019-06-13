using System;
using SwinGameSDK;

namespace MyGame.src
{
    public class GameMain
    {
        public static void Main()
        {
            int width = 800;
            int height = 600;

            Rectangle boundary = new Rectangle(width/2, height/2, width/2, height/2);
            QuadTree qt = new QuadTree(boundary);

            for (int i = 0; i < 1000; i++)
            {
                Point pt = new Point(SwinGame.Rnd(width),SwinGame.Rnd(height));
                qt.Insert(pt); 
            }

            SwinGame.OpenGraphicsWindow("GameMain", width, height);
            SwinGame.ShowSwinGameSplashScreen();
            while(false == SwinGame.WindowCloseRequested())
            {
                SwinGame.ProcessEvents();
                SwinGame.ClearScreen(Color.White);

                qt.DrawPoints();

                SwinGame.DrawFramerate(0,0);
                SwinGame.RefreshScreen(60);
            }
        }
    }
}