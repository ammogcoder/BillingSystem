﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using billing_system.Classes;
using System.Media;

namespace billing_system
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        
        }
  
        private void Login_Load(object sender, EventArgs e)
        {
            this.ActiveControl = UserName;
            this.KeyPreview = true;
            this.UserName.KeyDown += new KeyEventHandler(UserName_KeyDown);
            this.maskedTextBox1.KeyDown += new KeyEventHandler(maskedTextBox1_KeyDown);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserName.Text = "";
            maskedTextBox1.Text = "";
        }

        //Login button Click event
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            
            User UPName = new User();
            //set username
            UPName.GetUsername = UserName.Text;
            //set password
            UPName.GetPassword = maskedTextBox1.Text;

            //check if username empty
            if (UserName.Text != " ")
            {
                //check username with datbase
                if (UPName.UsernameAuthenticaion())
                {
                    //check if password empty
                    if (maskedTextBox1.Text != " ")
                    {
                        //check username with datbase
                        if (UPName.PasswordAuthenticaion())
                        {
                            //get the catagory
                            if (UPName.UserCatagory() == "Admin")
                            {
                                Admin AdminForm = new Admin(this);
                                AdminForm.Show();
                                this.Hide();

                                //Reset textboxes
                                UserName.Text = "UserName";
                                maskedTextBox1.Text = "Password";
                            }
                            else if (UPName.UserCatagory() == "User")
                            {
                                Billingform Bill = new Billingform(UPName.GetUsername, this);
                                Bill.Show();
                                this.Hide();

                                //Reset textboxes
                                UserName.Text = "UserName";
                                maskedTextBox1.Text = "Password";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Enter CORRECT Password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("password is Empty");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter CORRECT Username");
                }
            }
            else
            {
                MessageBox.Show("Username is Empty");
            }
        }

        private void UserName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void UserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidationText log = new ValidationText();
            log.UserName_KeyPress(sender, e);

        }

        private void UserName_Click(object sender, EventArgs e)
        {
            UserName.Text = string.Empty;
        }

        private void maskedTextBox1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = string.Empty;
<<<<<<< HEAD
        }         
               
=======
        }



        public void UserName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                
                
                string keyVal;
                string keyCode;
                keyVal = e.KeyValue.ToString(); //keycode value
                keyCode = e.KeyCode.ToString();
                

                if (int.Parse(keyVal) > 64 && int.Parse(keyVal) < 106) //validate Alphanumeric characters-------------------------
                {
                    UserName.Enabled = true;
                    if (int.Parse(keyVal) > 95 && int.Parse(keyVal) < 106) //validate numberpad inputs to "NumPad" part
                    {
                        
                        keyCode = keyCode.Substring(6, keyCode.Length - 6);
                    }

                    if (UserName.Text == "UserName")
                    {
                        UserName.Text = "";
                    }
                    UserName.ForeColor = Color.Black;
                    UserName.ReadOnly = false;
                    UserName.Text = UserName.Text + keyCode;
                    UserName.Select(UserName.Text.Length, 0);
                    UserName.ReadOnly = true;
                }

                
               

                if (int.Parse(keyVal) == 9)
                {
                    
                    if (UserName.Text == "UserName")
                    {
                        SystemSounds.Hand.Play();
                    }
                    else
                    {
                        this.ActiveControl = maskedTextBox1;
                        maskedTextBox1.ForeColor=Color.Black;
                    }
                    
                    

                }


                
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }








        public void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                
                string keyVal;
                string keyCode;
                keyVal = e.KeyValue.ToString(); //keycode value
                keyCode = e.KeyCode.ToString();

                if (int.Parse(keyVal) > 64 && int.Parse(keyVal) < 106) //validate Alphanumeric characters-------------------------
                {
                    if (int.Parse(keyVal) > 95 && int.Parse(keyVal) < 106) //validate numberpad inputs to "NumPad" part
                    {
                        keyCode = keyCode.Substring(6, keyCode.Length - 6);
                    }
                    if (maskedTextBox1.Text == "Password")
                    {
                        maskedTextBox1.Text = "";
                    }
                    maskedTextBox1.PasswordChar ='*';
                    maskedTextBox1.ReadOnly = false;
                    maskedTextBox1.Text = maskedTextBox1.Text + keyCode;
                    maskedTextBox1.Select(maskedTextBox1.Text.Length, 0);
                    maskedTextBox1.ReadOnly = true;
                }




                if (int.Parse(keyVal) == 13)
                {
                    if (maskedTextBox1.Text == "Password")
                    {
                        MessageBox.Show("Please Enter your Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        BtnLogin_Click(sender, e);
                    }

                }



            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }


       
>>>>>>> cdf8451d3d6ce359ed9af01e06e036951af96c40
    }
}
