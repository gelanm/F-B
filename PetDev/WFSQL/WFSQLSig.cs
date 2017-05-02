using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections;


namespace PetDev
{
    public partial class WFSQLSig : Form
    {
        #region"��������"
        private CommonAccess objAccess = new CommonAccess();

        private string strPath = "";
        private string strSysSetPath = "";
        private string strSelectPath = "";
        private string strInsertPath = "";
        private string strUpdatePath = "";
        private string strDeletePath = "";
        private string strBLLPath = "";
        private string strWebPath = "";
        private string strSPPath = "";

        private string strModulesPath = "";
        #endregion

        #region"���캯��"
        public WFSQLSig()
        {
            InitializeComponent();
        }
        #endregion

        #region"��������"
        private void FinNet3_Load(object sender, EventArgs e)
        {
            strPath = GetPath();
            strSysSetPath = strPath + "SetXML//DB.xml";
            strSelectPath = strPath + "SetClass//SQL//Select.txt";
            strUpdatePath = strPath + "SetClass//SQL//Update.txt";
            strDeletePath = strPath + "SetClass//SQL//Delete.txt";
            strInsertPath = strPath + "SetClass//SQL//Insert.txt";
            strBLLPath = strPath + "SetClass//SQL//BLL.txt";
            strWebPath = strPath + "SetClass//SQL//Web.txt";
            strModulesPath = strPath + "SetClass//SQL//Modules.txt";
            strSPPath = strPath + "SetClass//SQL//SP.txt";

            string strDBOwner = GetOwer();
            DataTable dtTableName = new DataTable();

            objAccess.strSql = "select name  as table_name  from sysobjects where xtype='U' ORDER BY name";
            objAccess.IsSP = false;
            objAccess.SqlParams = null;
            dtTableName = objAccess.getDataSet();
            treeData.Nodes.Clear();
            FillTree(dtTableName);

            GetData();
        }
        /// <summary>
        /// ��ȡ���������
        /// </summary>
        /// <returns></returns>
        private string GetOwer()
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
                    case "strDBName":
                        strDBOwner = node2.InnerText.ToString();
                        break;
                    default:
                        break;
                }
            }

            return strDBOwner;
        }

        /// <summary>
        /// ������ݿ��ṹ
        /// </summary>
        /// <param name="A_dtbTableName"></param>
        private void FillTree(DataTable A_dtbTableName)
        {
            string strDBOwner = GetOwer();
            foreach (DataRow dr in A_dtbTableName.Rows)
            {

                TreeNode trn = new TreeNode();
                trn.Text = dr["table_name"].ToString();
                treeData.Nodes.Add(trn);
                treeData.SelectedNode = trn;
                objAccess.strSql = "SELECT COLUMN_NAME AS [ColName] FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + dr["table_name"].ToString() + "' ";
                objAccess.IsSP = false;
                objAccess.SqlParams = null;
                DataTable dtTableNameCol = new DataTable();
                dtTableNameCol = objAccess.getDataSet();

                foreach (DataRow dr1 in dtTableNameCol.Rows)
                {
                    TreeNode trn1 = new TreeNode();
                    trn1.Text = dr1["ColName"].ToString();
                    treeData.SelectedNode.Nodes.Add(trn1);
                }

            }
        }
        #endregion

        #region"ҳ������¼�"
        /// <summary>
        /// �رմ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ���ȫ�����ֶ���Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTableName.Text == "")
                {
                    listTableCol.Items.Clear();
                    txtTableName.Text = this.treeData.SelectedNode.Text.ToString();

                    foreach (TreeNode nd in treeData.SelectedNode.Nodes)
                    {
                        listTableCol.Items.Add(nd.Text.ToString());
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// ��ӱ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTableName_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTableName.Text == "")
                {
                    txtTableName.Text = this.treeData.SelectedNode.Text.ToString();
                }

            }
            catch
            {

            }
        }

        /// <summary>
        /// ���ѡ���ֶ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddColm_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeData.SelectedNode.Parent.Text == txtTableName.Text.ToString())
                {
                    if (listTableCol.FindString(treeData.SelectedNode.Text.ToString(), -1) == ListBox.NoMatches)
                    {
                        listTableCol.Items.Add(treeData.SelectedNode.Text.ToString());
                    }

                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearAllCol_Click(object sender, EventArgs e)
        {
            listTableCol.Items.Clear();
            listTableColWhere.Items.Clear();
            txtTableName.Text = "";
            txtCSMorSQLDAL.Text = "";
        }

        /// <summary>
        /// ��Ӳ�ѯ����ɾ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddWhereCol_Click(object sender, EventArgs e)
        {
            try
            {
                //listTableCol.Items.Remove(listTableColWhere.Text.ToString());
                listTableColWhere.Items.Add(listTableCol.SelectedItem);
            }
            catch
            {
            }
        }

        /// <summary>
        /// ɾ����ѯ,����,������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearTableCol_Click(object sender, EventArgs e)
        {
            listTableCol.Items.Remove(listTableCol.SelectedItem);
        }
        /// <summary>
        /// ɾ����ѯ,����,ɾ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearTableWhereCol_Click(object sender, EventArgs e)
        {
            listTableColWhere.Items.Remove(listTableColWhere.SelectedItem);
        }


        /// <summary>
        /// ��ѯ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            SaveSetStruct();
            if (CheckSelect())
            {
                TextWriter tmp = Console.Out;

                FileStream OutFile = new FileStream(strSelectPath, FileMode.Create);

                StreamWriter objWriter = new StreamWriter(OutFile);
                Console.SetOut(objWriter);
                //����ģ��		  									  
                GetSelect();
                objWriter.Close();
                Console.SetOut(tmp);
                OpenFile(strSelectPath);
                MessageBox.Show("��ѯ�������ɳɹ�,���Ե�SetClass�ļ����²鿴Select.txt�ļ�");
            }

        }

        /// <summary>
        /// ���ɸ��º�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SaveSetStruct();
            if (CheckUpdate())
            {
                TextWriter FileSQLDAL = Console.Out;

                FileStream OutFile = new FileStream(strUpdatePath, FileMode.Create);

                StreamWriter objWriter = new StreamWriter(OutFile);
                Console.SetOut(objWriter);

                GetUpdate();

                objWriter.Close();
                Console.SetOut(FileSQLDAL);
                OpenFile(strUpdatePath);
                MessageBox.Show("���·������ɳɹ�,���Ե�SetClass�ļ����²鿴Update.txt�ļ�");
            }
            else
            {

            }
        }

        /// <summary>
        /// ����ɾ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            SaveSetStruct();
            if (CheckInsert())
            {
                TextWriter FileSQLDAL = Console.Out;

                FileStream OutFile = new FileStream(strDeletePath, FileMode.Create);

                StreamWriter objWriter = new StreamWriter(OutFile);
                Console.SetOut(objWriter);


                GetDelete();

                objWriter.Close();
                Console.SetOut(FileSQLDAL);
                OpenFile(strDeletePath);
                MessageBox.Show("ɾ���������ɳɹ�,���Ե�SetClass�ļ����²鿴Delete.txt�ļ�");
            }
        }

        /// <summary>
        /// ���ɲ��뺯������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            SaveSetStruct();
            if (CheckInsert())
            {
                SaveSetStruct();
                TextWriter FileSQLDAL = Console.Out;

                FileStream OutFile = new FileStream(strInsertPath, FileMode.Create);

                StreamWriter objWriter = new StreamWriter(OutFile);
                Console.SetOut(objWriter);


                GetInsert();

                objWriter.Close();
                Console.SetOut(FileSQLDAL);
                OpenFile(strInsertPath);
                MessageBox.Show("���뷽�����ɳɹ�,���Ե�SetClass�ļ����²鿴Insert.txt�ļ�");
            }
        }

        /// <summary>
        /// ����BLL��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBLL_Click(object sender, EventArgs e)
        {
            SaveSetStruct();

            string strDBOwner = GetOwer();
            TextWriter tmp = Console.Out;
            FileStream OutFile = new FileStream(strBLLPath, FileMode.Create);
            StreamWriter objWriter = new StreamWriter(OutFile);
            Console.SetOut(objWriter);
            GetBLLClass();
            objWriter.Close();
            Console.SetOut(tmp);
            OpenFile(strBLLPath);
            MessageBox.Show("BLL�����ɳɹ�,���Ե�SetClass�ļ����²鿴BLL.txt�ļ�");

        }

        /// <summary>
        /// ����Webҳ�洫�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWeb_Click(object sender, EventArgs e)
        {
            SaveSetStruct();
            TextWriter FileSQLDAL = Console.Out;

            FileStream OutFile = new FileStream(strWebPath, FileMode.Create);

            StreamWriter objWriter = new StreamWriter(OutFile);
            Console.SetOut(objWriter);

            GetWeb();

            objWriter.Close();
            Console.SetOut(FileSQLDAL);
            OpenFile(strWebPath);
        }

        #endregion

        #region"���ɵ��÷������뺯��"
        /// <summary>
        /// ����select ��ѯ��������
        /// </summary>
        private void GetSelect()
        {
            Console.WriteLine("/// <summary>");
            Console.WriteLine("/// ����:     С��");
            Console.WriteLine("/// ����ʱ��: " + DateTime.Now.ToString("yyyy-MM-dd"));
            Console.WriteLine("/// ��������: ����������ȡ��ѯ����");
            Console.WriteLine("/// </summary>");
            Console.WriteLine("/// <param name=\" p_obj" + txtModule.Text + "\">");
            Console.WriteLine("/// ��ѯ����HashTable��KeyΪ:");
            int intp = 1;
            foreach (string strCol1 in listTableColWhere.Items)
            {

                objAccess.strSql = "Select o.name as tableName,c.name as columnName,p.value as Comments FROM sys.extended_properties p join sys.tables o on o.object_id=p.major_id join sys.syscolumns c on p.major_id=c.id  and p.minor_id=c.colid  where p.name='MS_Description'  and o.name='" + txtTableName.Text + "' and c.name='" + strCol1 + "'";
                objAccess.IsSP = false;
                DataTable dtbComment = objAccess.getDataSet();
                if (dtbComment.Rows.Count > 0)
                {
                    Console.WriteLine("/// " + intp.ToString() + ": " + strCol1.ToString() + "--" + dtbComment.Rows[0]["Comments"].ToString().Replace("\n", ""));
                }

                intp++;
            }
            Console.WriteLine("/// </param>");
            Console.WriteLine("/// <returns>���ز�ѯ������</returns>");

            Console.WriteLine("public DataTable Get" + txtTableName.Text.ToString().Replace("T_", "") + "Info(" + txtModuleSp.Text + "." + txtModule.Text + " p_obj" + txtModule.Text + ")");
            Console.WriteLine("{");
            Console.WriteLine("	string strSQL =\"\";");
            //*****************************************************************��ѯ���
            string strSelect = "";
            string strWhere = "";

            foreach (string strCol1 in listTableCol.Items)
            {
                if (strSelect != "")
                {
                    strSelect += ",";
                    strSelect += strCol1;
                }
                else
                {
                    strSelect += strCol1;
                }
            }

            foreach (string strCol1 in listTableColWhere.Items)
            {
                if (strWhere != "")
                {
                    strWhere += " and ";
                    strWhere += strCol1 + "=@" + strCol1;
                }
                else
                {
                    strWhere += strCol1 + "=@" + strCol1;
                }
            }

            Console.WriteLine("	strSQL =\"select " + strSelect + "  from " + txtTableName.Text.ToString().Replace("T_", "S_") + " where " + strWhere + "\";");
            int intCount = listTableColWhere.Items.Count;
            int i = 0;
            Console.WriteLine("SqlParameter[] objParameter = new SqlParameter[" + intCount.ToString() + "];");
            Console.WriteLine("");
            foreach (string strCol1 in listTableColWhere.Items)
            {

                objAccess.strSql = "SELECT COLUMN_NAME AS [ColName],DATA_TYPE AS [Type],CHARACTER_MAXIMUM_LENGTH AS [Length] ,CHARACTER_MAXIMUM_LENGTH AS [NumberLength] ,IS_NULLABLE as [IsNull] , COLUMN_DEFAULT as [DefaultValue] FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + txtTableName.Text.ToString() + "' and COLUMN_NAME='" + strCol1.ToString() + "'";
                objAccess.IsSP = false;
                DataTable dtbModule = objAccess.getDataSet();

                foreach (DataRow dr in dtbModule.Rows)
                {

                    string strIn = "";
                    string strLength = "";
                    string strOutType = "";
                    string strOutSqlType = "";
                    string strOutValue = "";
                    GetColInfo(dr["ColName"].ToString(), dr["Type"].ToString(), dr["Length"].ToString(), dr["NumberLength"].ToString(), out strIn, out strLength, out strOutType, out strOutSqlType, out strOutValue);

                    Console.WriteLine(" objParameter[" + i + "] = new SqlParameter(\"@" + strCol1.ToString() + "\", System.Data.SqlDbType." + GetOracleType(dr["Type"].ToString()) + " , " + strLength + ");");
                    Console.WriteLine(" objParameter[" + i + "].Value =  p_obj" + txtModule.Text + "." + strIn + ";");

                    Console.WriteLine("");
                }
                i++;
            }

            Console.WriteLine("	return this.ExecuteReadTable(strSQL, objParameter);");
            Console.WriteLine("}");


            //**************************************************************************************************************************
            Console.WriteLine("/// <summary>");
            Console.WriteLine("/// ����:     С��");
            Console.WriteLine("/// ����ʱ��: " + DateTime.Now.ToString("yyyy-MM-dd"));
            Console.WriteLine("/// ��������: ����������ȡ��ѯ����");
            Console.WriteLine("/// </summary>");
            Console.WriteLine("/// <param name=\" p_obj" + txtModule.Text + "\">");
            Console.WriteLine("/// ��ѯ����HashTable��KeyΪ:");
            intp = 1;
            foreach (string strCol1 in listTableColWhere.Items)
            {

                objAccess.strSql = "Select o.name as tableName,c.name as columnName,p.value as Comments FROM sys.extended_properties p join sys.tables o on o.object_id=p.major_id join sys.syscolumns c on p.major_id=c.id  and p.minor_id=c.colid  where p.name='MS_Description'  and o.name='" + txtTableName.Text + "' and c.name='" + strCol1 + "'";
                objAccess.IsSP = false;
                DataTable dtbComment = objAccess.getDataSet();
                if (dtbComment.Rows.Count > 0)
                {
                    Console.WriteLine("/// " + intp.ToString() + ": " + strCol1.ToString() + "--" + dtbComment.Rows[0]["Comments"].ToString().Replace("\n", ""));
                }

                intp++;
            }
            Console.WriteLine("/// </param>");
            Console.WriteLine("/// <returns>���ز�ѯ������</returns>");

            Console.WriteLine("public DataTable Get" + txtTableName.Text.ToString().Replace("T_", "") + "List(" + txtModuleSp.Text + "." + txtModule.Text + " p_obj" + txtModule.Text + ",int p_intStart, int p_intPageSize, ref int Out_Count,string p_strOrderBy)");
            Console.WriteLine("{");
            Console.WriteLine("	SqlParameter[] objParameter = new SqlParameter[0];");
            Console.WriteLine("	string strWhere = \"\";");
            Console.WriteLine("	SqlParameter SPNewParm = null;");
            Console.WriteLine("	ArrayList listParam = new ArrayList();");
            Console.WriteLine("	string strSQL =\"\";");
            //*****************************************************************��ѯ���
            strSelect = "";
            strWhere = "";

            foreach (string strCol1 in listTableCol.Items)
            {
                if (strSelect != "")
                {
                    strSelect += ",";
                    strSelect += strCol1;
                }
                else
                {
                    strSelect += strCol1;
                }
            }

            //foreach (string strCol1 in listTableColWhere.Items)
            //{
            //    if (strWhere != "")
            //    {
            //        strWhere += " and ";
            //        strWhere += strCol1 + "=@" + strCol1;
            //    }
            //    else
            //    {
            //        strWhere += strCol1 + "=@" + strCol1;
            //    }
            //}

            Console.WriteLine("	strSQL =\"select " + strSelect + "  from " + txtTableName.Text.ToString().Replace("T_", "S_") + " where " + strWhere + "\";");
            intCount = listTableColWhere.Items.Count;
            i = 0;
            // Console.WriteLine("SqlParameter[] objParameter = new SqlParameter[" + intCount.ToString() + "];");
            Console.WriteLine("");
            foreach (string strCol1 in listTableColWhere.Items)
            {

                objAccess.strSql = "SELECT COLUMN_NAME AS [ColName],DATA_TYPE AS [Type],CHARACTER_MAXIMUM_LENGTH AS [Length] ,CHARACTER_MAXIMUM_LENGTH AS [NumberLength] ,IS_NULLABLE as [IsNull] , COLUMN_DEFAULT as [DefaultValue] FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + txtTableName.Text.ToString() + "' and COLUMN_NAME='" + strCol1.ToString() + "'";
                objAccess.IsSP = false;
                DataTable dtbModule = objAccess.getDataSet();

                foreach (DataRow dr in dtbModule.Rows)
                {

                    string strIn = "";
                    string strLength = "";
                    string strOutType = "";
                    string strOutSqlType = "";
                    string strOutValue = "";
                    GetColInfo(dr["ColName"].ToString(), dr["Type"].ToString(), dr["Length"].ToString(), dr["NumberLength"].ToString(), out strIn, out strLength, out strOutType, out strOutSqlType, out strOutValue);

                    //Console.WriteLine(" objParameter[" + i + "] = new SqlParameter(\"@" + strCol1.ToString() + "\", System.Data.SqlDbType." + GetOracleType(dr["Type"].ToString()) + " , " + strLength + ");");
                    //Console.WriteLine(" objParameter[" + i + "].Value =  p_obj" + txtModule.Text + "." + strIn + ";");
                    if ((dr["Type"].ToString().ToLower() == "int" || dr["Type"].ToString().ToLower() == "float"))
                    {
                        Console.WriteLine(" if ( p_obj" + txtModule.Text + "." + strIn + "!= " + dr["Type"].ToString().ToLower() + ".MinValue  )");
                        Console.WriteLine(" {");
                        //Console.WriteLine(" objParameter[" + i + "].Value =" + dr["DefaultValue"].ToString().Trim().Replace("(", "").Replace(")", "") + ";");
                        Console.WriteLine(" SPNewParm = new SqlParameter(\"@" + strCol1.ToString() + "\", System.Data.SqlDbType." + GetOracleType(dr["Type"].ToString()) + " , " + strLength + ");");
                        Console.WriteLine(" SPNewParm.Value =  p_obj" + txtModule.Text + "." + strIn + ";");

                        Console.WriteLine("     listParam.Add(SPNewParm);");
                        Console.WriteLine("     strWhere += \" and " + strCol1.ToString() + " =@" + strCol1.ToString() + "  \";");

                        Console.WriteLine(" }");

                    }
                    else
                    {
                        Console.WriteLine(" if ( p_obj" + txtModule.Text + "." + strIn + "!= \"\" && p_obj" + txtModule.Text + "." + strIn + "!= null)");
                        Console.WriteLine(" {");
                        //Console.WriteLine(" objParameter[" + i + "].Value =" + dr["DefaultValue"].ToString().Trim().Replace("(", "").Replace(")", "") + ";");
                        Console.WriteLine(" SPNewParm = new SqlParameter(\"@" + strCol1.ToString() + "\", System.Data.SqlDbType." + GetOracleType(dr["Type"].ToString()) + " , " + strLength + ");");
                        Console.WriteLine(" SPNewParm.Value =  p_obj" + txtModule.Text + "." + strIn + ";");

                        Console.WriteLine("     listParam.Add(SPNewParm);");
                        Console.WriteLine("     strWhere += \" and " + strCol1.ToString() + " =@" + strCol1.ToString() + "  \";");

                        Console.WriteLine(" }");
                    }
                    Console.WriteLine("");
                }
                i++;
            }
            Console.WriteLine("objParameter = (SqlParameter[])listParam.ToArray(typeof(SqlParameter));");
            Console.WriteLine("if (p_strOrderBy.Trim() != \"\")");
            Console.WriteLine("{");
            Console.WriteLine("    p_strOrderBy = \" order by \" + p_strOrderBy;");
            Console.WriteLine("}");
            Console.WriteLine("strSQL = strSQL + strWhere + p_strOrderBy;");
            Console.WriteLine("	return this.ExecuteReadTable(strSQL, objParameter,p_intStart,p_intPageSize,ref Out_Count);");
            Console.WriteLine("}");

        }

        /// <summary>
        /// update��������
        /// </summary>
        private void GetUpdate()
        {
            Console.WriteLine("/// <summary>");
            Console.WriteLine("/// ����:     ***");
            Console.WriteLine("/// ����ʱ��: " + DateTime.Now.ToString("yyyy-MM-dd"));
            Console.WriteLine("/// ��������: �����������±�����");
            Console.WriteLine("/// </summary>");
            Console.WriteLine("/// <param name=\"p_obj" + txtModule.Text + "\">");
            Console.WriteLine("/// ��������Ϊ:");
            int intp = 1;
            foreach (string strCol1 in listTableColWhere.Items)
            {
                objAccess.strSql = "Select o.name as tableName,c.name as columnName,p.value as Comments FROM sys.extended_properties p join sys.tables o on o.object_id=p.major_id join sys.syscolumns c on p.major_id=c.id  and p.minor_id=c.colid  where p.name='MS_Description'  and o.name='" + txtTableName.Text + "' and c.name='" + strCol1 + "'";
                objAccess.IsSP = false;
                DataTable dtbComment = objAccess.getDataSet();
                if (dtbComment.Rows.Count > 0)
                {
                    Console.WriteLine("/// " + intp.ToString() + ": " + strCol1.ToString() + "--" + dtbComment.Rows[0]["Comments"].ToString().Replace("\n", ""));
                }
                intp++;
            }
            Console.WriteLine("/// �����ֶ�Ϊ:");
            intp = 1;
            foreach (string strCol1 in listTableCol.Items)
            {
                objAccess.strSql = "Select o.name as tableName,c.name as columnName,p.value as Comments FROM sys.extended_properties p join sys.tables o on o.object_id=p.major_id join sys.syscolumns c on p.major_id=c.id  and p.minor_id=c.colid  where p.name='MS_Description'  and o.name='" + txtTableName.Text + "' and c.name='" + strCol1 + "'";
                objAccess.IsSP = false;
                DataTable dtbComment = objAccess.getDataSet();
                if (dtbComment.Rows.Count > 0)
                {
                    Console.WriteLine("/// " + intp.ToString() + ": " + strCol1.ToString() + "--" + dtbComment.Rows[0]["Comments"].ToString().Replace("\n", ""));
                }
                intp++;
            }
            Console.WriteLine("/// </param>");
            Console.WriteLine("/// <returns>����Ӱ������</returns>");


            Console.WriteLine("    public  int   Update" + txtTableName.Text.ToString().Replace("T_", "") + " (" + txtModuleSp.Text + "." + txtModule.Text + " p_obj" + txtModule.Text + ")");
            Console.WriteLine("    {");

            Console.WriteLine("	string strSQL =\"\";");
            //*****************************************************************��ѯ���

            string strUpdateValue = "";
            string strWhere = "";
            int intCount = 0;
            intCount = listTableCol.Items.Count;
            int intParmas = intCount + listTableColWhere.Items.Count;
            foreach (string strCol1 in listTableCol.Items)
            {
                if (strUpdateValue != "")
                {
                    strUpdateValue += ",";
                    strUpdateValue += strCol1 + "=@" + strCol1;
                }
                else
                {
                    strUpdateValue += strCol1 + "=@" + strCol1;
                }
            }

            foreach (string strCol1 in listTableColWhere.Items)
            {
                if (strWhere != "")
                {
                    strWhere += " and ";
                    strWhere += strCol1 + "=@" + strCol1;
                }
                else
                {
                    strWhere += strCol1 + "=@" + strCol1;
                }
            }


            Console.WriteLine("	strSQL =\"update  " + txtTableName.Text.ToString().Replace("T_", "S_") + " set  " + strUpdateValue + "    where " + strWhere + "\";");
            Console.WriteLine("SqlParameter[] objParameter = new SqlParameter[" + intParmas + "];");
            Console.WriteLine(" ");

            Console.WriteLine("    ");

            int i = 0;
            //�����ֶ�
            foreach (string strCol1 in listTableCol.Items)
            {
                objAccess.strSql = "SELECT COLUMN_NAME AS [ColName],DATA_TYPE AS [Type],CHARACTER_MAXIMUM_LENGTH AS [Length] ,CHARACTER_MAXIMUM_LENGTH AS [NumberLength] ,IS_NULLABLE as [IsNull] , COLUMN_DEFAULT as [DefaultValue] FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + txtTableName.Text.ToString() + "' and COLUMN_NAME='" + strCol1.ToString() + "'";
                objAccess.IsSP = false;
                DataTable dtbModule = objAccess.getDataSet();
                foreach (DataRow dr in dtbModule.Rows)
                {

                    string strIn = "";
                    string strLength = "";
                    string strOutType = "";
                    string strOutSqlType = "";
                    string strOutValue = "";
                    GetColInfo(dr["ColName"].ToString(), dr["Type"].ToString(), dr["Length"].ToString(), dr["NumberLength"].ToString(), out strIn, out strLength, out strOutType, out strOutSqlType, out strOutValue);

                    Console.WriteLine(" objParameter[" + i + "] = new SqlParameter(\"@" + strCol1.ToString() + "\", System.Data.SqlDbType." + GetOracleType(dr["Type"].ToString()) + " , " + strLength + ");");
                    Console.WriteLine(" objParameter[" + i + "].Value =  p_obj" + txtModule.Text + "." + strIn + ";");
                    Console.WriteLine(" ");
                }
                i++;
            }
            //�����ֶ�
            foreach (string strCol1 in listTableColWhere.Items)
            {
                objAccess.strSql = "SELECT COLUMN_NAME AS [ColName],DATA_TYPE AS [Type],CHARACTER_MAXIMUM_LENGTH AS [Length] ,CHARACTER_MAXIMUM_LENGTH AS [NumberLength] ,IS_NULLABLE as [IsNull] , COLUMN_DEFAULT as [DefaultValue] FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + txtTableName.Text.ToString() + "' and COLUMN_NAME='" + strCol1.ToString() + "'";
                objAccess.IsSP = false;
                DataTable dtbModule = objAccess.getDataSet();

                foreach (DataRow dr in dtbModule.Rows)
                {
                    string strIn = "";
                    string strLength = "";
                    string strOutType = "";
                    string strOutSqlType = "";
                    string strOutValue = "";
                    GetColInfo(dr["ColName"].ToString(), dr["Type"].ToString(), dr["Length"].ToString(), dr["NumberLength"].ToString(), out strIn, out strLength, out strOutType, out strOutSqlType, out strOutValue);

                    Console.WriteLine(" objParameter[" + i + "] = new SqlParameter(\"@" + strCol1.ToString() + "\", System.Data.SqlDbType." + GetOracleType(dr["Type"].ToString()) + " , " + strLength + ");");
                    Console.WriteLine(" objParameter[" + i + "].Value =  p_obj" + txtModule.Text + "." + strIn + ";");
                    Console.WriteLine(" ");
                }
                i++;
            }

            Console.WriteLine("	return this.ExecuteSQL(strSQL, objParameter);");
            Console.WriteLine("    }");

        }

        /// <summary>
        /// ����delete ɾ����������
        /// </summary>
        private void GetDelete()
        {
            Console.WriteLine("/// <summary>");
            Console.WriteLine("/// ����:     С��");
            Console.WriteLine("/// ����ʱ��: " + DateTime.Now.ToString("yyyy-MM-dd"));
            Console.WriteLine("/// ��������: ��������ɾ��");
            Console.WriteLine("/// </summary>");
            Console.WriteLine("/// <param name=\"p_obj" + txtModule.Text + "\">");
            Console.WriteLine("/// ��������Ϊ:");
            int intp = 1;
            foreach (string strCol1 in listTableColWhere.Items)
            {
                objAccess.strSql = "Select o.name as tableName,c.name as columnName,p.value as Comments FROM sys.extended_properties p join sys.tables o on o.object_id=p.major_id join sys.syscolumns c on p.major_id=c.id  and p.minor_id=c.colid  where p.name='MS_Description'  and o.name='" + txtTableName.Text + "' and c.name='" + strCol1 + "'";
                objAccess.IsSP = false;
                DataTable dtbComment = objAccess.getDataSet();
                if (dtbComment.Rows.Count > 0)
                {
                    Console.WriteLine("/// " + intp.ToString() + ": " + strCol1.ToString() + "--" + dtbComment.Rows[0]["Comments"].ToString().Replace("\n", ""));
                }
                intp++;
            }
            Console.WriteLine("/// </param>");
            Console.WriteLine("/// <returns>����Ӱ������</returns>");
            Console.WriteLine("public int  Delete" + txtTableName.Text.ToString().Replace("T_", "") + "Info(" + txtModuleSp.Text + "." + txtModule.Text + " p_obj" + txtModule.Text + ")");
            Console.WriteLine("{");
            Console.WriteLine("	string strSQL =\"\";");
            //*****************************************************************
            string strWhere = "";

            foreach (string strCol1 in listTableColWhere.Items)
            {
                if (strWhere != "")
                {
                    strWhere += " and ";
                    strWhere += strCol1 + "=@" + strCol1;
                }
                else
                {
                    strWhere += strCol1 + "=@" + strCol1;
                }
            }

            Console.WriteLine("	strSQL =\"delete     from " + txtTableName.Text.ToString().Replace("T_", "S_") + " where " + strWhere + "\";");
            int intCount = listTableColWhere.Items.Count;
            int i = 0;
            Console.WriteLine("SqlParameter[] objParmas = new SqlParameter[" + intCount.ToString() + "];");

            foreach (string strCol1 in listTableColWhere.Items)
            {

                objAccess.strSql = "SELECT COLUMN_NAME AS [ColName],DATA_TYPE AS [Type],CHARACTER_MAXIMUM_LENGTH AS [Length] ,CHARACTER_MAXIMUM_LENGTH AS [NumberLength] ,IS_NULLABLE as [IsNull] , COLUMN_DEFAULT as [DefaultValue] FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + txtTableName.Text.ToString() + "' and COLUMN_NAME='" + strCol1.ToString() + "'";
                objAccess.IsSP = false;
                DataTable dtbModule = objAccess.getDataSet();

                foreach (DataRow dr in dtbModule.Rows)
                {

                    string strIn = "";
                    string strLength = "";
                    string strOutType = "";
                    string strOutSqlType = "";
                    string strOutValue = "";
                    GetColInfo(dr["ColName"].ToString(), dr["Type"].ToString(), dr["Length"].ToString(), dr["NumberLength"].ToString(), out strIn, out strLength, out strOutType, out strOutSqlType, out strOutValue);

                    Console.WriteLine(" objParmas[" + i + "] = new SqlParameter(\"@" + strCol1.ToString() + "\", System.Data.SqlDbType." + GetOracleType(dr["Type"].ToString()) + " , " + strLength + ");");
                    Console.WriteLine(" objParmas[" + i + "].Value = p_obj" + txtModule.Text + "." + strIn + ";");
                    Console.WriteLine(" ");
                }
                i++;
            }

            Console.WriteLine("	return this.ExecuteSQL(strSQL, objParmas);");
            Console.WriteLine("}");
        }

        /// <summary>
        /// insert  ��������
        /// </summary>
        private void GetInsert()
        {
            Console.WriteLine("/// <summary>");
            Console.WriteLine("/// ����:     С��");
            Console.WriteLine("/// ����ʱ��: " + DateTime.Now.ToString("yyyy-MM-dd"));
            Console.WriteLine("/// ��������: ���������");
            Console.WriteLine("/// </summary>");
            Console.WriteLine("/// <param name=\"p_obj" + txtModule.Text + "\">");
            Console.WriteLine("/// ������Ϊ:");
            int intp = 1;
            foreach (string strCol1 in listTableCol.Items)
            {
                objAccess.strSql = "Select o.name as tableName,c.name as columnName,p.value as Comments FROM sys.extended_properties p join sys.tables o on o.object_id=p.major_id join sys.syscolumns c on p.major_id=c.id  and p.minor_id=c.colid  where p.name='MS_Description'  and o.name='" + txtTableName.Text + "' and c.name='" + strCol1 + "'";
                objAccess.IsSP = false;
                DataTable dtbComment = objAccess.getDataSet();
                if (dtbComment.Rows.Count > 0)
                {
                    Console.WriteLine("/// " + intp.ToString() + ": " + strCol1.ToString() + "--" + dtbComment.Rows[0]["Comments"].ToString().Replace("\n", ""));
                }
                intp++;
            }
            Console.WriteLine("/// </param>");
            Console.WriteLine("/// <returns>����Ӱ������</returns>");

            Console.WriteLine("    public  int   Insert" + txtTableName.Text.ToString().Replace("T_", "") + " (" + txtModuleSp.Text + "." + txtModule.Text + " p_obj" + txtModule.Text + ")");
            Console.WriteLine("    {");

            Console.WriteLine("	string strSQL =\"\";");

            #region"���̶��в��������"
            //***********************************
            /*
            Console.WriteLine("	SqlParameter SPNewParm = null;");
            Console.WriteLine("	ArrayList listParam = new ArrayList();");
            Console.WriteLine("	SqlParameter[] objParameter;");
            Console.WriteLine("	string strCol = \"\";");
            Console.WriteLine("	string strColValue = \"\";");

            foreach (string strCol1 in listTableCol.Items)
            {
                objAccess.strSql = "SELECT COLUMN_NAME AS ColName,DATA_TYPE AS Type,Data_LENGTH AS Length ,Data_Precision as NumberLength ,NULLABLE as IsNull FROM all_tab_columns  WHERE TABLE_NAME = '" + txtTableName.Text.ToString() + "' and COLUMN_NAME='" + strCol1.ToString() + "' and owner='" + GetOwer() + "'";
                objAccess.IsSP = false;
                DataTable dtbModule = objAccess.getDataSet();
                foreach (DataRow dr in dtbModule.Rows)
                {

                    string strIn = "";
                    string strLength = "";
                    string strOutType = "";
                    string strOutSqlType = "";
                    string strOutValue = "";
                    GetColInfo(dr["ColName"].ToString(), dr["Type"].ToString(), dr["Length"].ToString(), dr["NumberLength"].ToString(), out strIn, out strLength, out strOutType, out strOutSqlType, out strOutValue);

                    Console.WriteLine("if (p_hasParameter[\"" + dr["ColName"].ToString() + "\"] != null)");
                    Console.WriteLine("{");
                    Console.WriteLine("	SPNewParm = new SqlParameter(\"" + dr["ColName"].ToString() + "\", System.Data.SqlDbType." + GetOracleType(dr["Type"].ToString()) + " , " + strLength + ");");
                    Console.WriteLine("	SPNewParm.Value =p_hasParameter[\"" + strCol1.ToString() + "\"];");
                    Console.WriteLine("	listParam.Add(SPNewParm);");
                    Console.WriteLine("	if (strCol != \"\")");
                    Console.WriteLine("	{");
                    Console.WriteLine("		strCol += \" ,\";");
                    Console.WriteLine("	}");
                    Console.WriteLine("	else");
                    Console.WriteLine("	{");
                    Console.WriteLine("		strCol += \"" + dr["ColName"].ToString() + "\";");
                    Console.WriteLine("	}");

                    Console.WriteLine("	if (strColValue != \"\")");
                    Console.WriteLine("	{");
                    Console.WriteLine("		strColValue += \" ,\";");
                    Console.WriteLine("		strColValue +=\":\"+\"" + dr["ColName"].ToString() + "\";");
                    Console.WriteLine("	}");
                    Console.WriteLine("	else");
                    Console.WriteLine("	{");
                    Console.WriteLine("		strColValue +=\":\"+\"" + dr["ColName"].ToString() + "\";");
                    Console.WriteLine("	}");
                    Console.WriteLine("}");
                    Console.WriteLine(" ");
                }
             

            }
            Console.WriteLine("	strSQL =\"insert into   " + txtTableName.Text.ToString().Replace("T_", "S_") + " (  \"+ strCol +\" ) values ( \"+strColValue+\")\";");

            Console.WriteLine("	objParameter = (SqlParameter[])listParam.ToArray(typeof(SqlParameter));");

            Console.WriteLine("	return this.ExecuteSQL(strSQL, objParameter);");
            Console.WriteLine("    }");
             */
            #endregion

            #region"�̶�����������"
            string strInsertValue = "";
            string strInserCol = "";
            int intCount = 0;
            intCount = listTableCol.Items.Count;
            int intParmas = intCount + 1;
            foreach (string strCol1 in listTableCol.Items)
            {
                if (strInsertValue != "")
                {
                    strInsertValue += ",";
                    strInsertValue += "@" + strCol1;
                }
                else
                {
                    strInsertValue += "@" + strCol1;
                }
                if (strInserCol != "")
                {
                    strInserCol += ",";
                    strInserCol += strCol1;
                }
                else
                {
                    strInserCol += strCol1;
                }
            }

            Console.WriteLine("	strSQL =\"insert into   " + txtTableName.Text.ToString().Replace("T_", "S_") + " (  " + strInserCol + " ) values ( " + strInsertValue + ")\";");
            Console.WriteLine("SqlParameter[] objParameter = new SqlParameter[" + intCount + "];");
            Console.WriteLine("    ");
            int i = 0;
            //�����ֶ�
            foreach (string strCol1 in listTableCol.Items)
            {
                objAccess.strSql = "SELECT COLUMN_NAME AS [ColName],DATA_TYPE AS [Type],CHARACTER_MAXIMUM_LENGTH AS [Length] ,CHARACTER_MAXIMUM_LENGTH AS [NumberLength] ,IS_NULLABLE as [IsNull] , COLUMN_DEFAULT as [DefaultValue] FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + txtTableName.Text.ToString() + "' and COLUMN_NAME='" + strCol1.ToString() + "'";
                objAccess.IsSP = false;
                DataTable dtbModule = objAccess.getDataSet();
                foreach (DataRow dr in dtbModule.Rows)
                {

                    string strIn = "";
                    string strLength = "";
                    string strOutType = "";
                    string strOutSqlType = "";
                    string strOutValue = "";
                    GetColInfo(dr["ColName"].ToString(), dr["Type"].ToString(), dr["Length"].ToString(), dr["NumberLength"].ToString(), out strIn, out strLength, out strOutType, out strOutSqlType, out strOutValue);

                    Console.WriteLine(" objParameter[" + i + "] = new SqlParameter(\"@" + strCol1.ToString() + "\", System.Data.SqlDbType." + GetOracleType(dr["Type"].ToString()) + " , " + strLength + ");");
                    if ((dr["Type"].ToString().ToLower() == "int" || dr["Type"].ToString().ToLower() == "float") && dr["DefaultValue"].ToString().Trim() != "")
                    {
                        Console.WriteLine(" if ( p_obj" + txtModule.Text + "." + strIn + "== " + dr["Type"].ToString().ToLower() + ".MinValue  )");
                        Console.WriteLine(" {");
                        Console.WriteLine(" objParameter[" + i + "].Value =" + dr["DefaultValue"].ToString().Trim().Replace("(", "").Replace(")", "") + ";");
                        Console.WriteLine(" }");
                        Console.WriteLine(" else");
                        Console.WriteLine(" {");
                        Console.WriteLine(" objParameter[" + i + "].Value =  p_obj" + txtModule.Text + "." + strIn + ";");
                        Console.WriteLine(" }");

                    }
                    else
                    {
                        Console.WriteLine(" objParameter[" + i + "].Value =  p_obj" + txtModule.Text + "." + strIn + ";");
                    }
                    Console.WriteLine(" ");
                }
                i++;
            }

            Console.WriteLine("	return this.ExecuteSQL(strSQL, objParameter);");
            Console.WriteLine("    }");
            #endregion

        }

        /// <summary>
        /// �����ɵķ����������
        /// </summary>
        private void GetBLLClass()
        {
            Console.WriteLine("using System;");
            Console.WriteLine("using System.Text;");
            Console.WriteLine("using System.Data;");
            Console.WriteLine("using System.Collections;");
            Console.WriteLine("using System.Data.SqlClient;");
            Console.WriteLine("using eHR.DBModules;");
            Console.WriteLine("namespace " + txtBLLNameSpace.Text.ToString());
            Console.WriteLine("{");
            Console.WriteLine("	///<summary>");
            //Console.WriteLine("	/// *******************************************************************************************************");
            Console.WriteLine("	/// ������:     С��");
            Console.WriteLine("	/// ����ʱ��:   " + DateTime.Now.ToString("yyyy-MM-dd"));
            Console.WriteLine("	/// �޸���:     С��");
            Console.WriteLine("	/// �޸�ʱ��:   0000-00-00");
            Console.WriteLine("	/// �޸�����:   ");
            Console.WriteLine("	/// �๦������: ");
            // Console.WriteLine("	/// *******************************************************************************************************");
            Console.WriteLine("	///</summary>");
            Console.WriteLine("    public class " + txtBLLClassName.Text.ToString() + ":SQLHelper");
            Console.WriteLine("      {");
            Console.WriteLine("	///<summary>");
            Console.WriteLine("	/// ���캯�� ");
            Console.WriteLine("	///</summary>");
            Console.WriteLine("public " + txtBLLClassName.Text.ToString() + "()");
            Console.WriteLine("{");
            Console.WriteLine("	//");
            Console.WriteLine("	// �ڴ˴���ӹ��캯���߼�");
            Console.WriteLine("	//");
            Console.WriteLine("}");

            TextWriter stringWriter = new StringWriter();
            TextReader stringReader =
                new StringReader(stringWriter.ToString());
            //��ѯ�ļ�����**************************************************************************
            if (cbxSelect.Checked == true)
            {
                using (TextReader streamReader =
                          new StreamReader(strSelectPath))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
            }
            //�����ļ�����**************************************************************************
            if (cbxInsert.Checked == true)
            {
                using (TextReader streamReader =
                          new StreamReader(strInsertPath))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
            }
            //�����ļ�����**************************************************************************
            if (cbxUpdate.Checked == true)
            {
                using (TextReader streamReader =
                          new StreamReader(strUpdatePath))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
            }
            //ɾ���ļ�����**************************************************************************
            if (cbxDelete.Checked == true)
            {
                using (TextReader streamReader =
                          new StreamReader(strDeletePath))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
            }
            Console.WriteLine("}");
            Console.WriteLine("}");

        }

        /// <summary>
        /// ����select ��ѯ��������
        /// </summary>
        private void GetWeb()
        {
            Console.WriteLine("/// <summary>");
            Console.WriteLine("/// ����Hastable");
            Console.WriteLine("/// </summary>");

            Console.WriteLine("public " + txtModuleSp.Text + "." + txtModule.Text + " Get" + txtTableName.Text.ToString().Replace("T_", "") + "Info()");
            Console.WriteLine("{");
            string strSet = "";
            //*****************************************************************��ѯ���
            Console.WriteLine(txtModuleSp.Text + "." + txtModule.Text + " obj" + txtModule.Text + " = new " + txtModuleSp.Text + "." + txtModule.Text + "();");
            foreach (string strCol1 in listTableCol.Items)
            {
                objAccess.strSql = "SELECT COLUMN_NAME AS [ColName],DATA_TYPE AS [Type],CHARACTER_MAXIMUM_LENGTH AS [Length] ,CHARACTER_MAXIMUM_LENGTH AS [NumberLength] ,IS_NULLABLE as [IsNull] , COLUMN_DEFAULT as [DefaultValue] FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + txtTableName.Text.ToString() + "' and COLUMN_NAME='" + strCol1.ToString() + "'";
                objAccess.IsSP = false;
                DataTable dtbModule = objAccess.getDataSet();

                foreach (DataRow dr in dtbModule.Rows)
                {

                    string strIn = "";
                    string strLength = "";
                    string strOutType = "";
                    string strOutSqlType = "";
                    string strOutValue = "";
                    GetColInfo(dr["ColName"].ToString(), dr["Type"].ToString(), dr["Length"].ToString(), dr["NumberLength"].ToString(), out strIn, out strLength, out strOutType, out strOutSqlType, out strOutValue);
                    if (strOutValue == "")
                    {
                        Console.WriteLine(strOutType + " " + strIn + " = \"\" ;");
                    }
                    else
                    {
                        Console.WriteLine(strOutType + " " + strIn + " = " + strOutValue + ";");
                    }

                }
            }
            foreach (string strCol1 in listTableCol.Items)
            {
                objAccess.strSql = "SELECT COLUMN_NAME AS [ColName],DATA_TYPE AS [Type],CHARACTER_MAXIMUM_LENGTH AS [Length] ,CHARACTER_MAXIMUM_LENGTH AS [NumberLength] ,IS_NULLABLE as [IsNull] , COLUMN_DEFAULT as [DefaultValue] FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + txtTableName.Text.ToString() + "' and COLUMN_NAME='" + strCol1.ToString() + "'";
                objAccess.IsSP = false;
                DataTable dtbModule = objAccess.getDataSet();

                foreach (DataRow dr in dtbModule.Rows)
                {

                    string strIn = "";
                    string strLength = "";
                    string strOutType = "";
                    string strOutSqlType = "";
                    string strOutValue = "";
                    GetColInfo(dr["ColName"].ToString(), dr["Type"].ToString(), dr["Length"].ToString(), dr["NumberLength"].ToString(), out strIn, out strLength, out strOutType, out strOutSqlType, out strOutValue);
                    if (strOutValue == "")
                    {
                        Console.WriteLine(strIn + " = txt" + dr["ColName"].ToString() + ".Text.Trim();");
                    }
                    else
                    {
                        Console.WriteLine(strIn + " = txt" + dr["ColName"].ToString() + ".Text.Trim();");
                    }

                }
            }


            foreach (string strCol1 in listTableCol.Items)
            {
                objAccess.strSql = "SELECT COLUMN_NAME AS [ColName],DATA_TYPE AS [Type],CHARACTER_MAXIMUM_LENGTH AS [Length] ,CHARACTER_MAXIMUM_LENGTH AS [NumberLength] ,IS_NULLABLE as [IsNull] , COLUMN_DEFAULT as [DefaultValue] FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + txtTableName.Text.ToString() + "' and COLUMN_NAME='" + strCol1.ToString() + "'";
                objAccess.IsSP = false;
                DataTable dtbModule = objAccess.getDataSet();



                foreach (DataRow dr in dtbModule.Rows)
                {

                    string strIn = "";
                    string strLength = "";
                    string strOutType = "";
                    string strOutSqlType = "";
                    string strOutValue = "";
                    GetColInfo(dr["ColName"].ToString(), dr["Type"].ToString(), dr["Length"].ToString(), dr["NumberLength"].ToString(), out strIn, out strLength, out strOutType, out strOutSqlType, out strOutValue);
                    Console.WriteLine(" obj" + txtModule.Text + "." + strIn + "=" + strIn + ";");
                }

            }


            Console.WriteLine(strSet);
            //Console.WriteLine("return  ");
            Console.WriteLine("}");


            Console.WriteLine("/// <summary>");
            Console.WriteLine("/// ����Hastable");
            Console.WriteLine("/// </summary>");

            Console.WriteLine("public  void  Set" + txtTableName.Text.ToString().Replace("T_", "") + "Info(DataTabele p_" + txtModule.Text + " )");
            Console.WriteLine("{");
            foreach (string strCol1 in listTableCol.Items)
            {
                objAccess.strSql = "SELECT COLUMN_NAME AS [ColName],DATA_TYPE AS [Type],CHARACTER_MAXIMUM_LENGTH AS [Length] ,CHARACTER_MAXIMUM_LENGTH AS [NumberLength] ,IS_NULLABLE as [IsNull] , COLUMN_DEFAULT as [DefaultValue] FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + txtTableName.Text.ToString() + "' and COLUMN_NAME='" + strCol1.ToString() + "'";
                objAccess.IsSP = false;
                DataTable dtbModule = objAccess.getDataSet();



                foreach (DataRow dr in dtbModule.Rows)
                {

                    string strIn = "";
                    string strLength = "";
                    string strOutType = "";
                    string strOutSqlType = "";
                    string strOutValue = "";
                    GetColInfo(dr["ColName"].ToString(), dr["Type"].ToString(), dr["Length"].ToString(), dr["NumberLength"].ToString(), out strIn, out strLength, out strOutType, out strOutSqlType, out strOutValue);
                    Console.WriteLine("txt" + dr["ColName"].ToString() + ".Text= dtb" + txtModule.Text.Replace("MD", "") + ".Rows[0].[\"" + dr["ColName"].ToString() + "\"].ToString();");
                }

            }
            Console.WriteLine("}");

        }
        #endregion

        #region"�������ʹ���"
        /// <summary>
        /// �������ݱ��е��е����͵õ�ǰ׺ sqltye������
        /// </summary>
        /// <param name="strColName"></param>
        /// <param name="strType"></param>
        /// <param name="strInLength"></param>
        /// <param name="strOut"></param>
        /// <param name="strOutLength"></param>
        /// <param name="stroutType"></param>
        /// <param name="strOutSqlType"></param>
        private void GetColInfo(string strColName, string strType, string strInLength, string strNumberLength, out string strOut, out string strOutLength, out string stroutType, out string strOutSqlType, out string strOutValue)
        {

            strOut = "";
            strOutLength = "";
            stroutType = "";
            strOutSqlType = "";
            strOutValue = "";

            switch (strType.ToLower())
            {
                case "float":
                    strOutLength = "8";
                    strOut = "flt" + strColName;
                    stroutType = "float";
                    strOutSqlType = "Float";
                    strOutValue = "=float.MinValue";
                    break;
                case "date":
                    strOutLength = "8";
                    strOut = "dtm" + strColName;
                    stroutType = "DateTime";
                    strOutSqlType = "DateTime";
                    strOutValue = "=DateTime.MinValue";
                    break;
                case "datetime":
                    strOutLength = "8";
                    strOut = "dtm" + strColName;
                    stroutType = "DateTime";
                    strOutSqlType = "DateTime";
                    strOutValue = "=DateTime.MinValue";
                    break;
                case "uniqueidentifier":
                    strOutLength = "16";
                    strOut = "str" + strColName;
                    stroutType = "string";
                    strOutSqlType = "UniqueIdentifier";
                    strOutValue = "";
                    break;
                case "int":
                    strOutLength = "4";
                    strOut = "int" + strColName;
                    stroutType = "int";
                    strOutSqlType = "Int";
                    strOutValue = "=int.MinValue";
                    break;
                case "bigint":
                    strOutLength = "8";
                    strOut = "int" + strColName;
                    stroutType = "long";
                    strOutSqlType = "BigInt";
                    strOutValue = "=long.MinValue";
                    break;
                case "smallint":
                    strOutLength = "2";
                    strOut = "int" + strColName;
                    stroutType = "short";
                    strOutSqlType = "SmallInt";
                    strOutValue = "=short.MinValue";
                    break;
                case "number":
                    strOutLength = "4";
                    strOut = "int" + strColName;
                    stroutType = "int";
                    strOutSqlType = "Int";
                    strOutValue = "=int.MinValue";
                    break;
                case "smalldatetime":
                    strOutLength = "4";
                    strOut = "dtm" + strColName;
                    stroutType = "DateTime";
                    strOutSqlType = "SmallDateTime";
                    strOutValue = "=DateTime.MinValue";
                    break;
                case "bit":
                    strOutLength = "1";
                    strOut = "bln" + strColName;
                    stroutType = "bool";
                    strOutSqlType = "Bit";
                    strOutValue = "";
                    break;
                case "real":
                    strOutLength = "4";
                    strOut = "rel" + strColName;
                    stroutType = "float";
                    strOutSqlType = "Real";
                    break;
                case "money":
                    strOutLength = "8";
                    strOut = "moy" + strColName;
                    stroutType = "Decimal";
                    strOutSqlType = "Money";
                    strOutValue = "=Decimal.MinValue";
                    break;
                case "char":
                    strOutLength = strInLength;
                    strOut = "str" + strColName;
                    stroutType = "string";
                    strOutSqlType = "Char";
                    strOutValue = "";
                    break;
                case "nvarchar":
                    strOutLength = strInLength;
                    strOut = "str" + strColName;
                    stroutType = "string";
                    strOutSqlType = "NVarChar";
                    strOutValue = "";
                    break;
                case "varchar2":
                    strOutLength = strInLength;
                    strOut = "str" + strColName;
                    stroutType = "string";
                    strOutSqlType = "VarChar";
                    strOutValue = "";
                    break;
                case "nchar":
                    strOutLength = strInLength;
                    strOut = "str" + strColName;
                    stroutType = "string";
                    strOutSqlType = "NChar";
                    strOutValue = "";
                    break;
                case "image":
                    strOutLength = strInLength;
                    strOut = "Img" + strColName;
                    stroutType = "byte[]";
                    strOutSqlType = "Image";

                    break;
                case "numeric":
                    strOutLength = "8";
                    strOut = "num" + strColName;
                    stroutType = "Decimal";
                    strOutSqlType = "numeric";
                    strOutValue = "=Decimal.MinValue";
                    break;


                default:
                    strOutLength = strInLength;
                    strOut = "str" + strColName;
                    stroutType = "string";
                    strOutSqlType = "NVarChar";
                    strOutValue = "";
                    break;
            }
        }

        /// <summary>
        /// ��ȡOracle��������
        /// </summary>
        /// <param name="strType"></param>
        /// <returns></returns>
        private string GetOracleType(string strType)
        {
            string strTypeValue;
            switch (strType.ToLower())
            {
                case "int":
                    strTypeValue = "Int";
                    break;

                case "char":
                    strTypeValue = "Char";
                    break;
                case "number":
                    strTypeValue = "Number";

                    break;
                case "varchar2":
                    strTypeValue = "VarChar";

                    break;
                case "date":
                    strTypeValue = "DateTime";

                    break;
                case "float":
                    strTypeValue = "Float";
                    break;
                case "nvarchar":
                    strTypeValue = "VarChar";
                    break;
                default:
                    strTypeValue = "VarChar";

                    break;

            }
            return strTypeValue;
        }
        #endregion

        #region"������ݺϷ���"
        private bool CheckSelect()
        {
            if (txtTableName.Text.ToString() == "")
            {
                MessageBox.Show("���±�δ���ã�", "����");
                return false;
            }
            if (listTableCol.Items.Count < 1)
            {
                MessageBox.Show("��ѯ�ֶ�δѡ��", "����");
                return false;
            }
            if (listTableColWhere.Items.Count < 1)
            {
                MessageBox.Show("��ѯ�����ֶ�δѡ��", "����");
                return false;
            }
            return true;
        }

        private bool CheckInsert()
        {
            if (txtTableName.Text.ToString() == "")
            {
                MessageBox.Show("�����δ���ã�", "����");
                return false;
            }
            if (listTableCol.Items.Count < 1)
            {
                MessageBox.Show("�����ֶ�δѡ��", "����");
                return false;
            }

            return true;
        }

        private bool CheckDelete()
        {

            if (listTableColWhere.Items.Count < 1)
            {
                MessageBox.Show("ɾ�������ֶ�δѡ��", "����");
                return false;
            }
            return true;
        }

        private bool CheckUpdate()
        {
            if (txtTableName.Text.ToString() == "")
            {
                MessageBox.Show("���±�δ���ã�", "����");
                return false;
            }
            if (listTableCol.Items.Count < 1)
            {
                MessageBox.Show("�����ֶ�δѡ��", "����");
                return false;
            }
            if (listTableColWhere.Items.Count < 1)
            {
                MessageBox.Show("���������ֶ�δѡ��", "����");
                return false;
            }
            return true;
        }
        #endregion

        #region"�ļ�����"
        /// <summary>
        /// ��xml�ļ� 
        /// </summary>
        private void OpenFile(string strFileName)
        {

            TextWriter stringWriter = new StringWriter();

            TextReader stringReader =
                new StringReader(stringWriter.ToString());
            using (TextReader streamReader =
                      new StreamReader(strFileName))
            {
                txtCSMorSQLDAL.Text = streamReader.ReadToEnd();
            }

        }

        /// <summary>
        /// ���������������
        /// </summary>
        /// <param name="A_strTableName"></param>
        private void SaveSetStruct()
        {
            string strPath = GetPath();
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(strSysSetPath);
            XmlNode node;
            node = myXmlDocument.DocumentElement;
            foreach (XmlNode node2 in node.ChildNodes)
            {
                switch (node2.Name.ToString())
                {
                    case "strSQLBLLName":
                        node2.InnerText = txtBLLClassName.Text.ToString();
                        break;
                    case "strSQLBLLNameSP":
                        node2.InnerText = txtBLLNameSpace.Text.ToString();
                        break;
                    case "strSQLModuleName":
                        node2.InnerText = txtModule.Text.ToString();
                        break;
                    case "strSQLModuleSP":
                        node2.InnerText = txtModuleSp.Text.ToString();
                        break;
                    default:
                        break;
                }
            }
            myXmlDocument.Save(strSysSetPath);
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

        /// <summary>
        /// �õ������������
        /// </summary>
        private void GetData()
        {

            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(strSysSetPath);
            XmlNode node;
            node = myXmlDocument.DocumentElement;
            foreach (XmlNode node2 in node.ChildNodes)
            {
                switch (node2.Name.ToString())
                {
                    case "strSQLBLLName":
                        txtBLLClassName.Text = node2.InnerText.ToString();
                        break;
                    case "strSQLBLLNameSP":
                        txtBLLNameSpace.Text = node2.InnerText.ToString();
                        break;
                    case "strSQLModuleName":
                        txtModule.Text = node2.InnerText.ToString();
                        break;
                    case "strSQLModuleSP":
                        txtModuleSp.Text = node2.InnerText.ToString();
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        private void btnModule_Click(object sender, EventArgs e)
        {
            TextWriter tmp = Console.Out;

            FileStream OutFile = new FileStream(strModulesPath, FileMode.Create);

            StreamWriter objWriter = new StreamWriter(OutFile);
            Console.SetOut(objWriter);
            //����ģ��		  									  
            SaveSetStruct();

            Console.WriteLine("using System;");
            //Console.WriteLine("using FinNet.Modules.Comm;");
            //			Console.WriteLine("using eHire.Module.COMM;");
            Console.WriteLine("namespace " + txtModuleSp.Text.ToString() + " ");
            Console.WriteLine("{");
            Console.WriteLine("  public class  " + txtModule.Text.ToString());
            Console.WriteLine("  {");

            Console.WriteLine(" ");
            Console.WriteLine("      //**********************************************");
            Console.WriteLine("      //* [С��]" + DateTime.Now.ToShortDateString());
            Console.WriteLine("      //* " + txtModuleSp.Text.ToString() + txtModule.Text.ToString() + "��*");
            Console.WriteLine("      //**********************************************");
            Console.WriteLine(" ");
            Console.WriteLine("  public   " + txtModule.Text.ToString() + "()");
            Console.WriteLine("    { ");
            Console.WriteLine("        //���캯��");
            Console.WriteLine("    }");

            SetModelInfo();

            objWriter.Close();
            Console.SetOut(tmp);
            OpenFile(strModulesPath);
            MessageBox.Show("���������ɳɹ�,���Ե�SetClass�ļ����²鿴Modules.txt�ļ�");
        }

        /// <summary>
        /// ���� model�ļ�
        /// </summary>
        private void SetModelInfo()
        {
            string str = "";
            ArrayList arrl = new ArrayList();
            string strDBElement = "";
            string strDBElement1 = "";

            Console.WriteLine("public   string  strTableName");
            Console.WriteLine("{");
            Console.WriteLine("	get ");
            Console.WriteLine("	{");
            Console.WriteLine("		return  \"" + txtTableName.Text.ToString().Replace("T_", "S_") + "\";");
            Console.WriteLine("	}");
            Console.WriteLine("}");

            strDBElement1 = "public static MDElement[] objMDElement= new MDElement [] \n        { \n";
            int i = 0;
            foreach (string strCol1 in listTableCol.Items)
            {
                i++;
                try
                {
                    objAccess.strSql = "SELECT COLUMN_NAME AS [ColName],DATA_TYPE AS [Type],CHARACTER_MAXIMUM_LENGTH AS [Length] ,CHARACTER_MAXIMUM_LENGTH AS [NumberLength] ,IS_NULLABLE as [IsNull] , COLUMN_DEFAULT as [DefaultValue] FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + txtTableName.Text.ToString() + "' and COLUMN_NAME='" + strCol1.ToString() + "'";
                    objAccess.IsSP = false;
                    DataTable dtbModule = objAccess.getDataSet();



                    foreach (DataRow dr in dtbModule.Rows)
                    {
                        string intLength = "0";
                        string strtype = "";

                        string strIn = "";
                        string strLength = "";
                        string strOutType = "";
                        string strOutSqlType = "";
                        string strOutValue = "";
                        GetColInfo(dr["ColName"].ToString(), dr["Type"].ToString(), dr["Length"].ToString(), dr["NumberLength"].ToString(), out strIn, out strLength, out strOutType, out strOutSqlType, out strOutValue);
                        if (dr["Type"].ToString() == "uniqueidentifier")
                        {
                            strtype = "nvarchar";
                            intLength = "50";
                        }
                        else
                        {
                            strtype = dr["Type"].ToString();
                            intLength = strLength;
                        }
                        if (i != listTableCol.Items.Count)
                        {
                            strDBElement1 += "           new MDElement(\"" + dr["ColName"].ToString() + "\",				\"" + strtype + "\",		" + intLength + ",				\"" + strIn + "\"),\n  ";
                        }
                        else
                        {
                            strDBElement1 += "           new MDElement(\"" + dr["ColName"].ToString() + "\",				\"" + strtype + "\",		" + intLength + ",				\"" + strIn + "\")";
                        }

                    }

                }
                catch
                {

                }
            }
            Dictionary<string, string> dicDBTyle = new Dictionary<string, string>();
            foreach (string strCol1 in listTableCol.Items)
            {
                try
                {
                    objAccess.strSql = "SELECT COLUMN_NAME AS [ColName],DATA_TYPE AS [Type],CHARACTER_MAXIMUM_LENGTH AS [Length] ,CHARACTER_MAXIMUM_LENGTH AS [NumberLength] ,IS_NULLABLE as [IsNull] , COLUMN_DEFAULT as [DefaultValue] FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + txtTableName.Text.ToString() + "' and COLUMN_NAME='" + strCol1.ToString() + "'";
                    objAccess.IsSP = false;
                    DataTable dtbModule = objAccess.getDataSet();

                    objAccess.strSql = "Select o.name as tableName,c.name as columnName,p.value as Comments FROM sys.extended_properties p join sys.tables o on o.object_id=p.major_id join sys.syscolumns c on p.major_id=c.id  and p.minor_id=c.colid  where p.name='MS_Description'  and o.name='" + txtTableName.Text + "' and c.name='" + strCol1 + "'";
                    objAccess.IsSP = false;
                    DataTable dtbComment = objAccess.getDataSet();
                    foreach (DataRow dr in dtbModule.Rows)
                    {
                        string strIn = "";
                        string strLength = "";
                        string strOutType = "";
                        string strOutSqlType = "";
                        string strOutValue = "";
                        GetColInfo(dr["ColName"].ToString(), dr["Type"].ToString(), dr["Length"].ToString(), dr["NumberLength"].ToString(), out strIn, out strLength, out strOutType, out strOutSqlType, out strOutValue);
                        if (!dicDBTyle.ContainsKey(dr["Type"].ToString() + "|" + dr["Length"].ToString()))
                        {
                            dicDBTyle[dr["Type"].ToString() + "|" + dr["Length"].ToString()] = strIn;
                        }
                        else
                        {
                            dicDBTyle[dr["Type"].ToString() + "|" + dr["Length"].ToString()] += "," + strIn;
                        }

                        Console.WriteLine("    private  " + strOutType + "  _" + strIn + strOutValue + ";");
                        Console.WriteLine("    ///<summary>");
                        if (dtbComment.Rows.Count > 0)
                        {
                            Console.WriteLine("    ///" + dtbComment.Rows[0]["Comments"].ToString().Replace("\n", ""));
                        }
                        Console.WriteLine("    ///</summary>");
                        Console.WriteLine("    public   " + strOutType + "  " + strIn);
                        Console.WriteLine("    {");
                        Console.WriteLine("      get ");
                        Console.WriteLine("        {");
                        Console.WriteLine("           return " + " _" + strIn + ";");
                        Console.WriteLine("        }");
                        Console.WriteLine("      set ");
                        Console.WriteLine("        {");
                        Console.WriteLine("           _" + strIn + "= value" + ";");
                        Console.WriteLine("        }");
                        Console.WriteLine("    }");

                        Console.WriteLine("  ");

                        if (str != "")
                        {
                            str = str + ", ";
                            str = str + strOutType + " A_" + strIn;
                            arrl.Add("_" + strIn + " = A_" + strIn + ";");
                        }
                        else
                        {
                            str = str + strOutType + " A_" + strIn;
                            arrl.Add("_" + strIn + " = A_" + strIn + ";");

                        }
                        if (strDBElement != "")
                        {
                            strDBElement += ", \n";
                            strDBElement += "        new MDElement(\"" + dr["ColName"].ToString() + "\",				\"" + dr["Type"].ToString() + "\",		" + strLength + ",				\"" + strIn + "\")  ";
                        }
                        else
                        {
                            strDBElement += "        new MDElement(\"" + dr["ColName"].ToString() + "\",				\"" + dr["Type"].ToString() + "\",		" + strLength + ",				\"" + strIn + "\")  ";

                        }
                    }


                }
                catch
                {

                }
            }



            Console.WriteLine("    public " + txtModule.Text.ToString() + "( " + str + " )");
            Console.WriteLine("    { ");
            foreach (string strArr in arrl)
            {
                Console.WriteLine("      " + strArr);
            }
            Console.WriteLine("    } ");

            Console.WriteLine("    ///<summary>");
            Console.WriteLine("    ///��ȡ���Զ�Ӧ�����ݿ��ֶ���Ϣ");
            Console.WriteLine("    ///</summary>");
            Console.WriteLine("    public Comm.DBElement GetDBElement(string strPropertyName)");
            Console.WriteLine("    {");
            Console.WriteLine("        switch (strPropertyName)");
            Console.WriteLine("        {");
            foreach (KeyValuePair<string, string> kvp in dicDBTyle)
            {
                foreach (string strPro in kvp.Value.Split(','))
                {
                    Console.WriteLine("            case \"" + strPro + "\":");
                }
                Console.WriteLine("                return new Comm.DBElement(strPropertyName.Substring(3), \"" + kvp.Key.Split('|')[0] + "\", " + GetLength(kvp.Key.Split('|')[0], kvp.Key.Split('|')[1]) + ", strPropertyName);");
            }
            Console.WriteLine("            default:");
            Console.WriteLine("                return null;");
            Console.WriteLine("        }");
            Console.WriteLine("    }");

            // Console.WriteLine(strDBElement1);
            // Console.WriteLine("    ");
            //Console.WriteLine("         };");
            Console.WriteLine("    }  ");
            Console.WriteLine("}");
        }


        /// <summary>
        /// ��ȡĳһ���͵����ݿ��ֽڳ���
        /// </summary>
        /// <param name="p_strDBType"></param>
        /// <param name="p_strDBLen"></param>
        /// <returns></returns>
        private string GetLength(string p_strDBType, string p_strDBLen)
        {
            switch (p_strDBType.ToLower())
            {
                case "uniqueidentifier":
                    return "16";
                case "bigint":
                case "money":
                case "float":
                case "datetime":
                case "smalldatetime":
                case "timestamp":
                    return "8";
                case "int":
                case "smallmoney":
                case "real":
                    return "4";
                case "smallint":
                    return "2";
                case "tinyint":
                case "bit":
                    return "1";
                default:
                    return string.IsNullOrEmpty(p_strDBLen) ? "255" : p_strDBLen;
            }
        }

    }
}