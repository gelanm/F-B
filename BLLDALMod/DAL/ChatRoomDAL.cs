using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLLDALMod.Model;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace BLLDALMod.DAL
{
    public partial class ChatRoomDAL
    {
        public ChatRoomDAL()
		{
        
        }

		#region Method
        public int Add(ChatRoom model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ChatRoom(");
            strSql.Append("FromID, ToID, Content, CreateDateTime, Type, Status)");
            strSql.Append(" values (");
            strSql.Append("@FromID, @ToID, @Content, @CreateDateTime, @Type, @Status)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					new MySqlParameter("@FromID", MySqlDbType.Int16,4),
					new MySqlParameter("@ToID", MySqlDbType.Int16,4),
                    new MySqlParameter("@Content", MySqlDbType.VarChar, 2000),
                    new MySqlParameter("@CreateDateTime", MySqlDbType.DateTime),
                    new MySqlParameter("@Type", MySqlDbType.VarChar, 20),
                    new MySqlParameter("@Status", MySqlDbType.Int16,4)};
            parameters[0].Value = model.intFromID;
            parameters[1].Value = model.intToID;
            parameters[2].Value = model.strContent;
            parameters[3].Value = model.dtmCreateDateTime;
            parameters[4].Value = model.strType;
            parameters[5].Value = model.intStatus;
            object obj = DBhelpmysql.Add(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public bool Update(ChatRoom model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ChatRoom set ");
            strSql.Append("Status=@Status,");
            strSql.Append("UpdateDate=@UpdateDate");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@Status", MySqlDbType.Int32,16),
					new MySqlParameter("@UpdateDate", MySqlDbType.DateTime),
                    new MySqlParameter("@id", MySqlDbType.Int32,4)};
            parameters[0].Value = model.intStatus;
            parameters[1].Value = model.dtmUpdateDate;
            parameters[2].Value = model.intID;

            int rows = DBhelpmysql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            return true;
        }
        public int getChatCount(int fuserId,int tuserId)
        {
            string sql = string.Format("select  count(1)  from ChatRoom where FromID = {0} and ToId = {1} and Status = 0 order by CreateDateTime desc ", fuserId, tuserId);
            return DBhelpmysql.Count(sql);
        }
        public int getChatCount(int tuserId)
        {
            string sql = string.Format("select  count(1)  from ChatRoom where  ToId = {0} and Status = 0 order by CreateDateTime desc ", tuserId);
            return DBhelpmysql.Count(sql);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append(" FROM ChatRoom ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBhelpmysql.Select(strSql.ToString(),null);
        }
        
        public DataTable GetCurrentMessageList(int fid, int tid, int count){
            string sql = string.Format("select * from ChatRoom where FromId = {0} and ToId = {1} or  FromId = {1} and ToId = {0} order by CreateDateTime desc limit 0,{2} ", fid, tid, count);
            return DBhelpmysql.Select(sql, null);
        }

        public DataTable GetCurrentMessageList(int userid, int count)
        {
            string sql = string.Format("select * from ChatRoom where ToId = {0} order by CreateDateTime desc limit 0,{1} ", userid, count);
            return DBhelpmysql.Select(sql, null);
        }
        public DataTable GetCurrentMessageList(int userid)
        {
            string sql = string.Format("select * from ChatRoom where ToId = {0} and Status = 0 order by CreateDateTime desc ", userid);
            return DBhelpmysql.Select(sql, null);
        }
        #endregion
    }
}
