using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Complex
    {
        public double RealPart { get; private set; }
        public double ImaginaryPart { get; private set; }
        public string StringView { get; private set; }

        public Complex(double realPart, double imaginaryPart)
        {
            this.RealPart = realPart;
            this.ImaginaryPart = imaginaryPart;
            char sign = imaginaryPart >= 0 ? '+' : '-';
            this.StringView = $"{realPart} {sign} {imaginaryPart}i";
        }

        public Complex Plus(Complex complex)
        {
            return new Complex(this.RealPart + complex.RealPart,
                                this.ImaginaryPart + complex.ImaginaryPart);            
        }

        public Complex Minus(Complex complex)
        {
            return new Complex(this.RealPart - complex.RealPart,
                                this.ImaginaryPart - complex.ImaginaryPart);
        }
    }
}
