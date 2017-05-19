using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Drawing;

namespace BLLDALMod.Comm.UI
{
    /// 类功能描述: 分页控件,页面选择10 20 50显示,跳转到第几页,上页下页.
    /// </summary>
    public partial class ctrlPage : Label, INamingContainer
    {
        #region "定义包含控件名称"
        /// <summary>
        /// 分页组按钮
        /// </summary>
        private LinkButton[] m_lbtnPagingButtons;

        /// <summary>
        /// 上一页 带连接(有上一页)
        /// </summary>
        public LinkButton previousButton;
        /// <summary>
        /// 下一页 带连接(有下一页)
        /// </summary>
        public LinkButton nextButton;
        /// <summary>
        /// 上一页 不带连接(无上一页)
        /// </summary>
        public Literal previousLabel;
        /// <summary>
        /// 下一页 不带连接(无有下一页)
        /// </summary>
        public Literal nextLabel;
        /// <summary>
        /// "每页显示"说明,在10butten前
        /// </summary>
        public Literal TenLabel;
        /// <summary>
        /// 错误提示暂时不使用
        /// </summary>
        public Label litError;
        /// <summary>
        /// 跳转到第几页的页码输入框
        /// </summary>
        public TextBox txtGO;
        /// <summary>
        /// 跳转button
        /// </summary>
        public LinkButton lbtnGO;

        public Button TwentyButton;
        public Button FiftyButton;
        public Button HundredButton;
        public Button TotalButton;
        public Button ThousandButton;

        public Literal SplitLabel1;
        private ctrlPage m_objLinkagePager = null;

        #endregion

        #region "页面重写函数"

        /// <summary>
        /// CreateBy:BeautyMyth
        /// 在点击分页控件时是否需要Loading效果
        /// </summary>
        public bool IsShowLoading
        {
            get
            {
                return this.ViewState["IsShowLoading"] != null ? Convert.ToBoolean(this.ViewState["IsShowLoading"]) : false;
            }
            set
            {
                this.ViewState["IsShowLoading"] = value;
            }
        }

        /// <summary>
        /// 重写 提供使 ASP.NET 服务器控件能够维护其子控件列表的集合容器
        /// </summary>
        /// 
        public override ControlCollection Controls
        {
            get
            {
                return base.Controls;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override object SaveViewState()
        {
            return base.SaveViewState();
        }

        /// <summary>
        /// 创建子控件
        /// </summary>
        protected override void CreateChildControls()
        {
            if (this.DesignMode)
                return;
            Controls.Clear();

            TwentyButton = new Button();
            TwentyButton.ID = "TwentyButton";
            TwentyButton.Text = "20";
            TwentyButton.ToolTip = "20";
            TwentyButton.CommandArgument = "20";
            TwentyButton.CssClass = "BMPagerButtonClick";
            TwentyButton.Click += new System.EventHandler(RecordsChanged_Click);
            if (IsShowLoading)
            {
                TwentyButton.Attributes.Add("onclick", "ShowBMLoading();");
            }
            Controls.Add(TwentyButton);


            FiftyButton = new Button();
            FiftyButton.ID = "FiftyButton";
            FiftyButton.Text = "50";
            FiftyButton.ToolTip = "50";
            FiftyButton.CommandArgument = "50";
            FiftyButton.CssClass = "BMPagerButton";
            if (IsShowLoading)
            {
                FiftyButton.Attributes.Add("onclick", "ShowBMLoading();");
            }
            FiftyButton.Click += new System.EventHandler(RecordsChanged_Click);
            Controls.Add(FiftyButton);

            HundredButton = new Button();
            HundredButton.ID = "HundredButton";
            HundredButton.Text = "100";
            HundredButton.ToolTip = "100";
            HundredButton.CommandArgument = "100";
            HundredButton.CssClass = "BMPagerButton";
            if (IsShowLoading)
            {
                HundredButton.Attributes.Add("onclick", "ShowBMLoading();");
            }
            HundredButton.Click += new System.EventHandler(RecordsChanged_Click);
            Controls.Add(HundredButton);

            if (ShowThousandButton)
            {
                ThousandButton = new Button();
                ThousandButton.ID = "ThousandButton";
                ThousandButton.Text = "1000";
                ThousandButton.ToolTip = "1000";
                ThousandButton.CommandArgument = "1000";
                ThousandButton.CssClass = "BMPagerButton";
                if (IsShowLoading)
                {
                    ThousandButton.Attributes.Add("onclick", "ShowBMLoading();");
                }
                ThousandButton.Click += new System.EventHandler(RecordsChanged_Click);
                Controls.Add(ThousandButton);
            }

            if (ShowTotalButton)
            {
                TotalButton = new Button();
                TotalButton.ID = "TotalButton";
                TotalButton.Text = "全部";
                TotalButton.ToolTip = "全部";
                TotalButton.CommandArgument = "全部";
                TotalButton.CssClass = "BMPagerButton";
                if (IsShowLoading)
                {
                    TotalButton.Attributes.Add("onclick", "ShowBMLoading();");
                }
                TotalButton.Click += new System.EventHandler(RecordsChanged_Click);
                Controls.Add(TotalButton);
            }

            if (!IsShowPageSize)
            {
                TwentyButton.Visible = false;
                FiftyButton.Visible = false;
                HundredButton.Visible = false;                
                if (ShowTotalButton)
                {
                    TotalButton.Visible = false;
                }
                if (ShowThousandButton)
                {
                    ThousandButton.Visible = false;
                }
            }


            //添加数值控件***********************************************************************
            int intTotalPages = CalculateTotalPages();

            TenLabel = new Literal();
            TenLabel.Text = " ";
            int intGroupLength = 0;
            int intMidPage = 0;
            intMidPage = PagersToShow / 2;

            //设置当前组开始的页码

            int intStartIndex = 0;
            if (PageIndex < PagersToShow)
            {
                intStartIndex = 1;
            }
            else
            {
                intStartIndex = PageIndex - intMidPage;
            }

            if (intTotalPages - PagersToShow + 1 > 0)
            {
                if (intStartIndex >= intTotalPages - PagersToShow + 1)
                {
                    intStartIndex = intTotalPages - PagersToShow + 1;
                }
            }

            if (intTotalPages < PagersToShow)
            {
                intGroupLength = intTotalPages;
            }
            else
            {
                intGroupLength = PagersToShow;
            }



            //##############3
            //定义显示控件
            //设置页12345控件****************************************************************************************
            m_lbtnPagingButtons = new LinkButton[PagersToShow];
            for (int i = 0; i < PagersToShow; i++)
            {
                int M_Num = intStartIndex + i;
                m_lbtnPagingButtons[i] = new LinkButton();
                m_lbtnPagingButtons[i].CausesValidation = false;
                m_lbtnPagingButtons[i].Text = M_Num.ToString();
                m_lbtnPagingButtons[i].Font.Underline = false;
                //m_lbtnPagingButtons[i].Width = Unit.Parse("14px");
                m_lbtnPagingButtons[i].ID = M_Num.ToString();
                //设置当前索引
                m_lbtnPagingButtons[i].CommandArgument = M_Num.ToString();
                m_lbtnPagingButtons[i].Click += new EventHandler(IndexNumberChanged_Click);
                if (IsShowLoading)
                {
                    m_lbtnPagingButtons[i].OnClientClick = "ShowBMLoading();";
                }
                Controls.Add(m_lbtnPagingButtons[i]);
            }

            //上一页
            previousButton = new LinkButton();
            previousButton.ID = "previousButton";
            previousButton.Text = this.Previous;
            previousButton.ToolTip = this.Previous;
            previousButton.CommandArgument = "Prv";
            previousButton.Click += new System.EventHandler(PageIndex_Click);
            if (IsShowLoading)
            {
                previousButton.Attributes.Add("onclick", "ShowBMLoading();");
            }
            Controls.Add(previousButton);

            //*******************************************************************************8
            //AddPagingButtons();
            // 下一页
            nextButton = new LinkButton();
            nextButton.ID = "nextButton";
            nextButton.Text = this.Next;
            nextButton.ToolTip = this.Next;
            nextButton.CommandArgument = "Next";
            nextButton.Click += new System.EventHandler(PageIndex_Click);
            if (IsShowLoading)
            {
                nextButton.Attributes.Add("onclick", "ShowBMLoading();");
            }
            Controls.Add(nextButton);
            if (GoEnabled)
            {
                //跳转
                txtGO = new TextBox();
                txtGO.ID = "txtGO";
                txtGO.Text = string.Empty;
                //txtGO.Width = 30;
                //txtGO.Height = 15;
                txtGO.CssClass = "BMCssGO";
                txtGO.MaxLength = 5;
                Controls.Add(txtGO);

                lbtnGO = new LinkButton();
                lbtnGO.ID = "lbtnGO";
                lbtnGO.CssClass = "btngo";
                lbtnGO.Text = "GO";
                lbtnGO.Font.Bold = true;
                lbtnGO.Click += new System.EventHandler(PageGo_Click);
                if (IsShowLoading)
                {
                    lbtnGO.Attributes.Add("onclick", string.Format("return CtrlPagingGoValid{0}('{0}','1')",txtGO.ClientID));
                }
                else
                {
                    lbtnGO.Attributes.Add("onclick", string.Format("return CtrlPagingGoValid{0}('{0}','0')", txtGO.ClientID));
                }
                Controls.Add(lbtnGO);
                
            }
            base.CreateChildControls();
        }

        /// <summary>
        /// 呈现控件到页面上
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (this.DesignMode)
                return;
            int intTotalPages = CalculateTotalPages();

            AddAttributesToRender(writer);
            //by wind
            //writer.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClass, false);


            
            TwentyButton.RenderControl(writer);
            FiftyButton.RenderControl(writer);
            HundredButton.RenderControl(writer);
            if (ShowThousandButton)
            {
                ThousandButton.RenderControl(writer);
            }
            if (ShowTotalButton)
            {
                TotalButton.RenderControl(writer);
            }

            SplitLabel1 = new Literal();
            SplitLabel1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;";
            SplitLabel1.RenderControl(writer);

            TenLabel = new Literal();
            TenLabel.ID = "Summary";
            TenLabel.Text = TotalRecordsSummary;
            TenLabel.RenderControl(writer);
            if (this.TotalView)
            {
                TenLabel = new Literal();
                TenLabel.ID = "TotalRecort";
                TenLabel.Text = TotalRecords.ToString();
                TenLabel.RenderControl(writer);
            }

            SplitLabel1.RenderControl(writer);

            TenLabel = new Literal();
            TenLabel.ID = "nbsp3";
            TenLabel.RenderControl(writer);
            //上一页
            if (HasPrevious)
            {
                //previousButton.PostBackUrl = Page.Request.RawUrl;
                previousButton.RenderControl(writer);
            }
            else
            {
                if (IsEN)
                {
                    previousLabel = new Literal();
                    previousLabel.ID = "Previous";
                    previousLabel.Text = "<span>" + this.Previous + "</span>";
                    previousLabel.RenderControl(writer);
                }
                else
                {
                    previousLabel = new Literal();
                    previousLabel.ID = "上 页 ";
                    previousLabel.Text = "<span>" + this.Previous + "</span>";
                    previousLabel.RenderControl(writer);
                }
            }
            TenLabel.RenderControl(writer);

            
            //  
            //添加数值控件***********************************************************************
            TenLabel = new Literal();
            TenLabel.Text = " ";
            int intGroupLength = 0;
            //获取中间页码数
            int intMidPage = 0;
            intMidPage = PagersToShow / 2;

            //设置当前组开始的页码

            int intStartIndex = 0;
            if (PageIndex < PagersToShow)
            {
                intStartIndex = 1;
            }
            else
            {
                intStartIndex = PageIndex - intMidPage;
            }

            if (intTotalPages - PagersToShow + 1 > 0)
            {
                if (intStartIndex >= intTotalPages - PagersToShow + 1)
                {
                    intStartIndex = intTotalPages - PagersToShow + 1;
                }
            }
            if (intTotalPages < PagersToShow)
            {
                intGroupLength = intTotalPages;
            }
            else
            {
                intGroupLength = PagersToShow;
            }


            //##############3
            //定义显示控件
            //设置页12345控件****************************************************************************************
            m_lbtnPagingButtons = new LinkButton[PagersToShow];
            for (int i = 0; i < PagersToShow; i++)
            {
                int M_Num = intStartIndex + i;
                m_lbtnPagingButtons[i] = new LinkButton();
                m_lbtnPagingButtons[i].CausesValidation = false;
                m_lbtnPagingButtons[i].Text = M_Num.ToString();
                m_lbtnPagingButtons[i].Font.Underline = false;
                // m_lbtnPagingButtons[i].Width = Unit.Parse("14px");
                m_lbtnPagingButtons[i].ID = M_Num.ToString();
                //设置当前索引
                m_lbtnPagingButtons[i].CommandArgument = M_Num.ToString();
                m_lbtnPagingButtons[i].Click += new EventHandler(IndexNumberChanged_Click);
                if (IsShowLoading)
                {
                    m_lbtnPagingButtons[i].OnClientClick = "ShowBMLoading();";
                }
                Controls.Add(m_lbtnPagingButtons[i]);
            }
            //*************************************************************************************
            //##############
            for (int i = 0; i < intGroupLength; i++)
            {
                int M_Num = intStartIndex + i;
                if (M_Num == PageIndex)
                {
                    m_lbtnPagingButtons[i].ForeColor = Color.Red;
                }

                //m_lbtnPagingButtons[i].PostBackUrl = Page.Request.RawUrl;
                m_lbtnPagingButtons[i].RenderControl(writer);
                TenLabel.RenderControl(writer);
            }
            //****************************************************************************
            TenLabel.RenderControl(writer);
            //下一页
            if (HasNext)
            {
                nextButton.Text = this.Next;
                //nextButton.PostBackUrl = Page.Request.RawUrl;
                nextButton.RenderControl(writer);
            }
            else
            {
                if (IsEN)
                {
                    nextLabel = new Literal();
                    nextLabel.ID = "Next";
                    nextLabel.Text = "<span>" + this.Next + "</span>";
                    nextLabel.RenderControl(writer);
                }
                else
                {
                    nextLabel = new Literal();
                    nextLabel.ID = " 下 页 ";
                    nextLabel.Text = "<span>" + this.Next + "</span>";
                    nextLabel.RenderControl(writer);
                }
            }

            if (GoEnabled)
            {
                //SplitLabel1.RenderControl(writer);
                //转到  页 GO
                TenLabel = new Literal();
                TenLabel.ID = "nbsp5";
                if (IsEN)
                {
                    TenLabel.Text = "&nbsp;&nbsp;Goto ";
                }
                else
                {
                    TenLabel.Text = " 跳转 ";
                }
                TenLabel.RenderControl(writer);
                if (TotalRecords > 0)
                {
                    int intGo = PageIndex;
                    txtGO.Text = intGo.ToString();
                }
                else
                {
                    txtGO.Text = "";
                }
                txtGO.RenderControl(writer);

                TenLabel = new Literal();
                TenLabel.ID = "nbsp5";
                if (IsEN)
                {
                    TenLabel.Text = "";
                }
                else
                {
                    TenLabel.Text = " 页 ";
                }
                TenLabel.RenderControl(writer);

                //litError = new Label();
                //litError.ForeColor = System.Drawing.Color.Red;
                //litError.RenderControl(writer);
                //lbtnGO.PostBackUrl = Page.Request.RawUrl;
                lbtnGO.RenderControl(writer);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
           base.OnLoad(e);
           this.FindLinkagePager();
        }

        #endregion

        #region "判断上一页是否到了第一页　或者到了最后一页"
        /// <summary>
        /// 判断是否有上一页
        /// </summary>
        private bool HasPrevious
        {
            get
            {
                if (PageIndex > 1)
                    return true;
                return false;
            }
        }
        /// <summary>
        /// 判断是否有下一页
        /// </summary>
        private bool HasNext
        {
            get
            {
                if (PageIndex < CalculateTotalPages())
                    return true;
                return false;
            }
        }
        #endregion

        #region "控件暴露给外面的事件"

        private void FindLinkagePager()
        {
            if(this.LinkagePager != string.Empty)
            {
                if(this.m_objLinkagePager == null)
                    this.m_objLinkagePager = this.Parent.FindControl(this.LinkagePager) as ctrlPage;
            }
        }

        /// 每页显示条数事件　2０　5０　10０　三个规格
        /// </summary>
        public event System.EventHandler RecordsChanged;
        void RecordsChanged_Click(Object sender, EventArgs e)
        {
            if (((Button)sender).CommandArgument != "全部")
            {
                PageSize = Convert.ToInt32(((Button)sender).CommandArgument);
            }
            else
            {
                PageSize = int.MaxValue;
            }
            //PageSizeStyle();
            PageIndex = 0;
            txtGO.Text = "";
            //同步LinkagePager
            if (this.m_objLinkagePager != null)
            {
                this.m_objLinkagePager.PageSize = this.PageSize;
                this.m_objLinkagePager.PageIndex = this.PageIndex;
                this.m_objLinkagePager.txtGO.Text = this.txtGO.Text;
            }
           
            if (null != RecordsChanged)
            {
                RecordsChanged(sender, e);
            }
        }

        /// <summary>
        /// 暴露控件外上一页,下一页事件
        /// </summary>
        public event System.EventHandler IndexChanged;
        /// <summary>
        /// 上一页,下一页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PageIndex_Click(Object sender, EventArgs e)
        {
            string strMark = ((LinkButton)sender).CommandArgument.ToString();

            if (strMark == "Prv")
            {
                PageIndex = PageIndex - 1;
            }
            else
            {
                PageIndex = PageIndex + 1;
            }

            //同步LinkagePager
            if (this.m_objLinkagePager != null)
            {
                this.m_objLinkagePager.PageIndex = this.PageIndex;
            }

            if (null != IndexChanged)
                IndexChanged(sender, e);

        }
        /// <summary>
        /// 暴露控件外页切换
        /// </summary>
        public event System.EventHandler IndexNumberChanged;
        /// <summary>
        /// 每页显示条数事件 1 2 3 4 5数值事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void IndexNumberChanged_Click(Object sender, EventArgs e)
        {
            PageIndex = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            if (GoEnabled) txtGO.Text = PageSize.ToString();
            //同步LinkagePager
            if (this.m_objLinkagePager != null)
            {
                this.m_objLinkagePager.PageIndex = this.PageIndex;
                this.m_objLinkagePager.txtGO.Text = this.txtGO.Text;
            }
            if (null != IndexNumberChanged)
            {
                IndexNumberChanged(sender, e);
            }
        }
        

        /// <summary>
        /// 暴露控件外跳转页面事件
        /// </summary>
        public event System.EventHandler PageGo;
        /// <summary>
        /// 跳转页面事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PageGo_Click(Object sender, EventArgs e)
        {
            try
            {
                int.Parse(txtGO.Text);
            }
            catch
            {
                return;
            }
            if (CalculateTotalPages() < int.Parse(txtGO.Text))
            {
                txtGO.Text = CalculateTotalPages().ToString();
            }
            if (int.Parse(txtGO.Text) < CalculateTotalPages())
            {
                PageIndex = Convert.ToInt32(int.Parse(txtGO.Text));
            }
            else
            {
                PageIndex = CalculateTotalPages();
            }

            //同步LinkagePager
            if (this.m_objLinkagePager != null)
            {
                this.m_objLinkagePager.PageIndex = this.PageIndex;
                this.m_objLinkagePager.txtGO.Text = this.txtGO.Text;
            }

            if (null != PageGo)
            {
                PageGo(sender, e);
            }

        }

        #endregion

        #region "根据每页显示数目和总记录数获取显示页数"
        /// <summary>
        /// 获取总共多少页数据
        /// </summary>
        /// <returns></returns>
        public int CalculateTotalPages()
        {
            int totalPagesAvailable;

            if (TotalRecords == 0)
                return 0;


            totalPagesAvailable = TotalRecords / PageSize;


            if ((TotalRecords % PageSize) > 0)
                totalPagesAvailable++;

            return totalPagesAvailable;

        }
        #endregion

        #region "属性"

        /// <summary>
        /// 定义显示个数(默认为'5'"12345")
        /// </summary>
        [Description("定义显示个数"), Browsable(true), Category("Appearance")]
        public int PagersToShow
        {
            get { return ((this.ViewState["PagersToShow"] == null) ? 10 : ((int)this.ViewState["PagersToShow"])); }
            set { ViewState["PagersToShow"] = value; }
        }

        /// <summary>
        /// 总记录说明
        /// </summary>
        [Description("总记录说明"), Browsable(true), Category("Appearance")]
        public string TotalRecordsSummary
        {
            get { return this.ViewState["TotalRecordsSummary"] == null ? "总记录数:" : this.ViewState["TotalRecordsSummary"].ToString(); }
            set { ViewState["TotalRecordsSummary"] = value; }
        }

        /// <summary>
        /// 当前页索引
        /// </summary>
        public int PageIndex
        {
            get
            {
                int _pageIndex = 1;

                if (ViewState["PPageIndex"] == null)
                {
                    _pageIndex = 1;
                }
                else
                {
                    _pageIndex = Convert.ToInt32(ViewState["PPageIndex"]);
                }

                if (_pageIndex < 1)
                {
                    return 1;
                }
                else
                {
                    return _pageIndex;
                }
            }
            set
            {
                ViewState["PPageIndex"] = value;
                if (this.m_objLinkagePager != null)
                {
                    this.m_objLinkagePager.SetPageIndex(value);
                }
            }
        }
        private void SetPageIndex(int intPageIndex)
        {
            ViewState["PPageIndex"] = intPageIndex;
        }
        /// <summary>
        /// 每页显示记录条数
        /// </summary>
        public int PageSize
        {
            get
            {
                if (ViewState["PageSize"] == null)
                {
                    return 20;
                }
                else
                {
                    return Convert.ToInt32(ViewState["PageSize"]);
                }
            }
            set
            {
                ViewState["PageSize"] = value;
            }

        }
        /// <summary>
        /// 总记录条数
        /// </summary>
        public int TotalRecords
        {
            get
            {
                return Convert.ToInt32(ViewState["TotalRecords"]==null?"0":ViewState["TotalRecords"].ToString());
            }
            set
            {
                ViewState["TotalRecords"] = value;
            }
        }

        /// <summary>
        /// 上一页
        /// </summary>
        private string Previous
        {
            get
            {
                if (IsEN)
                {
                    return "Previous";
                }
                else
                {
                    return "上 页";
                }

            }

        }
        /// <summary>
        /// 下一页面
        /// </summary>
        private string Next
        {
            get
            {
                if (IsEN)
                {
                    return "Next";
                }
                else
                {
                    return " 下 页";
                }
            }
        }
        /// <summary>
        /// 跳转
        /// </summary>
        private string GoTo
        {
            get
            {
                if (IsEN)
                {
                    return "GO";
                }
                else
                {
                    return "GO";
                }
            }
        }
        /// <summary>
        /// 是否英文
        /// </summary>
        public bool IsEN
        {
            get
            {
                if (ViewState["IsEN"] == null)
                    return false;
                else
                    return Convert.ToBoolean(ViewState["IsEN"]);
            }
            set
            {
                ViewState["IsEN"] = value;
            }
        }

        /// <summary>
        /// 是否英文
        /// </summary>
        public string strGoTxt
        {
            get
            {
                return txtGO.Text;
            }
            set
            {
                txtGO.Text = value;
            }
        }
        /// <summary>
        /// by wind是否总计录数
        /// </summary>
        public bool TotalView
        {
            get
            {
                if (ViewState["TOTALVIEW"] == null)
                    return true;
                else
                    return Convert.ToBoolean(ViewState["TOTALVIEW"]);
            }
            set
            {
                ViewState["TOTALVIEW"] = value;
            }
        }
        /// <summary>
        /// by wind是否显示跳转
        /// </summary>
        public bool GoEnabled
        {
            get
            {
                if (ViewState["GOENABLED"] == null)
                    return true;
                else
                    return Convert.ToBoolean(ViewState["GOENABLED"]);
            }
            set
            {
                ViewState["GOENABLED"] = value;
            }
        }
        /// <summary>
        /// 当前开始数据
        /// </summary>
        public int PageStartRecord
        {
            get
            {
                if (PageIndex == 1)
                {
                    return 0;
                }
                else
                {
                    return (PageIndex - 1) * PageSize;
                }
            }
        }
        /// <summary>
        /// 作者：weiminfeng
        /// 创建时间：2012-05-13
        /// 关联分页控件
        /// </summary>
        public string LinkagePager
        {
            get
            {
                return (ViewState["LinkagePager"] == null) ? string.Empty : ViewState["LinkagePager"].ToString();
            }
            set
            {
                ViewState["LinkagePager"] = value;
            }
        }
        /// <summary>
        /// 是否显示页码选择
        /// </summary>
        public bool IsShowPageSize
        {
            get
            {
                if (ViewState["IsShowPageSize"] == null)
                    return true;
                else
                    return Convert.ToBoolean(ViewState["IsShowPageSize"]);
            }
            set
            {
                ViewState["IsShowPageSize"] = value;
            }
        }


        [Category("自定义信息区")]
        [Browsable(true)]
        [Description("是否显示全部按钮")]
        [DefaultValue(false)]
        public bool ShowTotalButton
        {
            get { return (ViewState["ShowTotalButton"] != null && ViewState["ShowTotalButton"].ToString().ToLower() == "true") ? true : false; }
            set { ViewState["ShowTotalButton"] = value; }
        }

        [Category("自定义信息区")]
        [Browsable(true)]
        [Description("是否显示1000按钮")]
        [DefaultValue(false)]
        public bool ShowThousandButton
        {
            get { return (ViewState["ShowThousandButton"] != null && ViewState["ShowThousandButton"].ToString().ToLower() == "true") ? true : false; }
            set { ViewState["ShowThousandButton"] = value; }
        }

        protected override void OnPreRender(EventArgs e)
        {
            int intBtnNum = ShowTotalButton && ShowThousandButton ? 5 : ((ShowTotalButton || ShowThousandButton) ? 4 : 3);
            
            //修改显示条数按钮样式
            if (Controls.Count >= intBtnNum)
            {
                for (int i = 0; i < intBtnNum; i++)
                {
                    if (((Button)Controls[i]).CommandArgument == PageSize.ToString() || (PageSize == int.MaxValue && ((Button)Controls[i]).CommandArgument == "全部"))
                    {
                        ((Button)Controls[i]).CssClass = "BMPagerButtonClick";
                    }
                    else
                    {
                        ((Button)Controls[i]).CssClass = "BMPagerButton";
                    }
                }
            }
            //Page.RegisterStartupScript("PagerValidScript", s_Js);
            if (!this.DesignMode)
                //modify:zhangmenghua 2013-07-19 防止一个页面有两个分页控件时，点击后面的分页控件的Go按钮报错
                Page.ClientScript.RegisterStartupScript(this.GetType(), "PagerValidScript" + txtGO.ClientID, s_Js.Replace("function CtrlPagingGoValid", "function CtrlPagingGoValid" + txtGO.ClientID));
            base.OnPreRender(e);
        }

        /// <summary>
        /// 注册到页面验证
        /// </summary>
        public const string s_Js = @"
		<script type=""text/javascript"" language=""javascript"">
			function CtrlPagingGoValid( target,IsShowLoading)
			{
				var curNum = document.getElementById(target);
                if(curNum==null)
                {
                    curNum=document.getElementById(target.replace(""_"",""$""))
                }
                if(curNum!=null)
                {
                    curNum=curNum.value;
                }
                else
                {
                    return false;
                }
                var chkNum = new RegExp(""^[0-9]{1}[0-9]*$"");
                if (curNum.match(chkNum) == null)
                {
                    alert(""跳转页码请输入正整数数值！"");
                    return false;
                }
                if (curNum == 0)
                {
                    alert(""跳转页码应大于0！"");
                    return false;
                }
                if(IsShowLoading=='1'){
                    ShowBMLoading();
                }
                return true;
			}
		</script>
            ";
        #endregion
    }
}
