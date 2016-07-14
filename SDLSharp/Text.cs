using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SDLSharp
{
    public class Text
    {
        public string Data;
        SDL.SDL_Color color;
        IntPtr font;
        IntPtr texture;
        int w, h;

        public Text(string data, IntPtr font, byte r, byte g, byte b, byte a)
        {
            this.Data = data;
            this.font = font;
            color = new SDL.SDL_Color(r, g, b, a);
            Update();
        }

        public void Update()
        {
            IntPtr surface = SDL_ttf.TTF_RenderText_Blended(font, Data, color);
            texture = SDL.SDL_CreateTextureFromSurface(Game.renderer, surface);
            SDL.SDL_FreeSurface(surface);
            uint tmp; int tmp2;
            SDL.SDL_QueryTexture(texture, out tmp, out tmp2, out w, out h);
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
            SDL.SDL_Rect dst = new SDL.SDL_Rect(x - (int)Game.Camera.X, y - (int)Game.Camera.Y, w, h);
            SDL.SDL_RenderCopy(Game.renderer, this.texture, IntPtr.Zero, ref dst);
        }

        public void Draw(int x, int y, int w, int h, double angle, bool flipv, bool fliph)
        {
            SDL.SDL_Rect dst = new SDL.SDL_Rect(x - (int)Game.Camera.X, y - (int)Game.Camera.Y, w, h);
            int flip = (flipv ? 2 : 0) + (fliph ? 1 : 0);
            SDL.SDL_RenderCopyEx(Game.renderer, this.texture, IntPtr.Zero, ref dst, angle, IntPtr.Zero, (SDL.SDL_RendererFlip)flip);
        }
    }
}
