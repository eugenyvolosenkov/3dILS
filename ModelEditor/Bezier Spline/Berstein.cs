using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auxiliary.MathTools;
namespace ModelEditor.Bezier_Spline
{
    class Berstein
    {
        private int DEG;
        public Berstein( int degree)
        {
            DEG = degree;
        }
        private float genPolin(int N, int K)
        {
            
            int min = Math.Min(K, N-K);
            int max = Math.Max(K, N - K);
            if (N == max) return 1.0f;
            float result = 1.0f;
            for(int i=1; i <= min; i++)
            {
                result *= (float)(i + max) / (float)i;
            }
            return result;
        }
        public Vector3D genPoint(float t, Vector3D[] Points)
        {
            float[] degsT = new float[DEG + 1];
            float[] undegsT = new float[DEG+1];
            degsT[0] =undegsT[0]= 1.0f;
            for( int i =1;i<DEG+1;i++)
            {
                degsT[i] = degsT[i - 1] * t;
                undegsT[i] = undegsT[i - 1] *(1- t);
            }
            Vector3D result = Vector3D.Zero;
            for(int i =0; i< DEG+1;i++)
            {
                result += (genPolin (DEG, DEG-i)* degsT[DEG-i]*undegsT[i] * Points[i]);
            }
            return result;
        }
    }
}
