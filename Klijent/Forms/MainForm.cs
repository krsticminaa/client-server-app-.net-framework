using Klijent.Controllers;
using Klijent.Utils;
using System.Windows.Forms;

namespace Klijent.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            kreirajToolStripMenuItem.Click += (s, a) => MainController.Instance.ShowUserControl(FormName.KreirajPrenosniRacunar);
            kreirajToolStripMenuItem1.Click += (s, a) => MainController.Instance.ShowUserControl(FormName.KreirajMarku);
            kreirajToolStripMenuItem2.Click += (s, a) => MainController.Instance.ShowUserControl(FormName.KreirajRacun);
            pretraziToolStripMenuItem.Click += (s, a) => MainController.Instance.ShowUserControl(FormName.PretraziPrenosneRacunare);
            pretraziToolStripMenuItem1.Click += (s, a) => MainController.Instance.ShowUserControl(FormName.PretraziMarke);
            pretraziToolStripMenuItem2.Click += (s, a) => MainController.Instance.ShowUserControl(FormName.PretraziRacune);
            label1.Click += MainController.Instance.Logout;
        }

        public void ShowUserControl(Control control)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            pnlMain.AutoSize = true;
        }
    }
}
