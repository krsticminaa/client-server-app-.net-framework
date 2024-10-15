using Klijent.Controllers;
using System.Windows.Forms;

namespace Klijent.Forms
{
    public partial class DetaljiPrenosniRacunarForm : Form
    {
        public DetaljiPrenosniRacunarForm(int id)
        {
            InitializeComponent();
            DetaljiPrenosniRacunarController.Instance.Load(this, id);
        }
    }
}
