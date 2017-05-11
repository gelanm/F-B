using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 实体类wangzhan 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class wangzhan
	{
		public wangzhan()
		{}
		#region Model
		private int? _id;
		private string _gsname;
		private string _zongbu;
		private string _jidi;
		private string _dianhua;
		private string _chuanzheng;
		private string _youbian;
		private string _dizhi;
        private string _lianxiwm;
		/// <summary>
		/// 
		/// </summary>
		public int? id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string gsname
		{
			set{ _gsname=value;}
			get{return _gsname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zongbu
		{
			set{ _zongbu=value;}
			get{return _zongbu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jidi
		{
			set{ _jidi=value;}
			get{return _jidi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dianhua
		{
			set{ _dianhua=value;}
			get{return _dianhua;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string chuanzheng
		{
			set{ _chuanzheng=value;}
			get{return _chuanzheng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string youbian
		{
			set{ _youbian=value;}
			get{return _youbian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dizhi
		{
			set{ _dizhi=value;}
			get{return _dizhi;}
		}
        public string lianxiwm
        {
            set { _lianxiwm = value; }
            get { return _lianxiwm; }
        }
		#endregion Model

	}
}

