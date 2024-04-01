using System;

namespace test {
    public static class Regression {
        public static double PolyFunction(List<double> coefficents, double argument) {
            double value = 0;
            for(int i = 0; i < coefficents.Count; i++) {
                value += coefficents[i] * Math.Pow(argument, i);               
            }
            return value;
        }

        public static List<double> PolyRegression(List<double> time, List<double> values, int n) {
            double lr = 0.01d;
            List<double> coefficents = new List<double>();
            for (int i = 0; i < n; i++) {
                coefficents.Add(1);
            }
            for (int i = 0; i<1000; i++) {
                List<double> grad = Gradient(time, values, coefficents, n);
                for (int j = 0; j < n; j++) {
                    coefficents[j] -= lr * grad[j];
                }
            }
            return coefficents;
        }

        private static List<double> Gradient(List<double> time, List<double> values, List<double> coefficents, int n) {
            List<double> grad = new List<double>();
            for (int i = 0; i < n; i++) {
                grad.Add(0);
            }
            for (int j = 0; j<time.Count; j++) {
                for(int i = 0; i<n; i++) {
                    grad[i] += -Math.Pow(time[j], i) * (values[j] - PolyFunction(coefficents, time[j]));
                }
            }
            return grad;
        }
    }
}