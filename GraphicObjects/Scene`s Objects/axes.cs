using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auxiliary.MathTools;
using Tao.OpenGl;
namespace GraphicsObjects.Scene_s_Objects
{
    public class Axes:SceneObject
    {
        private Vector3D center = Vector3D.Zero;
        private float size;
        private bool isVisible = true;
        private Vector3D[] axes = new Vector3D[3]
        {
            Vector3D.I, Vector3D.J, Vector3D.K
        };
        
        public Axes(float Size)
        {
            size = Size;
            CalculateVectors();
        }
        private void CalculateVectors()
        {
            for (int i = 0; i < 3; i++)
                axes[i] *= size;
        }
        public override void Show()
        {
            isVisible = true;
        }
        public override void Hide()
        {
            isVisible = false;
        }
        public override void MoveTo(Vector3D NewCenter)
        {
            throw new NotImplementedException();
        }
        public override void SetColor(Vector3D color)
        {
            throw new NotImplementedException();
        }
        public override void Draw()
        {
            if (!isVisible) return;
            Gl.glPushMatrix();
            Gl.glTranslatef(center.X, center.Y, center.Z);
            Gl.glLineWidth(4.0f);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex3f(center.X,center.Y,center.Z);
            Gl.glVertex3f(axes[0].X, axes[0].Y, axes[0].Z);
            Gl.glEnd();
            Gl.glColor3f(0.0f, 1.0f, 0.0f);
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex3f(center.X, center.Y, center.Z);
            Gl.glVertex3f(axes[1].X, axes[1].Y, axes[1].Z);
            Gl.glEnd();
            Gl.glColor3f(0.0f, 0.0f, 1.0f);
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex3f(center.X, center.Y, center.Z);
            Gl.glVertex3f(axes[2].X, axes[2].Y, axes[2].Z);
            Gl.glEnd();
            Gl.glPopMatrix();
        }
    }
}
