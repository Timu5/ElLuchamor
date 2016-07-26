using System;
using SDLSharp;

namespace ElLuchamor
{
    enum EnemyState
    {
        Idle,
        Patrol,
        Chase,
        Attack,
        Flee
    }

    class Enemy : Character // klasa Enenmy dziedziczasa po CHaracter
    {
        EnemyState estate;
        public Enemy(string name, float x, float y, EnemyState es)
            : base(name, x, y)
        {
            estate = es;
            Speed = new Vector2(250, 150);
        }

        override public void Update(float time)
        {
            sprite.Update(time);

            if (state == CharacterState.Dead) return;
            if (Player.Instance.Life <= 0.0f) return;

            if (estate == EnemyState.Idle)
            {
                if (sprite.GetAnim() == 3)
                    estate = EnemyState.Chase;
            }

            if (state == CharacterState.Walk || state == CharacterState.Idle)
            {
                if (state == CharacterState.Walk)
                    this.Dir = this.Pos.X - Player.Instance.Pos.X > 0;
                switch (estate)
                {
                    case EnemyState.Chase:
                        if (Player.Instance.Pos.Y < Pos.Y - 10)
                        {
                            Pos.Y -= time * Speed.Y;
                            sprite.SetAnim(1);
                            state = CharacterState.Walk;
                        }
                        else if (Player.Instance.Pos.Y > Pos.Y + 10)
                        {
                            Pos.Y += time * Speed.Y;
                            sprite.SetAnim(1);
                            state = CharacterState.Walk;
                        }
                        else
                        {
                            if (Player.Instance.Pos.X > Pos.X + 60)
                            {
                                Pos.X += time * Speed.X;
                                sprite.SetAnim(1);
                                state = CharacterState.Walk;
                            }
                            else if (Player.Instance.Pos.X < Pos.X - 60)
                            {
                                Pos.X -= time * Speed.X;
                                sprite.SetAnim(1);
                                state = CharacterState.Walk;
                            }
                            else
                            {
                                if (attackTimer <= Game.GetTime() && (new Random()).Next(0, 100) > 96) // Temp hack !
                                {
                                    sprite.SetAnim(2);
                                    state = CharacterState.Kick;
                                    chunks[0].Play();
                                }
                                else
                                {
                                    sprite.SetAnim(0);
                                    state = CharacterState.Idle;
                                }
                            }
                        }
                        break;
                }
            }
            else if (sprite.GetAnim() == 0)
            {
                state = CharacterState.Idle;
                attackLock = false;
            }
            else if (state == CharacterState.Kick)
            {
                if (sprite.GetFrame() == 1 && !attackLock)
                {
                    Kick();
                }
            }

            Pos.X = Math.Min(Math.Max(Level.Instance.Lock.X, Pos.X), Level.Instance.Lock.Y);
            Pos.Y = Math.Min(Math.Max(300 + C2B, Pos.Y), 430 + C2B);
        }
    }
}
