using Domen.Entiteti;

namespace Klijent.Storage
{
    internal class SessionStorage
    {
        private static SessionStorage _instance;
        private SessionStorage()
        {
        }

        public static SessionStorage Instance => _instance ?? (_instance = new SessionStorage());
        public Korisnik Korisnik { get; set; }
    }
}
