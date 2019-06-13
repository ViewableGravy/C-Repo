using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class QuadTree
    {
        private Rectangle _rectangle;
        private List<Point> ptList = new List<Point>();
        private const int CAPACITY = 4;
        private Rectangle ne, nw, se, sw;
        private QuadTree NorthEast, NorthWest, SouthEast, SouthWest;
        private bool divided;
        public QuadTree(Rectangle Boundary)
        {
            _rectangle = Boundary;
            divided = false;
        }

        public void Insert(Point pt)
        {
            if (!_rectangle.Contains(pt))
                return;
            if (ptList.Count < CAPACITY)
            {
                ptList.Add(pt);
            }
            else
            {
                if (!divided)
                {
                    SubDivide();
                }

                NorthEast.Insert(pt);
                SouthEast.Insert(pt);
                SouthWest.Insert(pt);
                NorthWest.Insert(pt);
            }
        }

        private void SubDivide()
        {
            nw = new Rectangle(_rectangle._x - ((_rectangle._w)/2), _rectangle._y - ((_rectangle._h)/2), _rectangle._w / 2, _rectangle._h / 2);
            ne = new Rectangle(_rectangle._x + ((_rectangle._w) / 2), _rectangle._y - ((_rectangle._h) / 2), _rectangle._w / 2, _rectangle._h / 2);
            se = new Rectangle(_rectangle._x + ((_rectangle._w) / 2), _rectangle._y + ((_rectangle._h) / 2), _rectangle._w / 2, _rectangle._h / 2);
            sw = new Rectangle(_rectangle._x - ((_rectangle._w) / 2), _rectangle._y + ((_rectangle._h) / 2), _rectangle._w / 2, _rectangle._h / 2);

            NorthEast = new QuadTree(ne);
            NorthWest = new QuadTree(nw);
            SouthEast = new QuadTree(se);
            SouthWest = new QuadTree(sw);

            divided = true;
        }

        public void DrawPoints()
        {
            int x = _rectangle._x;
            int y = _rectangle._y;
            int w = _rectangle._w;
            int h = _rectangle._h;
            SwinGame.DrawRectangle(SwinGame.ColorBlack(), x - w, y - h, w * 2, h * 2);
          // SwinGame.DrawRectangle(SwinGame.ColorBlack(), _rectangle._x - 1 - _rectangle._w , _rectangle._y - 1 - _rectangle._h, 2 + (_rectangle._w *2),2+( _rectangle._h *2));
            //SwinGame.DrawRectangle(SwinGame.ColorWhite(), _rectangle._x - _rectangle._w, _rectangle._y - _rectangle._h, _rectangle._w *2, _rectangle._h *2);
                
            foreach (Point pt in ptList)
            {
                SwinGame.DrawCircle(SwinGame.ColorBlack(), pt._x, pt._y, 1);
            }

            if (divided)
            {
                NorthWest.DrawPoints();
                NorthEast.DrawPoints();
                SouthWest.DrawPoints();
                SouthEast.DrawPoints();
            }
        }
    }
}
