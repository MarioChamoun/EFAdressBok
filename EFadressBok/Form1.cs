﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFadressBok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<kontakter> con = new List<kontakter>();

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void getinfo(bool redigera)
        {
            infokontakt form = new infokontakt();
            form.button1.Visible = false;

            using (contacts cn = new contacts())
            {

                var id = con[listBox1.SelectedIndex].contactId;


                var kontakt = from c in cn.contact
                              where c.contactId == id
                              select new
                              {
                                  c.contactId,
                                  c.namn,
                                  c.postnummer,
                                  c.postort,
                                  c.epost,
                                  c.födelsedag,
                                  c.gatuadress,
                                  c.telefon
                              };
               
                foreach (var person in kontakt)
                {
                    form.txtId.Text = person.contactId.ToString();
                    form.txtNamn.Text = person.namn;
                    form.txtAdress.Text = person.gatuadress;
                    form.txtPostnummer.Text = person.postnummer.ToString();
                    form.txtPostort.Text = person.postort;
                    form.txtTelefon.Text = person.telefon;
                    form.txtEpost.Text = person.epost;
                    form.txtBirthday.Text = person.födelsedag.ToShortDateString();
                }
                if(redigera == true) {

                    foreach (Control x in form.Controls)
                    {
                        if(x is TextBox)
                        {
                            ((TextBox)x).ReadOnly = false;
                        }
                    }
                    form.button1.Visible = true;
                }
                form.Show();
            }
        }

        private void btnSpara_Click(object sender, EventArgs e)
        {
            if (txtAdress.Text == string.Empty || txtEpost.Text == string.Empty || txtNamn.Text == string.Empty || txtPostnummer.Text == string.Empty || txtPostort.Text == string.Empty || txtTelefon.Text == string.Empty)
            {
                MessageBox.Show("Alla fält måste vara ifyllda.");
            }
            else
            {
                try
                {
                    using (contacts cn = new contacts())
                    {
                        contacts contact = new contacts
                        {
                            namn = txtNamn.Text,
                            gatuadress = txtAdress.Text,
                            postnummer = int.Parse(txtPostnummer.Text),
                            postort = txtPostort.Text,
                            telefon = txtTelefon.Text,
                            epost = txtEpost.Text,
                            födelsedag = dtBirthday.Value
                        };
                        cn.contact.Add(contact);
                        cn.SaveChanges();
                        MessageBox.Show("Kontakten har registrerats.");
                    }
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void btnSok_Click(object sender, EventArgs e)
        {
            con.Clear();
                listBox1.Items.Clear();
            using (contacts cn = new contacts())
            {
                var kontakt = from c in cn.contact
                              where c.namn.StartsWith(txtNamnSok.Text)
                              select c;

                    foreach (var namn in kontakt)
                {
                    listBox1.Items.Add(namn.namn);
                    con.Add(new kontakter {namn = namn.namn,contactId = namn.contactId });
                }
                }
            }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            try{
                getinfo(false);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       }
        

        private void btnRadera_Click(object sender, EventArgs e)
        {
            try {
                using (contacts cn = new contacts())
                {
                    var id = con[listBox1.SelectedIndex].contactId;
                    contacts kontakt = cn.contact.FirstOrDefault(r => r.contactId == id);
                    cn.contact.Remove(kontakt);
                    cn.SaveChanges();
                    MessageBox.Show("Kontakten har raderats.");
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                getinfo(true);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }
    }
}
