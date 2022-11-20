using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Trainers.FastTree;

namespace Hackathon
{
    public partial class MLModel1
    {
        /// <summary>
        /// Тренировка модели.
        /// </summary>
        public static ITransformer RetrainPipeline(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// Настройка конфигурации модели.
        /// </summary>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            var pipeline = mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"type", @"type"),new InputOutputColumnPair(@"class", @"class"),new InputOutputColumnPair(@"mailctg", @"mailctg"),new InputOutputColumnPair(@"transport_pay", @"transport_pay"),new InputOutputColumnPair(@"weight_mfi", @"weight_mfi"),new InputOutputColumnPair(@"dist_qty_oper_login_1", @"dist_qty_oper_login_1"),new InputOutputColumnPair(@"total_qty_oper_login_1", @"total_qty_oper_login_1"),new InputOutputColumnPair(@"total_qty_oper_login_0", @"total_qty_oper_login_0"),new InputOutputColumnPair(@"total_qty_over_index_and_type", @"total_qty_over_index_and_type"),new InputOutputColumnPair(@"total_qty_over_index", @"total_qty_over_index"),new InputOutputColumnPair(@"is_wrong_phone_number", @"is_wrong_phone_number")})      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"type",@"class",@"mailctg",@"transport_pay",@"weight_mfi",@"dist_qty_oper_login_1",@"total_qty_oper_login_1",@"total_qty_oper_login_0",@"total_qty_over_index_and_type",@"total_qty_over_index",@"is_wrong_phone_number"}))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName:@"label",inputColumnName:@"label"))      
                                    .Append(mlContext.MulticlassClassification.Trainers.OneVersusAll(binaryEstimator:mlContext.BinaryClassification.Trainers.FastTree(new FastTreeBinaryTrainer.Options(){NumberOfLeaves=48,MinimumExampleCountPerLeaf=21,NumberOfTrees=5,MaximumBinCountPerFeature=147,FeatureFraction=0.810160893838757,LearningRate=0.999999776672986,LabelColumnName=@"label",FeatureColumnName=@"Features"}),labelColumnName: @"label"))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName:@"PredictedLabel",inputColumnName:@"PredictedLabel"));

            return pipeline;
        }
    }
}
