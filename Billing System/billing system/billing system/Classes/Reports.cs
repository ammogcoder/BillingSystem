﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace billing_system.Classes
{
    //-----------------------Dilanka Rathnayaka---------------------2/9/2014--------------------
    /// <summary>
    /// Class for Report Generate
    /// </summary>
    class Reports : DBConnection
    {
        public void FormLoadDateTimePicker(DateTimePicker dPick2)
        {
            dPick2.MaxDate = DateTime.Now;
        }

        //Set Item to Cashier combobox
        public void FormLoadComboBox(ComboBox ComBo)
        {
            OpenConnection();

            string Quary = "SELECT Name FROM users";
            MySqlCommand command = new MySqlCommand(Quary, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string temp = reader.GetString(0);
                ComBo.Items.Add(temp);
            }
            reader.Close();
            CloseConnection();
        }

        //Set Items to combobox when type
        public void ComboBoxTextchange(ComboBox cmb, string text)
        {
            OpenConnection();
            string Quary = "SELECT Description FROM items WHERE Description LIKE '" + text + "%'";
            MySqlCommand command = new MySqlCommand(Quary, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string temp = reader.GetString(0);
                cmb.Items.Add(temp);
            }
            reader.Close();
        }
    }
}