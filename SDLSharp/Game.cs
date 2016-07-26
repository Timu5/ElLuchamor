using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SDLSharp
{
    public class Game
    {
        public static string Name = "Game";
        public static Vector2 Camera = new Vector2(0, 0);
        static bool running = true;
        public static IntPtr renderer = IntPtr.Zero;

        public static float TimeScale = 1.0f; 

        static IGameState current;

        public static void SetState(IGameState state)
        {
            SetState(state, true);
        }

        public static void SetState(IGameState state, bool fn)
        {
            if (fn)
            {
                current.Quit();
                state.Init();
            }
            current = state;
        }

        public static uint GetTime()
        {
            return SDL.SDL_GetTicks();
        }

        public static void Run(IGameState state)
        {
            current = state;
            Config.Load();
            SDL.SDL_Init(SDL2.SDL.SDL_INIT_EVERYTHING);
            SDL_mixer.Mix_OpenAudio(44100, SDL_mixer.MIX_DEFAULT_FORMAT, 2, 4096);
            SDL_ttf.TTF_Init();
            IntPtr window = SDL.SDL_CreateWindow(Name, SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, Config.GetInt("width"), Config.GetInt("height"), SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN | SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE);
            renderer = SDL.SDL_CreateRenderer(window, 0, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);

            if (Config.GetInt("fullscreen") > 0)
                SDL.SDL_SetWindowFullscreen(window, (Config.GetInt("fullscreen") == 1) ? (uint)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN : (uint)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP);

            SDL.SDL_SetHint(SDL.SDL_HINT_RENDER_SCALE_QUALITY, "0");
            SDL.SDL_RenderSetLogicalSize(renderer, 640, 480);

            Renderer.Init(renderer);

            current.Init();

            uint oldTime = 0;

            SDL.SDL_Event e;
            while (running)
            {
                while (SDL.SDL_PollEvent(out e) != 0)
                {
                    switch (e.type)
                    {
                        case SDL.SDL_EventType.SDL_QUIT:
                            running = false;
                            break;
                        case SDL.SDL_EventType.SDL_KEYDOWN:
                            if (e.key.repeat == 0)
                                Input.SetKey((int)e.key.keysym.scancode, true);
                            break;
                        case SDL.SDL_EventType.SDL_KEYUP:
                             Input.SetKey((int)e.key.keysym.scancode, false);
                            break;
                        case SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN:
                            break;
                        case SDL.SDL_EventType.SDL_MOUSEBUTTONUP:
                            break;
                    }
                }

                uint newTime = SDL.SDL_GetTicks();
                float time = (newTime - oldTime) / 1000.0f;
                oldTime = newTime;

                current.Update(time * TimeScale);

                SDL.SDL_RenderClear(renderer);

                current.Draw();
                
                SDL.SDL_RenderPresent(renderer);
            }

            current.Quit();

            SDL.SDL_DestroyRenderer(renderer);
            SDL.SDL_DestroyWindow(window);

            SDL_ttf.TTF_Quit();
            SDL_mixer.Mix_CloseAudio();
            SDL.SDL_Quit();
        }

        public static void Quit()
        {
            running = false;
        }
    }
}
