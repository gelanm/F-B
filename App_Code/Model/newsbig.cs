using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// ʵ����newsbig ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class newsbig
	{
		public newsbig()
		{}
		#region Model
		private int? _id;
		private string _newsclass;
		private int _newsid;
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
		public string newsclass
		{
			set{ _newsclass=value;}
			get{return _newsclass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int newsid
		{
			set{ _newsid=value;}
			get{return _newsid;}
		}
		#endregion Model

	}
}

