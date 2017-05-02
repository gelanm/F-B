using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;


namespace PetDev
{
    class BLLExcel
    {

        private void OpenSeet()
        {
            Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
            object missing = System.Reflection.Missing.Value;
            ObjWorkBook = ObjExcel.Workbooks.Open(Environment.CurrentDirectory + "SQL.xls", missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
        }

        private void AddSQL(string strValue)
        {

            /// ��ȡTxt�ı���·������
            string strFilePath = Environment.CurrentDirectory + "\\SQL.txt";
            //д�����ļ�
            StreamWriter objStrWriter = null;
            try
            {
                /// �жϸ���־�ļ��Ƿ����
                if (!File.Exists(strFilePath))
                {
                    objStrWriter = File.CreateText(strFilePath);
                }
                else
                {
                    objStrWriter = File.AppendText(strFilePath);
                }

                /// д�뵱ǰ��־��Ϣ
                objStrWriter.WriteLine(strValue);
                objStrWriter.WriteLine("--****************************************");
              
            }
            catch
            {
               
            }
            finally
            {
                objStrWriter.Close();
            }


        }
    }
}
