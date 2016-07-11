using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using SDL2;

namespace SDLSharp
{
    public class Animation
    {
        IntPtr texture;
        int w, h;

        float speed;
        public float frame;
        int frameCount;

        bool looped;

        public int Next;

        public Animation(string filename, int x, float speed, bool looped, int next)
        {
            this.frame = 0;
            this.speed = speed;
            this.texture = Assets.Get<Sprite>(filename).GetTexture();
            this.frameCount = x;
            this.looped = looped;
            this.Next = next;
            uint tmp1; int tmp2;
            SDL.SDL_QueryTexture(texture, out tmp1, out tmp2, out w, out h);
            w = w / frameCount;
        }

        ~Animation()
        {
            SDL.SDL_DestroyTexture(texture);
        }

        public void Reset()
        {
            frame = 0;
        }

        public void Update(float time, ref int next)
        {
            frame += time * speed;
            if (frame >= frameCount)
                if (looped)
                    frame = 0;
                else
                {
                    frame = frameCount - 1;
                    if (Next >= 0)
                        next = Next;
                }
        }

        public void Draw(int x, int y, int w, int h)
        {
            SDL.SDL_Rect src = new SDL.SDL_Rect((int)frame * this.w, 0, this.w, this.h);
            SDL.SDL_Rect dst = new SDL.SDL_Rect(x - (int)Game.Camera.X, y - (int)Game.Camera.Y, w <= 0 ? this.w : w, h <= 0 ? this.h : h);
            SDL.SDL_RenderCopy(Game.renderer, this.texture, ref src, ref dst);
        }

        public void Draw(int x, int y, int w, int h, double angle, bool flipv, bool fliph)
        {
            SDL.SDL_Rect src = new SDL.SDL_Rect((int)frame * this.w, 0, this.w, this.h);
            SDL.SDL_Rect dst = new SDL.SDL_Rect(x - (int)Game.Camera.X, y - (int)Game.Camera.Y, w <= 0 ? this.w : w, h <= 0 ? this.h : h);
            int flip = (flipv ? 2 : 0) + (fliph ? 1 : 0);
            SDL.SDL_RenderCopyEx(Game.renderer, this.texture, ref src, ref dst, angle, IntPtr.Zero, (SDL.SDL_RendererFlip)flip);
        }

        public void DrawCenter(int x, int y, int w, int h)
        {
            SDL.SDL_Rect src = new SDL.SDL_Rect((int)frame * this.w, 0, this.w, this.h);
            SDL.SDL_Rect dst = new SDL.SDL_Rect(x - (int)Game.Camera.X - this.w / 2, y - (int)Game.Camera.Y - this.h / 2, w <= 0 ? this.w : w, h <= 0 ? this.h : h);
            SDL.SDL_RenderCopy(Game.renderer, this.texture, ref src, ref dst);
        }

        public void DrawCenter(int x, int y, int w, int h, double angle, bool flipv, bool fliph)
        {
            SDL.SDL_Rect src = new SDL.SDL_Rect((int)frame * this.w, 0, this.w, this.h);
            SDL.SDL_Rect dst = new SDL.SDL_Rect(x - (int)Game.Camera.X - this.w / 2, y - (int)Game.Camera.Y - this.h / 2, w <= 0 ? this.w : w, h <= 0 ? this.h : h);
            int flip = (flipv ? 2 : 0) + (fliph ? 1 : 0);
            SDL.SDL_RenderCopyEx(Game.renderer, this.texture, ref src, ref dst, angle, IntPtr.Zero, (SDL.SDL_RendererFlip)flip);
        }
    }

    public class AnimSprite
    {
        Animation[] anims;
        int current;

        //bool stopped;

        public AnimSprite(string file)
        {
            //stopped = true;
            anims = new Animation[5];
            current = 0;

            string[] lines = file.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                if(line.Length != 0 && line[0] != '#')
                {
                    string[] toks = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (toks.Length != 6)
                    {
                        Log.WriteLine("Unkown line in " + file + " file!");
                    }
                    else
                    {
                        int ind = Convert.ToInt32(toks[0]);
                        if(ind+1 > anims.Length)
                            Array.Resize<Animation>(ref anims, ind+1);
                        anims[ind] = new Animation(toks[1], Convert.ToInt32(toks[2]), (float)Convert.ToDouble(toks[3]), Convert.ToBoolean(toks[4]), Convert.ToInt32(toks[5]));
                    }
                }
            }
        }

        public void SetAnim(int num)
        {
            if (num != current)
            {
                current = num;
                anims[current].Reset();
                //stopped = false;
            }
        }

        public int GetFrame()
        {
            return (int)anims[current].frame;
        }

        public int GetAnim()
        {
            return current;
        }

        public void Update(float time)
        {
            //if (!stopped)
            int next = current;
            anims[current].Update(time, ref next);
            current = next;
        }

        public void Draw(int x, int y)
        {
            anims[current].Draw(x, y, 0, 0);
        }

        public void Draw(int x, int y, double angle)
        {
            anims[current].Draw(x, y, 0, 0, angle, false, false);
        }

        public void Draw(int x, int y, bool flipv, bool fliph)
        {
            anims[current].Draw(x, y, 0, 0, 0.0, flipv, fliph);
        }

        public void Draw(int x, int y, int w, int h)
        {
            anims[current].Draw(x, y, w, h);
        }

        public void Draw(int x, int y, int w, int h, double angle, bool flipv, bool fliph)
        {
            anims[current].Draw(x, y, w, h, angle, flipv, fliph);
        }

        public void DrawCenter(int x, int y)
        {
            anims[current].DrawCenter(x, y, 0, 0);
        }

        public void DrawCenter(int x, int y, double angle)
        {
            anims[current].DrawCenter(x, y, 0, 0, angle, false, false);
        }

        public void DrawCenter(int x, int y, bool flipv, bool fliph)
        {
            anims[current].DrawCenter(x, y, 0, 0, 0.0, flipv, fliph);
        }

        public void DrawCenter(int x, int y, int w, int h)
        {
            anims[current].DrawCenter(x, y, w, h);
        }

        public void DrawCenter(int x, int y, int w, int h, double angle, bool flipv, bool fliph)
        {
            anims[current].DrawCenter(x, y, w, h, angle, flipv, fliph);
        }
    }
}
