using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DAL;
using Models;


namespace StudentManager
{
    public partial class FrmUserLogin : Form
    {
        
        private SysAdminService objAdminService = new SysAdminService();

        public FrmUserLogin()
        {
            InitializeComponent();
        }


       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (this.txtLoginId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入账号！", "登录提示");
                this.txtLoginId.Focus();
                return;
            }
            if (this.txtLoginPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入密码！", "登录提示");
                this.txtLoginPwd.Focus();
                return;
            }
            
            SysAdmin objAdmin = new SysAdmin()
            {
                LoginId = Convert.ToInt32(this.txtLoginId.Text.Trim()),
                LoginPwd = this.txtLoginPwd.Text.Trim()
            };
            
            try
            {
                objAdmin = objAdminService.AdminLogin(objAdmin);
                if (objAdmin != null)
                {
                    
                    Program.objCurrentAdmin = objAdmin;                   
                    this.DialogResult = DialogResult.OK;                  
                    this.Close();
                }
                else
                {
                    MessageBox.Show("账号或密码有误！", "登录提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据访问出现异常，登录失败！具体原因：" + ex.Message);
            }

        }
     
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
     

        private void txtLoginId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (this.txtLoginId.Text.Trim().Length != 0)
                {
                    this.txtLoginPwd.Focus();
                }                
            }
        }
        private void txtLoginPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnLogin_Click(null, null);
            }
        }


       
    }
}
