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
    public partial class Billingform : Form
    {
        public int stage;
        public Billingform()
        {
            InitializeComponent();
            stage = 0;
        }








        private void Billingform_Load(object sender, EventArgs e)
        {
            txtBoxDescription.Focus();
            BillGeneration bf = new BillGeneration();
            textBox1.Text=bf.BillNoGen().ToString();
            //label9.Text=bf.Date().ToString();

            timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

        }







        public void txtBoxDescription_KeyDown(object sender, KeyEventArgs e)
        {
            string keyCd;
            string searchKey;

            ManualBilling mb=new ManualBilling();
            if (mb.Visible == false)
            {
                mb.Show();
                keyCd = e.KeyCode.ToString();
                KeyPressEvent kpe = new KeyPressEvent();
                searchKey = kpe.manualSearchkey(keyCd, "Billingform", "des");
                


                if (searchKey == "exit")
                {
                    this.Close();
                }
                else
                {
                    BillGeneration bg = new BillGeneration();
                    bg.manualBilling(searchKey);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BillGeneration bf = new BillGeneration();
            label9.Text = bf.Date().ToString();
        }










        
    }
}
