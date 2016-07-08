using System;
using SDLSharp;

namespace ElLuchamor
{
    class Player : Character // klasa Player dzieczidzaca po Character
    {
        public static Player Instance;
        
        public Player(float x, float y)
            : base(x, y)
        {
            Instance = this;
        }

        override public void Update(float time)
        {
            sprite.Update(time);

            if (state == CharacterState.Dead) return;

            if (state == CharacterState.Idle || state == CharacterState.Walk)
            {
                if (Input.GetKey(Key.W))
                {
                    Pos.Y -= time * speed.Y;
                    sprite.SetAnim(1);
                    state = CharacterState.Walk;
                }
                else if (Input.GetKey(Key.S))
                {
                    Pos.Y += time * speed.Y;
                    sprite.SetAnim(1);
                    state = CharacterState.Walk;

                }
                else if (Input.GetKey(Key.A))
                {
                    Pos.X -= time * speed.X;
                    Dir = true;
                    sprite.SetAnim(1);
                    state = CharacterState.Walk;
                }
                else if (Input.GetKey(Key.D))
                {
                    Pos.X += time * speed.X;
                    Dir = false;
                    sprite.SetAnim(1);
                    state = CharacterState.Walk;
                }
                else if (state == CharacterState.Walk)
                {
                    sprite.SetAnim(0);
                    state = CharacterState.Idle;
                }

                if (Input.GetKeyDown(Key.E))
                {
                    sprite.SetAnim(2);
                    state = CharacterState.Kick;
                    chunks[0].Play();
                }
            }
            else
            {
                if (sprite.GetAnim() == 0)
                {
                    state = CharacterState.Idle;
                    kickLock = false;
                }
                else if (state == CharacterState.Kick)
                {
                    if (sprite.GetFrame() == 1 && !kickLock)
                    {
                        Kick();
                    }
                }
            }

            Pos.X = Math.Min(Math.Max(Level.Instance.Lock.X, Pos.X), Level.Instance.Lock.Y);
            Pos.Y = Math.Min(Math.Max(300, Pos.Y), 430);
            Game.Camera.X = Math.Min(Math.Max(Level.Instance.Lock.X - 200, Pos.X - 420), Level.Instance.Lock.Y - 640);
        }
    }
}
