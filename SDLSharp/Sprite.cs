using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SDLSharp
{
    public class Sprite
    {
        public IntPtr Texture;
        public int Width, Height;

        public Sprite(string filename)
        {
            Texture = SDL_image.IMG_LoadTexture(Game.renderer, filename);
            uint tmp; int tmp2;
            SDL.SDL_QueryTexture(Texture, out tmp, out tmp2, out Width, out Height);
        }

        ~Sprite()
        {
            SDL.SDL_DestroyTexture(Texture);
        }

        public void Draw(int x, int y)
        {
            Draw(x, y, Width, Height);
        }

        public void Draw(int x, int y, float scale)
        {
            Draw(x, y, (int)(Width * scale), (int)(Height * scale));
        }

        public void Draw(int x, int y, double angle)
        {
            Draw(x, y, Width, Height, angle, false, false);
        }

        public void Draw(int x, int y, bool flipv, bool fliph)
        {
            Draw(x, y, Width, Height, 0.0, flipv, fliph);
        }

        public void Draw(int x, int y, int w, int h)
        {
            SDL.SDL_Rect dst = new SDL.SDL_Rect(x - (int)Game.Camera.X, y - (int)Game.Camera.Y, w, h);
            SDL.SDL_RenderCopy(Game.renderer, this.Texture, IntPtr.Zero, ref dst);
        }

        public void Draw(int x, int y, int w, int h, double angle, bool flipv, bool fliph)
        {
            SDL.SDL_Rect dst = new SDL.SDL_Rect(x - (int)Game.Camera.X, y - (int)Game.Camera.Y, w, h);
            int flip = (flipv ? 2 : 0) + (fliph ? 1 : 0);
            SDL.SDL_RenderCopyEx(Game.renderer, this.Texture, IntPtr.Zero, ref dst, angle, IntPtr.Zero, (SDL.SDL_RendererFlip)flip);
        }

        public void DrawCenter(int x, int y)
        {
            DrawCenter(x, y, Width, Height);
        }

        public void DrawCenter(int x, int y, float scale)
        {
            DrawCenter(x, y, (int)(Width * scale), (int)(Height * scale));
        }

        public void DrawCenter(int x, int y, double angle)
        {
            DrawCenter(x, y, Width, Height, angle, false, false);
        }

        public void DrawCenter(int x, int y, bool flipv, bool fliph)
        {
            DrawCenter(x, y, Width, Height, 0.0, flipv, fliph);
        }

        public void DrawCenter(int x, int y, int w, int h)
        {
            SDL.SDL_Rect dst = new SDL.SDL_Rect(x - (int)Game.Camera.X - this.Width / 2, y - (int)Game.Camera.Y - this.Height / 2, w, h);
            SDL.SDL_RenderCopy(Game.renderer, this.Texture, IntPtr.Zero, ref dst);
        }

        public void DrawCenter(int x, int y, int w, int h, double angle, bool flipv, bool fliph)
        {
            SDL.SDL_Rect dst = new SDL.SDL_Rect(x - (int)Game.Camera.X - this.Width / 2, y - (int)Game.Camera.Y - this.Height / 2, w, h);
            int flip = (flipv ? 2 : 0) + (fliph ? 1 : 0);
            SDL.SDL_RenderCopyEx(Game.renderer, this.Texture, IntPtr.Zero, ref dst, angle, IntPtr.Zero, (SDL.SDL_RendererFlip)flip);
        }
    }
}
