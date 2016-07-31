using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auxiliary.MathTools;
using Tao.OpenGl;
namespace GraphicsObjects.Scene_s_Objects
{
    public class Point3D: SceneObject
    {
        private Vector3D bPoint;
        private Vector3D bColor;
        private bool isVisible=true;
        public bool Visible
        {
            get
            {
                return isVisible;
            }
            set
            {
                isVisible = value;
            }
        }
        public float X
        {
            get
            {
                return bPoint.X;
            }
            set
            {
                bPoint.X = value;
            }
        }
        public float Y
        {
            get
            {
                return bPoint.Y;
            }
            set
            {
                bPoint.Y = value;
            }
        }
        public float Z
        {
            get
            {
                return bPoint.Z;
            }
            set
            {
                bPoint.Z = value;
            }
        }
        public Point3D()
        {
            bColor = Vector3D.Zero;
            bPoint = Vector3D.Zero;
        }
        public Point3D(Vector3D point)
        {
            bColor = Vector3D.Zero;
            bPoint = new Vector3D(point);
        }

        public Point3D(Vector3D point, Vector3D color)
        {
            bColor = new Vector3D(color);
            bPoint = new Vector3D(point);
        }
        public override void Draw()
        {
            Gl.glColor3f(bColor.X, bColor.Y, bColor.Z);
            Gl.glPushMatrix();
            Gl.glTranslatef(this.X,this.Y,this.Z);
            Glu.GLUquadric sphere = Glu.gluNewQuadric();

            Glu.gluSphere(sphere, 0.1f, 80, 80);
            Gl.glPopMatrix();
        }
        public override void MoveTo(Vector3D NewCenter)
        {
            bPoint = new Vector3D(NewCenter);
        }
        //public abstract void Rotate();

        public override void Hide()
        {
            isVisible = false;
        }

        public override void SetColor(Vector3D color)
        {
            bColor = new Vector3D(color);
        }

        public override void Show()
        {
            isVisible = true;
        }
    }
}
