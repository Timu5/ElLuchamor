using System;
using System.Collections.Generic;
using SDLSharp;

namespace ElLuchamor
{
    class Level : IGameState  // klasa Level implementujaca interface IGameState (stan gry)
    {
        static public Level Instance;
        
        Sprite[] bg; // tlo
        Sprite arrow;
        Music m;
        public List<Character> chs; // postacie

        List<Vector2> stages;
        List<Character[]> stageEnemy;
        int currentStage;
        bool waitForPlayer;

        public Vector2 Lock; // obecna blokada pozycji gracza

        public Level(string data)
        {
            Instance = this;
            stages = new List<Vector2>();
            stages.Add(new Vector2(200, 900));
            stages.Add(new Vector2(1000, 1500));
            stages.Add(new Vector2(1600, 2000));
            stages.Add(new Vector2(2100, 3000));
            currentStage = 0;
            Lock = stages[currentStage];
        }

        public void Init() // wykona sie raz podczas wczytania
        {
            bg = new Sprite[3];
            bg[0] = Assets.Get<Sprite>("bg0.png"); // wczytujemy tło
            bg[1] = Assets.Get<Sprite>("bg1.png"); // wczytujemy tło
            bg[2] = Assets.Get<Sprite>("bg2.png"); // wczytujemy tło
            arrow = Assets.Get<Sprite>("arrow.png");
            m = Assets.Get<Music>("bg2.mp3"); // wczytujemy muzyke
            chs = new List<Character>(); // Tworzymy liste postaci
            chs.Add(new Player("test2.ch", 300, 200)); // dodajemy gracza do listy postaci
            chs.Add(new Enemy("test.ch", 1000, 220, EnemyState.Idle));
            //Lock = new Vector2(140+60, 3000+60+85);
            //m.Play(); // odpalamy muzyczke, bedzie leciała w petli
        }
        float fps = 0;
        int n = 0;
        public void Update(float time) // wykonuje sie podczas kazdej klatki około 60 razy na sekunde, time to czas od ostanie klatki, do fizyki i animacji
        {
            fps += time;
            n++;
            if (fps >= 2.0f)
            {
                Log.WriteLine("fps: " + (n / fps).ToString());
                n = 0;
                fps = 0;
            }

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

            if (waitForPlayer)
            {
                if (Player.Instance.Pos.X >= stages[currentStage].X && Player.Instance.Pos.X <= stages[currentStage].Y)
                {
                    Lock.X = stages[currentStage].X;
                    waitForPlayer = false;
                }
            }
            else
            {
                if (chs.Count - dead == 1)
                {
                    currentStage++;
                    if (currentStage >= stages.Count)
                    {
                        Game.Quit();
                        return;
                    }
                    waitForPlayer = true;
                    Log.WriteLine(stages.Count.ToString());
                    Lock.Y = stages[currentStage].Y;
                    chs.Add(new Enemy("test.ch", Player.Instance.Pos.X + 600, 300, EnemyState.Idle));
                }
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

            if (waitForPlayer)
                arrow.Draw((int)Game.Camera.X + 500, 0);
        }

        public void Quit() // wykonuje sie przy zakonczeniu gry lub zmianie stanu gry na inny
        {
            //m.Halt(); // konczymy muzyczke
        }
    }
}
