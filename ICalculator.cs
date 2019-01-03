using System;

namespace AzureF.Function{
    internal interface ICalculator
    {
        float Add(float p1, float p2);

        float Produce(float p1, float p2);

        float Divide(float p1, float p2);
    }
}
