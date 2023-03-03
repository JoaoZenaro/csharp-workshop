using System;
using System.Globalization;

namespace Chapter3.Exerc3_02
{
    public record Car
    {
        public double distance { get; init; }
        public double journeyTime { get; init; }
    }

    public class Comparison
    {
        private readonly Func<Car, double> _valueSelector;

        public Comparison(Func<Car, double> valueSelector)
        {
            _valueSelector = valueSelector;
        }
    }
}