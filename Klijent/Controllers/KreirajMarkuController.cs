using Domen.Entiteti;
using Domen.Util;
using Klijent.Forms.UserControls;
using System;
using System.Windows.Forms;

namespace Klijent.Controllers
{
    public class KreirajMarkuController : BaseFormController
    {
        private KreirajMarkuUserControl _userControl;
        public override void Load()
        {
            Control = _userControl = new KreirajMarkuUserControl();
        }

        public override void Actions()
        {
            _userControl.btnKreiraj.Click += Kreiraj;
        }

        private void Kreiraj(object sender, EventArgs e)
        {
            var naziv = _userControl.txtName.Text;
            if (string.IsNullOrEmpty(naziv))
            {
                MessageBox.Show(@"Unesite naziv marke prenosnog racunara");
                return;
            }

            var marka = new MarkaPrenosnogRacunara(0, naziv);
            var response = Communication.Instance.SendRequest(SistemskaOperacija.ZapamtiMarkuPrenosnogRacunara, marka);

            if (response.Signal)
            {
                MessageBox.Show(@"Uspesno ste dodali marku prenosnog racunara");
            }
            else
            {
                var errorText = response.Data?.ToString();
                if (!string.IsNullOrEmpty(errorText))
                {
                    MessageBox.Show(errorText);
                    return;
                }

                MessageBox.Show(@"Sistem ne moze da doda marku prenosnog racunara");
            }
        }
    }
}
