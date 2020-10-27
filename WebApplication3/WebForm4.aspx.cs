using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2;

namespace WebApplication3
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllProvince();
            }
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedCity();
        }


        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedDistrict();
        }


        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 获取所有省份
        /// </summary>
        private void GetAllProvince()
        {
            string sql = "select * from S_Province";
            DataSet ds = OperaterBase.GetData(sql);
            // 给下拉框绑定
            DropDownList1.DataSource = ds;
            // 绑定下拉框文字
            DropDownList1.DataTextField = "ProvinceName";
            //绑定下拉框value值
            DropDownList1.DataValueField = "ProvinceID";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("请选择省份", "0"));
        }

        /// <summary>
        /// 获取选定省份的城市
        /// </summary>
        private void GetSelectedCity()
        {
            string ProvinceID = DropDownList1.SelectedValue;
            string sql = "select * from S_City where ProvinceID=" + ProvinceID + "";
            DataSet ds = OperaterBase.GetData(sql);
            // 给下拉框绑定
            DropDownList2.DataSource = ds;
            // 绑定下拉框文字
            DropDownList2.DataTextField = "CityName";
            //绑定下拉框value值
            DropDownList2.DataValueField = "CityID";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("请选择城市", "0"));
        }

        /// <summary>
        /// 获取选定城市的区县
        /// </summary>
        private void GetSelectedDistrict()
        {
            string CityID = DropDownList2.SelectedValue;
            string sql = "select * from S_District where CityID=" + CityID + "";
            DataSet ds = OperaterBase.GetData(sql);
            // 给下拉框绑定
            DropDownList3.DataSource = ds;
            // 绑定下拉框文字
            DropDownList3.DataTextField = "DistrictName";
            //绑定下拉框value值
            DropDownList3.DataValueField = "DistrictID";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("请选择地区", "0"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string DropDownList1Text = DropDownList1.SelectedItem.Text;
            string DropDownList2Text = DropDownList2.SelectedItem.Text;
            string DropDownList3Text = DropDownList3.SelectedItem.Text;
            if (DropDownList1.SelectedValue == "0")
            {
                DropDownList1Text = "";
            }

            if (DropDownList2.SelectedValue == "0")
            {
                DropDownList2Text = "";
            }

            if (DropDownList3.SelectedValue == "0")
            {
                DropDownList3Text = "";
            }

            int num = OperaterBase.CommandBySql("insert into S_Address values (newid(),'" + DropDownList1Text + "','" +
                                                DropDownList2Text + "','" + DropDownList3Text + "')");
        }
    }
}