using System;
using Klijent.Utils;
using System.Collections.Generic;
using Klijent.Forms;
using Klijent.Storage;
using System.Windows.Forms;
using Domen.Util;

namespace Klijent.Controllers
{
    internal class MainController
    {
        private MainForm _mainForm;
        private readonly Dictionary<FormName, BaseFormController> _forms;
        private static MainController _instance;
        public static MainController Instance => _instance ?? (_instance = new MainController());

        private MainController()
        {
            _forms = new Dictionary<FormName, BaseFormController>()
            {
                {FormName.KreirajMarku, new KreirajMarkuController()},
                {FormName.KreirajPrenosniRacunar, new KreirajPrenosniRacunarController()},
                {FormName.KreirajRacun, new KreirajRacunController()},
                {FormName.PretraziMarke, new PretraziMarkeController()},
                {FormName.PretraziPrenosneRacunare, new PretraziPrenosneRacunareController()},
                {FormName.PretraziRacune, new PretraziRacuneController()},
            };
        }

        internal void ShowMainForm()
        {
            _mainForm = new MainForm();
            _mainForm.AutoSize = true;
            _mainForm.ShowDialog();
        }

        internal void ShowUserControl(FormName formName)
        {
            if (_forms.TryGetValue(formName, out var formController))
            {
                _mainForm.ShowUserControl(formController.Initialize());
            }
        }

        public void Logout(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"Da li ste sigurni da zelite da se odjavite?", @"Odjavi se", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                return;
            }

            Communication.Instance.SendRequest(SistemskaOperacija.Logout, SessionStorage.Instance.Korisnik);
            SessionStorage.Instance.Korisnik = null;
            _mainForm.Close();
        }
    }
}
