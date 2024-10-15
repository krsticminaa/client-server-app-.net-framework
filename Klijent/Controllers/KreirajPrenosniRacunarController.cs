using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Domen.Entiteti;
using Domen.Util;
using Klijent.Forms.UserControls;

namespace Klijent.Controllers
{
    internal class KreirajPrenosniRacunarController : BaseFormController
    {
        private KreirajPrenosniRacunarUserControl _userControl;
        private BindingList<PrenosniRacunarKarakteristika> _karakteristike;
        public override void Load()
        {
            Control = _userControl = new KreirajPrenosniRacunarUserControl();
            _karakteristike = new BindingList<PrenosniRacunarKarakteristika>();
            _userControl.cmbMarka.DataSource =
                Communication.Instance.GetEntities(SistemskaOperacija.VratiListuMarki, new MarkaPrenosnogRacunara());
            _userControl.cmbKarakteristika.DataSource =
                Communication.Instance.GetEntities(SistemskaOperacija.VratiListuKarakteristika, new Karakteristika());
        }

        public override void Actions()
        {
            _userControl.btnDodaj.Click += DodajKarakteristiku;
            _userControl.btnObrisi.Click += ObrisiKarakteristiku;
            _userControl.btnKreiraj.Click += Kreiraj;
        }

        private void ObrisiKarakteristiku(object sender, EventArgs e)
        {
            PrenosniRacunarKarakteristika prenosniRacunarKarakteristika;
            try
            {
                prenosniRacunarKarakteristika = (PrenosniRacunarKarakteristika)_userControl.dataGridView1.SelectedRows[0].DataBoundItem;

            }
            catch (Exception)
            {
                MessageBox.Show(@"Morate selektovati red");
                return;
            }

            _karakteristike.Remove(prenosniRacunarKarakteristika);
            _userControl.dataGridView1.DataSource = _karakteristike;
        }

        private void Kreiraj(object sender, EventArgs e)
        {
            var prenosniRacunar = new PrenosniRacunar()
            {
                MarkaPrenosnogRacunara = _userControl.cmbMarka.SelectedItem as MarkaPrenosnogRacunara,
                Karakteristike = _karakteristike.ToList()
            };

            if (int.TryParse(_userControl.txtBrojNaStanju.Text, out var brojNaStanju) && brojNaStanju > 0)
            {
                prenosniRacunar.BrojNaStanju = brojNaStanju;
            }
            else
            {
                MessageBox.Show(@"Broj prenosnih racunara mora biti broj veci od 0");
                return;
            }

            if (double.TryParse(_userControl.txtCena.Text, out var cena) && cena > 0)
            {
                prenosniRacunar.Cena = cena;
            }
            else
            {
                MessageBox.Show(@"Cena mora biti broj veca od 0");
                return;
            }

            var naziv = _userControl.txtNaziv.Text;
            if (string.IsNullOrEmpty(naziv))
            {
                MessageBox.Show(@"Unesite naziv prenosnog racunara");
                return;
            }

            prenosniRacunar.Naziv = naziv;

            var response = Communication.Instance.SendRequest(SistemskaOperacija.DodajPrenosniRacunar, prenosniRacunar);

            if (response.Signal)
            {
                MessageBox.Show(@"Uspesno je dodat prenosni racunar u sistem");
            }
            else
            {
                var errorText = response.Data?.ToString();
                if (!string.IsNullOrEmpty(errorText))
                {
                    MessageBox.Show(errorText);
                    return;
                }

                MessageBox.Show(@"Sistem ne moze da doda prenosni racunar. Pokusajte ponovo");
            }
        }

        private void DodajKarakteristiku(object sender, EventArgs e)
        {
            var karakteristika = _userControl.cmbKarakteristika.SelectedItem as Karakteristika;

            if (karakteristika == null)
            {
                return;
            }

            if (_karakteristike.Any(ka => ka.Karakteristika.Id == karakteristika.Id))
            {
                MessageBox.Show($@"Vec ste dodali karakteristiku: {karakteristika.Naziv}");
                return;
            }

            var prenosniRacunarKarakteristika = new PrenosniRacunarKarakteristika()
            {
                Karakteristika = karakteristika,
                Opis = _userControl.rtbOpis.Text ?? string.Empty
            };

            _karakteristike.Add(prenosniRacunarKarakteristika);
            _userControl.dataGridView1.DataSource = _karakteristike;
        }
    }
}
