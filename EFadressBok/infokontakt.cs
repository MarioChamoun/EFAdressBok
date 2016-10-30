using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFadressBok
{
    public partial class infokontakt : Form
    {
        public infokontakt()
        {
            InitializeComponent();
        }

        private void infokontakt_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAdress.Text == string.Empty || txtEpost.Text == string.Empty || txtNamn.Text == string.Empty || txtPostnummer.Text == string.Empty || txtPostort.Text == string.Empty || txtTelefon.Text == string.Empty || txtBirthday.Text == string.Empty)
            {
                MessageBox.Show("Alla fält måste vara ifyllda.");
            }
            else
            {
                int id = int.Parse(txtId.Text);
                try
                {
                    using (contacts cn = new contacts())
                    {
                        contacts kontakt = cn.contact.FirstOrDefault(i => i.contactId == id);
                        kontakt.namn = txtNamn.Text;
                        kontakt.postnummer = int.Parse(txtPostnummer.Text);
                        kontakt.postort = txtPostort.Text;
                        kontakt.telefon = txtTelefon.Text;
                        kontakt.gatuadress = txtAdress.Text;
                        kontakt.epost = txtEpost.Text;
                        kontakt.födelsedag = Convert.ToDateTime(txtBirthday.Text);
                        cn.SaveChanges();
                        MessageBox.Show("Kontakten har uppdaterats.");
                    }
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
