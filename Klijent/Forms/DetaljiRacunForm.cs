using Klijent.Controllers;
using System.Windows.Forms;

namespace Klijent.Forms
{
    public partial class DetaljiRacunForm : Form
    {
        public DetaljiRacunForm(int id)
        {
            InitializeComponent();
            DetaljiRacunController.Instance.Load(this, id);
        }
    }
}
