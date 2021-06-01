using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Complex
    {
        public float Real { get; set; }
        public float Imag { get; set; }
        public Complex(float real, float imag)
        {
            Real = real;
            Imag = imag;
        }
         public static Complex operator+(Complex complex1, Complex complex2)
        {
            return new Complex(complex1.Real + complex2.Real, complex1.Imag + complex2.Imag);
        }
        public static Complex operator-(Complex complex1, Complex complex2)
        {
            return new Complex(complex1.Real - complex2.Real, complex1.Imag - complex2.Imag);
        }
        public static Complex operator*(Complex complex1, Complex complex2)
        {
            return new Complex(complex1.Real * complex2.Real - complex1.Imag * complex2.Imag, complex1.Imag * complex2.Real + complex1.Real * complex2.Imag);
        }
        public static Complex operator/(Complex complex1, Complex complex2)
        {
            float sum1, sum2;
            sum1 = (float)(complex1.Real * complex2.Real + complex1.Imag * complex2.Imag) / (complex2.Real * complex2.Real + complex2.Imag * complex2.Imag);
            sum2 = (float)(complex1.Imag * complex2.Real - complex1.Real * complex2.Imag) / (complex2.Real * complex2.Real + complex2.Imag * complex2.Imag);

            return new Complex(sum1,sum2);
        }
        public static Complex operator*(int num, Complex complex)
        {
            return new Complex(num * complex.Real, num * complex.Imag);
        }
        public static Complex operator *(Complex complex, int num)
        {
            return new Complex(num * complex.Real, num * complex.Imag);
        }
        public static Complex operator-(Complex complex, int num)
        {
            return new Complex(complex.Real - num, complex.Imag);
        }
        public static Complex operator-(int num, Complex complex)
        {
            return new Complex(num - complex.Real, complex.Imag);
        }
        public override string ToString()
        {
            return $"{Real}{(Imag>=0?'+':'-')}{Imag}j";
        }
    }
}
