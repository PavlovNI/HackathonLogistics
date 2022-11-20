using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.IO;

namespace Hackathon
{
    public partial class MLModel1
    {
        private static string ModelPath = Path.GetFullPath("MLModel1.zip");

        public static readonly Lazy<PredictionEngine<Input, Output>> PredictEngine = new Lazy<PredictionEngine<Input, Output>>(() => CreatePredictEngine(), true);

        /// <summary>
        /// Метод прогнозирования.
        /// </summary>
        public static Output Predict(Input input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

        /// <summary>
        /// Загрузка обученной модели.
        /// </summary>
        private static PredictionEngine<Input, Output> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(ModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<Input, Output>(mlModel);
        }
    }
}
