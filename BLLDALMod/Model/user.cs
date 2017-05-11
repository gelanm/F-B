using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 实体类user 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class user
	{
		public user()
		{}
		#region Model
		private int? _id;
		private string _admin;
		private string _pass;
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
		public string admin
		{
			set{ _admin=value;}
			get{return _admin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pass
		{
			set{ _pass=value;}
			get{return _pass;}
		}
		#endregion Model

	}
}

