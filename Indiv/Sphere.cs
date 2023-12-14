using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indiv
{
    internal class Sphere: Figure
    {
        float radius;

        public Color color = Color.Black;

        public Sphere(PointZ p, float r)
        {
            points.Add(p);
            radius = r;
        }

        public override void SetColor(Color dw)
        {
            color = dw;
        }

        public override bool Intersection(Ray r, out double intersection, out PointZ normal)
        {
            intersection = 0;
            normal = null;
            var centre = points[0]; 
            PointZ oc = r.start - centre;

            double a = PointZ.DotProduct(r.direction, r.direction);
            double b = 2 * PointZ.DotProduct(oc, r.direction);
            double c = PointZ.DotProduct(oc, oc) - radius * radius;

            double discriminant = b * b - 4 * a * c;
            intersection = 0;
            if (discriminant < 0)
            {
                return false;
            }

            double sqrtd = Math.Sqrt(discriminant);
            double t1 = (-b + sqrtd) / (2 * a);
            double t2 = (-b - sqrtd) / (2 * a);

            double min_t = Math.Min(t1, t2);
            double max_t = Math.Max(t1, t2);

            intersection = (min_t > eps) ? min_t : max_t;
            if(intersection > eps)
            {
                normal = (r.start + r.direction * intersection) - points[0];
                normal.Normalize();
                fMaterial.color = new PointZ(color.R / 255f, color.G / 255f, color.B / 255f);
                return true;
            }
            return false;
        }
    }
}
