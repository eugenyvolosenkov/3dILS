using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auxiliary.MathTools;
using Auxiliary.Graphics;
using Tao.OpenGl;
using GraphicsObjects.Scene_s_Objects;
namespace GraphicsObjects
{
    public class Scene
    {
        private Vector3D SceneCenter;
        private List<SceneObject> ListObjects;
        private bool isVisible;
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
        private Camera MCamera;
        Keyboard keyboard;
        Mouse mouse;

        public Scene(Vector3D center)
        {
            SceneCenter = center;
            MCamera = new Camera();
            Visible = true;
            MCamera.Position = new Vector3D(29.0f, 11.0f, 11.0f);
            
            MCamera.Orientation = new Vector3D(0.0f, 0.36f, -0.38f);
            
            ListObjects = new List<SceneObject>();
            
        }
        public Scene():this(Vector3D.Zero)
        {
            
        }
        public void  Render()
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(SceneCenter.X, SceneCenter.Y, SceneCenter.Z);
            if (!isVisible) return;
            keyboard.Apply(MCamera);
            mouse.Apply(MCamera);
            MCamera.Setup();
            foreach (var elem in ListObjects)
                elem.Draw();
            Gl.glPopMatrix();
        }
        public void BindKeyboard(Keyboard key)
        {
            keyboard = key;
        }
        public void unBindKeyboard()
        {
            keyboard = null;
        }
        public void BindMouse(Mouse mous)
        {
            mouse = mous;
        }
        public void unBindMouse()
        {
            mouse = null;
        }
        
        public void AddObject(SceneObject obj)
        {
            ListObjects.Add(obj);
        }
    }   
}
