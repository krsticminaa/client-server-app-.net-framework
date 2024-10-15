using Domen;
using Domen.Entiteti;
using Domen.Util;
using Klijent.Forms.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Klijent.Controllers
{
    internal class PretraziMarkeController : BaseFormController
    {
        BindingList<MarkaPrenosnogRacunara> _list;
        PretraziMarkeUserControl _userControl;
        public override void Load()
        {
            Control = _userControl = new PretraziMarkeUserControl();
            LoadData();
        }

        private void LoadData()
        {
            var marke = Communication.Instance.GetEntities(SistemskaOperacija.VratiListuMarki,
                new MarkaPrenosnogRacunara());
            _list = new BindingList<MarkaPrenosnogRacunara>(marke);
            _userControl.dataGridView1.DataSource = _list;
        }

        public override void Actions()
        {
            _userControl.btnPretrazi.Click += Pretrazi;
            _userControl.btnReset.Click += Reset;
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

            var response = Communication.Instance.SendRequest(SistemskaOperacija.PretraziMarkePrenosnihRacunara,
                new KriterijumPretrage(tekst));

            if (response.Signal)
            {
                var marke = ((List<IEntity>)response.Data).OfType<MarkaPrenosnogRacunara>().ToList();

                if (!marke.Any())
                {
                    MessageBox.Show(@"Sistem ne moze da pronadje marke prenosnih racunara po zadatim kriterijumima. Pokusajte ponovo");
                    return;
                }

                MessageBox.Show(@"Sistem je uspesno pronasao marke prenosnih racunara po zadatim kriterijumima");

                _list = new BindingList<MarkaPrenosnogRacunara>(marke);
                _userControl.dataGridView1.DataSource = _list;
            }
            else
            {
                MessageBox.Show(@"Sistem ne moze da pronadje marke prenosnih racunara po zadatim kriterijumima. Pokusajte ponovo");
            }
        }
    }
}
