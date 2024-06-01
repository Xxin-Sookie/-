using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DAL;


namespace StudentManager
{
    public partial class FrmScoreManage : Form
    {
        private ScoreListService objScoreService = new ScoreListService();

        public FrmScoreManage()
        {
            InitializeComponent();
            //断开事件
            this.cboClass.SelectedIndexChanged -= new EventHandler(this.cboClass_SelectedIndexChanged);
            //初始化班级下拉框
            this.cboClass.DataSource = new StudentClassService().GetAllClasses();
            this.cboClass.DisplayMember = "ClassName";//设置下拉框的显示文本
            this.cboClass.ValueMember = "ClassId";//设置下拉框显示文本对应的value 
            this.cboClass.SelectedIndex = -1;
            //挂接事件
            this.cboClass.SelectedIndexChanged +=
                new EventHandler(this.cboClass_SelectedIndexChanged);
        }
        //根据班级查询      
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboClass.SelectedIndex == -1)
            {
                MessageBox.Show("请首先选择要查询的班级", "查询提示");
                return;
            }
            this.dgvScoreList.AutoGenerateColumns = false;
            this.dgvScoreList.DataSource = objScoreService.GetScoreList(this.cboClass.Text.Trim());
            //同步显示班级考试信息
            this.gbStat.Text = "[" + this.cboClass.Text.Trim() + "]考试成绩统计";
            Dictionary<string, string> dic =
                objScoreService.GetScoreInfoByClassId(this.cboClass.SelectedValue.ToString());
            this.lblAttendCount.Text = dic["stuCount"];
            this.lblCSharpAvg.Text = dic["avgCSharp"];
            this.lblDBAvg.Text = dic["avgDB"];
            this.lblCount.Text = dic["absentCount"];
            //显示缺考人员姓名
            List<string> list =
                objScoreService.GetAbsentListByClassId(this.cboClass.SelectedValue.ToString());
            this.lblList.Items.Clear();
            if (list.Count == 0) this.lblList.Items.Add("没有缺考");
            else lblList.Items.AddRange(list.ToArray());
        }
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //统计全校考试成绩
        private void btnStat_Click(object sender, EventArgs e)
        {
            this.gbStat.Text = "全校考试成绩统计";
            //查询成绩列表
            this.dgvScoreList.AutoGenerateColumns = false;
            this.dgvScoreList.DataSource = objScoreService.GetScoreList("");
            //查询并显示成绩统计
            Dictionary<string, string> dic = objScoreService.GetScoreInfo();
            this.lblAttendCount.Text = dic["stuCount"];
            this.lblDBAvg.Text = dic["avgDB"];
            this.lblCSharpAvg.Text = dic["avgCSharp"];
            this.lblCount.Text = dic["absentCount"];
            //显示缺考的人员姓名
            List<string> list = objScoreService.GetAbsentList();
            this.lblList.Items.Clear();
            this.lblList.Items.AddRange(list.ToArray());
        }
    }
}