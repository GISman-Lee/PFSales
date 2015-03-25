using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Cls_BinderHelper
/// </summary>

namespace Mechsoft.GeneralUtilities
{
    public static class Cls_BinderHelper
    {
        
        public static void BindDropdownList(ListControl ddlList, string textField, string valueField, object dataSource)
        {
            Cls_BinderHelper.BindDropdownList(ddlList, textField, valueField, dataSource, true);
        }

        public static void BindDropdownList(ListControl ddlList, string textField, string valueField, object dataSource, bool includeSelect)
        {
            if (includeSelect == true)
            {
                Cls_BinderHelper.BindDropdownList(ddlList, textField, valueField, dataSource, true, string.Empty);
            }
            else
            {
                Cls_BinderHelper.BindDropdownList(ddlList, textField, valueField, dataSource, false, string.Empty);
            }
        }


        public static void BindDropdownList(ListControl ddlList, string textField, string valueField, object dataSource, bool includeSelect, string selectedValue)
        {
            ddlList.Items.Clear();
            ddlList.SelectedValue = null;
            ddlList.DataSource = dataSource;
            ddlList.DataTextField = textField;
            ddlList.DataValueField = valueField;
            ddlList.DataBind();
            if (includeSelect)
                ddlList.Items.Insert(0, new ListItem("-- Select --", "0"));
            if (includeSelect && ddlList.Items.Count == 2)
            {
                ddlList.SelectedIndex = 1;
            }
            else if (!includeSelect && ddlList.Items.Count == 1)
            {
                ddlList.SelectedIndex = 0;
            }
            if (selectedValue.Trim() != string.Empty)
                ddlList.SelectedValue = selectedValue;
            ddlList.SelectedIndex = -1;

            foreach (ListItem _listItem in ddlList.Items)
            {
                _listItem.Attributes.Add("title", _listItem.Text);
            }
            ddlList.Attributes.Add("onmouseover", "this.title=this.options[this.selectedIndex].title");




        }

    }
}
