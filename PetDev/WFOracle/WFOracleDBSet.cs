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
    public partial class WFOracleDBSet : Form
    {
        public WFOracleDBSet()
        {
            InitializeComponent();
        }

        private string strDBPath = "";
        private string strDBErrorPath = "";
        private string strSysSetPath = "";
        private string strPath = "";
        private string strSQLPath = "";
        private string strOraclePath = "";
        private string strOracleDataPath = "";

        private void WFDBSet_Load(object sender, EventArgs e)
        {
            strPath = GetPath();
            strSysSetPath = strPath + "SetXML//DB.xml";
            strSQLPath = strPath + "DBFile//Oracle//SQL.TXT";
            strOraclePath = strPath + "DBFile//Oracle//OracleSQL.TXT";

            strOracleDataPath = strPath + "DBFile//Oracle//OracleData.TXT";
            strDBErrorPath = strPath + "DBFile//Oracle//DBError.TXT";
            strDBPath = GetDbPath();
            
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();//��һ��ExcelӦ��
            if (app == null)
            {
                return;
            }
            Workbooks wbs = app.Workbooks;
            _Workbook wb = wbs.Add(strDBPath);//��һ�����еĹ�����Environment.CurrentDirectory + "\\SQL.xls"
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
                    cbxTable.Items.Add(System.Convert.ToString(r.Value2).Trim() + "," + System.Convert.ToString(V.Value2).Trim() + "," + System.Convert.ToString(D.Value2).Trim());
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
                    case "strORACLEDBPath":
                        strDBOwner = node2.InnerText.ToString();
                        break;
                    default:
                        break;
                }
            }

            return strDBOwner;
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

        private void SetOracleTable(_Worksheet objSheet)
        {
           

            string strValue, strTableName, strColumnName, strCName, strColumnType, strLength, strIsNull, strDefaultValue, strIsPK, strMemo;
            strValue = "";
            string strIndexValue="";
            //��ȡ������
            Range TableName = objSheet.get_Range("B1", System.Reflection.Missing.Value);
            string strOwner = "EHRDAT1";
            Range TableSpace = objSheet.get_Range("D1", System.Reflection.Missing.Value);
            string strTableSpace = "";
            strTableSpace = System.Convert.ToString(TableSpace.Value2).Trim();
            strTableName = System.Convert.ToString(TableName.Value2).Trim();
            string strUserName=txtLogInName.Text.Trim();
            //******************************************************************************
            Console.WriteLine("/*****�����Ǵ�����[" + strTableName + "]SQL�ű�****************************/\r\n");
            Console.Write("/*ɾ�����б�*/\r\n");
            Console.WriteLine("/*drop table fnd.T_" + strTableName + ";*/");
            Console.Write("/*������ṹ*/\r\n");
            Console.WriteLine("CREATE TABLE fnd.T_" + strTableName + "\r\n(");
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
                    if (strDefaultValue.ToLower() == "date")
                    {
                        strDefaultValue = " Default " + strDefaultValue ;
                    }
                    else
                    {
                        strDefaultValue = " Default '" + strDefaultValue + "'";
                    }
                }
                //��ȡ����
                Range IsPK = objSheet.get_Range("H" + i.ToString(), System.Reflection.Missing.Value);
                strIsPK = System.Convert.ToString(IsPK.Value2).Trim();
                if (strIsPK.ToUpper() != "")
                {
                    strIndexValue = "CREATE INDEX  fnd.I_" + strIsPK + " ON  fnd.T_" + strTableName + "(" + strColumnName + ") TABLESPACE IDX_FINNET;\r\n";
                    strIndexValue += "ALTER TABLE fnd.T_" + strTableName + " ADD PRIMARY KEY(" + strColumnName + ");\r\n";
                }
                //��ȡ˵��
                Range Memo = objSheet.get_Range("I" + i.ToString(), System.Reflection.Missing.Value);
                strMemo = System.Convert.ToString(Memo.Value2).Trim();
                if (i == objSheet.UsedRange.Rows.Count)
                {
                    switch (strColumnType.ToLower())
                    {
                        case "varchar2":
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "(" + strLength + ") " + strDefaultValue + strIsNull + " /*" + strCName + ":" + strMemo + " */");
                            break;
                        case "number":
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "(" + strLength + ") " + strDefaultValue.Replace("'","") + strIsNull + " /*" + strCName + ":" + strMemo + " */");
                            break;
                        case "date":
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "  " + strDefaultValue + strIsNull + " /*" + strCName + ":" + strMemo + " */");
                            break;
                        case "clob":
                            Console.WriteLine(" " + strColumnName + "  " + strColumnType + "   /*" + strCName + ":" + strMemo + " */");
                            break;
                        default:
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "(" + strLength + ") " + strDefaultValue + strIsNull + " /*" + strCName + ":" + strMemo + " */");
                            break;
                    }
                }
                else
                {
                    switch (strColumnType.ToLower())
                    {
                        case "varchar2":
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "(" + strLength + ") " + strDefaultValue + strIsNull + ",  /*" + strCName + ":" + strMemo + " */");
                            break;
                        case "number":
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "(" + strLength + ") " + strDefaultValue.Replace("'", "") + strIsNull + ",  /*" + strCName + ":" + strMemo + " */");
                            break;
                        case "date":
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "   " + strDefaultValue + strIsNull + ",  /*" + strCName + ":" + strMemo + " */");
                            break;
                        case "clob":
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "  ,   /*" + strCName + ":" + strMemo + " */");
                            break;
                        default:
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "(" + strLength + ") " + strDefaultValue + strIsNull + ",  /*" + strCName + ":" + strMemo + " */");
                            break;
                    }
                }

                strValue += "COMMENT ON COLUMN  fnd.T_" + strTableName + "." + strColumnName + " IS " + "'" + strCName + ":" + strMemo + "';\r\n";
            }
            Console.Write(")\r\n");
            Console.Write("TABLESPACE " + strTableSpace + "; \r\n");
            Console.Write("/*�������ֶ�˵��*/\r\n");
            Console.Write(strValue);
            Console.Write("/*�������ֶ�����*/\r\n");
            Console.Write(strIndexValue);
            Console.Write("\r\n");
           
            Range SQIsPK = objSheet.get_Range("H4", System.Reflection.Missing.Value);
            strIsPK = System.Convert.ToString(SQIsPK.Value2).Trim();
            if (strIsPK.ToUpper() != "")
            {
                Console.Write("/*����������Ҫʹ�õ���SEQUENCE*/\r\n");
                Console.Write("CREATE SEQUENCE fnd.Q_" + strTableName + "ID START WITH 1 INCREMENT BY 1 NOCYCLE NOMAXVALUE; \r\n");
                Console.Write("CREATE PUBLIC SYNONYM SEQ_" + strTableName + "ID FOR fnd.Q_" + strTableName + "ID; \r\n");
                Console.Write("/*��SEQUENCE��ѯȨ��*/\r\n");
                Console.Write("GRANT SELECT ON fnd.Q_" + strTableName + "ID to finnet;");
            }

            //Range ColumnSeq = objSheet.get_Range("B4", System.Reflection.Missing.Value);
            //string strColumnSeqName = System.Convert.ToString(ColumnSeq.Value2).Trim();
          
            Console.Write("/*����������*/\r\n");
            Console.Write("CREATE PUBLIC SYNONYM S_" + strTableName + " for fnd.T_" + strTableName + "; \r\n");

           // Console.Write("Create synonym " + strUserName + ".S_"+strTableName+" for T_"+strTableName+";\r\n");
            Console.Write("/*�������û���ʹ��Ȩ��*/\r\n");
            Console.Write("GRANT SELECT,INSERT,UPDATE,DELETE ON fnd.T_" + strTableName + "  to finnet; ");

     
        }


         

        private void SetOracleTableData(_Worksheet objSheet,_Worksheet objtb)
        {
            //���ñ��Ĭ�Ͻṹ**************************************************************************************8888
            System.Data.DataTable dtbTable = new System.Data.DataTable();
            dtbTable.Columns.Add("CoName", typeof(string));
            dtbTable.Columns.Add("Length", typeof(string));
            dtbTable.Columns.Add("Type", typeof(string));

            string strValue, strColumnName, strCName, strColumnType, strLength, strIsNull, strDefaultValue, strIsPK, strMemo;
            strValue = "";
            string strIndexValue = "";

            for (int i = 4; i <= objtb.UsedRange.Rows.Count; i++)
            {

                //��ȡ�ֶ���
                Range Column = objtb.get_Range("B" + i.ToString(), System.Reflection.Missing.Value);
                strColumnName = System.Convert.ToString(Column.Value2).Trim().ToUpper();
                //��ȡ�ֶ�����
                Range Type = objtb.get_Range("D" + i.ToString(), System.Reflection.Missing.Value);
                strColumnType = System.Convert.ToString(Type.Value2).Trim().ToUpper();
                //��ȡ�ֶγ���
                Range Length = objtb.get_Range("E" + i.ToString(), System.Reflection.Missing.Value);
                strLength = System.Convert.ToString(Length.Value2).Trim();

                System.Data.DataRow dr= dtbTable.NewRow();
                dr["CoName"] = strColumnName;
                dr["Length"] = strLength;
                dr["Type"] = strColumnType;

                dtbTable.Rows.Add(dr);
            }
            //**************************************************************************************8888*********************

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
            Console.WriteLine(" set define off ;");
            Console.WriteLine("delete from  T_" + strTableName + ";");
           
            //**************************************************************************************
            //###############��֯��############################################################################################################
            int intAsciiCode = 0;
            for (int i = 2; i <= objSheet.UsedRange.Columns.Count; i++)
            {

                Range Column = objSheet.get_Range(strMark + "3", System.Reflection.Missing.Value);
                //�жϱ��е��������ݿ����Ƿ����
                dtbTable.DefaultView.RowFilter = "CoName='" + System.Convert.ToString(Column.Value2).Trim().ToUpper() + "'";
                if (dtbTable.DefaultView.Count <= 0)
                {
                    MessageBox.Show("�ֶ�[ " + System.Convert.ToString(Column.Value2).Trim() + " ]�����ݿ��в����ڣ�", "����");
                    return;

                }

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
            //##################################################################################################################

            strMark = "B";
            for (int i = 4; i <= objSheet.UsedRange.Rows.Count; i++)
            {
                string strColType = "";
                string  strColLength ="";
                


                string strInsertValue = "";
                char[] carTwo = new char[] { ',' };
                string[] strColTwo;
                strColTwo = strColValue.Split(carTwo);
                for (int j = 0; j < strColTwo.Length; j++)
                {

                    //��ȡ������
                    Range Column = objSheet.get_Range(strColTwo[j] + "3", System.Reflection.Missing.Value);
                    string strColName = System.Convert.ToString(Column.Value2).Trim().ToUpper();
                    dtbTable.DefaultView.RowFilter = "CoName='" + strColName + "'";
                    if (dtbTable.DefaultView.Count <= 0)
                    {
                        MessageBox.Show("�ֶ�[ " + strColName + " ]�����ݿ��в����ڣ�", "����");
                        return;
                    }
                    else
                    {
                        strColType = dtbTable.DefaultView[0]["Type"].ToString().ToUpper();
                        strColLength = dtbTable.DefaultView[0]["Length"].ToString();
                    }



                    string strCurrentValue = "";
                    Range ColValue = objSheet.get_Range(strColTwo[j].ToString() + i.ToString(), System.Reflection.Missing.Value);
                    strCurrentValue = System.Convert.ToString(ColValue.Text).Trim();
                    if (strCurrentValue != "")
                    {
                        strCurrentValue=strCurrentValue.Replace("'", "''");
                        //�ж��Ƿ񳤶ȳ���
                        if (strColLength.Trim() != "" || strColType == "CLOB")
                        {
                            switch (strColType)
                            {
                                case "CLOB":
                                    if (strTableName.ToUpper() != "CP" && strTableName.ToUpper() != "T_CP")
                                    {
                                        strCurrentValue = strCurrentValue.Replace("\r\n", "<BR>");
                                        strCurrentValue = strCurrentValue.Replace("\n\n", "<BR>");
                                        strCurrentValue = strCurrentValue.Replace("\n", "<BR>");
                                    }
                                    if (CheckLength(strCurrentValue ,4000))
                                    {
                                        
                                        if (strTableName.ToUpper() == "T_CP" && strTableName.ToUpper() == "T_CP")
                                        {
                                            //strCurrentValue.Replace("\r\n", "<BR>");
                                        }
                                        //MessageBox.Show(i+"���ֶ�[ " + strColName + " ]���ȳ�����4000��", "����");
                                        //return;
                                        if (CheckLength(strCurrentValue, 3950))
                                        {
                                            strCurrentValue = SubStr(strCurrentValue, 3950) + "...";
                                        }
                                    }
                                    break;
                                case "VARCHAR2":
                                    if ( CheckLength(strCurrentValue  , Convert.ToInt32(strColLength)))
                                    {
                                        MessageBox.Show( "EXCEL " +strColTwo[j]+i + " �ֶ�[ " + strColName + " ]���ȳ�����" + strColLength + "��", "����");
                                        return;
                                    }
                                    break;
                                case "CHAR":
                                    if (CheckLength(strCurrentValue, Convert.ToInt32(strColLength)))
                                    {
                                        MessageBox.Show("EXCEL " + strColTwo[j] + i + " �ֶ�[ " + strColName + " ]���ȳ�����" + strColLength + "��", "����");
                                        return;
                                    }
                                    break;
                                case "NUMBER":
                                    if (CheckLength(strCurrentValue, Convert.ToInt32(strColLength)))
                                    {
                                        MessageBox.Show("EXCEL " + strColTwo[j] + i + " �ֶ�[ " + strColName + " ]���ȳ�����" + strColLength + "��", "����");
                                        return;
                                    }
                                    break;
                                case "DATE":
                                    if (CheckLength(strCurrentValue, 19))
                                    {
                                        MessageBox.Show("EXCEL " + strColTwo[j] + i + " �ֶ�[ " + strColName + " ]���ȳ�����" + strColLength + "��", "����");
                                        return;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }

                        if (strInsertValue != "")
                        {
                            strInsertValue += ",";
                            if (strCurrentValue.Trim().ToUpper() != "SEQ")
                            {
                                if (strColType == "DATE")
                                {
                                    if (strCurrentValue.Length > 10)
                                    {
                                        strInsertValue += "to_date('" + strCurrentValue + "',' yyyy-MM-dd hh24:mi:ss')";
                                    }
                                    else
                                    {
                                        strInsertValue += "to_date('" + strCurrentValue + "','yyyy-MM-dd')";
                                    }
                                }
                                else
                                {
                                    strInsertValue += "'" + strCurrentValue + "'";
                                }
                            }
                            else
                            {
                                strInsertValue += "SEQ_" + strTableName.ToUpper()+"ID.NEXTVAL";
                            }
                        }
                        else
                        {
                            if (strCurrentValue.Trim().ToUpper() != "SEQ")
                            {
                                if (strColType == "DATE")
                                {
                                    if (strCurrentValue.Length > 10)
                                    {
                                        strInsertValue += "to_date('" + strCurrentValue + "',' yyyy-MM-dd hh24:mi:ss')";
                                    }
                                    else
                                    {
                                        strInsertValue += "to_date('" + strCurrentValue + "','yyyy-MM-dd')";
                                    }
                                }
                                else
                                {
                                    strInsertValue += "'" + strCurrentValue + "'";
                                }
                            }
                            else
                            {
                                strInsertValue += "SEQ_" + strTableName.ToUpper() + "ID.NEXTVAL";
                            }
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
                //д�������
                Console.WriteLine("insert into  T_" + strTableName + "( " + strCol + ") values(" + strInsertValue + ") ;");
            }
           

          
        }
        /// <summary>
        /// �����ɺõĽű�
        /// </summary>
        private void OpenFile(string p_strSQLPath)
        {
            string strPath = p_strSQLPath;
            TextWriter stringWriter = new StringWriter();

            TextReader stringReader =
                new StringReader(stringWriter.ToString());
            using (TextReader streamReader =
                      new StreamReader(strPath))
            {
                textBox1.Text = streamReader.ReadToEnd();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOracle_Click(object sender, EventArgs e)
        {
            

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();//��һ��ExcelӦ��
            if (app == null)
            {
                return;
            }

            Workbooks wbs = app.Workbooks;
            _Workbook wb = wbs.Add(strDBPath);//��һ�����еĹ�����
            Sheets shs = wb.Sheets;

            TextWriter FileSQL = Console.Out;
            FileStream OutFile = new FileStream(strOraclePath, FileMode.Create);
            StreamWriter objWriter = new StreamWriter(OutFile);
            Console.SetOut(objWriter);

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
                            }
                            SetOracleTable(sh);  //ѡ��Sheetҳ
                        }
                    }
                    catch (Exception ex)
                    {
                        //��ʾû��Sheet����������
                        MessageBox.Show(strColTwo[0].ToString() + "����������" + ex.Message);
                        continue;
                    }
                    intCount++;
                }
               

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
            //textBox1.Text = strValue;
            //�����ļ����Ҵ�
            objWriter.Close();
            Console.SetOut(FileSQL);
            OpenFile(strOraclePath);
            MessageBox.Show("���ݿ��ṹ���ɳɹ���", "��ʾ��");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();//��һ��ExcelӦ��
            if (app == null)
            {
                return;
            }

            Workbooks wbs = app.Workbooks;
            _Workbook wb = wbs.Add(strDBPath);//��һ�����еĹ�����
            Sheets shs = wb.Sheets;

            //**********************************************************************************************
            TextWriter FileSQLData = Console.Out;
      
            FileStream OutFileData = new FileStream(strOracleDataPath, FileMode.Create);
     
            StreamWriter objWriterData = new StreamWriter(OutFileData,Encoding.UTF8);

         
            Console.SetOut(objWriterData);

            try
            {
                int intCount = 0;
                 
                intCount = 0;
                foreach (string str in cbxTable.CheckedItems)
                {
                    char[] carTwo = new char[] { ',' };
                    string[] strColTwo;
                    strColTwo = str.Split(carTwo);
                    try
                    {
                        _Worksheet shtb = (_Worksheet)wb.Sheets[strColTwo[0].ToString().Trim()];
                        if (strColTwo[2].ToString().Trim() != "")
                        {
                            _Worksheet shData = (_Worksheet)wb.Sheets[strColTwo[2].ToString().Trim()];
                            if (shData != null)
                            {
                                if (intCount > 0)
                                {
                                    Console.Write("\r\n");
                                }
                                SetOracleTableData(shData, shtb);  //ѡ��Sheetҳ
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //��ʾû��Sheet����������
                        MessageBox.Show(strColTwo[0].ToString() + "����������" + ex.Message);
                        continue;
                    }
                    intCount++;
                }
                Console.WriteLine("commit;");
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
            objWriterData.Close();
            Console.SetOut(FileSQLData);
            OpenFile(strOracleDataPath);
            MessageBox.Show("���ݿ��Ĭ���������ɳɹ���", "��ʾ��");

        }

        public  bool CheckLength(string p_strInputText, int p_intLength)
        {
            bool boolCheck = false;
            Regex regex = new Regex("[^\x00-\xff]", RegexOptions.Compiled);     // ������ʽƥ��˫�ֽ��ַ�(������������)
            char[] arrChar = p_strInputText.ToCharArray();
            int intLength = 0;
            for (int i = 0; i < arrChar.Length; i++)
            {
                intLength++;
                if (regex.IsMatch((arrChar[i]).ToString()))                     // �ж��Ƿ���˫�ֽ�
                {
                    intLength++;
                }
            }
            if (intLength > p_intLength)
            {
                boolCheck = true;
            }
            return boolCheck;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();//��һ��ExcelӦ��
            if (app == null)
            {
                return;
            }
            if (!File.Exists(strDBErrorPath))
            {
                File.Create(strDBErrorPath);
            }
            Workbooks wbs = app.Workbooks;
            _Workbook wb = wbs.Add(strDBPath);//��һ�����еĹ�����
            Sheets shs = wb.Sheets;

            //**********************************************************************************************
            TextWriter FileSQLData = Console.Out;

            FileStream OutFileData = new FileStream(strDBErrorPath, FileMode.Create);

            StreamWriter objWriterData = new StreamWriter(OutFileData, Encoding.UTF8);


            Console.SetOut(objWriterData);
            int refCount = 0;
            try
            {
                int intCount = 0;

                intCount = 0;
                foreach (string str in cbxTable.CheckedItems)
                {
                    char[] carTwo = new char[] { ',' };
                    string[] strColTwo;
                    strColTwo = str.Split(carTwo);
                    try
                    {
                        _Worksheet shtb = (_Worksheet)wb.Sheets[strColTwo[0].ToString().Trim()];
                        if (strColTwo[2].ToString().Trim() != "")
                        {
                            _Worksheet shData = (_Worksheet)wb.Sheets[strColTwo[2].ToString().Trim()];
                            if (shData != null)
                            {
                                if (intCount > 0)
                                {
                                    Console.Write("\r\n");
                                }
                                CheckOracleTableData(shData, shtb,ref refCount);  //ѡ��Sheetҳ
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //��ʾû��Sheet����������
                        MessageBox.Show(strColTwo[0].ToString() + "����������" + ex.Message);
                        continue;
                    }
                    intCount++;
                }
                
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
            objWriterData.Close();
            Console.SetOut(FileSQLData);
            OpenFile(strDBErrorPath);
            MessageBox.Show("������֤���,��" + refCount+"����", "��ʾ��");

        }


        private void CheckOracleTableData(_Worksheet objSheet, _Worksheet objtb, ref int refCount)
        {
            //���ñ��Ĭ�Ͻṹ**************************************************************************************8888
            System.Data.DataTable dtbTable = new System.Data.DataTable();
            dtbTable.Columns.Add("CoName", typeof(string));
            dtbTable.Columns.Add("Length", typeof(string));
            dtbTable.Columns.Add("Type", typeof(string));

            string strValue, strColumnName, strCName, strColumnType, strLength, strIsNull, strDefaultValue, strIsPK, strMemo;
            strValue = "";
            string strIndexValue = "";

            for (int i = 4; i <= objtb.UsedRange.Rows.Count; i++)
            {

                //��ȡ�ֶ���
                Range Column = objtb.get_Range("B" + i.ToString(), System.Reflection.Missing.Value);
                strColumnName = System.Convert.ToString(Column.Value2).Trim().ToUpper();
                //��ȡ�ֶ�����
                Range Type = objtb.get_Range("D" + i.ToString(), System.Reflection.Missing.Value);
                strColumnType = System.Convert.ToString(Type.Value2).Trim().ToUpper();
                //��ȡ�ֶγ���
                Range Length = objtb.get_Range("E" + i.ToString(), System.Reflection.Missing.Value);
                strLength = System.Convert.ToString(Length.Value2).Trim();

                System.Data.DataRow dr = dtbTable.NewRow();
                dr["CoName"] = strColumnName;
                dr["Length"] = strLength;
                dr["Type"] = strColumnType;

                dtbTable.Rows.Add(dr);
            }
            //**************************************************************************************8888*********************

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
            Console.WriteLine("--*****�����ǶԲ�������[" + strTableName + "]���ݺϷ��Ե���֤****************************");


            //**************************************************************************************
            //###############��֯��############################################################################################################
            int intAsciiCode = 0;
            for (int i = 2; i <= objSheet.UsedRange.Columns.Count; i++)
            {

                Range Column = objSheet.get_Range(strMark + "3", System.Reflection.Missing.Value);
                //�жϱ��е��������ݿ����Ƿ����
                dtbTable.DefaultView.RowFilter = "CoName='" + System.Convert.ToString(Column.Value2).Trim().ToUpper() + "'";
                if (dtbTable.DefaultView.Count <= 0)
                {


                }

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
            //##################################################################################################################

            strMark = "B";
            for (int i = 4; i <= objSheet.UsedRange.Rows.Count; i++)
            {
                string strColType = "";
                string strColLength = "";



                string strInsertValue = "";
                char[] carTwo = new char[] { ',' };
                string[] strColTwo;
                strColTwo = strColValue.Split(carTwo);
                for (int j = 0; j < strColTwo.Length; j++)
                {

                    //��ȡ������
                    Range Column = objSheet.get_Range(strColTwo[j] + "3", System.Reflection.Missing.Value);
                    string strColName = System.Convert.ToString(Column.Value2).Trim().ToUpper();
                    dtbTable.DefaultView.RowFilter = "CoName='" + strColName + "'";
                    if (dtbTable.DefaultView.Count <= 0)
                    {
                        Console.WriteLine("EXCEL " + strColTwo[j] + i + "���ֶ�����[ " + strColName + " ]�����ݿ��в����� ");
                        refCount++;
                        return;
                    }
                    else
                    {
                        strColType = dtbTable.DefaultView[0]["Type"].ToString().ToUpper();
                        strColLength = dtbTable.DefaultView[0]["Length"].ToString();
                    }



                    string strCurrentValue = "";
                    Range ColValue = objSheet.get_Range(strColTwo[j].ToString() + i.ToString(), System.Reflection.Missing.Value);
                    strCurrentValue = System.Convert.ToString(ColValue.Text).Trim();
                    if (strCurrentValue != "")
                    {
                        strCurrentValue = strCurrentValue.Replace("'", "''");
                        //�ж��Ƿ񳤶ȳ���
                        if (strColLength.Trim() != "" || strColType == "CLOB")
                        {
                            switch (strColType)
                            {
                                case "CLOB":
                                    if (CheckLength(strCurrentValue, 4000))
                                    {
                                        Console.WriteLine("EXCEL " + strColTwo[j] + i + "���ֶ�[ " + strColName + " ]���ȳ�����4000 ");
                                        refCount++;
                                    }
                                    break;
                                case "VARCHAR2":
                                    if (CheckLength(strCurrentValue, Convert.ToInt32(strColLength)))
                                    {
                                        Console.WriteLine("EXCEL " + strColTwo[j] + i + " �ֶ�[ " + strColName + " ]���ȳ�����" + strColLength + " ");
                                        refCount++;
                                    }
                                    break;
                                case "CHAR":
                                    if (CheckLength(strCurrentValue, Convert.ToInt32(strColLength)))
                                    {
                                        Console.WriteLine("EXCEL " + strColTwo[j] + i + " �ֶ�[ " + strColName + " ]���ȳ�����" + strColLength + " ");
                                        refCount++;
                                    }
                                    break;

                                case "NUMBER":
                                    if (strCurrentValue.Trim().ToUpper() != "SEQ")
                                    {
                                        if (CheckLength(strCurrentValue, Convert.ToInt32(strColLength)))
                                        {
                                            Console.WriteLine("EXCEL " + strColTwo[j] + i + " �ֶ�[ " + strColName + " ]���ȳ�����" + strColLength + " ");
                                            refCount++;
                                        }
                                        try
                                        {
                                            Convert.ToInt32(strCurrentValue);
                                        }
                                        catch
                                        {
                                            Console.WriteLine("EXCEL " + strColTwo[j] + i + " �ֶ�[ " + strColName + " ]�������Ͳ���ȷӦ��Ϊ" + strColType + " ");
                                            refCount++;
                                        }
                                    }
                                    break;
                                case "DATE":
                                    if (CheckLength(strCurrentValue, 19))
                                    {
                                        Console.WriteLine("EXCEL " + strColTwo[j] + i + " �ֶ�[ " + strColName + " ]���ȳ�����" + strColLength + " ");
                                        refCount++;
                                    }
                                    try
                                    {
                                        Convert.ToDateTime(strCurrentValue);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("EXCEL " + strColTwo[j] + i + " �ֶ�[ " + strColName + " ]�������Ͳ���ȷӦ��Ϊ" + strColType + " ");
                                        refCount++;
                                    }
                                    break;
                                default:
                                    break;
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

                }
            }
            Console.WriteLine("��[ "+ refCount+" ]������");
        }

        /// <summary>
        /// ����:     flighingandblue.com
        /// ����ʱ��: 2008-10-13
        /// ��������: ��ȡ�ַ���
        /// </summary>
        /// <param name="p_strInputText">�����ַ���</param>
        /// <param name="p_intlength">��󳤶�</param>
        /// <returns>���ؽ�ȡ���ַ����ĳ���</returns>
        public   string SubStr(string p_strInputText, int p_intlength)
        {
            return SubStr(p_strInputText, p_intlength, string.Empty);
        }

        /// <summary>
        /// ����:     flighingandblue.com
        /// ����ʱ��: 2008-10-13
        /// ��������: ��ȡ�����ַ�����ָ�����ȣ����ֺ�Ӣ����1�������ĺ�ȫ����2��
        /// </summary>
        /// <param name="p_strInputText">�����ַ���</param>
        /// <param name="p_intLength">��ȡ����</param>
        /// <param name="p_strLast">ƴ�������</param>
        /// <returns>��ȡ����ַ���</returns>
        public   string SubStr(string p_strInputText, int p_intLength, string p_strLast)
        {
            Regex regex = new Regex("[^\x00-\xff]", RegexOptions.Compiled);     // ������ʽƥ��˫�ֽ��ַ�(������������)
            char[] arrChar = p_strInputText.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int intLength = 0;
            for (int i = 0; i < arrChar.Length; i++)
            {
                sb.Append(arrChar[i]);
                intLength++;
                if (regex.IsMatch((arrChar[i]).ToString()))                     // �ж��Ƿ���˫�ֽ�
                {
                    intLength++;
                }
                if (intLength == p_intLength)                                   // �жϽ�ȡ�����Ƿ�һ��
                {
                    break;
                }
                if (intLength > p_intLength)                                    // �����ȡ�ĳ��ȱ��趨�ĳ��ȴ������⴦��
                {
                    sb.Remove(sb.Length - 1, 1);
                    break;
                }
            }
            if (p_strLast != string.Empty && sb.Length < arrChar.Length)
                sb.Append(p_strLast);
            return sb.ToString();
        }





    }

}