using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLDALMod.Model
{
    [Serializable]
    public partial class orders
    {
        public orders()
        { }
        #region Model
        private int _id;
        private string _ordernumber;
        private int _aid;
        private int _bid;
        private int _agoodid;
        private int _bgoodid;  
        private DateTime _createdate;
        private DateTime _updatetime;
        private string _memo;
        private string _status;

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
        public string OrderNumber
        {
            set { _ordernumber = value; }
            get { return _ordernumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Aid
        {
            set { _aid = value; }
            get { return _aid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Bid
        {
            set { _bid = value; }
            get { return _bid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AGoodId
        {
            set { _agoodid = value; }
            get { return _agoodid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BGoodId
        {
            set { _bgoodid = value; }
            get { return _bgoodid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
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
        #endregion Model

    }
}
 