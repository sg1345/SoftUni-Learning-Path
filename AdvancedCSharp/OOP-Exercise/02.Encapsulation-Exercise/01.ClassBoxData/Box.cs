using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double _length;
        private double _width;
        private double _height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length 
        { 
            get => _length;
            private set 
            {
                if (ValueIsNegativeOrZero(value))
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }

                _length = value;
            }
        }

        public double Width 
        { 
            get => _width; 
            private set 
            {
                if (ValueIsNegativeOrZero(value))
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }

                _width = value;
            } 
        }
        public double Height 
        { 
            get => _height;
            private set
            {
                if (ValueIsNegativeOrZero(value))
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                }

                _height = value;
            }
        }

        private bool ValueIsNegativeOrZero(double value)
        {
            return value <= 0;
           
        }

        public double SurfaceArea()
        {
            return 2*this.Length*this.Width + 2*this.Length*this.Height + 2*this.Width*this.Height;
        }

        public double LateralSurfaceArea()
        {
            return 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
}
