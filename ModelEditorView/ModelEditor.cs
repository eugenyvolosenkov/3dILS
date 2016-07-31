using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphicsObjects;
using Tao.OpenGl;
using Auxiliary.Graphics;
using ModelEditor;
namespace ModelEditorView
{
    public partial class ModelEditor : Form
    {
        private Scene scene;
        Keyboard UserKeyboard;
        Mouse UserMouse;
        public ModelEditor()
        {
            InitializeComponent();
            AnT.InitializeContexts();
            scene = new Scene();
            UserKeyboard = new Keyboard(0.05f);
            UserMouse = new Mouse(0.03f);
            scene = new Scene();
            scene.BindKeyboard(UserKeyboard);
            scene.BindMouse(UserMouse);
            MEEngine eng = new MEEngine(scene);
        }

        private void RenderTimer1_Tick(object sender, EventArgs e)
        {
            Render();
        }
        private void beginRender()
        {

               Gl.glClearColor(255, 255, 255, 1);
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
        private void ModelEditor_Load(object sender, EventArgs e)
        {
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
    }
}
