﻿using System;
using SDLSharp;

namespace ElLuchamor
{
    class Player : Character // klasa Player dzieczidzaca po Character
    {
        public static Player Instance;

        float lifeBar;

        public Player(string name, float x, float y)
            : base(name, x, y)
        {
            Instance = this;
            lifeBar = Life * 200;
        }

        override public void Update(float time)
        {
            sprite.Update(time);

            if (state == CharacterState.Dead) return;

            if (state == CharacterState.Idle || state == CharacterState.Walk)
            {
                if (Input.GetKey(Key.W))
                {
                    Pos.Y -= time * Speed.Y;
                    sprite.SetAnim(1);
                    state = CharacterState.Walk;
                }
                else if (Input.GetKey(Key.S))
                {
                    Pos.Y += time * Speed.Y;
                    sprite.SetAnim(1);
                    state = CharacterState.Walk;

                }
                else if (Input.GetKey(Key.A))
                {
                    Pos.X -= time * Speed.X;
                    Dir = true;
                    sprite.SetAnim(1);
                    state = CharacterState.Walk;
                }
                else if (Input.GetKey(Key.D))
                {
                    Pos.X += time * Speed.X;
                    Dir = false;
                    sprite.SetAnim(1);
                    state = CharacterState.Walk;
                }
                else if (state == CharacterState.Walk)
                {
                    sprite.SetAnim(0);
                    state = CharacterState.Idle;
                }

                if (Input.GetKeyDown(Key.E) && attackTimer <= Game.GetTime())
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
                    attackLock = false;
                }
                else if (state == CharacterState.Kick)
                {
                    if (sprite.GetFrame() == 1 && !attackLock)
                    {
                        Kick();
                    }
                }
            }

            Pos.X = Math.Min(Math.Max(Level.Instance.Lock.X, Pos.X), Level.Instance.Lock.Y + 150);
            Pos.Y = Math.Min(Math.Max(300 + C2B, Pos.Y), 430 + C2B);
            //Game.Camera.X = MathE.Lerp(Game.Camera.X, Pos.X - (640 / 2d) - (Pos.Y / 1.5f) + 100, 0.1f);
            Game.Camera.X = MathE.Lerp(Game.Camera.X, Math.Min(Math.Max(Level.Instance.Lock.X - 200, Pos.X - (640 / 2) - (Pos.Y / 1.5f) + 100), Level.Instance.Lock.Y - 640), 0.1f);
        }

        override public void Draw()
        {
            base.Draw();
            Renderer.SetColor(0, 0, 0, 0);
            Renderer.FillRect(new Vector2(4 + Game.Camera.X, 4), new Vector2(202, 27));
            Renderer.SetColor(255, 0, 0, 0);
            Renderer.FillRect(new Vector2(5 + Game.Camera.X, 5), new Vector2(lifeBar = MathE.Lerp(lifeBar, 200 * Life, 0.2f), 25));
            Renderer.SetColor(0, 0, 0, 0);
        }
    }
}
