using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDLSharp;

namespace ElLuchamor
{
    class MainMenu : IGameState
    {
        Text[] texts;
        int selected;

        public void Init()
        {
            Game.Camera.X = 0;
            Game.Camera.Y = 0;
            texts = new Text[3];
            texts[0] = new Text("Start Game", Assets.Get<IntPtr>("Vera.ttf"), 255, 0, 0, 0);
            texts[1] = new Text("Options", Assets.Get<IntPtr>("Vera.ttf"), 255, 0, 0, 0);
            texts[2] = new Text("Exit", Assets.Get<IntPtr>("Vera.ttf"), 255, 0, 0, 0);
            selected = 0;
        }

        public void Update(float time)
        {
            if (Input.GetKeyDown(Key.UP))
            {
                selected = Math.Max(selected - 1, 0);
            }

            if (Input.GetKeyDown(Key.DOWN))
            {
                selected = Math.Min(selected + 1, 2);
            }

            if (Input.GetKeyDown(Key.RETURN))
            {
                if (selected == 0)
                {
                    Game.SetState(new Level());
                }
                else if( selected == 2)
                {
                    Game.Quit();
                }
            }
        }

        public void Draw()
        {
            Renderer.SetColor(125, 125, 125, 0);
            Renderer.FillRect(new Vector2(0, selected * 60), new Vector2(640, 60));
            
            int i = 0;
            foreach (Text t in texts)
            {
                t.Draw(0, 60 * i);
                i++;
            }

            Renderer.SetColor(0, 0, 0, 0);
        }

        public void Quit()
        {

        }
    }
}
