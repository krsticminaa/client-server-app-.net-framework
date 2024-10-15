using Domen.Entiteti;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    internal class SessionStorage
    {
        private static SessionStorage _instance;
        private SessionStorage()
        {
        }

        public static SessionStorage Instance => _instance ?? (_instance = new SessionStorage());
        public List<Korisnik> Korisnici { get; set; } = new List<Korisnik>();

        public void RemoveUser(Korisnik korisnik)
        {
            Korisnici = Korisnici.Where(e => e.Id != korisnik.Id).ToList();
        }
    }
}
