using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDLSharp
{
    public static class MathE
    {
        public static float Lerp(float f, float v1, float t)
        {
            return (1 - t) * f + t * v1;
        }
    }
}
