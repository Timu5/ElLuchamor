using System;
using SDLSharp;

namespace ElLuchamor
{
    enum EnemyState
    {
        Idle,
        Patrol,
        Chasing,
        Attack
    }

    class Enemy : Character // klasa Enenmy dziedziczasa po CHaracter
    {
        EnemyState estate;
        public Enemy(float x, float y)
            : base(x, y)
        {
            estate = EnemyState.Chasing;
            speed = new Vector2(250, 150);
        }

        override public void Update(float time)
        {
            sprite.Update(time);

            if (state == CharacterState.Dead) return;

            if (state == CharacterState.Walk || state == CharacterState.Idle)
            {

                switch (estate)
                {
                    case EnemyState.Chasing:
                        if (Player.Instance.Pos.Y < Pos.Y - 10)
                        {
                            Pos.Y -= time * speed.Y;
                            sprite.SetAnim(1);
                            state = CharacterState.Walk;
                        }
                        else if (Player.Instance.Pos.Y > Pos.Y + 10)
                        {
                            Pos.Y += time * speed.Y;
                            sprite.SetAnim(1);
                            state = CharacterState.Walk;
                        }
                        else
                        {
                            if (Player.Instance.Pos.X > Pos.X + 60)
                            {
                                Pos.X += time * speed.X;
                                sprite.SetAnim(1);
                                state = CharacterState.Walk;
                            }
                            else if (Player.Instance.Pos.X < Pos.X - 60)
                            {
                                Pos.X -= time * speed.X;
                                sprite.SetAnim(1);
                                state = CharacterState.Walk;
                            }
                            else
                            {
                                sprite.SetAnim(0);
                                state = CharacterState.Idle;
                            }
                        }

                        break;
                }
            }
            else if (sprite.GetAnim() == 0)
            {
                state = CharacterState.Idle;
                kickLock = false;
            }

            this.Dir = this.Pos.X - Player.Instance.Pos.X > 0;
            // todo ai
            Pos.X = Math.Min(Math.Max(Level.Instance.Lock.X, Pos.X), Level.Instance.Lock.Y);
            Pos.Y = Math.Min(Math.Max(300, Pos.Y), 430);
        }
    }
}
