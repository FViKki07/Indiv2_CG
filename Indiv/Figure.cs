using Indiv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indiv
{
    public class Figure
    {
        public static float eps = 0.001f;
        public List<PointZ> points = new List<PointZ>();
        public List<Polygon> polygons = new List<Polygon>();
        public Material fMaterial;

        public Figure() { }

        public Figure(Figure f)
        {
            foreach (PointZ p in f.points)
                points.Add(new PointZ(p));

            foreach (Polygon s in f.polygons)
            {
                polygons.Add(new Polygon(s));
                polygons.Last().figure = this;
            }
        }

        public Figure(Polygon pol, List<PointZ> ps)
        {
            foreach (var i in pol.points)
                points.Add(ps.ElementAt(i));
            polygons.Add(pol);
        }
        static public Figure get_Cube(float sz)
        {
            Figure res = new Figure();
            res.points.Add(new PointZ(sz / 2, sz / 2, sz / 2));
            res.points.Add(new PointZ(-sz / 2, sz / 2, sz / 2));
            res.points.Add(new PointZ(-sz / 2, sz / 2, -sz / 2));
            res.points.Add(new PointZ(sz / 2, sz / 2, -sz / 2));
            res.points.Add(new PointZ(sz / 2, -sz / 2, sz / 2));
            res.points.Add(new PointZ(-sz / 2, -sz / 2, sz / 2));
            res.points.Add(new PointZ(-sz / 2, -sz / 2, -sz / 2));
            res.points.Add(new PointZ(sz / 2, -sz / 2, -sz / 2));

            Polygon s = new Polygon(res);
            s.points.AddRange(new int[] { 3, 2, 1, 0 });
            res.polygons.Add(s);

            s = new Polygon(res);
            s.points.AddRange(new int[] { 4, 5, 6, 7 });
            res.polygons.Add(s);

            s = new Polygon(res);
            s.points.AddRange(new int[] { 2, 6, 5, 1 });
            res.polygons.Add(s);

            s = new Polygon(res);
            s.points.AddRange(new int[] { 0, 4, 7, 3 });
            res.polygons.Add(s);

            s = new Polygon(res);
            s.points.AddRange(new int[] { 1, 5, 4, 0 });
            res.polygons.Add(s);

            s = new Polygon(res);
            s.points.AddRange(new int[] { 2, 3, 7, 6 });
            res.polygons.Add(s);
            return res;
        }

        static public Figure get_StretchCube(float szX, float szY, float szZ)
        {
            Figure res = new Figure();
            res.points.Add(new PointZ(szX / 2, szY / 2, szZ / 2));
            res.points.Add(new PointZ(-szX / 2, szY / 2, szZ / 2));
            res.points.Add(new PointZ(-szX / 2, szY / 2, -szZ / 2));
            res.points.Add(new PointZ(szX / 2, szY / 2, -szZ / 2));

            res.points.Add(new PointZ(szX / 2, -szY / 2, szZ / 2));
            res.points.Add(new PointZ(-szX / 2, -szY / 2, szZ / 2));
            res.points.Add(new PointZ(-szX / 2, -szY / 2, -szZ / 2));
            res.points.Add(new PointZ(szX / 2, -szY / 2, -szZ / 2));

            Polygon s = new Polygon(res);
            s.points.AddRange(new int[] { 3, 2, 1, 0 });
            res.polygons.Add(s);

            s = new Polygon(res);
            s.points.AddRange(new int[] { 4, 5, 6, 7 });
            res.polygons.Add(s);

            s = new Polygon(res);
            s.points.AddRange(new int[] { 2, 6, 5, 1 });
            res.polygons.Add(s);

            s = new Polygon(res);
            s.points.AddRange(new int[] { 0, 4, 7, 3 });
            res.polygons.Add(s);

            s = new Polygon(res);
            s.points.AddRange(new int[] { 1, 5, 4, 0 });
            res.polygons.Add(s);

            s = new Polygon(res);
            s.points.AddRange(new int[] { 2, 3, 7, 6 });
            res.polygons.Add(s);

            return res;
        }

        public virtual void SetColor(Color color)
        {
            foreach (Polygon s in polygons)
                s.color = color;
        }


        public bool IntersectsTriangle(Ray r, PointZ p0, PointZ p1, PointZ p2, out double intersect)
        {
            intersect = -1;
            PointZ edge1 = p1 - p0;
            PointZ edge2 = p2 - p0;
            PointZ h = r.direction * edge2;
            double a = PointZ.DotProduct(edge1, h);
            if (a > -eps && a < eps)//параллельность луча и полигона
                return false;

            double f = 1.0f / a;
            PointZ s = r.start - p0;
            double u = f * PointZ.DotProduct(s, h);
            if (u < 0 || u > 1)
                return false;
            PointZ q = s * edge1;
            double v = f * PointZ.DotProduct(r.direction, q);
            if (v < 0 || u + v > 1)
                return false;
            double t = f * PointZ.DotProduct(edge2, q);
            if (t > eps)
            {
                intersect = t;
                return true;
            }
            else
                return false;
        }

        public void Apply(Transform t)
        {
            foreach (var v in points)
                v.Apply(t);
        }

        public void Translate(double x, double y, double z)
        {
            Apply(Transform.Translate(x, y, z));
        }

        public virtual bool Intersection(Ray r, out double intersect, out PointZ normal)
        {
            intersect = 0;
            normal = null;
            Polygon polygon = null;
            foreach (Polygon p in polygons)
            {
                    if (IntersectsTriangle(r, p.getPoint(0), p.getPoint(1), p.getPoint(2), out double t) && (intersect == 0 || t < intersect))
                    {
                        intersect = t;
                        polygon = p;
                    }
                    else if (IntersectsTriangle(r, p.getPoint(0), p.getPoint(2), p.getPoint(3), out t) && (intersect == 0 || t < intersect))
                    {
                        intersect = t;
                        polygon = p;
                    }
 
            }
            if (intersect != 0)
            {
                normal = Polygon.norm(polygon);
                fMaterial.color = new PointZ(polygon.color.R / 255f, polygon.color.G / 255f, polygon.color.B / 255f);
                return true;
            }
            return false;
        }
    }
}
