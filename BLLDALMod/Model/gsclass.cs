using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 实体类gsclass 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class gsclass
	{
		public gsclass()
		{}
		#region Model
		private int? _id;
		private string _classname;
		private int _classid;
		private string _content;
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
		public string classname
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int classid
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		#endregion Model

	}
}

