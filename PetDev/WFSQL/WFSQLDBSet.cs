using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.Xml;
using System.Text.RegularExpressions;



namespace PetDev
{
    public partial class WFSQLDBSet : Form
    {

        private string strDBPath = "";
        private string strDBErrorPath = "";
        private string strSysSetPath = "";
        private string strPath = "";
        private string strSQLPath = "";
        private string strOraclePath = "";
        private string strOracleDataPath = "";

        public WFSQLDBSet()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ASCIIEncoding objEnCode = new ASCIIEncoding();
            //byte[] byteArray = new byte[] { (byte) 64 };
            //MessageBox.Show( objEnCode.GetString(byteArray));
            strPath = GetPath();
            strSysSetPath = strPath + "SetXML//DB.xml";
            strSQLPath = strPath + "DBFile//SQL//SQL.TXT";
            strOraclePath = strPath + "DBFile//SQL//SQL.TXT";

            strOracleDataPath = strPath + "DBFile//SQL//Data.TXT";
            strDBErrorPath = strPath + "DBFile//SQL//DBError.TXT";
            strDBPath = GetDbPath();


            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();//��һ��ExcelӦ��
            if (app == null)
            {
                return;
            }
            Workbooks wbs = app.Workbooks;
            _Workbook wb = wbs.Add(strDBPath);//��һ�����еĹ�����
            Sheets shs = wb.Sheets;
            _Worksheet sh = (_Worksheet)wb.Sheets["DBSet"];  // (_Worksheet)shs.//.get_Item(1);//ѡ���һ��Sheetҳ
            if (sh == null)
            {
                return;
            }
            try
            {
                for (int i = 3; i <= sh.UsedRange.Rows.Count; i++)
                {
                    Range r = sh.get_Range("B" + i.ToString(), System.Reflection.Missing.Value);
                    Range V = sh.get_Range("C" + i.ToString(), System.Reflection.Missing.Value);
                    Range D = sh.get_Range("D" + i.ToString(), System.Reflection.Missing.Value);
                    cbxTable.Items.Add(System.Convert.ToString(r.Value2).Trim() + "," + System.Convert.ToString(V.Value2).Trim() + "," + System.Convert.ToString(D.Value2).Trim() + "," + i.ToString());
                }
            }

            catch
            {

            }
            finally
            {
                //ɱ��EXCEL����
                wb.Close(false, Type.Missing, Type.Missing);
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                wb = null;
                app = null;
                GC.Collect();
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            //string strValue = "";
            TextWriter FileSQL = Console.Out;

            FileStream OutFile = new FileStream(strSQLPath, FileMode.Create);

            StreamWriter objWriter = new StreamWriter(OutFile);
            Console.SetOut(objWriter);

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();//��һ��ExcelӦ��
            if (app == null)
            {
                return;
            }

            Workbooks wbs = app.Workbooks;
            _Workbook wb = wbs.Add(strDBPath);//��һ�����еĹ�����
            Sheets shs = wb.Sheets;

            try
            {
                int intCount = 0;
                foreach (string str in cbxTable.CheckedItems)
                {
                    char[] carTwo = new char[] { ',' };
                    string[] strColTwo;
                    strColTwo = str.Split(carTwo);
                    try
                    {
                        _Worksheet sh = (_Worksheet)wb.Sheets[strColTwo[0].ToString().Trim()];
                        if (sh != null)
                        {
                            if (intCount > 0)
                            {
                                Console.Write("\r\n");
                                Console.Write("\r\n");
                            }
                            SetTable(sh);  //ѡ��Sheetҳ
                            SetTableIndex(strColTwo[3]);
                        }
                        if (strColTwo[2].ToString().Trim() != "")
                        {
                            _Worksheet shData = (_Worksheet)wb.Sheets[strColTwo[2].ToString().Trim()];
                            if (shData != null)
                            {
                                if (intCount > 0)
                                {
                                    Console.Write("\r\n");
                                    Console.Write("\r\n");
                                }
                                SetTableData(shData);  //ѡ��Sheetҳ
                            }
                        }
                    }
                    catch
                    {
                        //��ʾû��Sheet����������
                        MessageBox.Show(strColTwo[0].ToString() + "����������");
                        continue;
                    }
                    intCount++;
                }
                //textBox1.Text = strValue;

            }
            catch (Exception ex)
            {
                string strMsg = "";
                strMsg = ex.Message;
                MessageBox.Show(strMsg);
            }
            finally
            {
                //ɱ��EXCEL����
                wb.Close(false, Type.Missing, Type.Missing);
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                wb = null;
                app = null;
                GC.Collect();
            }
            //�����ļ����Ҵ�
            objWriter.Close();
            Console.SetOut(FileSQL);
            OpenFile();

        }
        private void SetTable(_Worksheet objSheet)
        {

            string strValue, strTableName, strColumnName, strCName, strColumnType, strLength, strIsNull, strDefaultValue, strIsPK, strMemo;
            strValue = "";
            //��ȡ������
            Range TableName = objSheet.get_Range("B1", System.Reflection.Missing.Value);
            strTableName = System.Convert.ToString(TableName.Value2).Trim();
            //******************************************************************************
            Console.WriteLine("--*****�����Ǵ�����[" + strTableName + "]SQL�ű�****************************");
            Console.WriteLine("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[" + strTableName + "]')");
            Console.WriteLine("and OBJECTPROPERTY(id, N'IsUserTable') = 1)");
            Console.WriteLine("drop table [dbo].[" + strTableName + "]");
            Console.WriteLine("GO");
            Console.WriteLine("CREATE TABLE [dbo].[" + strTableName + "] (");
            //**************************************************************************************8888
            for (int i = 4; i <= objSheet.UsedRange.Rows.Count; i++)
            {

                //��ȡ�ֶ���
                Range Column = objSheet.get_Range("B" + i.ToString(), System.Reflection.Missing.Value);
                strColumnName = System.Convert.ToString(Column.Value2).Trim();
                //��ȡ�ֶ���������
                Range CName = objSheet.get_Range("C" + i.ToString(), System.Reflection.Missing.Value);
                strCName = System.Convert.ToString(CName.Value2).Trim();
                //��ȡ�ֶ�����
                Range Type = objSheet.get_Range("D" + i.ToString(), System.Reflection.Missing.Value);
                strColumnType = System.Convert.ToString(Type.Value2).Trim();
                //��ȡ�ֶγ���
                Range Length = objSheet.get_Range("E" + i.ToString(), System.Reflection.Missing.Value);
                strLength = System.Convert.ToString(Length.Value2).Trim();
                //��ȡ�ֶγ���
                Range IsNULL = objSheet.get_Range("F" + i.ToString(), System.Reflection.Missing.Value);
                strIsNull = System.Convert.ToString(IsNULL.Value2).Trim();

                if (strIsNull != "")
                {
                    strIsNull = "  NOT NULL";
                }
                //��ȡ�ֶ�Ĭ��ֵ
                Range Default = objSheet.get_Range("G" + i.ToString(), System.Reflection.Missing.Value);
                strDefaultValue = System.Convert.ToString(Default.Value2).Trim();
                if (strDefaultValue != "")
                {
                    strDefaultValue = strDefaultValue.Replace("'", "").Replace("'", "");

                    if (strDefaultValue != "")
                    {
                        if (strColumnType.ToUpper().Contains("CHAR"))
                        {
                            strDefaultValue = "  constraint DF_" + strTableName + "_" + strColumnName + "  Default '" + strDefaultValue + "'";
                        }
                        else
                        {

                            strDefaultValue = "   constraint DF_" + strTableName + "_" + strColumnName + " Default " + strDefaultValue;
                        }
                    }
                    else
                    {
                        strDefaultValue = "   constraint DF_" + strTableName + "_" + strColumnName + " Default ''";
                    }



                }
                //��ȡ����
                Range IsPK = objSheet.get_Range("H" + i.ToString(), System.Reflection.Missing.Value);
                strIsPK = System.Convert.ToString(IsPK.Value2).Trim();
                if (strIsPK.ToUpper() != "")
                {
                    //strIsPK = " IDENTITY(1,1) ";
                }
                //��ȡ˵��
                Range Memo = objSheet.get_Range("I" + i.ToString(), System.Reflection.Missing.Value);
                strMemo = System.Convert.ToString(Memo.Value2).Trim();
                if (i == objSheet.UsedRange.Rows.Count)
                {
                    if (strColumnType.ToLower() == "varchar" || strColumnType.ToLower() == "nvarchar" || strColumnType.ToLower() == "char")
                    {
                        Console.WriteLine("[" + strColumnName + "] [" + strColumnType + "] (" + strLength + ") " + strIsPK + strIsNull + strDefaultValue + " --" + strCName + ":" + strMemo);
                    }
                    else
                    {
                        Console.WriteLine("[" + strColumnName + "] [" + strColumnType + "] " + strIsNull + strIsPK + strDefaultValue + " --" + strCName + ":" + strMemo);
                    }
                }
                else
                {
                    if (strColumnType.ToLower() == "varchar" || strColumnType.ToLower() == "nvarchar" || strColumnType.ToLower() == "char")
                    {
                        Console.WriteLine("[" + strColumnName + "] [" + strColumnType + "] (" + strLength + ") " + strIsNull + strIsPK + strDefaultValue + ", --" + strCName + ":" + strMemo);
                    }
                    else
                    {
                        Console.WriteLine("[" + strColumnName + "] [" + strColumnType + "] " + strIsNull + strIsPK + strDefaultValue + ", --" + strCName + ":" + strMemo);
                    }
                }
                strValue += "\r\n exec sp_addextendedproperty N'MS_Description', N'" + strCName + ":" + strMemo + "', N'user', N'dbo', N'table',N'" + strTableName + "', N'column', N'" + strColumnName + "'";
            }
            Console.Write(") ON [PRIMARY]");
            Console.WriteLine("\r\n WITH (DATA_COMPRESSION=page) ");
            Console.WriteLine("\r\n GO ");
            Console.Write(strValue);
            Console.WriteLine("\r\n  GO ");
        }


        private void SetTableData(_Worksheet objSheet)
        {
            string strTableName = "";
            string strCol = "";         //������
            string strColValue = "";    //�ж�ӦEXCEL������λ��
            string strMark = "";        //����λ�ñ�ʶ
            strMark = "B";
            string strMarkA = "@";
            //��ȡ������
            Range TableName = objSheet.get_Range("B1", System.Reflection.Missing.Value);
            strTableName = System.Convert.ToString(TableName.Value2).Trim();
            //******************************************************************************
            Console.WriteLine("--*****�����ǲ����[" + strTableName + "]SQL�ű�****************************");
            Console.WriteLine(" delete from  " + strTableName + " ");
            Console.WriteLine("\r\n GO ");
            //**************************************************************************************
            //###############��֯��########################
            int intAsciiCode = 0;
            for (int i = 2; i <= objSheet.UsedRange.Columns.Count; i++)
            {

                Range Column = objSheet.get_Range(strMark + "3", System.Reflection.Missing.Value);
                if (strCol != "")
                {
                    strCol += ",";
                    strCol += System.Convert.ToString(Column.Value2).Trim();
                }
                else
                {
                    strCol += System.Convert.ToString(Column.Value2).Trim();
                }
                if (strColValue != "")
                {
                    strColValue += ",";
                    strColValue += strMark;
                }
                else
                {
                    strColValue += strMark;
                }
                //strMark = Convert.tos strMark
                if (intAsciiCode < 90)
                {
                    ASCIIEncoding objEnCode = new ASCIIEncoding();
                    intAsciiCode = (int)objEnCode.GetBytes(strMark)[0];
                    intAsciiCode = intAsciiCode + 1;
                    byte[] byteArray = new byte[] { (byte)intAsciiCode };
                    strMark = objEnCode.GetString(byteArray);
                }
                else
                {
                    ASCIIEncoding objEnCode = new ASCIIEncoding();
                    int intAsciiCode1 = (int)objEnCode.GetBytes(strMarkA)[0];
                    intAsciiCode1 = intAsciiCode1 + 1;
                    byte[] byteArray = new byte[] { (byte)intAsciiCode1 };
                    strMarkA = objEnCode.GetString(byteArray);
                    strMark = "A" + strMarkA;
                }


            }
            //##############################
            for (int i = 4; i <= objSheet.UsedRange.Rows.Count; i++)
            {
                string strInsertValue = "";
                char[] carTwo = new char[] { ',' };
                string[] strColTwo;
                strColTwo = strColValue.Split(carTwo);
                for (int j = 0; j < strColTwo.Length; j++)
                {
                    string strCurrentValue = "";
                    Range ColValue = objSheet.get_Range(strColTwo[j].ToString() + i.ToString(), System.Reflection.Missing.Value);
                    strCurrentValue = System.Convert.ToString(ColValue.Value2).Trim();
                    if (strCurrentValue != "")
                    {
                        if (strInsertValue != "")
                        {
                            strInsertValue += ",";
                            strInsertValue += "'" + strCurrentValue + "'";
                        }
                        else
                        {
                            strInsertValue += "'" + strCurrentValue + "'";
                        }
                    }
                    else
                    {
                        if (strInsertValue != "")
                        {
                            strInsertValue += ",";
                            strInsertValue += "NULL";
                        }
                        else
                        {
                            strInsertValue += "NULL";
                        }
                    }
                }
                //д�������
                Console.WriteLine(" insert into  " + strTableName + "( " + strCol + ") values(" + strInsertValue + ")");
                Console.WriteLine("\r\n GO ");

            }
        }
        /// <summary>
        /// �����ɺõĽű�
        /// </summary>
        private void OpenFile()
        {
            string strPath = strSQLPath;
            TextWriter stringWriter = new StringWriter();

            TextReader stringReader =
                new StringReader(stringWriter.ToString());
            using (TextReader streamReader =
                      new StreamReader(strPath))
            {
                textBox1.Text = streamReader.ReadToEnd();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cbxTable.Items.Count; i++)
            {
                cbxTable.SetItemChecked(i, true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cbxTable.Items.Count; i++)
            {
                cbxTable.SetItemChecked(i, false);
            }
        }

        /// <summary>
        /// ��ȡ��ǰӦ�ó���������·��
        /// </summary>
        /// <returns></returns>
        private string GetPath()
        {
            string str = System.Windows.Forms.Application.ExecutablePath.ToString();
            string strPath = str.ToUpper().Replace("TOMDEV.EXE", "");
            return strPath;
        }

        private string GetDbPath()
        {
            string strDBOwner = "";
            string strPath = GetPath();
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(strSysSetPath);
            XmlNode node;
            node = myXmlDocument.DocumentElement;
            foreach (XmlNode node2 in node.ChildNodes)
            {
                switch (node2.Name.ToString())
                {
                    case "strSQLDBPath":
                        strDBOwner = node2.InnerText.ToString();
                        break;
                    default:
                        break;
                }
            }

            return strDBOwner;
        }

        private void SetTableIndex(string p_strRowIndex)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();//��һ��ExcelӦ��
            if (app == null)
            {
                return;
            }
            Workbooks wbs = app.Workbooks;
            _Workbook wb = wbs.Add(strDBPath);//��һ�����еĹ�����
            Sheets shs = wb.Sheets;
            _Worksheet sh = (_Worksheet)wb.Sheets["DBSet"];  // (_Worksheet)shs.//.get_Item(1);//ѡ���һ��Sheetҳ
            if (sh == null)
            {
                return;
            }
            try
            {
                Range B = sh.get_Range("B" + p_strRowIndex, System.Reflection.Missing.Value);
                Range H = sh.get_Range("H" + p_strRowIndex, System.Reflection.Missing.Value);
                Range I = sh.get_Range("I" + p_strRowIndex, System.Reflection.Missing.Value);
                string strIndexes = System.Convert.ToString(H.Value2).Trim();
                string strNonIndexes = System.Convert.ToString(I.Value2).Trim();
                string strTableName = System.Convert.ToString(B.Value2).Trim();

                StringBuilder sb = new StringBuilder();

                if (string.IsNullOrEmpty(strTableName))
                {
                    return;
                }
                //���� �ֶ� Ψһ ���� ����

                //�ۼ�����
                if (!string.IsNullOrEmpty(strIndexes))
                {

                    CreateTableIndex(strIndexes, strTableName, true);

                }

                //�Ǿۼ�����
                if (!string.IsNullOrEmpty(strNonIndexes))
                {
                    CreateTableIndex(strNonIndexes, strTableName, false);
                }
            }

            catch
            {

            }
            finally
            {
                //ɱ��EXCEL����
                wb.Close(false, Type.Missing, Type.Missing);
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                wb = null;
                app = null;
                GC.Collect();
            }
        }

        private static void CreateTableIndex(string strIndexes, string strTableName, bool blnIsIndex)
        {
            foreach (string strIndex in strIndexes.Split(';'))
            {
                string[] IndexPro = strIndex.Split('|');
                if (IndexPro.Length == 5)
                {
                    string strName = IndexPro[0];
                    string strCols = IndexPro[1];
                    bool blnUnique = (IndexPro[2] == "T" ? true : false);
                    string strCondition = IndexPro[3];
                    string strPartition = IndexPro[4];

                    string strIndexType = blnIsIndex ? "Clustered" : "NonClustered";
                    Console.WriteLine("--*****************�����Ǵ�������" + strName + "���ɽű�");
                    Console.WriteLine("if exists (select 1 from sysindexes where id = object_id('" + strTableName + "')  and   name  = '" + strName + "' and indid > 0 and indid < 255)");
                    Console.WriteLine("	drop Index " + strTableName + "." + strName);
                    Console.WriteLine("go");

                    if (blnUnique)
                    {
                        Console.WriteLine("Create Unique " + strIndexType + "  Index " + strName + " on " + strTableName + "(");
                    }
                    else
                    {
                        Console.WriteLine("Create " + strIndexType + "  Index " + strName + " on " + strTableName + "(");
                    }

                    int intColNo = 0;
                    foreach (string strCol in strCols.Split(','))
                    {
                        if (intColNo == 0)
                        {
                            Console.WriteLine(strCol + " Asc");
                        }
                        else
                        {
                            Console.WriteLine("," + strCol + " Asc");
                        }
                        intColNo++;
                    }
                    Console.WriteLine(")");
                    if (!string.IsNullOrEmpty(strCondition))
                    {
                        Console.WriteLine("Where " + strCondition);
                    }
                    Console.WriteLine("WITH (DATA_COMPRESSION = PAGE)");
                    if (!string.IsNullOrEmpty(strPartition))
                    {
                        Console.WriteLine("on " + strPartition + "(" + strCols + ")");
                    }
                    Console.WriteLine("go");
                }

            }
        }
    }
}