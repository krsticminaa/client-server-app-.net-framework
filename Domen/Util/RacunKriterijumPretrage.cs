using System;
using Domen.Entiteti;

namespace Domen.Util
{
    [Serializable]
    public class RacunKriterijumPretrage : KriterijumPretrage
    {
        public int KorisnikId { get; set; }
        public PrenosniRacunar PrenosniRacunar { get; set; }

        public RacunKriterijumPretrage(string tekst, int korisnikId, PrenosniRacunar prenosniRacunar) : base(tekst)
        {
            KorisnikId = korisnikId;
            PrenosniRacunar = prenosniRacunar;
        }
    }
}
