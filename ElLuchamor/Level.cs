using System;
using System.Collections.Generic;
using SDLSharp;

namespace ElLuchamor
{
    class Level : IGameState  // klasa Level implementujaca interface IGameState (stan gry)
    {
        static public Level Instance;
        
        Sprite[] bg; // tlo
        Music m;
        public List<Character> chs; // postacie

        public Vector2 Lock; // obecna blokada pozycji gracza

        public Level()
        {
            Instance = this;
        }

        public void Init() // wykona sie raz podczas wczytania
        {
            bg = new Sprite[3];
            bg[0] = Assets.Get<Sprite>("bg0.png"); // wczytujemy tło
            bg[1] = Assets.Get<Sprite>("bg1.png"); // wczytujemy tło
            bg[2] = Assets.Get<Sprite>("bg2.png"); // wczytujemy tło
            m = Assets.Get<Music>("bg2.mp3"); // wczytujemy muzyke
            chs = new List<Character>(); // Tworzymy liste postaci
            chs.Add(new Player(300, 200)); // dodajemy gracza do listy postaci
            chs.Add(new Enemy(1000, 220));
            Lock = new Vector2(140+60, 3000+60+85);
            //m.Play(); // odpalamy muzyczke, bedzie leciała w petli
        }

        public void Update(float time) // wykonuje sie podczas kazdej klatki około 60 razy na sekunde, time to czas od ostanie klatki, do fizyki i animacji
        {
            if (Input.GetKeyDown(Key.Escape))
            {
                Game.SetState(new MainMenu());
                return;
            }

            if (Input.GetKeyDown(Key.Q))
            {
                Game.SetState(new Shop(this), false);
                return;
            }

            int dead = 0;
            for (int i = 0; i < chs.Count; i++)
            {
                chs[i].Update(time); // dokonujemy aktualizacji stanu wszytkich postaci
                if (!chs[i].IsAlive())
                {
                    dead++;
                }
            }
            if (chs.Count - dead == 1)
            {
                chs.Add(new Enemy(Player.Instance.Pos.X + 600, 300));
            }
            chs.Sort(); // sortujemy postacie, aby były prawidłowo narysowane
        }

        public void Draw() // wykonuje sie podczas kazdej klatki
        {
            bg[0].Draw((int)(Game.Camera.X), (int)(Game.Camera.Y)); 
            bg[1].Draw((int)(Game.Camera.X * 0.5), (int)(Game.Camera.Y * 0.5)); 
            bg[2].Draw(0, 0); // rysyj tlo
            for (int i = 0; i < chs.Count; i++)
            {
                chs[i].Draw(); // rysuj wszytkie posacie, w tym gracza
            }
        }

        public void Quit() // wykonuje sie przy zakonczeniu gry lub zmianie stanu gry na inny
        {
            //m.Halt(); // konczymy muzyczke
        }
    }
}
