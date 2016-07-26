using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SDLSharp
{
    public class Music
    {
        IntPtr music;

        public Music(string filename)
        {
            music = SDL_mixer.Mix_LoadMUS(filename);
        }

        ~Music()
        {
            SDL_mixer.Mix_FreeMusic(music);
        }

        public void Play()
        {
            SDL_mixer.Mix_PlayMusic(music, -1);
        }

        public void Play(int n)
        {
            SDL_mixer.Mix_PlayMusic(music, n);
        }

        public void Resume()
        {
            SDL_mixer.Mix_ResumeMusic();
        }

        public void Pause()
        {
            SDL_mixer.Mix_PauseMusic();
        }

        public void Halt()
        {
            SDL_mixer.Mix_HaltMusic();
        }
    }
}
