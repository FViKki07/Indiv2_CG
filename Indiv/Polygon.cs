using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.DataFormats;

namespace Indiv
{
    public class Polygon
    {
        public Figure host = null;
        public List<int> points = new List<int>();
        public Color color = Color.Black;
        //public Material material;
        public PointZ normal;

        public Polygon(Figure h = null)
        {
            host = h;
            
        }

        public Polygon(Polygon s)
        {
            points = new List<int>(s.points);
            host = s.host;
            //drawing_pen = s.drawing_pen.Clone() as Pen;
            color = s.color;
            normal = new PointZ(s.normal);
        }


        public PointZ getPoint(int index)
        {
            if (host != null)
                return host.points[points[index]];
            return null;
        }

        public static PointZ norm(Polygon S)
        {
            if (S.points.Count() < 3)
                return new PointZ(0, 0, 0);
            PointZ U = S.getPoint(1) - S.getPoint(0);
            PointZ V = S.getPoint(S.points.Count - 1) - S.getPoint(0);
            PointZ normal = U * V;
            return normal.Normalize();
        }
    }
}
