using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using System.Security.Principal;
using System.Configuration;
using System.Security.Cryptography;

namespace VDT
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();      
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.PasswordChar = '*';
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Membership.ValidateUser(txtUsername.Text.Trim(), txtPassword.Text.Trim()))
            {
                FormsAuthentication.SetAuthCookie(txtUsername.Text.Trim(), cbxRemember.Checked);
                VDT vDT = new VDT();
                vDT.lblFullName.Text = userprofile.CurrentUser.FullName;
                vDT.Show();
                this.Close();
            }
            else
            {
                //Membership.GetUser(txtUsername.Text.Trim());
                MessageBox.Show("Thông tin đăng nhập không đúng.");
            }
        }
        public string EncodePassword(string pass, int passwordFormat, string salt)
        {
            byte[] numArray;
            byte[] numArray1;
            string base64String;

            if (passwordFormat == 1)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(pass);
                byte[] numArray2 = Convert.FromBase64String(salt);
                byte[] numArray3;

                // Hash password
                HashAlgorithm hashAlgorithm = HashAlgorithm.Create(Membership.HashAlgorithmType);

                if (hashAlgorithm as KeyedHashAlgorithm == null)
                {
                    numArray1 = new byte[numArray2.Length + bytes.Length];
                    Buffer.BlockCopy(numArray2, 0, numArray1, 0, numArray2.Length);
                    Buffer.BlockCopy(bytes, 0, numArray1, numArray2.Length, bytes.Length);
                    numArray3 = hashAlgorithm.ComputeHash(numArray1);
                }
                else
                {
                    KeyedHashAlgorithm keyedHashAlgorithm = (KeyedHashAlgorithm)hashAlgorithm;

                    if (keyedHashAlgorithm.Key.Length != numArray2.Length)
                    {

                        if (keyedHashAlgorithm.Key.Length >= numArray2.Length)
                        {
                            numArray = new byte[keyedHashAlgorithm.Key.Length];
                            int num = 0;
                            while (true)
                            {
                                if (!(num < numArray.Length))
                                {
                                    break;
                                }
                                int num1 = Math.Min(numArray2.Length, numArray.Length - num);
                                Buffer.BlockCopy(numArray2, 0, numArray, num, num1);
                                num = num + num1;
                            }
                            keyedHashAlgorithm.Key = numArray;
                        }
                        else
                        {
                            numArray = new byte[keyedHashAlgorithm.Key.Length];
                            Buffer.BlockCopy(numArray2, 0, numArray, 0, numArray.Length);
                            keyedHashAlgorithm.Key = numArray;
                        }
                    }
                    else
                    {
                        keyedHashAlgorithm.Key = numArray2;
                    }
                    numArray3 = keyedHashAlgorithm.ComputeHash(bytes);
                }

                base64String = Convert.ToBase64String(numArray3);
            }
            else if (passwordFormat == 2)
            {
                throw new NotImplementedException("Encrypted password method is not supported.");
            }
            else
            {
                base64String = pass;
            }

            return base64String;
        }
        private void hidePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
