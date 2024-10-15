using Domen.Entiteti;
using Domen.Util;
using Klijent.Forms;
using System;
using System.Windows.Forms;
using Klijent.Storage;

namespace Klijent.Controllers
{
    public class LoginController
    {
        private LoginForm _loginForm;
        private static LoginController _instance;
        public static LoginController Instance => _instance ?? (_instance = new LoginController());

        private LoginController()
        {
        }

        internal void ShowForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _loginForm = new LoginForm();
            _loginForm.AutoSize = true;
            Application.Run(_loginForm);
        }

        public void Login(object sender, EventArgs e)
        {
            var email = _loginForm.txtEmail.Text;
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show(@"Unesite email");
                return;
            }

            var sifra = _loginForm.txtPassword.Text;
            if (string.IsNullOrEmpty(sifra))
            {
                MessageBox.Show(@"Unesite sifru");
                return;
            }

            var response = Communication.Instance.SendRequest(SistemskaOperacija.PrijaviSe, new Korisnik(email, sifra));

            if (response.Signal)
            {
                MessageBox.Show(@"Uspesno ste se prijavili na sistem!");
                _loginForm.txtEmail.Text = string.Empty;
                _loginForm.txtPassword.Text = string.Empty;
                SessionStorage.Instance.Korisnik = (Korisnik)response.Data;
                MainController.Instance.ShowMainForm();
            }
            else
            {
                MessageBox.Show(@"Neuspesna prijava na sistem!");
            }
        }
    }
}
