using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace PetDev.WFControl
{
	/// <summary>
	/// UCTreeView ��ժҪ˵����
	/// </summary>
	public class UCTreeView : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TreeView treeData;
		/// <summary> 
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UCTreeView()
		{
			// �õ����� Windows.Forms ���������������ġ�
			InitializeComponent();

			// TODO: �� InitializeComponent ���ú�����κγ�ʼ��

		}

		/// <summary> 
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region �����������ɵĴ���
		/// <summary> 
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭�� 
		/// �޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("�ڵ�7");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("�ڵ�6", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("�ڵ�0", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("�ڵ�9");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("�ڵ�8", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("�ڵ�1", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("�ڵ�2");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("�ڵ�5");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("�ڵ�4", new System.Windows.Forms.TreeNode[] {
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("�ڵ�3", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.treeData = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeData
            // 
            this.treeData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeData.Indent = 19;
            this.treeData.ItemHeight = 14;
            this.treeData.Location = new System.Drawing.Point(40, 16);
            this.treeData.Name = "treeData";
            treeNode1.Name = "";
            treeNode1.Text = "�ڵ�7";
            treeNode2.Name = "";
            treeNode2.Text = "�ڵ�6";
            treeNode3.Name = "";
            treeNode3.Text = "�ڵ�0";
            treeNode4.Name = "";
            treeNode4.Text = "�ڵ�9";
            treeNode5.Name = "";
            treeNode5.Text = "�ڵ�8";
            treeNode6.Name = "";
            treeNode6.Text = "�ڵ�1";
            treeNode7.Name = "";
            treeNode7.Text = "�ڵ�2";
            treeNode8.Name = "";
            treeNode8.Text = "�ڵ�5";
            treeNode9.Name = "";
            treeNode9.Text = "�ڵ�4";
            treeNode10.Name = "";
            treeNode10.Text = "�ڵ�3";
            this.treeData.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode7,
            treeNode10});
            this.treeData.Size = new System.Drawing.Size(164, 680);
            this.treeData.TabIndex = 26;
            // 
            // UCTreeView
            // 
            this.Controls.Add(this.treeData);
            this.Name = "UCTreeView";
            this.Size = new System.Drawing.Size(248, 728);
            this.Load += new System.EventHandler(this.UCTreeView_Load);
            this.ResumeLayout(false);

		}
		#endregion

        private void UCTreeView_Load(object sender, EventArgs e)
        {

        }
	}
}
