using Domen.Entiteti;
using Domen.Util;
using Klijent.Forms.UserControls;
using Klijent.Storage;
using Klijent.Utils;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Klijent.Controllers
{
    internal class KreirajRacunController : BaseFormController
    {
        private KreirajRacunUserControl _userControl;
        private BindingList<StavkaRacuna> _stavke;

        public override void Load()
        {
            Control = _userControl = new KreirajRacunUserControl();
            _stavke = new BindingList<StavkaRacuna>();

            var prenosniRacunari = Communication.Instance.GetEntities(SistemskaOperacija.VratiListuPrenosnihRacunara,
                new PrenosniRacunar());
            _userControl.cmbPrenosniRacunar.DataSource = prenosniRacunari;
            IzmenjenPrenosniRacunarDetalji(prenosniRacunari.FirstOrDefault());
            _userControl.cmbNacinPlacanja.DataSource = Enum.GetNames(typeof(NacinPlacanja)).ToList();
        }

        public override void Actions()
        {
            _userControl.btnDodaj.Click += DodajStavku;
            _userControl.btnObrisi.Click += ObrisiStavku;
            _userControl.btnKreiraj.Click += Kreiraj;
            _userControl.cmbPrenosniRacunar.SelectedIndexChanged += IzmenjenPrenosniRacunar;
        }

        private void IzmenjenPrenosniRacunar(object sender, EventArgs e)
        {
            var prenosniRacunar = _userControl.cmbPrenosniRacunar.SelectedItem as PrenosniRacunar;

            if (prenosniRacunar == null)
            {
                return;
            }

            IzmenjenPrenosniRacunarDetalji(prenosniRacunar);
        }

        private void IzmenjenPrenosniRacunarDetalji(PrenosniRacunar prenosniRacunar)
        {
            _userControl.lblBrojNaStanju.Text = prenosniRacunar.BrojNaStanju.ToString();
            _userControl.lblCena.Text = prenosniRacunar.Cena.ToString(CultureInfo.InvariantCulture);
        }

        private void ObrisiStavku(object sender, EventArgs e)
        {
            StavkaRacuna stavkaRacuna;
            try
            {
                stavkaRacuna = (StavkaRacuna)_userControl.dataGridView1.SelectedRows[0].DataBoundItem;

            }
            catch (Exception)
            {
                MessageBox.Show(@"Oznacite stavku racuna koju zelite da obrisete");
                return;
            }

            _stavke.Remove(stavkaRacuna);
            _userControl.txtUkupanDug.Text = _stavke.Sum(stavka => stavka.UkupnaNaknada).ToString(CultureInfo.InvariantCulture);
            stavkaRacuna.PrenosniRacunar.BrojNaStanju += stavkaRacuna.Kolicina;

            if (_userControl.cmbPrenosniRacunar.SelectedItem is PrenosniRacunar pr && pr.Id == stavkaRacuna.PrenosniRacunar.Id)
            {
                _userControl.lblBrojNaStanju.Text = stavkaRacuna.PrenosniRacunar.BrojNaStanju.ToString();
            }

            _userControl.dataGridView1.DataSource = _stavke;
        }

        private void Kreiraj(object sender, EventArgs e)
        {
            if (_stavke.Count == 0)
            {
                MessageBox.Show(@"Mora postojati makar jedna stavka racuna");
                return;
            }

            var racun = new Racun()
            {
                Korisnik = SessionStorage.Instance.Korisnik,
                DatumKreiranja = DateTime.UtcNow,
                NacinPlacanja = _userControl.cmbNacinPlacanja.SelectedItem as string,
                UkupanDug = _stavke.Sum(stavka => stavka.UkupnaNaknada),
                StavkeRacuna = _stavke.ToList()
            };

            var response = Communication.Instance.SendRequest(SistemskaOperacija.ZapamtiRacun, racun);
            MessageBox.Show(response.Signal ? "Upsesno ste dodali nov racun" : "Sistem ne moze da doda racun. Pokusajte ponovo");
        }

        private void DodajStavku(object sender, EventArgs e)
        {
            var prenosniRacunar = _userControl.cmbPrenosniRacunar.SelectedItem as PrenosniRacunar;

            if (prenosniRacunar == null)
            {
                return;
            }

            if (_stavke.Any(ka => ka.PrenosniRacunar.Id == prenosniRacunar.Id))
            {
                MessageBox.Show($@"Vec ste dodali prenosni racunar: {prenosniRacunar.Naziv}");
                return;
            }

            var stavkaRacuna = new StavkaRacuna()
            {
                PrenosniRacunar = prenosniRacunar,
                Cena = prenosniRacunar.Cena,
            };

            if (int.TryParse(_userControl.txtKolicina.Text, out var kolicina) && kolicina > 0)
            {
                if (kolicina > prenosniRacunar.BrojNaStanju)
                {
                    MessageBox.Show($@"Trenutno ima {prenosniRacunar.BrojNaStanju} modela prenosnog racunara {prenosniRacunar.Naziv}");
                    return;
                }

                stavkaRacuna.Kolicina = kolicina;
                stavkaRacuna.UkupnaNaknada = kolicina * prenosniRacunar.Cena;
            }
            else
            {
                MessageBox.Show(@"Kolicina mora biti broj veci od 0");
                return;
            }

            _stavke.Add(stavkaRacuna);
            _userControl.txtUkupanDug.Text = _stavke.Sum(stavka => stavka.UkupnaNaknada).ToString(CultureInfo.InvariantCulture);
            prenosniRacunar.BrojNaStanju -= stavkaRacuna.Kolicina;
            _userControl.lblBrojNaStanju.Text = prenosniRacunar.BrojNaStanju.ToString();
            _userControl.dataGridView1.DataSource = _stavke;
        }
    }
}
