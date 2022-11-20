using Microsoft.ML.Data;
using System.IO;
using System.Collections.Generic;

namespace Hackathon
{
    /// <summary>
    /// Класс выходных данных.
    /// </summary>
    public class Output
    {
        [ColumnName(@"id")]
        public float Id { get; set; }

        [ColumnName(@"oper_type_attr")]
        public float Oper_type_attr { get; set; }

        [ColumnName(@"index_oper")]
        public float Index_oper { get; set; }

        [ColumnName(@"type")]
        public float Type { get; set; }

        [ColumnName(@"priority")]
        public float Priority { get; set; }

        [ColumnName(@"is_privatecategory")]
        public float Is_privatecategory { get; set; }

        [ColumnName(@"class")]
        public float Class { get; set; }

        [ColumnName(@"is_in_yandex")]
        public float Is_in_yandex { get; set; }

        [ColumnName(@"is_return")]
        public float Is_return { get; set; }

        [ColumnName(@"weight")]
        public float Weight { get; set; }

        [ColumnName(@"mailtype")]
        public float Mailtype { get; set; }

        [ColumnName(@"mailctg")]
        public float Mailctg { get; set; }

        [ColumnName(@"mailrank")]
        public float Mailrank { get; set; }

        [ColumnName(@"directctg")]
        public float Directctg { get; set; }

        [ColumnName(@"transport_pay")]
        public float Transport_pay { get; set; }

        [ColumnName(@"postmark")]
        public float Postmark { get; set; }

        [ColumnName(@"name_mfi")]
        public float Name_mfi { get; set; }

        [ColumnName(@"weight_mfi")]
        public float Weight_mfi { get; set; }

        [ColumnName(@"price_mfi")]
        public float Price_mfi { get; set; }

        [ColumnName(@"dist_qty_oper_login_1")]
        public float Dist_qty_oper_login_1 { get; set; }

        [ColumnName(@"total_qty_oper_login_1")]
        public float Total_qty_oper_login_1 { get; set; }

        [ColumnName(@"total_qty_oper_login_0")]
        public float Total_qty_oper_login_0 { get; set; }

        [ColumnName(@"total_qty_over_index_and_type")]
        public float Total_qty_over_index_and_type { get; set; }

        [ColumnName(@"total_qty_over_index")]
        public float Total_qty_over_index { get; set; }

        [ColumnName(@"is_wrong_sndr_name")]
        public float Is_wrong_sndr_name { get; set; }

        [ColumnName(@"is_wrong_rcpn_name")]
        public float Is_wrong_rcpn_name { get; set; }

        [ColumnName(@"is_wrong_phone_number")]
        public float Is_wrong_phone_number { get; set; }

        [ColumnName(@"is_wrong_address")]
        public float Is_wrong_address { get; set; }

        [ColumnName(@"label")]
        public uint Label { get; set; }

        [ColumnName(@"Features")]
        public float[] Features { get; set; }

        [ColumnName(@"PredictedLabel")]
        public float PredictedLabel { get; set; }

        [ColumnName(@"Score")]
        public float[] Score { get; set; }

        /// <summary>
        /// Сохранение результатов прогнозирования.
        /// </summary>
        public static void Save(List<Output> outputs, string path)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write)))
            {
                writer.Write($"id,label\n");

                for (int i = 0; i < outputs.Count; i++)
                {
                    writer.Write($"{outputs[i].Id},{outputs[i].PredictedLabel}\n");
                }
            }
        }
    }
}
