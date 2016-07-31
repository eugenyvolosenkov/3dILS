using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auxiliary.MathTools;
using GraphicsObjects.Scene_s_Objects;
using Tao.OpenGl;
namespace ModelEditor.Bezier_Spline
{
    class BeizerSurface:SceneObject
    {
        private Vector3D[][] Anchors;
        private Vector3D[][] SurfacePoligons;
        private Vector3D bcolor;
        public Vector3D this[int indexU,int indexV]
        {
            get
            {
                return Anchors[indexU][indexV];
            }
            set
            {
                Anchors[indexU][indexV] = new Vector3D(value);
            }
        }
        private int numSplitsU, numSplitsV;
        private int degU, degV;
        public BeizerSurface(int degreeU, int degreeV, int splitsU, int splitsV, Vector3D[,] Mass)
        {
            degU = degreeU;
            degV = degreeV;
            numSplitsU = splitsU;
            numSplitsV = splitsV;
            Anchors = new Vector3D[degU+1][];
            for (int i = 0; i <=degU; i++)
                Anchors[i] = new Vector3D[degV + 1];
            for (int i = 0; i <= degU; i++)
            {
                for (int j = 0; j <= degV; j++)
                    Anchors[i][j] = Mass[i,j];
            }
            SurfacePoligons = new Vector3D[numSplitsU + 1][];
            for (int i = 0; i < numSplitsU + 1; i++)
                SurfacePoligons[i] = new Vector3D[(numSplitsV + 1)];
            
            bcolor = Vector3D.Zero;
            genSurface();
        }
        private void genSurface()
        {
            Vector3D[] newLinePoligs = new Vector3D[numSplitsV + 1];
            Vector3D[] anchorLinePoligs = new Vector3D[degU+1];
            for(int i =0;i<= degU; i++)
            {
                anchorLinePoligs[i] = Anchors[i][degV - 1];
            }
            Berstein berU = new Berstein(degU);
            Berstein berV = new Berstein(degV);
            for (int V=0; V<=numSplitsV; V++)
            {
                float percentV = (float)V / (float)numSplitsV;
                
                SurfacePoligons[0][V]= berV.genPoint(percentV, anchorLinePoligs);
            }
            
            for( int u=1; u<= numSplitsV; u++)
            {
                float percentU = (float)u / (float)numSplitsV;
                float percentUOld=( (float)u -1.0f)/ (float)numSplitsV;
                for (int i = 0; i < degU; i++)
                {
                    anchorLinePoligs[i] = berU.genPoint(percentU, Anchors[i]);
                }
                for(int v=0; v<=numSplitsV;v++)
                {
                    float percentV = (float)v / (float)numSplitsV;
                    SurfacePoligons[u][v] = berV.genPoint(percentV, anchorLinePoligs);
                }
            }
        }
        public override void Draw()
        {
            Gl.glColor3f(bcolor.X,bcolor.Y,bcolor.Z);
            Gl.glBegin(Gl.GL_TRIANGLE_STRIP);
            for(int i =1; i< numSplitsU+1; i++)
                for(int j=0;j<(numSplitsV+1);j++)
                {
                    Gl.glVertex3f(SurfacePoligons[i-1][j].X, SurfacePoligons[i-1][j].Y, SurfacePoligons[i-1][j].Z);
                    Gl.glVertex3f(SurfacePoligons[i][j].X, SurfacePoligons[i][j].Y, SurfacePoligons[i][j].Z);
                }
            Gl.glEnd();
        }

        public override void Hide()
        {
            throw new NotImplementedException();
        }

        public override void MoveTo(Vector3D NewCenter)
        {
            throw new NotImplementedException();
        }

        public override void Show()
        {
            throw new NotImplementedException();
        }

        public override void SetColor(Vector3D color)
        {
            bcolor = new Vector3D(color);
        }
    }
}
