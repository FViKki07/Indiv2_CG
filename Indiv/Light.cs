using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indiv
{
    public class Light
    {

        public PointZ position { get; set; }
        public PointZ color { get; set; }

        public Light(PointZ p, PointZ color) { 
            this.position = p;
            this.color = color;
        }

        //TODO
        public PointZ ShadeByLambert(PointZ hit_point, PointZ normal, PointZ material_color, float diffuse_coef)
        {
            PointZ dir = position - hit_point;
            dir.Normalize();
            PointZ diff = diffuse_coef * color * Math.Max(PointZ.DotProduct(normal, dir), 0);
            return new PointZ(diff.X * material_color.X, diff.Y * material_color.Y, diff.Z * material_color.Z);
        }
    }
}
