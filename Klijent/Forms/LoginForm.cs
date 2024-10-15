using Klijent.Controllers;
using System.Windows.Forms;

namespace Klijent.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            btnKreiraj.Click += LoginController.Instance.Login;
        }
    }
}
