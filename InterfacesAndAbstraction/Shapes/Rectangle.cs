

using System;

namespace Shapes
{
     public class Rectangle : IDrawable
    {
        
        private int width;
        private int height;
        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public void Draw()
        {
            Drawline(this.width, '*', '*');
            for (int i = 1; i < this.height - 1; ++i)
            {
                Drawline(this.width, '*', ' ');
            }
            Drawline(this.width, '*', '*');
        }

        private void Drawline(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 1; i < width - 1; ++i)
            {
                Console.Write(mid);
            }
            Console.WriteLine(end);
        }
    }
}
