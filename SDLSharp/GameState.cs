using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDLSharp
{
    public interface IGameState
    {
        void Init();
        void Update(float time);
        void Draw();
        void Quit();
    }
}
