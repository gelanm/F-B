using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// ʵ����newscontent ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class newscontent
	{
		public newscontent()
		{}
		#region Model
		private int? _id;
		private string _title;
		private string _faburen;
		private DateTime _time;
		private string _content;
		private int _hit;
		private string _keywords;
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
		#endregion Model

	}
}

