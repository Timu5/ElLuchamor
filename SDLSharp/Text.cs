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
        public SDL.SDL_Color Color;
        public IntPtr Font;
        public IntPtr Texture;
        public int Width, Height;

        public Text(string data, IntPtr font, byte r, byte g, byte b, byte a)
        {
            Data = data;
            Font = font;
            Color = new SDL.SDL_Color(r, g, b, a);
            Update();
        }

        ~Text()
        {
            SDL.SDL_DestroyTexture(Texture);
        }

        public void Update()
        {
            IntPtr surface = SDL_ttf.TTF_RenderText_Blended(Font, Data, Color);
            Texture = SDL.SDL_CreateTextureFromSurface(Game.renderer, surface);
            SDL.SDL_FreeSurface(surface);
            uint tmp; int tmp2;
            SDL.SDL_QueryTexture(Texture, out tmp, out tmp2, out Width, out Height);
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
    }
}
