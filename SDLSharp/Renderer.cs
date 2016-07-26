using System;
using SDL2;

namespace SDLSharp
{
	public class Renderer
	{
		static IntPtr renderer;
		public static void Init(IntPtr _renderer)
		{
			renderer = _renderer;
		}

        public static void SetColor(byte r, byte g, byte b, byte a)
        {
            SDL.SDL_SetRenderDrawColor(renderer, r, g, b, a);
        }

		public static void DrawLine(Vector2 start, Vector2 end)
		{
			DrawLine((int)start.X, (int)start.Y, (int)end.X, (int)end.Y);
		}

		public static void DrawLine(int x1, int y1, int x2, int y2)
		{
            SDL.SDL_RenderDrawLine(renderer, x1 - (int)Game.Camera.X, y1 - (int)Game.Camera.Y, x2 - (int)Game.Camera.X, y2 - (int)Game.Camera.Y);
		}

        public static void DrawRect(Vector2 pos, Vector2 size)
        {
            SDL.SDL_Rect r = new SDL.SDL_Rect((int)pos.X - (int)Game.Camera.X, (int)pos.Y - (int)Game.Camera.Y, (int)size.X, (int)size.Y);
            SDL.SDL_RenderDrawRect(renderer, ref r);
        }

        public static void FillRect(Vector2 pos, Vector2 size)
        {
            SDL.SDL_Rect r = new SDL.SDL_Rect((int)pos.X - (int)Game.Camera.X, (int)pos.Y - (int)Game.Camera.Y, (int)size.X, (int)size.Y);
            SDL.SDL_RenderFillRect(renderer, ref r);
        }
	}
}

