using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auxiliary.MathTools;
//using Tao.FreeGlut;
using Tao.OpenGl;
namespace GraphicsObjects.Scene_s_Objects
{
    class Sphere :SceneObject
    {
        private Vector3D center;
        private Vector3D orient = Vector3D.Zero;
        private float size;
        private Vector3D color = Vector3D.Zero;
        private bool isVisible;
        
        public Sphere(Vector3D Center, Vector3D Sizes)
        {
            center = new Vector3D(Center);
            size = Sizes.X;
            isVisible = true;
        }
        public override void Show()
        {
            isVisible = true;
        }
        public override void Hide()
        {
            isVisible = false;
        }
        public override void SetColor(Vector3D color)
        {
            this.color = new Vector3D(color);
        }
        public override void MoveTo(Vector3D NewCenter)
        {
            center = new Vector3D(NewCenter);
        }
        public override void Draw()
        {
            if (!isVisible) return;
             Gl.glPushMatrix();
             Gl.glTranslatef(center.X, center.Y, center.Z);
             Gl.glColor3f(color.X, color.Y, color.Z);
            Glu.GLUquadric sphere = Glu.gluNewQuadric();

            Glu.gluSphere(sphere, size, 80, 80);

            Glu.gluDeleteQuadric(sphere);
            Gl.glPopMatrix();
        }
    }
}
