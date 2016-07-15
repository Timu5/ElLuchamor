using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDLSharp;

namespace ElLuchamor
{
    class Shop : IGameState
    {
        Text t;
        Level level;

        public Shop(Level l)
        {
            level = l;
            Init();
        }

        public void Init()
        {
            t = new Text("Hello in Shop, press e to exit", Assets.Get<IntPtr>("Vera.ttf"), 255, 0, 0, 0);
        }

        public void Update(float time)
        {
            if (Input.GetKeyDown(Key.E))
            {
                Game.SetState(level, false);
            }
        }

        public void Draw()
        {
            t.Draw((int)Game.Camera.X, (int)Game.Camera.Y, 0.5f);
        }

        public void Quit()
        {
        }
    }
}
