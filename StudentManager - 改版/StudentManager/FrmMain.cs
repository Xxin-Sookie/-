using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            
            this.lblCurrentUser.Text = Program.objCurrentAdmin.AdminName + "]";

        }

        public static FrmAddStudent objFrmAddStudent = null;
        private void tsmiAddStudent_Click(object sender, EventArgs e)
        {
            if (objFrmAddStudent == null)
            {
                objFrmAddStudent = new FrmAddStudent();
                objFrmAddStudent.Show();
            }
            else
            {
                objFrmAddStudent.Activate();
                objFrmAddStudent.WindowState = FormWindowState.Normal;
            }
        }
      
        public static FrmStudentManage objFrmStuManage = null;
        private void tsmiManageStudent_Click(object sender, EventArgs e)
        {
            if (objFrmStuManage == null)
            {
                objFrmStuManage = new FrmStudentManage();
                objFrmStuManage.Show();
            }
            else
            {
                objFrmStuManage.Activate();
                objFrmStuManage.WindowState = FormWindowState.Normal;
            }
        }
      
        public static FrmScoreManage objFrmScoreManage = null;
        private void tsmiQueryAndAnalysis_Click(object sender, EventArgs e)
        {
            if (objFrmScoreManage == null)
            {
                objFrmScoreManage = new FrmScoreManage();
                objFrmScoreManage.Show();
            }
            else
            {
                objFrmScoreManage.Activate();
                objFrmScoreManage.WindowState = FormWindowState.Normal;
            }
        }
       
        private void tmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        public static FrmScoreQuery objFrmScore = null;
        private void tsmiQuery_Click(object sender, EventArgs e)
        {
            if (objFrmScore == null)
            {
                objFrmScore = new FrmScoreQuery();
                objFrmScore.Show();
            }
            else
            {
                objFrmScore.Activate();
                objFrmScore.WindowState = FormWindowState.Normal;
            }         
        }
        
        public static FrmModifyPwd objFrmModifyPwd = null;
        private void tmiModifyPwd_Click(object sender, EventArgs e)
        {
            if (objFrmModifyPwd == null)
            {
                objFrmModifyPwd = new FrmModifyPwd();
                objFrmModifyPwd.Show();
            }
            else
            {
                objFrmModifyPwd.Activate();
                objFrmModifyPwd.WindowState = FormWindowState.Normal;
            }
        }

        private void tsbAddStudent_Click(object sender, EventArgs e)
        {
            tsmiAddStudent_Click(null, null);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tsmiManageStudent_Click(null, null);
        }
        private void tsbScoreAnalysis_Click(object sender, EventArgs e)
        {
            tsmiQueryAndAnalysis_Click(null, null);
        }
        private void tsbModifyPwd_Click(object sender, EventArgs e)
        {
            tmiModifyPwd_Click(null, null);
        }

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            tsmiQuery_Click(null, null);
        }

       
        
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗？", "退出询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result != DialogResult.OK)
            {
                
                e.Cancel = true;
            }
        }
    }
}