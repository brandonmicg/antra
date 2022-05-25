using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Color
    {
        private int r, g, b, a;

        public int R 
        {
            get { return r; }
            set
            {
                if (value < 0) r = 0;
                else if(value > 255) r = 255;
                else r = value;
            } 
        }

        public int G
        {
            get { return g; }
            set
            {
                if (value < 0) g = 0;
                else if (value > 255) g = 255;
                else g = value;
            }
        }

        public int B
        {
            get { return b; }
            set
            {
                if (value < 0) b = 0;
                else if (value > 255) b = 255;
                else b = value;
            }
        }


        public Color(int r, int g, int b, int a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Color(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            a = 255;
        }

        public int GetGrayScale()
        {
            return (r + g + b) / 3;
        }
    }
}
