using System.ComponentModel;
using Domen.Entiteti;
using Klijent.Forms;
using System.Globalization;
using System.Windows.Forms;
using Domen.Util;

namespace Klijent.Controllers
{
    public class DetaljiRacunController
    {
        private static DetaljiRacunController _instance;
        public static DetaljiRacunController Instance => _instance ?? (_instance = new DetaljiRacunController());

        private DetaljiRacunController()
        {
        }

        public void Load(DetaljiRacunForm form, int id)
        {
            var response =
                Communication.Instance.SendRequest(SistemskaOperacija.UcitajRacun, new Racun() { Id = id });

            if (!response.Signal)
            {
                return;
            }

            if (!(response.Data is Racun racun))
            {
                return;
            }

            MessageBox.Show(@"Sistem je ucitao racun");

            form.lblDatumKreiranja.Text = racun.DatumKreiranja.ToString("dd-MM-yyyy");
            form.lblNacinPlacanja.Text = racun.NacinPlacanja;
            form.lblDug.Text = racun.UkupanDug.ToString(CultureInfo.InvariantCulture);
            form.dataGridView1.DataSource = new BindingList<StavkaRacuna>(racun.StavkeRacuna);
        }
    }
}
