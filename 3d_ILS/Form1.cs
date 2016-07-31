using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform;
using GraphicsObjects;
using Auxiliary.Graphics;
namespace _3d_ILS
{
    public partial class Form1 : Form
    {
        private Scene scene;
        Keyboard UserKeyboard;
        Mouse UserMouse;
        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
            UserKeyboard = new Keyboard(0.05f);
            UserMouse = new Mouse(0.03f);
            scene = new Scene(new Auxiliary.MathTools.Vector3D(0.0f,0.0f,0.0f));
            scene.BindKeyboard(UserKeyboard);
            scene.BindMouse(UserMouse);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
//            Glut.glutInit();
//            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);
            Gl.glShadeModel(Gl.GL_SMOOTH);

            Gl.glEnable(Gl.GL_POINT_SMOOTH);

            Gl.glPointSize(5.0f);
            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluPerspective(45, (float)AnT.Width / (float)AnT.Height, 0.1, 200);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            RenderTimer.Start();
        }
        private void beginRender()
        {
            
         //   Gl.glClearColor(255, 255, 255, 1);
            Gl.glLoadIdentity();
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            //    Gl.glViewport(0, 0, AnT.Width, AnT.Height);
        }
        private void Camera()
        {
            
        }
        private void renderObject()
        {
        }
        private void endRender()
        {
      //      Gl.glFlush();
            AnT.Invalidate();
        }
        private void Render()
        {
            beginRender();
            scene.Render();
            renderObject();
            endRender();
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            Render();
        }

        private void AnT_KeyDown(object sender, KeyEventArgs e)
        {
            UserKeyboard.OnKeyDown(e);
        }

        private void AnT_KeyUp(object sender, KeyEventArgs e)
        {
            UserKeyboard.OnKeyUp(e);
        }

        private void AnT_MouseDown(object sender, MouseEventArgs e)
        {
            UserMouse.OnMouseDown(e);
        }

        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            UserMouse.OnMouseMove(e);
        }

        private void AnT_MouseUp(object sender, MouseEventArgs e)
        {
            UserMouse.OnMouseUp(e);
        }
    }
}
