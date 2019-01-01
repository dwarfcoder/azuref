using System;

namespace AzureF.Function
{
    internal class Calculator : ICalculator
    {
        public float Add(float p1, float p2)
        {
            return p1 + p2;
        }
    }
}