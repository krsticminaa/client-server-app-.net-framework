using System.Windows.Forms;

namespace Klijent.Controllers
{
    public abstract class BaseFormController
    {
        protected Control Control;
        public Control Initialize()
        {
            Load();
            Actions();
            return Control;
        }

        public abstract void Load();
        public abstract void Actions();
    }
}
