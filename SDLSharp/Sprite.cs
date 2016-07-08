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
        IntPtr texture;
        int w, h;

        public Sprite(string filename)
        {
            texture = SDL_image.IMG_LoadTexture(Game.renderer, filename);
            uint tmp; int tmp2;
            SDL.SDL_QueryTexture(texture, out tmp, out tmp2, out w, out h);
        }

        ~Sprite()
        {
            SDL.SDL_DestroyTexture(texture);
        }

        internal IntPtr GetTexture()
        {
            return texture;
        }

        public void Draw(int x, int y)
        {
            Draw(x, y, w, h);
        }

        public void Draw(int x, int y, double angle)
        {
            Draw(x, y, w, h, angle, false, false);
        }

        public void Draw(int x, int y, bool flipv, bool fliph)
        {
            Draw(x, y, w, h, 0.0, flipv, fliph);
        }

        public void Draw(int x, int y, int w, int h)
        {
            SDL.SDL_Rect dst;
            dst.x = x - (int)Game.Camera.X;
            dst.y = y - (int)Game.Camera.Y;
            dst.w = w;
            dst.h = h;
            SDL.SDL_RenderCopy(Game.renderer, this.texture, IntPtr.Zero, ref dst);
        }

        public void Draw(int x, int y, int w, int h, double angle, bool flipv, bool fliph)
        {
            SDL.SDL_Rect dst;
            dst.x = x - (int)Game.Camera.X;
            dst.y = y - (int)Game.Camera.Y;
            dst.w = w;
            dst.h = h;
            int flip = (flipv ? 2 : 0) + (fliph ? 1 : 0);
            SDL.SDL_RenderCopyEx(Game.renderer, this.texture, IntPtr.Zero, ref dst, angle, IntPtr.Zero, (SDL.SDL_RendererFlip)flip);
        }

        public void DrawCenter(int x, int y)
        {
            DrawCenter(x, y, w, h);
        }

        public void DrawCenter(int x, int y, double angle)
        {
            DrawCenter(x, y, w, h, angle, false, false);
        }

        public void DrawCenter(int x, int y, bool flipv, bool fliph)
        {
            DrawCenter(x, y, w, h, 0.0, flipv, fliph);
        }

        public void DrawCenter(int x, int y, int w, int h)
        {
            SDL.SDL_Rect dst;
            dst.x = x - this.w / 2 - (int)Game.Camera.X;
            dst.y = y - this.h / 2 - (int)Game.Camera.Y;
            dst.w = w;
            dst.h = h;
            SDL.SDL_RenderCopy(Game.renderer, this.texture, IntPtr.Zero, ref dst);
        }

        public void DrawCenter(int x, int y, int w, int h, double angle, bool flipv, bool fliph)
        {
            SDL.SDL_Rect dst;
            dst.x = x - this.w / 2 - (int)Game.Camera.X;
            dst.y = y - this.h / 2 - (int)Game.Camera.Y;
            dst.w = w;
            dst.h = h;
            int flip = (flipv ? 2 : 0) + (fliph ? 1 : 0);
            SDL.SDL_RenderCopyEx(Game.renderer, this.texture, IntPtr.Zero, ref dst, angle, IntPtr.Zero, (SDL.SDL_RendererFlip)flip);
        }
    }
}
