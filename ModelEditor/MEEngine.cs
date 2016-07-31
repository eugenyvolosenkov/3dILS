using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsObjects;
using GraphicsObjects.Scene_s_Objects;
using Auxiliary.MathTools;
using ModelEditor.Bezier_Spline;
namespace ModelEditor
{
    public class MEEngine
    {
        private Scene scene;
        public MEEngine(Scene _scene)
        {
            scene = _scene;
            Init();
        }
        private void Init()
        {
            Axes axe = new Axes(10.0f);
            
            Vector3D[,] AnchorPoints = new Vector3D[4, 4];
            AnchorPoints[0, 0] = new Vector3D(0.0f, -2.0f,  0.0f);
            AnchorPoints[0, 1] = new Vector3D( 0.0f,-2.0f, 4.0f);
            AnchorPoints[0, 2] = new Vector3D(0.0f,2.0f,  4.0f);
            AnchorPoints[0, 3] = new Vector3D(0.0f,2.0f,  0.0f);
            for (int i = 1; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    AnchorPoints[i, j] = AnchorPoints[i - 1, j] + new Vector3D(3.0f, 0.0f, 0.0f);
            BeizerSurface surf = new BeizerSurface(3, 3, 20, 20, AnchorPoints);
            scene.AddObject(axe);
            scene.AddObject(surf);
        }
    }
}
