using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLDALMod.Model
{
    [Serializable]
    public class ChatRoom
    {
        public ChatRoom()
        {
            //构造函数
        }
 
        private int _intFromID = int.MinValue;
        ///<summary>
        ///</summary>
        public int intFromID
        {
            get
            {
                return _intFromID;
            }
            set
            {
                _intFromID = value;
            }
        }

        private int _intToID = int.MinValue;
        ///<summary>
        ///</summary>
        public int intToID
        {
            get
            {
                return _intToID;
            }
            set
            {
                _intToID = value;
            }
        }

        private string _strContent;
        ///<summary>
        ///</summary>
        public string strContent
        {
            get
            {
                return _strContent;
            }
            set
            {
                _strContent = value;
            }
        }

        private DateTime _dtmCreateDateTime = DateTime.MinValue;
        ///<summary>
        ///</summary>
        public DateTime dtmCreateDateTime
        {
            get
            {
                return _dtmCreateDateTime;
            }
            set
            {
                _dtmCreateDateTime = value;
            }
        }

        private DateTime _dtmUpdateDate = DateTime.MinValue;
        ///<summary>
        ///</summary>
        public DateTime dtmUpdateDate
        {
            get
            {
                return _dtmUpdateDate;
            }
            set
            {
                _dtmUpdateDate = value;
            }
        }

        private string _strType;
        ///<summary>
        ///</summary>
        public string strType
        {
            get
            {
                return _strType;
            }
            set
            {
                _strType = value;
            }
        }

        private int _intStatus = int.MinValue;
        ///<summary>
        ///</summary>
        public int intStatus
        {
            get
            {
                return _intStatus;
            }
            set
            {
                _intStatus = value;
            }
        }
    }
}
