using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLDALMod.Model
{
    [Serializable]
    public partial class WXUser
    {
        public WXUser()
        { }
        #region Model
        private int _id;
        private string _openid;
        private string _unionid;
        private string _nickname;
        private int _sex;
        private string _province;
        private string _city;
        private string _country;
        private string _headimgurl;
        private string _access_token;
        private string _refresh_token;
        private DateTime _adddate;
        private DateTime _updatetime;
        private string _memo;
        private string _status;
        private string _latitude;
        private string _longitude;

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OpenId
        {
            set { _openid = value; }
            get { return _openid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UnionId
        {
            set { _unionid = value; }
            get { return _unionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NickName
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Country
        {
            set { _country = value; }
            get { return _country; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HeadimgUrl
        {
            set { _headimgurl = value; }
            get { return _headimgurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AccessToken
        {
            set { _access_token = value; }
            get { return _access_token; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RefreshToken
        {
            set { _refresh_token = value; }
            get { return _refresh_token; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Latitude
        {
            set { _latitude = value; }
            get { return _latitude; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Longitude
        {
            set { _longitude = value; }
            get { return _longitude; }
        }


        #endregion Model

    }
}
