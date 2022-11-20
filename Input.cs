using Microsoft.ML.Data;
using System;
using System.IO;
using System.Collections.Generic;

namespace Hackathon
{
    /// <summary>
    /// Класс входных данных.
    /// </summary>
    public class Input
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
        public float Label { get; set; }


        /// <summary>
        /// Загрузка тестового набора данных.
        /// </summary>
        public static List<Input> Load(string path)
        {
            List<Data> input = new List<Data>();

            using (StreamReader reader = new StreamReader(path))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string[] columns = Data.NormalRow(reader.ReadLine()).Split(',');
                    string[] op = columns[1].Split('_');

                    input.Add(new Data
                    {
                        Id = Data.ColumToReal(columns[0]),
                        Oper_type_attr = Data.ColumToReal(op[0]) + Data.ColumToReal(op[1]),
                        Index_oper = Data.ColumToReal(columns[2]),
                        Type = Data.ColumType(columns[3]),
                        Priority = Data.ColumToReal(columns[4]),
                        Is_privatecategory = Data.ColumYR(columns[5]),
                        Class = Data.ColumToReal(columns[6]),
                        Is_in_yandex = Data.ColumYR(columns[7]),
                        Is_return = Data.ColumYR(columns[8]),
                        Weight = Data.ColumToReal(columns[9]),
                        Mailtype = Data.ColumToReal(columns[10]),
                        Mailctg = Data.ColumToReal(columns[11]),
                        Mailrank = Data.ColumToReal(columns[12]),
                        Directctg = Data.ColumToReal(columns[13]),
                        Transport_pay = Data.ColumToReal(columns[14]),
                        Postmark = Data.ColumToReal(columns[15]),
                        Name_mfi = Data.ColumNames(columns[16]),
                        Weight_mfi = Data.ColumToReal(columns[17]),
                        Price_mfi = Data.ColumToReal(columns[18]),
                        Dist_qty_oper_login_1 = Data.ColumToReal(columns[19]),
                        Total_qty_oper_login_1 = Data.ColumToReal(columns[20]),
                        Total_qty_oper_login_0 = Data.ColumToReal(columns[21]),
                        Total_qty_over_index_and_type = Data.ColumToReal(columns[22]),
                        Total_qty_over_index = Data.ColumToReal(columns[23]),
                        Is_wrong_sndr_name = columns[24] == "1" ? 1 : 0,
                        Is_wrong_rcpn_name = columns[25] == "1" ? 1 : 0,
                        Is_wrong_phone_number = columns[26] == "1" ? 1 : 0,
                        Is_wrong_address = columns[27] == "1" ? 1 : 0
                    });
                }
            }

            List<Input> data = new List<Input>();

            for (int i = 0; i < input.Count; i++)
            {
                data.Add(new Input()
                {
                    Id = (float)input[i].Id,
                    Oper_type_attr = (float)input[i].Oper_type_attr,
                    Index_oper = (float)input[i].Index_oper,
                    Type = (float)input[i].Type,
                    Priority = (float)input[i].Priority,
                    Is_privatecategory = (float)input[i].Is_privatecategory,
                    Class = (float)input[i].Class,
                    Is_in_yandex = (float)input[i].Is_in_yandex,
                    Is_return = (float)input[i].Is_return,
                    Weight = (float)input[i].Weight,
                    Mailtype = (float)input[i].Mailtype,
                    Mailctg = (float)input[i].Mailctg,
                    Mailrank = (float)input[i].Mailrank,
                    Directctg = (float)input[i].Directctg,
                    Postmark = (float)input[i].Postmark,
                    Name_mfi = (float)input[i].Name_mfi,
                    Weight_mfi = (float)input[i].Weight_mfi,
                    Price_mfi = (float)input[i].Price_mfi,
                    Dist_qty_oper_login_1 = (float)input[i].Dist_qty_oper_login_1,
                    Total_qty_oper_login_1 = (float)input[i].Total_qty_oper_login_1,
                    Total_qty_oper_login_0 = (float)input[i].Total_qty_oper_login_0,
                    Total_qty_over_index_and_type = (float)input[i].Total_qty_over_index_and_type,
                    Total_qty_over_index = (float)input[i].Total_qty_over_index,
                    Is_wrong_sndr_name = (float)input[i].Is_wrong_sndr_name,
                    Is_wrong_rcpn_name = (float)input[i].Is_wrong_rcpn_name,
                    Is_wrong_phone_number = (float)input[i].Is_wrong_phone_number,
                    Is_wrong_address = (float)input[i].Is_wrong_address,
                });
            }

            return data;
        }
    }
}
