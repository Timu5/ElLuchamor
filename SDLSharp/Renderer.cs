using System;
using SDL2;

namespace SDLSharp
{
	public class Renderer
	{
		static IntPtr renderer;
		public Renderer(IntPtr _renderer)
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
	}
}

