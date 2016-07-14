using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SDLSharp
{
    public static class Config
    {
        private static Dictionary<string, string> vars;

        public static void Load()
        {
            vars = new Dictionary<string, string>();
            string[] lines = File.ReadAllLines("config.txt");
            foreach (string line in lines)
            {
                string[] tok = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (tok.Length != 2)
                    continue;
                vars.Add(tok[0], tok[1]);
            }
        }

        public static string GetString(string key)
        {
            if (vars.ContainsKey(key))
                return vars[key];
            return "";
        }

        public static int GetInt(string key)
        {
            if (vars.ContainsKey(key))
            {
                int i;
                if (int.TryParse(vars[key], out i))
                    return i;
            }
            return 0;
        }

        public static float GetFloat(string key)
        {
            if (vars.ContainsKey(key))
            {
                float i;
                if (float.TryParse(vars[key], out i))
                    return i;
            }
            return 0.0f;
        }
    }
}
