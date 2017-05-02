using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Collections;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace PetDev
{
    /// <summary>
    /// �޸���:     ***
    /// �޸�ʱ��:   0000-00-00
    /// �޸�����:   
    /// �๦������: DataTable�ĵ�����Excel����
    /// </summary>
    public class ToExcel
    {
        /// <summary>
        /// ��������: DataTable�������ݵ�Excel,������Ը�����Ҫ�ٽ����޸�
        /// ����˵��:
        /// objArrayCol.Insert(0, "XM");
        /// objArrayCol.Insert(1, "NJ");
        /// objArrayCol.Insert(2, "SFZH");
        /// objArrayCol.Insert(3, "CSRQ");
        /// objArrayColName.Insert(0, "����");
        /// objArrayColName.Insert(1, "����");
        /// objArrayColName.Insert(2, "���֤��");
        /// objArrayColName.Insert(3, "��������");
        /// </summary>
        /// <param name="dtbOut">���������ݼ�</param>
        /// <param name="objArrayColName">������objHasValue.add("���к�","�ֶ���")</param>
        /// <param name="objArrayCol">�ж�Ӧ��˵�� objHasValue.add("���к�","�ֶ�˵��")</param>
        /// <param name="strFileName">��ʱ�ļ�·��</param>
        public void SetExcelLog(System.Data.DataTable dtbOut, ArrayList objArrayColName, ArrayList objArrayCol, string strFileName)
        {
            #region"��ʼ������"
            Microsoft.Office.Interop.Excel.Application ThisApplication = new ApplicationClass();//����Excel����
            Microsoft.Office.Interop.Excel.Workbook ThisWorkBook;
            ThisWorkBook = ThisApplication.Workbooks.Add(true);
            object missing = System.Reflection.Missing.Value;
            #endregion
            try
            {
                //ʵ����Sheet
                Worksheet ThisSheet = new Worksheet();

                //#region"������Sheet"
                //ThisSheet = (Worksheet)ThisWorkBook.ActiveSheet;
                //ThisSheet.Name = "Ŀ¼";
                //for (int t = 1; t <= 5; t++)
                //{
                //    Range r1 = (Range)ThisSheet.Cells[t, 1];
                //    //���õ�ǰλ�ó����ӵ���Sheet
                //    r1.Hyperlinks.Add(r1, "", "��Ϣ" + t + "!A1", missing, "��Ϣ" + t);
                //}
                //#endregion

                #region"���÷�Sheet"
                //for (int x = 1; x <= 5; x++)
                //{
                //int y = x - 1;
                ////�����п��������Ǽ���sheet���滹��ǰ��
                //if (x > 0)
                //{
                //    ThisApplication.Worksheets.Add(missing, ThisSheet, missing, missing);
                //}
                ThisSheet = (Worksheet)ThisWorkBook.ActiveSheet;
                ThisSheet.Name = "Sheet";// +x.ToString();

                #region"���ɱ�����"
                //int m = 1;
                for (int i = 0; i < objArrayColName.Count; i++)
                {
                    //if (i < objArrayColName.Count)
                    //{
                    ThisSheet.Cells[1, i + 1] = "'" + objArrayColName[i].ToString();
                    //Range r1 = (Range)ThisSheet.Cells[1, m];
                    Range r1 = (Range)ThisSheet.Cells[1, i + 1];
                    r1.Font.Bold = true;
                    // r1.Borders.LineStyle = 1;                                   //��Ԫ��߿���
                    //r1.Borders.Color = System.Drawing.Color.Black.ToArgb();        //��Ԫ��߿���ɫ
                    //r1.Interior.Color = System.Drawing.Color.LightGray.ToArgb();   //��Ԫ�񱳾���ɫ
                    //r1.Borders[XlBordersIndex.xlDiagonalDown].Weight = 1;           //���ñ߿���ʽ    
                    //}
                    //else
                    //{
                    //    Range r1 = (Range)ThisSheet.Cells[1, m];
                    //r1.Hyperlinks.Add(r1, "http://www. .com", " ");
                    //���÷��ص���ǰλ�ó�����
                    //r1.Hyperlinks.Add(r1, "", "Ŀ¼!A1", missing, "back");
                    //}
                    //m++;
                }
                #endregion

                #region"����������"
                for (int i = 0; i < dtbOut.Rows.Count; i++)
                {
                    int j = 1;
                    for (int n = 0; n < objArrayCol.Count; n++)
                    {
                        string str = objArrayCol[n].ToString();
                        string str1 = dtbOut.Columns[str].DataType.ToString();
                        //�ж����������������⴦��
                        if (str1 == "System.DateTime")
                        {
                            ThisSheet.Cells[i + 2, j] = "'" + Convert.ToDateTime(dtbOut.Rows[i][str]).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            ThisSheet.Cells[i + 2, j] = dtbOut.Rows[i][str].ToString();// + x.ToString();
                        }
                        j++;
                    }

                }
                #endregion

                //���ù�ʽ��
                //Range r2 = (Range)ThisSheet.Cells[4, 2];
                //r2.Formula = "=SUM(B3+B2)";

                /*����˵��
                FileName                Ҫ������ OLE �����Դ�ļ���
                LinkToFile              Ҫ���������ļ���
                SaveWithDocument        ͼƬ���ĵ�һ�𱣴档
                Left                    ���Ͻǵ�λ�á�
                Top                     ͼƬ���Ͻǵ�λ�á�
                Width                   ͼƬ�Ŀ�ȡ�
                Height                  ͼƬ�ĸ߶ȡ�
                ��EXCEL�����ͼƬ*/
                //ThisSheet.Shapes.AddPicture("C:\\ .gif", Microsoft.Office.Core.MsoTriState.msoCTrue, Microsoft.Office.Core.MsoTriState.msoCTrue, 250, 0, 70, 30);
                //}
                #endregion

                //���湤����
                ThisSheet.SaveAs("C:\\"+strFileName, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            finally
            {
                #region"����Excel����"
                ThisWorkBook.Close(false, Type.Missing, Type.Missing);
                ThisApplication.Workbooks.Close();
                ThisApplication.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ThisWorkBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ThisApplication);
                ThisWorkBook = null;
                ThisApplication = null;
                GC.Collect();
                #endregion
            }
        }
 

    }
}
