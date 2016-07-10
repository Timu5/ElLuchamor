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

		public static void DrawLine(Vector2 start, Vector2 end)
		{
			DrawLine ((int)start.X, (int)start.Y, (int)end.X, (int)end.Y);
		}

		public static void DrawLine(int x1, int y1, int x2, int y2)
		{
			SDL.SDL_RenderDrawLine (renderer, x1, y1, x2, y2);
		}
	}
}

