using System;

namespace AzureF.Function
{
    internal class Calculator : ICalculator
    {
        public float Add(float p1, float p2) => p1 + p2;

        public float Produce(float p1, float p2) => p1 * p2;
    }
}