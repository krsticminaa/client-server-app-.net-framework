using Domen;
using Domen.Entiteti;
using Domen.Util;
using Klijent.Forms;
using Klijent.Forms.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Klijent.Storage;

namespace Klijent.Controllers
{
    internal class PretraziRacuneController : BaseFormController
    {
        BindingList<Racun> _list;
        PretraziRacuneUserControl _userControl;
        public override void Load()
        {
            Control = _userControl = new PretraziRacuneUserControl();
            LoadData();
        }

        private void LoadData()
        {
            var racuni = Communication.Instance.GetEntities(SistemskaOperacija.VratiListuRacuna,
                new Racun());
            _list = new BindingList<Racun>(racuni);
            _userControl.dataGridView1.DataSource = _list;
            var prenosniRacunari = Communication.Instance.GetEntities(SistemskaOperacija.VratiListuPrenosnihRacunara,
                new PrenosniRacunar());
            prenosniRacunari.Insert(0, new PrenosniRacunar(0, ""));
            _userControl.cmbRacunari.DataSource = prenosniRacunari;
        }

        public override void Actions()
        {
            _userControl.btnPretrazi.Click += Pretrazi;
            _userControl.btnReset.Click += Reset;
            _userControl.btnDetalji.Click += Detalji;
        }

        private void Detalji(object sender, EventArgs e)
        {
            Racun racun;
            try
            {

                racun = (Racun)_userControl.dataGridView1.SelectedRows[0].DataBoundItem;
            }
            catch (Exception)
            {
                MessageBox.Show(@"Oznacite racun za koji zelite da vidite detalje");
                return;
            }

            new DetaljiRacunForm(racun.Id).ShowDialog();
        }

        private void Reset(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Pretrazi(object sender, EventArgs e)
        {
            var tekst = _userControl.txtTekst.Text;

            var racunar = _userControl.cmbRacunari.SelectedItem as PrenosniRacunar;
            var zaTogKorisnika = _userControl.checkBox1.Checked;

            //if (!int.TryParse(tekst, out _) 
            //    && !DateTime.TryParseExact(tekst, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            //{
            //    MessageBox.Show(@"Unesite broj ili datum u formatu 'dd-MM-yyyy' za tekst pretrage");
            //    return;
            //}
            var kriterijumPretrage = new RacunKriterijumPretrage(tekst,
                zaTogKorisnika ? SessionStorage.Instance.Korisnik.Id : 0, racunar);

            var response = Communication.Instance.SendRequest(SistemskaOperacija.PretraziRacune,
                kriterijumPretrage);

            if (response.Signal)
            {
                var racuni = ((List<IEntity>)response.Data).OfType<Racun>().ToList();

                if (!racuni.Any())
                {
                    MessageBox.Show(@"Sistem ne moze da pronadje racune po zadatom kriterijumi");
                    return;
                }

                MessageBox.Show(@"Sistem je uspesno pronasao racune po zadatom kriterijumu");

                _list = new BindingList<Racun>(racuni);
                _userControl.dataGridView1.DataSource = _list;
            }
            else
            {
                MessageBox.Show(@"Sistem ne moze da pronadje racune po zadatom kriterijumi");
            }
        }
    }
}
