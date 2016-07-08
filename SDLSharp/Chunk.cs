using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SDLSharp
{
    public class Chunk
    {
        IntPtr chunk;

        public Chunk(string filename)
        {
           chunk = SDL_mixer.Mix_LoadWAV(filename);
        }

        ~Chunk()
        {
            SDL_mixer.Mix_FreeChunk(chunk);
        }

        public void Play()
        {
            SDL_mixer.Mix_PlayChannel(-1, chunk, 0);
        }

        public void Play(int n)
        {
            SDL_mixer.Mix_PlayChannel(-1, chunk, n);
        }
    }
}
