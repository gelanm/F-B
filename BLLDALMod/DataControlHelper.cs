using System.Data.Common;

using System.Web.UI.WebControls;

namespace Maticsoft.Utility
{
    public static class DataControlHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wc">要绑定的控件</param>
        /// <param name="dataSource">用于绑定的数据源</param>
        public static void Bind(WebControl wc, object dataSource)
        {
            if (wc is GridView)
            {
                GridView gv = wc as GridView;
                gv.DataSource = dataSource;
                gv.DataBind();
            }
            if (wc is DataList)
            {
                DataList dl = wc as DataList;
                dl.DataSource = dataSource;
                dl.DataBind();
            }
           
            if (wc is ListControl)
            {
                ListControl lc = wc as ListControl;
                //lc.Items.Clear();
                lc.DataSource = dataSource;
                lc.DataBind();
                if (dataSource is DbDataReader)
                {
                    DbDataReader dr = dataSource as DbDataReader;
                    dr.Close();
                }
            }


        }
    }
}
