using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitsRecognizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var distance = new ManhattenDistance();
            var classifier = new BasicClassifier(distance);

            var trainingPath = @"C:\Users\Patterson\Documents\Machine Learning\trainingsample.csv";
            var training = DataReader.ReadObservations(trainingPath);

            classifier.Train(training);

            var validationPath = @"C:\Users\Patterson\Documents\Machine Learning\validationsample.csv";
            var validation = DataReader.ReadObservations(validationPath);

            var correct = Evaluator.Correct(validation, classifier);

            Console.WriteLine("Correctly classified: {0:P2}", correct);

            Console.ReadLine();
        }
    }
}
