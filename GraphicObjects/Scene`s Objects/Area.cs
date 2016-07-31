using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Auxiliary.MathTools;
namespace GraphicsObjects.Scene_s_Objects
{
    public class Area:SceneObject
    {
        private Vector3D center;
        private Vector3D orient = Vector3D.Zero;
        private Vector2D sizes;
        private Vector3D[] points;
        private bool isVisible;
        private Vector3D color = Vector3D.Zero;
        public Area(Vector3D Center, Vector3D Sizes)
        {
            center = new Vector3D(Center);
           // orient = new Vector3D(Orient);
            sizes = new Vector2D(Sizes.XY);
            points = new Vector3D[4];
            isVisible = true;
            CalculatePoints();
        }
        private void CalculatePoints()
        {
            points[0] = new Vector3D(-sizes[0]/2, -sizes[1]/2, 0.0f);
            points[1] = new Vector3D(-sizes[0]/2, sizes[1]/2, 0.0f);
            points[2] = new Vector3D(sizes[0]/2, -sizes[1]/2, 0.0f);
            points[3] = new Vector3D(sizes[0]/2, sizes[1]/2, 0.0f);
        }
        public override void Show()
        {
            isVisible = true;
        }
        public override void Hide()
        {
            isVisible = false;
        }
        public override void Draw()
        {
            if (!isVisible) return;
            Gl.glPushMatrix();
            Gl.glTranslatef(center.X, center.Y, center.Z);
            Gl.glColor3f(color.X, color.Y, color.Z);
            Gl.glBegin(Gl.GL_QUAD_STRIP);
            for (int i = 0; i < 4; i++)
                Gl.glVertex3f(points[i][0], points[i][1], points[i][2]);
            Gl.glEnd();
            Gl.glPopMatrix();
        }
        public override void SetColor(Vector3D color)
        {
            this.color = new Vector3D(color);
        }
        public override void MoveTo(Vector3D NewCenter)
        {
            center = new Vector3D(NewCenter);
        }
    }
}
