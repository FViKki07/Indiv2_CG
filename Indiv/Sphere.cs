using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static bool SphereIntersection(Ray r, PointZ sphere_pos, float sphere_rad, out double t)
        {
            PointZ k = r.start - sphere_pos;
            double b = PointZ.DotProduct(k, r.direction);
            double c = PointZ.DotProduct(k, k) - sphere_rad * sphere_rad;
            double d = b * b - c;
            t = 0;
            if (d >= 0)
            {
                double sqrtd = Math.Sqrt(d);
                double t1 = -b + sqrtd;
                double t2 = -b - sqrtd;

                double min_t = Math.Min(t1, t2);
                double max_t = Math.Max(t1, t2);

                t = (min_t > eps) ? min_t : max_t;
                return t > eps;
            }
            return false;
        }

        public override void SetColor(Color dw)
        {
            color = dw;
        }

        public override bool Intersection(Ray r, out double t, out PointZ normal)
        {
            t = 0;
            normal = null;
            if (SphereIntersection(r, points[0], radius, out t) && (t > eps))
            {
                normal = (r.start + r.direction * t) - points[0];
                normal.Normalize();
                fMaterial.color = new PointZ(color.R / 255f, color.G / 255f, color.B / 255f);
                return true;
            }
            return false;
        }
    }
}
