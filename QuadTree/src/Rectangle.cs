using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    
    public class Rectangle
    {
        public int _x, _y, _w, _h;
        public Rectangle(int x, int y, int w, int h)
        {
            _x = x;
            _y = y;
            _w = w;
            _h = h;
        }

        public bool Contains(Point pt)
        {
            if (pt._x < _x + _w && pt._x > _x - _w && pt._y < _y + _h && pt._y > _y - _h)
                return true;
            return false;
        }
    }
}
