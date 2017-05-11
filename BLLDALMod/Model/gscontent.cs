using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 实体类gscontent 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class gscontent
	{
		public gscontent()
		{}
		#region Model
		private int? _id;
		private string _title;
		private string _faburen;
		private DateTime _time;
		private string _content;
		private int _hit;
		private string _keywords;
		private int _classid;
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
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string faburen
		{
			set{ _faburen=value;}
			get{return _faburen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime time
		{
			set{ _time=value;}
			get{return _time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int hit
		{
			set{ _hit=value;}
			get{return _hit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string keywords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int classid
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		#endregion Model

	}
}

