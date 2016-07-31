using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auxiliary.MathTools;
using Tao.OpenGl;
namespace GraphicsObjects.Scene_s_Objects
{
    public class Box:SceneObject
    {
        private Vector3D _center;
        private Vector3D _sizes;
        private bool isVisible;
        private Vector3D[] points;
        private Vector3D Color;
        public Box(Vector3D center, Vector3D size)
        {
            _center = center;
            _sizes = size;
            points = new Vector3D[10];
            Color = new Vector3D(1.0f,0.0f,0.0f);
            CalculatePoints();
            isVisible = true;
        }
        public override void Hide()
        {
            isVisible = false;
        }
        public override void Show()
        {
            isVisible = true;
        }
        public override void Draw()
        {
            if (!isVisible) return;
            Gl.glPushMatrix();
            Gl.glTranslatef(_center[0],_center[1],_center[2]);
            Gl.glColor3f(Color[0],Color[1],Color[2]);
            Gl.glBegin(Gl.GL_QUAD_STRIP);
            for (int i = 0; i < 10; i++)
                Gl.glVertex3f(points[i][0], points[i][1], points[i][2]);
                
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUAD_STRIP);
            Gl.glVertex3f(points[0][0], points[0][1], points[0][2]);
            Gl.glVertex3f(points[6][0], points[6][1], points[6][2]);
            Gl.glVertex3f(points[2][0], points[2][1], points[2][2]);
            Gl.glVertex3f(points[4][0], points[4][1], points[4][2]);

            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUAD_STRIP);
            Gl.glVertex3f(points[1][0], points[1][1], points[1][2]);
            Gl.glVertex3f(points[7][0], points[7][1], points[7][2]);
            Gl.glVertex3f(points[3][0], points[3][1], points[3][2]);
            Gl.glVertex3f(points[5][0], points[5][1], points[5][2]);

            Gl.glEnd();
            Gl.glPopMatrix();
        }
        public  void Resize(Vector3D newSize)
        {
            _sizes.X = newSize.X;
            _sizes.Y = newSize.Y;
            _sizes.Z = newSize.Z;
            CalculatePoints();
        }
        private void CalculatePoints()
        {
            points[0]= new Vector3D(-_sizes[0],-_sizes[1],-_sizes[2]);
            points[1] = new Vector3D(-_sizes[0], -_sizes[1], _sizes[2]);
            points[2] = new Vector3D(_sizes[0], -_sizes[1], -_sizes[2]);
            points[3] = new Vector3D(_sizes[0], -_sizes[1], _sizes[2]);
            points[4] = new Vector3D(_sizes[0], _sizes[1], -_sizes[2]);
            points[5] = new Vector3D(_sizes[0], _sizes[1], _sizes[2]);
            points[6] = new Vector3D(-_sizes[0], _sizes[1], -_sizes[2]);
            points[7] = new Vector3D(-_sizes[0], _sizes[1], _sizes[2]);
            points[8] = new Vector3D(points[0]);
            points[9] = new Vector3D(points[1]);
        }
        public override void MoveTo(Vector3D NewCenter)
        {
            _center.X = NewCenter.X;
            _center.Y = NewCenter.Y;
            _center.Z = NewCenter.Z;
        }
        public override void SetColor(Vector3D color)
        {
            Color[0] = color[0];
            Color[1] = color[1];
            Color[2] = color[2];
        }
        
    }
}
