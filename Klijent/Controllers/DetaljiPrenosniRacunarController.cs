using Domen.Entiteti;
using Domen.Util;
using Klijent.Forms;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Klijent.Controllers
{
    public class DetaljiPrenosniRacunarController
    {
        private static DetaljiPrenosniRacunarController _instance;
        public static DetaljiPrenosniRacunarController Instance => _instance ?? (_instance = new DetaljiPrenosniRacunarController());

        private DetaljiPrenosniRacunarController()
        {
        }

        public void Load(DetaljiPrenosniRacunarForm form, int id)
        {

            var response =
                Communication.Instance.SendRequest(SistemskaOperacija.UcitajPrenosniRacunar, new PrenosniRacunar() { Id = id });

            if (!response.Signal)
            {
                return;
            }

            if (!(response.Data is PrenosniRacunar prenosniRacunar))
            {
                return;
            }

            MessageBox.Show(@"Sistem je ucitao prenosni racunar");

            form.lblNaziv.Text = prenosniRacunar.Naziv;
            form.lblBrojNaStanju.Text = prenosniRacunar.BrojNaStanju.ToString();
            form.lblCena.Text = prenosniRacunar.Cena.ToString(CultureInfo.InvariantCulture);
            form.lblMarka.Text = prenosniRacunar.MarkaPrenosnogRacunara.Naziv;
            form.dataGridView1.DataSource = new BindingList<PrenosniRacunarKarakteristika>(prenosniRacunar.Karakteristike);
        }
    }
}
