using System;
using SDLSharp;

namespace ElLuchamor
{
    enum CharacterState // mozliwe stany postaci
    {
        Idle,
        Walk,
        Kick,
        Hit,
        KnockedDown,
        Dead
    }

    class Character : IComparable<Character> // klasa postaci implementuje interface IComparable dzieki czemu mozna ja potem sortowac
    {
        public Vector2 Pos; // pozycja postaci
        protected AnimSprite sprite; // sprite postaci

        public bool Dir; // kierunek lewo, prawo

        public float Life; // zycie postaci

        protected CharacterState state; // obecny stan postaci

        protected Chunk[] chunks; // efekty dzwiekowe

        public Vector2 Speed;

        public uint Attack;
        public uint Defense;

        public float C2S; // center to side
        public float C2B; // center to bottom

        public uint AttackTimeout;
        public uint ComboTimeout;

        protected uint combo;
        protected uint kills;

        protected bool attackLock;
        protected uint attackTimer;
        protected uint comboTimer;

        public Character(string name)
            : this(name, 0, 0)
        {
        }

        public Character(string name, float x, float y)
        {
            string[] pars = Assets.Get<string>(name).Split(new char[]{' ', '\t', '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);

            Pos = new Vector2(x, y);
            Life = 1.0f;
            state = CharacterState.Idle;

            Dir = false;

            chunks = new Chunk[3];
            chunks[0] = Assets.Get<Chunk>("cpunch.ogg");
            chunks[1] = Assets.Get<Chunk>("chit.ogg");
            chunks[2] = Assets.Get<Chunk>("cgrunt.ogg");

            sprite = new AnimSprite(Assets.Get<string>(pars[0]));

            Speed = new Vector2(float.Parse(pars[3]), float.Parse(pars[4]));

            Attack = uint.Parse(pars[5]);
            Defense = uint.Parse(pars[6]);

            C2S = float.Parse(pars[1]);
            C2B = float.Parse(pars[2]);

            attackLock = false;
            AttackTimeout = 500; // 0.5s
            ComboTimeout = 1000; // 1s

            combo = 1;
            kills = 0;

            attackTimer = 0;
            comboTimer = 0;
        }

        virtual public void Update(float time)
        {
            //to jest implementowane przez konretna klase dziedziczaca po postaci, np gracz albo przeciwnik
        }

        virtual public void Draw()
        {
            sprite.DrawCenter((int)(Pos.X - Pos.Y / 1.5) + 100, (int)(Pos.Y - C2B), false, Dir); // rusujemy z uwzgledniemiem glebokosci
            Renderer.FillRect(new Vector2((int)(Pos.X - Pos.Y / 1.5) + 100, Pos.Y - C2B), new Vector2(3, C2B));
            Renderer.FillRect(new Vector2((int)(Pos.X - Pos.Y / 1.5) + 100, Pos.Y - C2B), new Vector2(C2S, 3));
        
        }

        public int CompareTo(Character ch)
        {
            return (int)(Pos.Y - ch.Pos.Y); // porownanie glebokosci postaci, urzyte przy sortowaniu
        }

        public bool IsAlive()
        {
            if (state == CharacterState.Dead)
                return false;
            return true;
        }

        private void AddComboPoint()
        {
            if (comboTimer >= Game.GetTime())
                combo++;
            else
                combo = 1;
            comboTimer = Game.GetTime() + ComboTimeout;
        }

        public int Hurt(float damage)
        {
            if (state != CharacterState.Dead)
            {
                Life = Math.Max(0.0f, Life - damage);
                if (Life <= 0.0f)
                {
                    state = CharacterState.Dead;
                    sprite.SetAnim(4);
                    chunks[2].Play();
                    return 2;
                }
                else
                {
                    state = CharacterState.Hit;
                    sprite.SetAnim(3);
                    chunks[1].Play();
                    return 1;
                }
            }
            return 0;
        }

        public void Kick()
        {
            int start = (int)(Pos.X + (Dir ? -30 - C2S : C2S));
            int end = start + 30;
            attackLock = true;
            attackTimer = Game.GetTime() + AttackTimeout;
            foreach (Character ch in Level.Instance.chs)
            {
                if (ch != this)
                {
                    if ((ch.Pos.X <= start + ch.C2S && ch.Pos.X >= start - ch.C2S) ||
                        (ch.Pos.X <= end + ch.C2S && ch.Pos.X >= end - ch.C2S))
                    {
                        if (ch.Pos.Y <= Pos.Y + 30 && ch.Pos.Y >= Pos.Y - 30)
                        {
                            switch (ch.Hurt(0.1f * Attack / ch.Defense))
                            {
                                case 2:
                                    kills++;
                                    AddComboPoint();
                                    break;
                                case 1:
                                    AddComboPoint();
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
