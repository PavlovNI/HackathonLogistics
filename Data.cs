using System;
using System.IO;
using System.Collections.Generic;

namespace Hackathon
{
    /// <summary>
    /// Класс данных.
    /// </summary>
    public class Data
    {
        public double Id { get; set; }
        public double Oper_type_attr { get; set; }
        public double Index_oper { get; set; }
        public double Type { get; set; }
        public double Priority { get; set; }
        public double Is_privatecategory { get; set; }
        public double Class { get; set; }
        public double Is_in_yandex { get; set; }
        public double Is_return { get; set; }
        public double Weight { get; set; }
        public double Mailtype { get; set; }
        public double Mailctg { get; set; }
        public double Mailrank { get; set; }
        public double Directctg { get; set; }
        public double Transport_pay { get; set; }
        public double Postmark { get; set; }
        public double Name_mfi { get; set; }
        public double Weight_mfi { get; set; }
        public double Price_mfi { get; set; }
        public double Dist_qty_oper_login_1 { get; set; }
        public double Total_qty_oper_login_1 { get; set; }
        public double Total_qty_oper_login_0 { get; set; }
        public double Total_qty_over_index_and_type { get; set; }
        public double Total_qty_over_index { get; set; }
        public double Is_wrong_sndr_name { get; set; }
        public double Is_wrong_rcpn_name { get; set; }
        public double Is_wrong_phone_number { get; set; }
        public double Is_wrong_address { get; set; }
        public double Label { get; set; }

        /// <summary>
        /// Загрузка тренировочных данных.
        /// </summary>
        public static List<Data> Load(string path)
        {
            List<Data> output = new List<Data>();

            using (StreamReader reader = new StreamReader(path))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string[] columns = NormalRow(reader.ReadLine()).Split(',');
                    string[] op = columns[1].Split('_');

                    output.Add(new Data
                    {
                        Id = ColumToReal(columns[0]),
                        Oper_type_attr = ColumToReal(op[0]) + ColumToReal(op[1]),
                        Index_oper = ColumToReal(columns[2]),
                        Type = ColumType(columns[3]),
                        Priority = ColumToReal(columns[4]),
                        Is_privatecategory = ColumYR(columns[5]),
                        Class = ColumToReal(columns[6]),
                        Is_in_yandex = ColumYR(columns[7]),
                        Is_return = ColumYR(columns[8]),
                        Weight = ColumToReal(columns[9]),
                        Mailtype = ColumToReal(columns[10]),
                        Mailctg = ColumToReal(columns[11]),
                        Mailrank = ColumToReal(columns[12]),
                        Directctg = ColumToReal(columns[13]),
                        Transport_pay = ColumToReal(columns[14]),
                        Postmark = ColumToReal(columns[15]),
                        Name_mfi = ColumNames(columns[16]),
                        Weight_mfi = ColumToReal(columns[17]),
                        Price_mfi = ColumToReal(columns[18]),
                        Dist_qty_oper_login_1 = ColumToReal(columns[19]),
                        Total_qty_oper_login_1 = ColumToReal(columns[20]),
                        Total_qty_oper_login_0 = ColumToReal(columns[21]),
                        Total_qty_over_index_and_type = ColumToReal(columns[22]),
                        Total_qty_over_index = ColumToReal(columns[23]),
                        Is_wrong_sndr_name = columns[24] == "1" ? 1 : 0,
                        Is_wrong_rcpn_name = columns[25] == "1" ? 1 : 0,
                        Is_wrong_phone_number = columns[26] == "1" ? 1 : 0,
                        Is_wrong_address = columns[27] == "1" ? 1 : 0,
                        Label = columns[28] == "1" ? 1 : 0
                    });
                }
            }

            return output;
        }

        /// <summary>
        /// Сохранение тренировочных данных.
        /// </summary>
        public static void Save(List<Data> outputs, string path)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write)))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                writer.Write($"id,oper_type_attr,index_oper,type,priority,is_privatecategory,class,is_in_yandex,is_return,weight,mailtype,mailctg,mailrank,directctg,transport_pay,postmark,name_mfi,weight_mfi,price_mfi,dist_qty_oper_login_1,total_qty_oper_login_1,total_qty_oper_login_0,total_qty_over_index_and_type,total_qty_over_index,is_wrong_sndr_name,is_wrong_rcpn_name,is_wrong_phone_number,is_wrong_address,label\n");

                for (int i = 0; i < outputs.Count; i++)
                {
                    writer.Write(
                       $"{outputs[i].Id}," +
                       $"{outputs[i].Oper_type_attr}," +
                       $"{outputs[i].Index_oper}," +
                       $"{outputs[i].Type}," +
                       $"{outputs[i].Priority}," +
                       $"{outputs[i].Is_privatecategory}," +
                       $"{outputs[i].Class}," +
                       $"{outputs[i].Is_in_yandex}," +
                       $"{outputs[i].Is_return}," +
                       $"{outputs[i].Weight}," +
                       $"{outputs[i].Mailtype}," +
                       $"{outputs[i].Mailctg}," +
                       $"{outputs[i].Mailrank}," +
                       $"{outputs[i].Directctg}," +
                       $"{outputs[i].Transport_pay}," +
                       $"{outputs[i].Postmark}," +
                       $"{outputs[i].Name_mfi}," +
                       $"{outputs[i].Weight_mfi}," +
                       $"{outputs[i].Price_mfi}," +
                       $"{outputs[i].Dist_qty_oper_login_1}," +
                       $"{outputs[i].Total_qty_oper_login_1}," +
                       $"{outputs[i].Total_qty_oper_login_0}," +
                       $"{outputs[i].Total_qty_over_index_and_type}," +
                       $"{outputs[i].Total_qty_over_index}," +
                       $"{outputs[i].Is_wrong_sndr_name}," +
                       $"{outputs[i].Is_wrong_rcpn_name}," +
                       $"{outputs[i].Is_wrong_phone_number}," +
                       $"{outputs[i].Is_wrong_address}," +
                       $"{outputs[i].Label}\n");
                }
            }
        }

        /// <summary>
        /// Балансировка данных.
        /// </summary>
        public static List<Data> Balancing(List<Data> input)
        {
            List<Data> data = new List<Data>();
            List<Data> zero = new List<Data>();

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].Label == 1) { data.Add(input[i]); }
                else { zero.Add(input[i]); }
            }

            data.AddRange(zero.GetRange(0, data.Count));

            return data;
        }

        /// <summary>
        /// Нормализация строки.
        /// </summary>
        public static string NormalRow(string row)
        {
            int fIndex = row.IndexOf('"');
            int sIndex = row.LastIndexOf('"');

            if (fIndex != -1 && sIndex != -1)
            {
                string nameMfi = row.Substring(fIndex + 1, sIndex - fIndex - 1);
                row = row.Remove(fIndex + 1, sIndex - fIndex - 1);

                while (nameMfi.IndexOf(",,") != -1)
                {
                    int f = nameMfi.IndexOf(",,");
                    int s1 = nameMfi.IndexOf('"', f + 1);
                    int s2 = nameMfi.IndexOf(',', f + 2);

                    if (s2 < s1 && s2 != -1) { nameMfi = nameMfi.Remove(f, 2).Insert(f, ","); }
                    else if (s1 < s2 && s1 != -1) { nameMfi = nameMfi.Remove(f, 2).Insert(f, "\""); }
                    else { nameMfi = nameMfi.Replace(",,", ","); }
                }

                row = row.Insert(fIndex + 1, nameMfi.Replace(",", "/+/"));
            }

            return row;
        }

        /// <summary>
        /// Подсчет количества наименований.
        /// </summary>
        public static double ColumNames(string cell)
        {
            cell = cell.Replace("\"", "").ToLower();

            while (cell.Contains("  ")) { cell = cell.Replace("  ", " "); }

            string[] arr = cell.Split("/+/");

            return cell == "0" ? 0 : arr.Length;
        }

        /// <summary>
        /// Конвертирование значений в числа.
        /// </summary>
        public static double ColumToReal(string cell)
        {
            try { return Convert.ToDouble(cell.Replace('.', ',')); }
            catch { return 0; }
        }

        /// <summary>
        /// Конвертирование бинарных значений.
        /// </summary>
        public static double ColumYR(string cell)
        {
            if (cell == "Y") { return 1; }
            if (cell == "N") { return 0; }
            else { return -1; }
        }

        /// <summary>
        /// Конвертирование значений "Type" в числовое представление.
        /// </summary>
        public static double ColumType(string cell)
        {
            string[] arr = new string[] {
                "0", "Участок", "ММПО", "Цех", "П", "ТИ", "ГОПС","МСЦ", "СОПС", "АО",
                "МРП", "СЦ", "МСО", "ОПП", "АОПП", "ПЕРЕДВИЖНОЕ ОС", "ОП", "ППС", "УМСЦ", "УКД" };

            for (int i = 0; i < arr.Length; i++) { if (cell == arr[i]) { return i; } }

            return 0;
        }
    }
}
