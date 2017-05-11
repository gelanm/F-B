using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 实体类product 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class product
	{
		public product()
		{}
		#region Model
		private int? _id;
		private string _protitle;
		private string _projianjie;
		private string _projiage;
		private string _proxinhao;
		private string _proleibei;
		private string _procontent;
		private DateTime _fabutime;
		private string _propic;
        private int? _classid;
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
		public string protitle
		{
			set{ _protitle=value;}
			get{return _protitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string projianjie
		{
			set{ _projianjie=value;}
			get{return _projianjie;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string projiage
		{
			set{ _projiage=value;}
			get{return _projiage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string proxinhao
		{
			set{ _proxinhao=value;}
			get{return _proxinhao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string proleibei
		{
			set{ _proleibei=value;}
			get{return _proleibei;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string procontent
		{
			set{ _procontent=value;}
			get{return _procontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime fabutime
		{
			set{ _fabutime=value;}
			get{return _fabutime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string propic
		{
			set{ _propic=value;}
			get{return _propic;}
		}
        public int? classid
        {
            set { _classid = value; }
            get { return _classid; }
        }
		#endregion Model

	}
}

