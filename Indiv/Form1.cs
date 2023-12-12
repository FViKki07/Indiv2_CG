using System.Windows.Forms;

namespace Indiv
{
    public partial class Form1 : Form
    {
        static Bitmap bmp;
        public int height, width;
        public List<Figure> scene = new List<Figure>();
        public List<Light> lights = new List<Light>();
        public Color[,] pixels_color;
        public PointZ[,] pixels;
        public PointZ cameraPoint;
        public PointZ up_left, up_right, down_left, down_right;

        public Form1()
        {
            InitializeComponent();
            height = pictureBox1.Height;
            width = pictureBox1.Width;
            //bmp = new Bitmap(width, height);
            cameraPoint = new PointZ();
            up_left = new PointZ();
            up_right = new PointZ();
            down_left = new PointZ();
            down_right = new PointZ();
            pictureBox1.Image = new Bitmap(width, height);
            GetRoom();
            BackwardRayTracing();
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    (pictureBox1.Image as Bitmap).SetPixel(i, j, pixels_color[i, j]);
                }
                //pictureBox1.Image = bmp;
                pictureBox1.Invalidate();
            }
        }


        void GetRoom()
        {
            Figure room = Figure.get_Cube(10);
            up_left = room.polygons[0].getPoint(0);
            up_right = room.polygons[0].getPoint(1);
            down_right = room.polygons[0].getPoint(2);
            down_left = room.polygons[0].getPoint(3);

            PointZ normal = Polygon.norm(room.polygons[0]);
            PointZ center = (up_left + up_right + down_left + down_right) / 4;
            cameraPoint = center + normal * 11;

            room.SetColor(Color.White);
            Figure wall1 = new Figure(room.polygons[0], room.points);
            Figure wall2 = new Figure(room.polygons[1], room.points);
            Figure wall3 = new Figure(room.polygons[2], room.points);
            Figure wall4 = new Figure(room.polygons[3], room.points);
            Figure wall5 = new Figure(room.polygons[4], room.points);
            Figure wall6 = new Figure(room.polygons[5], room.points);

            wall1.polygons[0].color = Color.White;//back
            wall2.polygons[0].color = Color.White;//face
            wall3.polygons[0].color = Color.Blue;//right
            wall4.polygons[0].color = Color.Red;//left
            wall5.polygons[0].color = Color.Green;//up
            wall6.polygons[0].color = Color.Pink;//down

            if(BackWall.Checked)
                wall1.fMaterial = new Material(1, 0f, 0.1f, 0.5f, 1.05f);
            else wall1.fMaterial = new Material(0f, 0f, 0.1f, 0.8f);
            if(FaceWall.Checked)
                wall2.fMaterial = new Material(1, 0f, 0.1f, 0.5f, 1.05f);
            else wall2.fMaterial = new Material(0f, 0f, 0.1f, 0.8f);
            if (RightWall.Checked)
                wall3.fMaterial = new Material(1, 0f, 0.1f, 0.5f, 1.05f);
            else wall3.fMaterial = new Material(0f, 0f, 0.1f, 0.8f);
            if (LeftWall.Checked)
                wall4.fMaterial = new Material(1, 0f, 0.1f, 0.5f, 1.05f);
            else wall4.fMaterial = new Material(0f, 0f, 0.1f, 0.8f);
            if (UpWall.Checked)
                wall5.fMaterial = new Material(1, 0f, 0.1f, 0.5f, 1.05f);
            else wall5.fMaterial = new Material(0f, 0f, 0.1f, 0.8f);
            if (DownWall.Checked)
                wall6.fMaterial = new Material(1, 0f, 0.1f, 0.5f, 1.05f);
            else wall6.fMaterial = new Material(0f, 0f, 0.1f, 0.8f);




            Figure c1 = Figure.get_Cube(3f);
            c1.Apply(Transform.Translate(-2, 0, -4));
            c1.Apply(Transform.RotateZ(60));
            c1.SetColor(Color.Yellow);
            if (cube_mirror.Checked)
                c1.fMaterial = new Material(1, 0f, 0.1f, 0.5f, 1.05f);
            else c1.fMaterial = new Material(0f, 0f, 0.1f, 1f, 1f);

            Figure c2 = Figure.get_Cube(1.5f);
            c2.Apply(Transform.Translate(2, 2, -4.3));
            c2.Apply(Transform.RotateZ(-10));
            c2.SetColor(Color.Violet);
            if (cube_trans.Checked)
                c2.fMaterial = new Material(0f, 0.7f, 0.1f, 1f, 1f);
            else c2.fMaterial = new Material(0, 0f, 0.1f, 1f, 1f);

            Sphere s1 = new Sphere(new PointZ(-2.5f, -2, 2.5f), 2.5f);
            s1.SetColor(Color.Green);
            if (shere_mirror.Checked)
                s1.fMaterial = new Material(0.9f, 0f, 0.1f, 0.7f, 1f);
            else s1.fMaterial = new Material(0.0f, 0f, 0.1f, 0.7f, 1f);

            Sphere s2 = new Sphere(new PointZ(2, 0, 0), 1);
            s2.SetColor(Color.HotPink);
            if (shere_trans.Checked)
                s2.fMaterial = new Material(0f, 0.7f, 0.1f, 1f, 1f);
            else s2.fMaterial = new Material(0.0f, 0f, 0.1f, 0.7f, 1f);

            Figure c3 = Figure.get_StretchCube(2, 4, 2);
            c3.Apply(Transform.Translate(-1, 3, -4.9));
            c3.SetColor(Color.Lavender);
            c3.fMaterial = new Material(0, 0f, 0.1f, 1f, 1f);

            Light l1 = new Light(new PointZ(0, 2, 4.9), new PointZ(1, 1, 1));
            //Light l2 = new Light(new PointZ(-4.9f, -4.9f, 4.9f), new PointZ(1f, 1f, 1f));
            lights.Add(l1);
            // lights.Add(l2);

            //scene.Add(room);
            scene.Add(wall1);
            scene.Add(wall2);
            scene.Add(wall3);
            scene.Add(wall4);
            scene.Add(wall5);
            scene.Add(wall6);
            scene.Add(c1);
            scene.Add(c2);
            scene.Add(c3);
            scene.Add(s1);
            scene.Add(s2);
        }

        void BackwardRayTracing()
        {
            pixel_map();
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    Ray r = new Ray(cameraPoint, pixels[i, j]);
                    r.start = new PointZ(pixels[i, j]);
                    PointZ color = RayTrace(r, 10, 1);
                    if (color.X > 1.0f || color.Y > 1.0f || color.Z > 1.0f)
                        color.Normalize();
                    pixels_color[i, j] = Color.FromArgb((int)(255 * color.X), (int)(255 * color.Y), (int)(255 * color.Z));
                }
            }
        }

        public void pixel_map()
        {
            pixels = new PointZ[width, height];
            pixels_color = new Color[width, height];
            PointZ step_up = (up_right - up_left) / (width - 1);
            PointZ step_down = (down_right - down_left) / (width - 1);
            PointZ up = new PointZ(up_left);
            PointZ down = new PointZ(down_left);
            for (int i = 0; i < width; ++i)
            {
                PointZ step_y = (up - down) / (height - 1);
                PointZ d = new PointZ(down);
                for (int j = 0; j < height; ++j)
                {
                    pixels[i, j] = d;
                    d += step_y;
                }
                up += step_up;
                down += step_down;
            }
        }

        public bool IsVisible(PointZ light_point, PointZ hit_point)
        {
            double max_t = (light_point - hit_point).length();
            Ray r = new Ray(hit_point, light_point);
            foreach (Figure fig in scene)
                if (fig.Intersection(r, out double t, out PointZ n))
                    if (t < max_t && t > Figure.eps)
                        return false;
            return true;
        }


        public PointZ RayTrace(Ray r, int iter, float env)
        {
            if (iter <= 0)
                return new PointZ(0, 0, 0);
            double rey_fig_intersect = 0;
            PointZ normal = null;
            Material material = new Material();
            PointZ res_color = new PointZ(0, 0, 0);
            bool refract_out_of_figure = false;

            foreach (Figure fig in scene)
            {
                if (fig.Intersection(r, out double intersect, out PointZ norm))
                    if (intersect < rey_fig_intersect || rey_fig_intersect == 0)
                    {
                        rey_fig_intersect = intersect;
                        normal = norm;
                        material = new Material(fig.fMaterial);
                    }
            }

            if (rey_fig_intersect == 0)
                return new PointZ(0, 0, 0);

            if (PointZ.DotProduct(r.direction, normal) > 0)
            {
                normal *= -1;
                refract_out_of_figure = true;
            }

            PointZ hit_point = r.start + r.direction * rey_fig_intersect;

            foreach (Light light in lights)
            {
                PointZ ambient_coef = light.color * material.ambient;
                ambient_coef.X = (ambient_coef.X * material.color.X);
                ambient_coef.Y = (ambient_coef.Y * material.color.Y);
                ambient_coef.Z = (ambient_coef.Z * material.color.Z);
                res_color += ambient_coef;
                if (IsVisible(light.position, hit_point))
                    res_color += light.Shade(hit_point, normal, material.color, material.diffuse);
            }

            if (material.reflection > 0)
            {
                Ray reflected_ray = r.Reflect(hit_point, normal);
                res_color += material.reflection * RayTrace(reflected_ray, iter - 1, env);
            }

            if (material.refraction > 0)
            {
                float refract_coef;
                if (refract_out_of_figure)
                    refract_coef = material.environment;
                else
                    refract_coef = 1 / material.environment;

                Ray refracted_ray = r.Refract(hit_point, normal, material.refraction, refract_coef);

                if (refracted_ray != null)
                    res_color += material.refraction * RayTrace(refracted_ray, iter - 1, material.environment);
            }
            return res_color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scene = new List<Figure>();
            lights = new List<Light>();
            pictureBox1.Image = new Bitmap(width, height);
            GetRoom();
            BackwardRayTracing();
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    (pictureBox1.Image as Bitmap).SetPixel(i, j, pixels_color[i, j]);
                }
                //pictureBox1.Image = bmp;
                pictureBox1.Invalidate();
            }
        }

    }
}