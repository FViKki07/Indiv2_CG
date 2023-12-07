using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Indiv
{
    public class Material
    {
        public float reflection;//отражение
        public float refraction;//преломление
        public float ambient;//фоновое освещение
        public float diffuse;//диффузное освещение
        public float environment;//преломление среды
        public PointZ color;

        public Material(float refl, float refr, float amb, float dif, float env = 1)
        {
            reflection = refl;
            refraction = refr;
            ambient = amb;
            diffuse = dif;
            environment = env;
        }

        public Material(Material m)
        {
            reflection = m.reflection;
            refraction = m.refraction;
            environment = m.environment;
            ambient = m.ambient;
            diffuse = m.diffuse;
            color = new PointZ(m.color);
        }

        public Material() { }
    }
}
