using BLLDALMod.DAL;
using BLLDALMod.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLLDALMod.BLL
{
    public partial class ChatRoomBLL
    {
        private readonly ChatRoomDAL dal = new ChatRoomDAL();
        public ChatRoomBLL()
        { }
        public int Add(ChatRoom model)
        {
           return dal.Add(model);
        }

        public bool Update(ChatRoom model)
        {
            return dal.Update(model);
        }

        public bool Delete(int Id)
        {
            return true;
        }
        public int getChatCount(int userId) {
            return dal.getChatCount(userId);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public DataTable GetCurrentMessageList(int fid, int tid, int count)
        {
            return dal.GetCurrentMessageList(fid, tid, count);
            
        }
        public DataTable GetCurrentMessageList(int userid, int count)
        {
            return dal.GetCurrentMessageList(userid, count);
        }
        public DataTable GetCurrentMessageList(int userid)
        {
            return dal.GetCurrentMessageList(userid);
        }
    }
}
