using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace SDLSharp
{
    public class Assets
    {
        static List<string> queue = new List<string>();
        static Dictionary<string, object> assets = new Dictionary<string, object>();

        static string directory = "data";

        public static void Queue(string name)
        {
            queue.Add(name);
        }

        public static T Get<T>(string name)
        {
            object tmp;
            if (!assets.TryGetValue(name, out tmp))
            {
                Queue(name);
                LoadAll();
                tmp = (T)assets[name];
            }
            if (typeof(T) != tmp.GetType())
                Log.WriteLine("Wrong type!");
            return (T)tmp;
        }

        public static void LoadAll()
        {
            foreach(string name in queue)
            {
                string fullname = Path.Combine(directory, name);
                object obj = null;
                switch(Path.GetExtension(name))
                {
                    case ".png":
                        obj = new Sprite(fullname);
                        break;

                    case ".anim":
                    case ".txt":
                    case ".ch":
                        obj = File.ReadAllText(fullname);
                        break;

                    case ".ogg":
                    case ".mp3":
                        if (name[0] == 'c')
                            obj = new Chunk(fullname);
                        else
                            obj = new Music(fullname);
                        break;

                    case ".ttf":
                        obj = SDL2.SDL_ttf.TTF_OpenFont(fullname, 60);
                        break;

                    default: // Read as binary file
                        obj = File.ReadAllBytes(fullname);
                        break;
                }
                
                assets.Add(name, obj);
            }
            queue.Clear();
        }
    }
}
