using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation_polynomials_in_the_form_Lagrange
{
    internal class TInterpolation_polynomials_Lagrange
    {
        double[] Original_Vector_X()
        {
            double[] vector_X = { -3, 0, 1, 3 };
            return vector_X;
        }
        //-----------------------------------------------------------------------------------------
        double[] Function_X(double[] vector_X) 
        {
            double[] function_X = new double[vector_X.Length];
            for (int i = 0; i < function_X.Length; i++)
            {
                function_X[i] = Math.Atan(vector_X[i]) + vector_X[i];
            }
            return function_X;
        }
        //-----------------------------------------------------------------------------------------
        double Function_X(double X)
        {
            double function_X = Math.Atan(X) + X;
            return function_X;
        }
        //-----------------------------------------------------------------------------------------
        double[] Function_W(double X, double[] vector_X) 
        {
            double[] function_W = new double[vector_X.Length];
            function_W[0] = (X - vector_X[1]) * (X - vector_X[2]) * (X - vector_X[3]);
            function_W[1] = (X - vector_X[0]) * (X - vector_X[2]) * (X - vector_X[3]);
            function_W[2] = (X - vector_X[0]) * (X - vector_X[1]) * (X - vector_X[3]);
            function_W[3] = (X - vector_X[0]) * (X - vector_X[1]) * (X - vector_X[2]);
            return function_W;
        }
        //-----------------------------------------------------------------------------------------
        double Function_W_for_X(double X, double[] vector_X)
        {
            double function_W = (X - vector_X[0]) * (X - vector_X[1]) * (X - vector_X[2]) * (X - vector_X[3]);
            return function_W;
        }
        //-----------------------------------------------------------------------------------------
        double[] Function_WWW(double[] vector_X) 
        {
            double[] function_WWW = new double[vector_X.Length];
            function_WWW[0] = (vector_X[0] - vector_X[1]) * (vector_X[0] - vector_X[2]) * (vector_X[0] - vector_X[3]);
            function_WWW[1] = (vector_X[1] - vector_X[0]) * (vector_X[1] - vector_X[2]) * (vector_X[1] - vector_X[3]);
            function_WWW[2] = (vector_X[2] - vector_X[1]) * (vector_X[2] - vector_X[0]) * (vector_X[2] - vector_X[3]);
            function_WWW[3] = (vector_X[3] - vector_X[1]) * (vector_X[3] - vector_X[2]) * (vector_X[3] - vector_X[0]);
            return function_WWW;
        }
        //-----------------------------------------------------------------------------------------
        double Function_L(double[] function_X, double[] function_W, double[] function_WWW)
        {
            double function_L = 0;
            for (int i = 0; i < function_X.Length; i++)
            {
                function_L += function_W[i] * function_X[i] / function_WWW[i];
            }
            return function_L;
        }
        //-----------------------------------------------------------------------------------------
        void Error_rate(double X, double function_L, double[] vector_X)
        {
            var function_X = Function_X(X);
            var absolute_error = Math.Abs(function_L - function_X);
            var priori_error = (4.669 / 24) * Math.Abs(Function_W_for_X(X, vector_X));
            Console.WriteLine("absolute error = " + absolute_error);
            Console.WriteLine("priori error = " + priori_error);
        }
        //-----------------------------------------------------------------------------------------
        void Method_Lagrange()
        {
            //Console.WriteLine("X* = ");
            //var X = double.Parse(Console.ReadLine());
            var X = -0.5;
            var vector_X = Original_Vector_X();
            var function_X = Function_X(vector_X);
            var function_W = Function_W(X, vector_X);
            var function_WWW = Function_WWW(vector_X);
            double function_L = Function_L(function_X, function_W, function_WWW);
            Error_rate(X, function_L, vector_X);
        }
        //-----------------------------------------------------------------------------------------
        public void Start()
        {
            Method_Lagrange();
        }
    }
}
