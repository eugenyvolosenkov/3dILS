using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auxiliary.MathTools;
//using Accessibility;
namespace GraphicsObjects.Scene_s_Objects
{
    public abstract class SceneObject
    {
        public abstract void Draw();
        public abstract void MoveTo(Vector3D NewCenter);
        //public abstract void Rotate();
        public abstract void Hide();
        public abstract void Show();
        public abstract void SetColor(Vector3D color);
    }
}
