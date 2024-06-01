using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DAL;


namespace StudentManager
{
    public partial class FrmScoreQuery : Form
    {
        private StudentClassService objClasservice = new StudentClassService();
        private ScoreListService objScoreService = new ScoreListService();

        private DataTable dtScoreList = null;

        public FrmScoreQuery()
        {
            InitializeComponent();

            
            DataTable dt = objClasservice.GetAllClass().Tables[0];
            this.cboClass.DataSource = dt;
            this.cboClass.ValueMember = "ClassId";
            this.cboClass.DisplayMember = "ClassName";

            
            dtScoreList = objScoreService.GetAllScoreList().Tables[0];
            this.dgvScoreList.DataSource = dtScoreList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtScoreList == null) return;
            this.dtScoreList.DefaultView.RowFilter = string.Format("ClassName='{0}'", this.cboClass.Text.Trim());
        }
        
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            if (dtScoreList == null) return;
            this.dtScoreList.DefaultView.RowFilter = "ClassName like '%%'";
        }
        
        private void txtScore_TextChanged(object sender, EventArgs e)
        {
            if (dtScoreList == null) return;
            if (this.txtScore.Text.Trim().Length == 0) return;
            if (!Common.DataValidate.IsInteger(this.txtScore.Text.Trim()))
            {
                this.txtScore.Text = "";
                return;
            }
            this.dtScoreList.DefaultView.RowFilter = string.Format("CSharp>{0}", this.txtScore.Text.Trim());
        }
    }
}

