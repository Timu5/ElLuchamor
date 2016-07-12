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

        protected bool kickLock;

        protected Vector2 speed = new Vector2(300, 150);

        public Character()
            : this(0, 0)
        {
        }

        public Character(float x, float y)
        {
            Pos = new Vector2(x, y);
            Life = 1.0f;
            state = CharacterState.Idle;

            Dir = false;

            chunks = new Chunk[1];
            chunks[0] = Assets.Get<Chunk>("c.ogg");

            sprite = new AnimSprite(Assets.Get<string>("test.anim"));

            kickLock = false;
        }

        virtual public void Update(float time)
        {
            //to jest implementowane przez konretna klase dziedziczaca po postaci, np gracz albo przeciwnik
        }

        virtual public void Draw()
        {
            sprite.DrawCenter((int)(Pos.X - Pos.Y / 1.5) + 100, (int)Pos.Y, false, Dir); // rusujemy z uwzgledniemiem glebokosci
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

        public void Hit()
        {
            if (state != CharacterState.Dead)
            {
                Log.WriteLine("Hit! " + Life);
                if (Life <= 0.0f)
                {
                    state = CharacterState.Dead;
                    sprite.SetAnim(4);
                }
                else
                {
                    state = CharacterState.Hit;
                    sprite.SetAnim(3);
                }
            }
        }

        public void Kick()
        {
            int start = (int)Pos.X + (Dir ? -30 - 45 : 45);
            int end = start + 30;
            kickLock = true;
            foreach (Character ch in Level.Instance.chs)
            {
                if (ch != this)
                {
                    if ((ch.Pos.X <= start + 45 && ch.Pos.X >= start - 45) || (ch.Pos.X <= end + 45 && ch.Pos.X >= end - 45))
                    {
                        if (ch.Pos.Y <= Pos.Y + 30 && ch.Pos.Y >= Pos.Y - 30)
                        {
                            ch.Life = Math.Max(0.0f, ch.Life - 0.21f);
                            ch.Hit();
                        }
                    }
                }

            }
        }
    }
}
