using Domen;
using Domen.Entiteti;
using Domen.Util;
using Klijent.Forms.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Klijent.Forms;

namespace Klijent.Controllers
{
    internal class PretraziPrenosneRacunareController : BaseFormController
    {
        BindingList<PrenosniRacunar> _list;
        PretraziPrenosneRacunareUserControl _userControl;
        public override void Load()
        {
            Control = _userControl = new PretraziPrenosneRacunareUserControl();
            LoadData();
        }

        private void LoadData()
        {
            var racunari = Communication.Instance.GetEntities(SistemskaOperacija.VratiListuPrenosnihRacunara,
                new PrenosniRacunar());
            _list = new BindingList<PrenosniRacunar>(racunari);
            _userControl.dataGridView1.DataSource = _list;
        }

        public override void Actions()
        {
            _userControl.btnPretrazi.Click += Pretrazi;
            _userControl.btnReset.Click += Reset;
            _userControl.btnDetalji.Click += Detalji;
            _userControl.btnObrisi.Click += Obrisi;
        }

        private void Obrisi(object sender, EventArgs e)
        {
            PrenosniRacunar prenosniRacunar;
            try
            {

                prenosniRacunar = (PrenosniRacunar)_userControl.dataGridView1.SelectedRows[0].DataBoundItem;
            }
            catch (Exception)
            {
                MessageBox.Show(@"Oznacite prenosni racunar koji zelite da obrisete");
                return;
            }

            var deleteMessageBoxResult = MessageBox.Show($@"Da li ste sigurni da zelite da obrisete prenosni racunar {prenosniRacunar.Naziv}?", @"Brisanje prenosnog racunara", MessageBoxButtons.YesNo);

            if (deleteMessageBoxResult == DialogResult.No)
            {
                return;
            }

            var response = Communication.Instance.SendRequest(SistemskaOperacija.ObrisiPrenosniRacunar,
                prenosniRacunar);

            if (response.Signal)
            {
                MessageBox.Show(@"Sistem je uspesno obrisao prenosni racunar!");
                _list.Remove(prenosniRacunar);
                _userControl.dataGridView1.DataSource = _list;
            }
            else
            {
                MessageBox.Show(@"Sistem ne moze da obrise prenosni racunar! Pokusajte ponovo");
            }
        }

        private void Detalji(object sender, EventArgs e)
        {
            PrenosniRacunar prenosniRacunar;
            try
            {

                prenosniRacunar = (PrenosniRacunar)_userControl.dataGridView1.SelectedRows[0].DataBoundItem;
            }
            catch (Exception)
            {
                MessageBox.Show(@"Oznacite prenosni racunar za koji zelite da vidite detalje");
                return;
            }

            new DetaljiPrenosniRacunarForm(prenosniRacunar.Id).ShowDialog();
        }

        private void Reset(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Pretrazi(object sender, EventArgs e)
        {
            var tekst = _userControl.txtTekst.Text;

            if (string.IsNullOrEmpty(tekst))
            {
                MessageBox.Show(@"Unesite tekst pretrage");
                return;
            }

            var response = Communication.Instance.SendRequest(SistemskaOperacija.PretraziPrenosneRacunare,
                new KriterijumPretrage(tekst));

            if (response.Signal)
            {
                var prenosniRacunari = ((List<IEntity>)response.Data).OfType<PrenosniRacunar>().ToList();

                if (!prenosniRacunari.Any())
                {
                    MessageBox.Show(@"Sistem ne moze da pronadje prenosne racunare po zadatim kriterijumima. Pokusajte ponovo");
                    return;
                }

                MessageBox.Show(@"Sistem je uspesno pronasao prenosne racunare po zadatim kriterijumima");

                _list = new BindingList<PrenosniRacunar>(prenosniRacunari);
                _userControl.dataGridView1.DataSource = _list;
            }
            else
            {
                MessageBox.Show(@"Sistem ne moze da pronadje prenosne racunare po zadatim kriterijumima. Pokusajte ponovo");
            }
        }
    }
}
