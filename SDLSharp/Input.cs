using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDLSharp
{
    public enum Key
    {
        Unkown = 0,
        A = 4,
        B = 5,
        C = 6,
        D = 7,
        E = 8,
        F = 9,
        G = 10,
        H = 11,
        I = 12,
        J = 13,
        K = 14,
        L = 15,
        M = 16,
        N = 17,
        O = 18,
        P = 19,
        Q = 20,
        R = 21,
        S = 22,
        T = 23,
        U = 24,
        V = 25,
        W = 26,
        X = 27,
        Y = 28,
        Z = 29,
        N1 = 30,
        N2 = 31,
        N3 = 32,
        N4 = 33,
        N5 = 34,
        N6 = 35,
        N7 = 36,
        N8 = 37,
        N9 = 38,
        N0 = 39,
        Return = 40,
        Escape = 41,
        Backspace = 42,
        Tab = 43,
        Space = 44,
        Minus = 45,
        Equals = 46,
        LeftBracket = 47,
        RightBracket = 48,
        Backslash = 49,
        Nonushash = 50,
        Semicolon = 51,
        Apostrophe = 52,
        Grave = 53,
        Comma = 54,
        Period = 55,
        Slash = 56,
        Capslock = 57,
        F1 = 58,
        F2 = 59,
        F3 = 60,
        F4 = 61,
        F5 = 62,
        F6 = 63,
        F7 = 64,
        F8 = 65,
        F9 = 66,
        F10 = 67,
        F11 = 68,
        F12 = 69,
        Printscreen = 70,
        Scrolllock = 71,
        Pause = 72,
        Insert = 73,
        Home = 74,
        Pageup = 75,
        Delete = 76,
        End = 77,
        Pagedown = 78,
        Right = 79,
        Left = 80,
        Down = 81,
        Up = 82,
        Numlockclear = 83,
        KP_DIVIDE = 84,
        KP_MULTIPLY = 85,
        KP_MINUS = 86,
        KP_PLUS = 87,
        KP_ENTER = 88,
        KP_1 = 89,
        KP_2 = 90,
        KP_3 = 91,
        KP_4 = 92,
        KP_5 = 93,
        KP_6 = 94,
        KP_7 = 95,
        KP_8 = 96,
        KP_9 = 97,
        KP_0 = 98,
        KP_PERIOD = 99,
        Nonusbackslash = 100,
        Application = 101,
        Power = 102,
        KP_EQUALS = 103,
        F13 = 104,
        F14 = 105,
        F15 = 106,
        F16 = 107,
        F17 = 108,
        F18 = 109,
        F19 = 110,
        F20 = 111,
        F21 = 112,
        F22 = 113,
        F23 = 114,
        F24 = 115,
        Execute = 116,
        Help = 117,
        Menu = 118,
        Select = 119,
        Stop = 120,
        Again = 121,
        Undo = 122,
        Cut = 123,
        Copy = 124,
        Paste = 125,
        Find = 126,
        Mute = 127,
        Volumeup = 128,
        Volumedown = 129,
        KP_COMMA = 133,
        KP_EQUALSAS400 = 134,
        INTERNATIONAL1 = 135,
        INTERNATIONAL2 = 136,
        INTERNATIONAL3 = 137,
        INTERNATIONAL4 = 138,
        INTERNATIONAL5 = 139,
        INTERNATIONAL6 = 140,
        INTERNATIONAL7 = 141,
        INTERNATIONAL8 = 142,
        INTERNATIONAL9 = 143,
        LANG1 = 144,
        LANG2 = 145,
        LANG3 = 146,
        LANG4 = 147,
        LANG5 = 148,
        LANG6 = 149,
        LANG7 = 150,
        LANG8 = 151,
        LANG9 = 152,
        Alterase = 153,
        Sysreq = 154,
        Cancel = 155,
        Clear = 156,
        Prior = 157,
        Return2 = 158,
        Separator = 159,
        Out = 160,
        Oper = 161,
        Clearagain = 162,
        Crsel = 163,
        Exsel = 164,
        KP_00 = 176,
        KP_000 = 177,
        Thousandsseparator = 178,
        Decimalseparator = 179,
        Currencyunit = 180,
        Currencysubunit = 181,
        KP_LEFTPAREN = 182,
        KP_RIGHTPAREN = 183,
        KP_LEFTBRACE = 184,
        KP_RIGHTBRACE = 185,
        KP_TAB = 186,
        KP_BACKSPACE = 187,
        KP_A = 188,
        KP_B = 189,
        KP_C = 190,
        KP_D = 191,
        KP_E = 192,
        KP_F = 193,
        KP_XOR = 194,
        KP_POWER = 195,
        KP_PERCENT = 196,
        KP_LESS = 197,
        KP_GREATER = 198,
        KP_AMPERSAND = 199,
        KP_DBLAMPERSAND = 200,
        KP_VERTICALBAR = 201,
        KP_DBLVERTICALBAR = 202,
        KP_COLON = 203,
        KP_HASH = 204,
        KP_SPACE = 205,
        KP_AT = 206,
        KP_EXCLAM = 207,
        KP_MEMSTORE = 208,
        KP_MEMRECALL = 209,
        KP_MEMCLEAR = 210,
        KP_MEMADD = 211,
        KP_MEMSUBTRACT = 212,
        KP_MEMMULTIPLY = 213,
        KP_MEMDIVIDE = 214,
        KP_PLUSMINUS = 215,
        KP_CLEAR = 216,
        KP_CLEARENTRY = 217,
        KP_BINARY = 218,
        KP_OCTAL = 219,
        KP_DECIMAL = 220,
        KP_HEXADECIMAL = 221,
        Lctrl = 224,
        Lshift = 225,
        Lalt = 226,
        Lgui = 227,
        Rctrl = 228,
        Rshift = 229,
        Ralt = 230,
        Rgui = 231,
        Mode = 257,
        AUDIONEXT = 258,
        AUDIOPREV = 259,
        AUDIOSTOP = 260,
        AUDIOPLAY = 261,
        AUDIOMUTE = 262,
        MEDIASELECT = 263,
        WWW = 264,
        MAIL = 265,
        CALCULATOR = 266,
        COMPUTER = 267,
        AC_SEARCH = 268,
        AC_HOME = 269,
        AC_BACK = 270,
        AC_FORWARD = 271,
        AC_STOP = 272,
        AC_REFRESH = 273,
        AC_BOOKMARKS = 274,
        BRIGHTNESSDOWN = 275,
        BRIGHTNESSUP = 276,
        DISPLAYSWITCH = 277,
        KBDILLUMTOGGLE = 278,
        KBDILLUMDOWN = 279,
        KBDILLUMUP = 280,
        EJECT = 281,
        SLEEP = 282,
        APP1 = 283,
        APP2 = 284,
    }

    public class Input
    {
        static bool[] keys = new bool[512];
        static bool[] keysUp = new bool[512];
        static bool[] keysDown = new bool[512];

        public static void SetKey(int id, bool val)
        {
            if (keys[id] == val)
            {
                return;
            }

            if (val == true)
            {
                keysDown[id] = true;
                keysUp[id] = false;
                keys[id] = true;
            }
            else
            {
                keysDown[id] = false;
                keysUp[id] = true;
                keys[id] = false;
            }
        }

        public static bool GetKey(Key key)
        {
            return GetKey((int)key);
        }

        public static bool GetKey(int id)
        {
            return keys[id];
        }

        public static bool GetKeyDown(Key key)
        {
            return GetKeyDown((int)key);
        }

        public static bool GetKeyDown(int id)
        {
            bool tmp = keysDown[id];
            keysDown[id] = false;
            return tmp;
        }

        public static bool GetKeyUp(Key key)
        {
            return GetKeyUp((int)key);
        }

        public static bool GetKeyUp(int id)
        {
            bool tmp = keysUp[id];
            keysUp[id] = false;
            return tmp;
        }

       /* public bool GetMouseButton()
        {
            return false;
        }

        public bool GetMouseDown()
        {
            return false;
        }

        public bool GetMouseUp()
        {
            return false;
        }

        public float GetAxis()
        {
            return 0.0f;
        }*/
    }
}
