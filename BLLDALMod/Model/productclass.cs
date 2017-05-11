using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 实体类productclass 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class productclass
	{
		public productclass()
		{}
		#region Model
		private int? _id;
		private string _productname;
		private int _productid;
        private string _content;
        private string _propic;
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
		public string productname
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int productid
		{
			set{ _productid=value;}
			get{return _productid;}
		}
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        public string propic
        {
            set { _propic = value; }
            get { return _propic; }
        }
		#endregion Model

	}
}

