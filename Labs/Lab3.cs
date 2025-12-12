using System;
using static Labs.LabFunc;

namespace Labs.Labs
{
    public class Lab3 : ILab
    {
        public void Run()
        {
            const double StartX = 0.1,
                EndX = 0.8;
            const int Steps = 10;
            const int NTermCount = 10;
            const double Epsilon = 0.0001;
            double step = (EndX - StartX) / Steps;

            Console.WriteLine("Вычисление функции");
            for (int i = 0; i <= Steps; i++)
            {
                double x = StartX + (i * step);
                double sn = CalculateSN(x, NTermCount);
                double se = CalculateSE(x, Epsilon);
                double y = CalculateY(x);

                Console.WriteLine($"X = {x:F4} SN = {sn:F6} SE = {se:F6} Y = {y:F6}");
            }
        }
    }
}
