using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// 实体类book 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class book
    {
        public book()
        { }
        #region Model
        private int? _id;
        private string _liuyantitle;
        private string _liuyangcontent;
        private string _username;
        private string _phonenum;
        private DateTime _liuyantitme;
        private string _hueifu;
        /// <summary>
        /// 
        /// </summary>
        public int? id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string liuyantitle
        {
            set { _liuyantitle = value; }
            get { return _liuyantitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        public string phonenum
        {
            set { _phonenum = value; }
            get { return _phonenum; }
        }
        public string liuyangcontent
        {
            set { _liuyangcontent = value; }
            get { return _liuyangcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime liuyantitme
        {
            set { _liuyantitme = value; }
            get { return _liuyantitme; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hueifu
        {
            set { _hueifu = value; }
            get { return _hueifu; }
        }
        #endregion Model

    }
}