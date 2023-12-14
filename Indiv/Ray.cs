using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Indiv
{
    public class Ray
    {
        public PointZ start, direction;

        public Ray(PointZ st, PointZ end)
        {
            start = new PointZ(st);
            direction = (end - st).Normalize();
        }

        public Ray() { }

        public Ray(Ray r)
        {
            start = r.start;
            direction = r.direction;
        }


        // Создает отраженный луч 
        public Ray Reflect(PointZ hit_point, PointZ normal)
        {
            PointZ reflect_dir = direction - 2 * normal * PointZ.DotProduct(direction, normal);
            return new Ray(hit_point, hit_point + reflect_dir);
        }

        //Создает преломленный луч 
        public Ray Refract(PointZ hit_point, PointZ normal,float refraction ,float refract_coef)
        {
            Ray res_ray = new Ray();
            double sclr = PointZ.DotProduct(normal, direction);
            float coef = refraction / refract_coef;
            double theta_formula = 1 - coef * coef * (1 - sclr * sclr);
            if (theta_formula >= 0)
            {
                float cos_theta = (float)Math.Sqrt(theta_formula);
                res_ray.start = new PointZ(hit_point);
                res_ray.direction = (direction * coef - (cos_theta + coef * sclr) * normal).Normalize();
                return res_ray;
            }
            else
                return null;
        }
    }

}
