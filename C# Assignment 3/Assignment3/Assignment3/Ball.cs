using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Ball
    {
        int size;
        int thrown;
        Color color;

        public Ball(Color color, int size = 0)
        {
            this.size = size;
            thrown = 0;
            this.color = color;
        }

        public void Pop()
        {
            size = 0;
        }

        public void Throw()
        {
            if (size == 0) thrown++;
        }

        public int GetThrown()
        {
            return thrown;
        }
    }
}
