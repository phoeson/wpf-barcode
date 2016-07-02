using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfBarCode
{
    public class BarcodeEngine
    {
        private double code39WideRate = 2.3;
        public double Code39WideRate
        {
            get
            {
                return this.code39WideRate;
            }
            set
            {
                this.code39WideRate = value;
            }
        }


        private string codeType = BarCodeType.Code39;
        public string CodeType
        {
            get
            {
                return this.codeType;
            }
            set
            {
                this.codeType = value;
            }
        }

        private double barWidth = 1;
        public double BarWidth
        {
            get
            {
                return this.barWidth;
            }
            set
            {
                this.barWidth = value;
            }
        }

        //W Wide - Black
        //N Narrow - Black
        //w Wide - White
        //n Narrow - White
        #region code 39
        Dictionary<string, string> code39 = new Dictionary<string, string>
        {
            {"0","NnNwWnWnN"},
            {"1","WnNwNnNnW"},
            {"2","NnWwNnNnW"},
            {"3","WnWwNnNnN"},
            {"4","NnNwWnNnW"},
            {"5","WnNwWnNnN"},
            {"6","NnWwWnNnN"},
            {"7","NnNwNnWnW"},
            {"8","WnNwNnWnN"},
            {"9","NnWwNnWnN"},
            {"A","WnNnNwNnW"},
            {"B","NnWnNwNnW"},
            {"C","WnWnNwNnN"},
            {"D","NnNnWwNnW"},
            {"E","WnNnWwNnN"},
            {"F","NnWnWwNnN"},
            {"G","NnNnNwWnW"},
            {"H","WnNnNwWnN"},
            {"I","NnWnNwWnN"},
            {"J","NnNnWwWnN"},
            {"K","WnNnNnNwW"},
            {"L","NnWnNnNwW"},
            {"M","WnWnNnNwN"},
            {"N","NnNnWnNwW"},
            {"O","WnNnWnNwN"},
            {"P","NnWnWnNwN"},
            {"Q","NnNnNnWwW"},
            {"R","WnNnNnWwN"},
            {"S","NnWnNnWwN"},
            {"T","NnNnWnWwN"},
            {"U","WwNnNnNnW"},
            {"V","NwWnNnNnW"},
            {"W","WwWnNnNnN"},
            {"X","NwNnWnNnW"},
            {"Y","WwNnWnNnN"},
            {"Z","NwWnWnNnN"},
            {"-","NwNnNnWnW"},
            {".","WwNnNnWnN"},
            {" ","NwWnNnWnN"},
            {"$","NwNwNwNnN"},
            {"/","NwNwNnNwN"},
            {"+","NwNnNwNwN"},
            {"%","NnNwNwNwN"},
            {"*","NwNnWnWnN"},
        };
        #endregion

        #region code value code128A, code128B, code128C
        Dictionary<string, int> codeValue = new Dictionary<string, int>
        {
            { " ", 0 }, { "00", 0 },
            { "!", 1 }, { "01", 1 },
            { "\"", 2 }, { "02", 2 },
            { "#", 3 }, { "03", 3 },
            { "$", 4 }, { "04", 4 },
            { "%", 5 }, { "05", 5 },
            { "&", 6 }, { "06", 6 },
            { "'", 7 }, { "07", 7 },
            { "(", 8 }, { "08", 8 },
            { ")", 9 }, { "09", 9 },
            { "*", 10 }, { "10", 10 },
            { "+", 11 }, { "11", 11 },
            { ",", 12 }, { "12", 12 },
            { "-", 13 }, { "13", 13 },
            { ".", 14 }, { "14", 14 },
            { "/", 15 }, { "15", 15 },
            { "0", 16 }, { "16", 16 },
            { "1", 17 }, { "17", 17 },
            { "2", 18 }, { "18", 18 },
            { "3", 19 }, { "19", 19 },
            { "4", 20 }, { "20", 20 },
            { "5", 21 }, { "21", 21 },
            { "6", 22 }, { "22", 22 },
            { "7", 23 }, { "23", 23 },
            { "8", 24 }, { "24", 24 },
            { "9", 25 }, { "25", 25 },
            { ":", 26 }, { "26", 26 },
            { ";", 27 }, { "27", 27 },
            { "<", 28 }, { "28", 28 },
            { "=", 29 }, { "29", 29 },
            { ">", 30 }, { "30", 30 },
            { "?", 31 }, { "31", 31 },
            { "@", 32 }, { "32", 32 },
            { "A", 33 }, { "33", 33 },
            { "B", 34 }, { "34", 34 },
            { "C", 35 }, { "35", 35 },
            { "D", 36 }, { "36", 36 },
            { "E", 37 }, { "37", 37 },
            { "F", 38 }, { "38", 38 },
            { "G", 39 }, { "39", 39 },
            { "H", 40 }, { "40", 40 },
            { "I", 41 }, { "41", 41 },
            { "J", 42 }, { "42", 42 },
            { "K", 43 }, { "43", 43 },
            { "L", 44 }, { "44", 44 },
            { "M", 45 }, { "45", 45 },
            { "N", 46 }, { "46", 46 },
            { "O", 47 }, { "47", 47 },
            { "P", 48 }, { "48", 48 },
            { "Q", 49 }, { "49", 49 },
            { "R", 50 }, { "50", 50 },
            { "S", 51 }, { "51", 51 },
            { "T", 52 }, { "52", 52 },
            { "U", 53 }, { "53", 53 },
            { "V", 54 }, { "54", 54 },
            { "W", 55 }, { "55", 55 },
            { "X", 56 }, { "56", 56 },
            { "Y", 57 }, { "57", 57 },
            { "Z", 58 }, { "58", 58 },
            { "[", 59 }, { "59", 59 },
            { "\\", 60 }, { "60", 60 },
            { "]", 61 }, { "61", 61 },
            { "^", 62 }, { "62", 62 },
            { "_", 63 }, { "63", 63 },
            { "NUL", 64 }, { "`", 64 }, { "64", 64 },
            { "SOH", 65 }, { "a", 65 }, { "65", 65 },
            { "STX", 66 }, { "b", 66 }, { "66", 66 },
            { "ETX", 67 }, { "c", 67 }, { "67", 67 },
            { "EOT", 68 }, { "d", 68 }, { "68", 68 },
            { "ENQ", 69 }, { "e", 69 }, { "69", 69 },
            { "ACK", 70 }, { "f", 70 }, { "70", 70 },
            { "BEL", 71 }, { "g", 71 }, { "71", 71 },
            { "BS", 72 }, { "h", 72 }, { "72", 72 },
            { "HT", 73 }, { "i", 73 }, { "73", 73 },
            { "LF", 74 }, { "j", 74 }, { "74", 74 },
            { "VT", 75 }, { "k", 75 }, { "75", 75 },
            { "FF", 76 }, { "l", 76 }, { "76", 76 },
            { "CR", 77 }, { "m", 77 }, { "77", 77 },
            { "SO", 78 }, { "n", 78 }, { "78", 78 },
            { "SI", 79 }, { "o", 79 }, { "79", 79 },
            { "DLE", 80 }, { "p", 80 }, { "80", 80 },
            { "DC1", 81 }, { "q", 81 }, { "81", 81 },
            { "DC2", 82 }, { "r", 82 }, { "82", 82 },
            { "DC3", 83 }, { "s", 83 }, { "83", 83 },
            { "DC4", 84 }, { "t", 84 }, { "84", 84 },
            { "NAK", 85 }, { "u", 85 }, { "85", 85 },
            { "SYN", 86 }, { "v", 86 }, { "86", 86 },
            { "ETB", 87 }, { "w", 87 }, { "87", 87 },
            { "CAN", 88 }, { "x", 88 }, { "88", 88 },
            { "EM", 89 }, { "y", 89 }, { "89", 89 },
            { "SUB", 90 }, { "z", 90 }, { "90", 90 },
            { "ESC", 91 }, { "{", 91 }, { "91", 91 },
            { "FS", 92 }, { "|", 92 }, { "92", 92 },
            { "GS", 93 }, { "}", 93 }, { "93", 93 },
            { "RS", 94 }, { "~", 94 }, { "94", 94 },
            { "US", 95 }, { "DEL", 95 }, { "95", 95 },
            { "FNC3", 96 }, { "96", 96 },
            { "FNC2", 97 }, { "97", 97 },
            { "SHIFT", 98 }, { "98", 98 },
            { "CODEC", 99 }, { "99", 99 },
            { "CODEB", 100 }, //{ "FNC4", 100 },
            { "FNC4", 101 }, { "CODEA", 101 },
            { "FNC1", 102 },
            { "StartA", 103 },
            { "StartB", 104 },
            { "StartC", 105 },
            { "Stop", 106 },
        };
        #endregion

        #region band value
        Dictionary<int, string> valueBand = new Dictionary<int, string>
        {
            { 0, "212222"},
            { 1, "222122"},
            { 2, "222221"},
            { 3, "121223"},
            { 4, "121322"},
            { 5, "131222"},
            { 6, "122213"},
            { 7, "122312"},
            { 8, "132212"},
            { 9, "221213"},
            { 10, "221312"},
            { 11, "231212"},
            { 12, "112232"},
            { 13, "122132"},
            { 14, "122231"},
            { 15, "113222"},
            { 16, "123122"},
            { 17, "123221"},
            { 18, "223211"},
            { 19, "221132"},
            { 20, "221231"},
            { 21, "213212"},
            { 22, "223112"},
            { 23, "312131"},
            { 24, "311222"},
            { 25, "321122"},
            { 26, "321221"},
            { 27, "312212"},
            { 28, "322112"},
            { 29, "322211"},
            { 30, "212123"},
            { 31, "212321"},
            { 32, "232121"},
            { 33, "111323"},
            { 34, "131123"},
            { 35, "131321"},
            { 36, "112313"},
            { 37, "132113"},
            { 38, "132311"},
            { 39, "211313"},
            { 40, "231113"},
            { 41, "231311"},
            { 42, "112133"},
            { 43, "112331"},
            { 44, "132131"},
            { 45, "113123"},
            { 46, "113321"},
            { 47, "133121"},
            { 48, "313121"},
            { 49, "211331"},
            { 50, "231131"},
            { 51, "213113"},
            { 52, "213311"},
            { 53, "213131"},
            { 54, "311123"},
            { 55, "311321"},
            { 56, "331121"},
            { 57, "312113"},
            { 58, "312311"},
            { 59, "332111"},
            { 60, "314111"},
            { 61, "221411"},
            { 62, "431111"},
            { 63, "111224"},
            { 64, "111422"},
            { 65, "121124"},
            { 66, "121421"},
            { 67, "141122"},
            { 68, "141221"},
            { 69, "112214"},
            { 70, "112412"},
            { 71, "122114"},
            { 72, "122411"},
            { 73, "142112"},
            { 74, "142211"},
            { 75, "241211"},
            { 76, "221114"},
            { 77, "413111"},
            { 78, "241112"},
            { 79, "134111"},
            { 80, "111242"},
            { 81, "121142"},
            { 82, "121241"},
            { 83, "114212"},
            { 84, "124112"},
            { 85, "124211"},
            { 86, "411212"},
            { 87, "421112"},
            { 88, "421211"},
            { 89, "212141"},
            { 90, "214121"},
            { 91, "412121"},
            { 92, "111143"},
            { 93, "111341"},
            { 94, "131141"},
            { 95, "114113"},
            { 96, "114311"},
            { 97, "411113"},
            { 98, "411311"},
            { 99, "113141"},
            { 100, "114131"},
            { 101, "311141"},
            { 102, "411131"},
            { 103, "211412"},
            { 104, "211214"},
            { 105, "211232"},
            { 106, "2331112"},
        };
        #endregion

        #region code table
        private DataTable m_Code128 = new DataTable();
        private void InitCodeTable()
        {
            m_Code128.Columns.Add("ID");
            m_Code128.Columns.Add("Code128A");
            m_Code128.Columns.Add("Code128B");
            m_Code128.Columns.Add("Code128C");
            m_Code128.Columns.Add("BandCode");
            m_Code128.CaseSensitive = true;
            #region 数据表
            m_Code128.Rows.Add("0", " ", " ", "00", "212222");
            m_Code128.Rows.Add("1", "!", "!", "01", "222122");
            m_Code128.Rows.Add("2", "\"", "\"", "02", "222221");
            m_Code128.Rows.Add("3", "#", "#", "03", "121223");
            m_Code128.Rows.Add("4", "$", "$", "04", "121322");
            m_Code128.Rows.Add("5", "%", "%", "05", "131222");
            m_Code128.Rows.Add("6", "&", "&", "06", "122213");
            m_Code128.Rows.Add("7", "'", "'", "07", "122312");
            m_Code128.Rows.Add("8", "(", "(", "08", "132212");
            m_Code128.Rows.Add("9", ")", ")", "09", "221213");
            m_Code128.Rows.Add("10", "*", "*", "10", "221312");
            m_Code128.Rows.Add("11", "+", "+", "11", "231212");
            m_Code128.Rows.Add("12", ",", ",", "12", "112232");
            m_Code128.Rows.Add("13", "-", "-", "13", "122132");
            m_Code128.Rows.Add("14", ".", ".", "14", "122231");
            m_Code128.Rows.Add("15", "/", "/", "15", "113222");
            m_Code128.Rows.Add("16", "0", "0", "16", "123122");
            m_Code128.Rows.Add("17", "1", "1", "17", "123221");
            m_Code128.Rows.Add("18", "2", "2", "18", "223211");
            m_Code128.Rows.Add("19", "3", "3", "19", "221132");
            m_Code128.Rows.Add("20", "4", "4", "20", "221231");
            m_Code128.Rows.Add("21", "5", "5", "21", "213212");
            m_Code128.Rows.Add("22", "6", "6", "22", "223112");
            m_Code128.Rows.Add("23", "7", "7", "23", "312131");
            m_Code128.Rows.Add("24", "8", "8", "24", "311222");
            m_Code128.Rows.Add("25", "9", "9", "25", "321122");
            m_Code128.Rows.Add("26", ":", ":", "26", "321221");
            m_Code128.Rows.Add("27", ";", ";", "27", "312212");
            m_Code128.Rows.Add("28", "<", "<", "28", "322112");
            m_Code128.Rows.Add("29", "=", "=", "29", "322211");
            m_Code128.Rows.Add("30", ">", ">", "30", "212123");
            m_Code128.Rows.Add("31", "?", "?", "31", "212321");
            m_Code128.Rows.Add("32", "@", "@", "32", "232121");
            m_Code128.Rows.Add("33", "A", "A", "33", "111323");
            m_Code128.Rows.Add("34", "B", "B", "34", "131123");
            m_Code128.Rows.Add("35", "C", "C", "35", "131321");
            m_Code128.Rows.Add("36", "D", "D", "36", "112313");
            m_Code128.Rows.Add("37", "E", "E", "37", "132113");
            m_Code128.Rows.Add("38", "F", "F", "38", "132311");
            m_Code128.Rows.Add("39", "G", "G", "39", "211313");
            m_Code128.Rows.Add("40", "H", "H", "40", "231113");
            m_Code128.Rows.Add("41", "I", "I", "41", "231311");
            m_Code128.Rows.Add("42", "J", "J", "42", "112133");
            m_Code128.Rows.Add("43", "K", "K", "43", "112331");
            m_Code128.Rows.Add("44", "L", "L", "44", "132131");
            m_Code128.Rows.Add("45", "M", "M", "45", "113123");
            m_Code128.Rows.Add("46", "N", "N", "46", "113321");
            m_Code128.Rows.Add("47", "O", "O", "47", "133121");
            m_Code128.Rows.Add("48", "P", "P", "48", "313121");
            m_Code128.Rows.Add("49", "Q", "Q", "49", "211331");
            m_Code128.Rows.Add("50", "R", "R", "50", "231131");
            m_Code128.Rows.Add("51", "S", "S", "51", "213113");
            m_Code128.Rows.Add("52", "T", "T", "52", "213311");
            m_Code128.Rows.Add("53", "U", "U", "53", "213131");
            m_Code128.Rows.Add("54", "V", "V", "54", "311123");
            m_Code128.Rows.Add("55", "W", "W", "55", "311321");
            m_Code128.Rows.Add("56", "X", "X", "56", "331121");
            m_Code128.Rows.Add("57", "Y", "Y", "57", "312113");
            m_Code128.Rows.Add("58", "Z", "Z", "58", "312311");
            m_Code128.Rows.Add("59", "[", "[", "59", "332111");
            m_Code128.Rows.Add("60", "\\", "\\", "60", "314111");
            m_Code128.Rows.Add("61", "]", "]", "61", "221411");
            m_Code128.Rows.Add("62", "^", "^", "62", "431111");
            m_Code128.Rows.Add("63", "_", "_", "63", "111224");
            m_Code128.Rows.Add("64", "NUL", "`", "64", "111422");
            m_Code128.Rows.Add("65", "SOH", "a", "65", "121124");
            m_Code128.Rows.Add("66", "STX", "b", "66", "121421");
            m_Code128.Rows.Add("67", "ETX", "c", "67", "141122");
            m_Code128.Rows.Add("68", "EOT", "d", "68", "141221");
            m_Code128.Rows.Add("69", "ENQ", "e", "69", "112214");
            m_Code128.Rows.Add("70", "ACK", "f", "70", "112412");
            m_Code128.Rows.Add("71", "BEL", "g", "71", "122114");
            m_Code128.Rows.Add("72", "BS", "h", "72", "122411");
            m_Code128.Rows.Add("73", "HT", "i", "73", "142112");
            m_Code128.Rows.Add("74", "LF", "j", "74", "142211");
            m_Code128.Rows.Add("75", "VT", "k", "75", "241211");
            m_Code128.Rows.Add("76", "FF", "I", "76", "221114");
            m_Code128.Rows.Add("77", "CR", "m", "77", "413111");
            m_Code128.Rows.Add("78", "SO", "n", "78", "241112");
            m_Code128.Rows.Add("79", "SI", "o", "79", "134111");
            m_Code128.Rows.Add("80", "DLE", "p", "80", "111242");
            m_Code128.Rows.Add("81", "DC1", "q", "81", "121142");
            m_Code128.Rows.Add("82", "DC2", "r", "82", "121241");
            m_Code128.Rows.Add("83", "DC3", "s", "83", "114212");
            m_Code128.Rows.Add("84", "DC4", "t", "84", "124112");
            m_Code128.Rows.Add("85", "NAK", "u", "85", "124211");
            m_Code128.Rows.Add("86", "SYN", "v", "86", "411212");
            m_Code128.Rows.Add("87", "ETB", "w", "87", "421112");
            m_Code128.Rows.Add("88", "CAN", "x", "88", "421211");
            m_Code128.Rows.Add("89", "EM", "y", "89", "212141");
            m_Code128.Rows.Add("90", "SUB", "z", "90", "214121");
            m_Code128.Rows.Add("91", "ESC", "{", "91", "412121");
            m_Code128.Rows.Add("92", "FS", "|", "92", "111143");
            m_Code128.Rows.Add("93", "GS", "}", "93", "111341");
            m_Code128.Rows.Add("94", "RS", "~", "94", "131141");
            m_Code128.Rows.Add("95", "US", "DEL", "95", "114113");
            m_Code128.Rows.Add("96", "FNC3", "FNC3", "96", "114311");
            m_Code128.Rows.Add("97", "FNC2", "FNC2", "97", "411113");
            m_Code128.Rows.Add("98", "SHIFT", "SHIFT", "98", "411311");
            m_Code128.Rows.Add("99", "CODEC", "CODEC", "99", "113141");
            m_Code128.Rows.Add("100", "CODEB", "FNC4", "CODEB", "114131");
            m_Code128.Rows.Add("101", "FNC4", "CODEA", "CODEA", "311141");
            m_Code128.Rows.Add("102", "FNC1", "FNC1", "FNC1", "411131");
            m_Code128.Rows.Add("103", "StartA", "StartA", "StartA", "211412");
            m_Code128.Rows.Add("104", "StartB", "StartB", "StartB", "211214");
            m_Code128.Rows.Add("105", "StartC", "StartC", "StartC", "211232");
            m_Code128.Rows.Add("106", "Stop", "Stop", "Stop", "2331112");
            #endregion
        }
        #endregion

        public List<BarcodeItem> Generate(string code)
        {
            string barcode = code;
            List<BarcodeItem> result = new List<BarcodeItem>();
            List<int> elementsKeyList = new List<int>();
            int sum = 0;
            switch (CodeType)
            {
                // Code128码有一个头一个尾。
                // 尾总是2331112，这代表Code128已经结束。其余的部分是6位为一个块，包括头。
                // 头有3种：A)211412 B)211214 C)211232 。这分别表示此Code128是什么类型的。（ABC其中一种）
                // 中间内容的其中最后一个块（除去尾段）是校验位，用于检查该条形码是否被正确编码
                // http://www.barcoderesource.com/code128_barcodefont.html
                // http://www.tiaoma100.com/doc/3852
                case BarCodeType.Code128A:
                    #region Code128A
                    for (int i = 0; i < barcode.Length; i++)
                    {
                        char charcode;
                        charcode = barcode[i];
                        if (codeValue.ContainsKey(charcode.ToString()))
                        {
                            int elementKey = codeValue[charcode.ToString()];
                            elementsKeyList.Add(elementKey);
                        }
                    }

                    //add check sum
                    for (int i = 0; i < elementsKeyList.Count; i++)
                    {
                        sum += elementsKeyList[i] * (i + 1);
                    }
                    sum %= 103;

                    elementsKeyList.Insert(0, 103);//头StartA
                    elementsKeyList.Add(sum);
                    elementsKeyList.Add(106);//尾
                    foreach (var band in elementsKeyList)
                    {
                        string bandcode = valueBand[band];
                        for (int i = 0; i < bandcode.Length; i++)
                        {
                            result.Add(new BarcodeItem()
                            {
                                Color = i % 2 == 0 ? Brushes.Black : Brushes.Transparent,
                                Width = int.Parse((bandcode[i].ToString())) * this.BarWidth
                            });
                        }
                    }
                    #endregion
                    break;
                case BarCodeType.Code128B:
                    #region Code128B
                    for (int i = 0; i < barcode.Length; i++)
                    {
                        char charcode;
                        charcode = barcode[i];
                        if (codeValue.ContainsKey(charcode.ToString()))
                        {
                            int elementKey = codeValue[charcode.ToString()];
                            elementsKeyList.Add(elementKey);
                        }
                    }

                    //add check sum
                    for (int i = 0; i < elementsKeyList.Count; i++)
                    {
                        sum += elementsKeyList[i] * (i + 1);
                    }
                    sum += 104;
                    sum %= 103;

                    elementsKeyList.Insert(0, 104);//头StartB
                    elementsKeyList.Add(sum);
                    elementsKeyList.Add(106);//尾
                    foreach (var band in elementsKeyList)
                    {
                        string bandcode = valueBand[band];
                        for (int i = 0; i < bandcode.Length; i++)
                        {
                            result.Add(new BarcodeItem
                            {
                                Color = i % 2 == 0 ? Brushes.Black : Brushes.Transparent,
                                Width = int.Parse((bandcode[i].ToString())) * this.BarWidth
                            });
                        }
                    }
                    #endregion
                    break;
                case BarCodeType.Code128C:
                    #region code128c
                    //128C必须是数字
                    long numberbarcode = 0;
                    if (long.TryParse(barcode, out numberbarcode) == false)
                    {
                        return result;
                    }

                    //1. separate the barcode to codeValue elements

                    for (int i = 0; i < (barcode.Length + 1) / 2; i++)
                    {
                        string section = null;
                        if (i == (barcode.Length + 1) / 2 - 1)
                        {
                            section = barcode.Substring(i * 2);
                        }
                        else
                        {
                            section = barcode.Substring(i * 2, 2);
                        }
                        if (section.Length == 1)
                        {
                            //insert CodeB
                            elementsKeyList.Add(100);
                        }
                        if (codeValue.ContainsKey(section))
                        {
                            int elementKey = codeValue[section];
                            elementsKeyList.Add(elementKey);
                        }
                    }

                    //add check sum
                    for (int i = 0; i < elementsKeyList.Count; i++)
                    {
                        sum += elementsKeyList[i] * (i + 1);
                    }
                    sum += 105;
                    sum %= 103;

                    elementsKeyList.Insert(0, 105);//头
                    elementsKeyList.Add(sum);
                    elementsKeyList.Add(106);//尾
                    foreach (var band in elementsKeyList)
                    {
                        string bandcode = valueBand[band];
                        for (int i = 0; i < bandcode.Length; i++)
                        {
                            result.Add(new BarcodeItem
                            {
                                Color = i % 2 == 0 ? Brushes.Black : Brushes.Transparent,
                                Width = int.Parse((bandcode[i].ToString())) * this.BarWidth
                            });
                        }
                    }
                    #endregion
                    break;
                case BarCodeType.Code39:
                    #region code39
                    barcode = string.Format("*{0}*", barcode);
                    string codeItem = null;
                    if (true)
                    {
                        foreach (var item in barcode)
                        {
                            if (!code39.TryGetValue(item.ToString(), out codeItem)) return null;
                            codeItem += 'n';
                            var a = from i in Enumerable.Range(0, codeItem.Length)
                                    select new BarcodeItem
                                    {
                                        Color = (codeItem[i] == 'W' || codeItem[i] == 'N') ? Brushes.Black : Brushes.Transparent,
                                        Width = ((codeItem[i] == 'n' || codeItem[i] == 'N') ? 1 : this.Code39WideRate) * this.BarWidth
                                    };
                            result.AddRange(a);
                        }
                    }
                    #endregion
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
