using Domen;
using Domen.Util;
using Server.SistemskeOperacije;
using System;
using System.Linq;
using Domen.Entiteti;
using System.Configuration;

namespace Server
{

    public class Kontroler
    {
        private static Kontroler _instance;
        private Kontroler()
        {

        }
        public static Kontroler Instance => _instance ?? (_instance = new Kontroler());

        internal Odgovor ExecuteRequest(Zahtev zahtev)
        {
            switch (zahtev.SistemskaOperacija)
            {
                case SistemskaOperacija.DodajPrenosniRacunar: 
                    return DodajPrenosniRacunarSo(zahtev.Entity);
                case SistemskaOperacija.ObrisiPrenosniRacunar:
                    return ObrisiPrenosniRacunarSo(zahtev.Entity);
                case SistemskaOperacija.PretraziMarkePrenosnihRacunara:
                    return PretraziMarkePrenosnihRacunaraSo(zahtev.Entity);
                case SistemskaOperacija.PretraziPrenosneRacunare:
                    return PretraziPrenosneRacunareSo(zahtev.Entity);
                case SistemskaOperacija.PretraziRacune:
                    return PretraziRacuneSo(zahtev.Entity);
                case SistemskaOperacija.PrijaviSe:
                    return PrijaviSeSo(zahtev.Entity);
                case SistemskaOperacija.UcitajPrenosniRacunar:
                    return UcitajPrenosniRacunarSo(zahtev.Entity);
                case SistemskaOperacija.UcitajRacun:
                    return UcitajRacunSo(zahtev.Entity);
                case SistemskaOperacija.VratiListuKarakteristika:
                    return VratiListuKarakteristikaSo(zahtev.Entity);
                case SistemskaOperacija.VratiListuMarki:
                    return VratiListuMarkiSo(zahtev.Entity);
                case SistemskaOperacija.VratiListuPrenosnihRacunara:
                    return VratiListuPrenosnihRacunaraSo(zahtev.Entity);
                case SistemskaOperacija.VratiListuRacuna:
                    return VratiListuRacunaSo(zahtev.Entity);
                case SistemskaOperacija.VratiMarkuPrenosnogRacunara:
                    return VratiMarkuPrenosnogRacunaraSo(zahtev.Entity);
                case SistemskaOperacija.ZapamtiMarkuPrenosnogRacunara:
                    return ZapamtiMarkuPrenosnogRacunaraSo(zahtev.Entity);
                case SistemskaOperacija.ZapamtiRacun:
                    return ZapamtiRacunSo(zahtev.Entity);
                case SistemskaOperacija.Logout:
                    return Logout(zahtev.Entity);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private Odgovor Logout(IEntity entity)
        {
            var korisnik = entity as Korisnik;
            SessionStorage.Instance.RemoveUser(korisnik);
            return new Odgovor(true);
        }

        private Odgovor ZapamtiRacunSo(IEntity entity)
        {
            OpstaSistemskaOperacija oso = new ZapamtiRacun();
            oso.Execute(entity);
            return new Odgovor(true);
        }

        private Odgovor ZapamtiMarkuPrenosnogRacunaraSo(IEntity entity)
        {
            OpstaSistemskaOperacija oso = new ZapamtiMarkuPrenosnogRacunara();
            oso.Execute(entity);

            if (((ZapamtiMarkuPrenosnogRacunara)oso).ExistSame)
            {
                return new Odgovor(false, "Postoji marka prenosnog racunara sa istim nazivom");
            }

            return new Odgovor(true);
        }

        private Odgovor VratiMarkuPrenosnogRacunaraSo(IEntity entity)
        {
            OpstaSistemskaOperacija oso = new VratiMarkuPrenosnogRacunara();
            oso.Execute(entity);
            return new Odgovor(true, ((VratiMarkuPrenosnogRacunara)oso).Entity);
        }

        private Odgovor VratiListuRacunaSo(IEntity entity)
        {
            OpstaSistemskaOperacija oso = new VratiListuRacuna();
            oso.Execute(entity);
            return new Odgovor(true, ((VratiListuRacuna)oso).Entities);
        }

        private Odgovor VratiListuPrenosnihRacunaraSo(IEntity entity)
        {
            OpstaSistemskaOperacija oso = new VratiListuPrenosnihRacunara();
            oso.Execute(entity);
            return new Odgovor(true, ((VratiListuPrenosnihRacunara)oso).Entities);
        }

        private Odgovor VratiListuMarkiSo(IEntity entity)
        {
            OpstaSistemskaOperacija oso = new VratiListuMarki();
            oso.Execute(entity);
            return new Odgovor(true, ((VratiListuMarki)oso).Entities);
        }

        private Odgovor VratiListuKarakteristikaSo(IEntity entity)
        {
            OpstaSistemskaOperacija oso = new VratiListuKarakteristika();
            oso.Execute(entity);
            return new Odgovor(true, ((VratiListuKarakteristika)oso).Entities);
        }

        private Odgovor UcitajRacunSo(IEntity entity)
        {
            OpstaSistemskaOperacija oso = new UcitajRacun();
            oso.Execute(entity);
            return new Odgovor(true, ((UcitajRacun)oso).Entity);
        }

        private Odgovor UcitajPrenosniRacunarSo(IEntity entity)
        {
            OpstaSistemskaOperacija oso = new UcitajPrenosniRacunar();
            oso.Execute(entity);
            return new Odgovor(true, ((UcitajPrenosniRacunar)oso).Entity);
        }

        private Odgovor PrijaviSeSo(IEntity entity)
        {
            OpstaSistemskaOperacija oso = new PrijaviSe();

            var maxUsers = Convert.ToInt32(ConfigurationManager.AppSettings["UserId"]);
            if (SessionStorage.Instance.Korisnici.Count >= maxUsers)
            {
                return new Odgovor(false);
            }

            oso.Execute(entity);

            var korisnik = entity as Korisnik;

            if (SessionStorage.Instance.Korisnici.Any(e => e.Sifra == korisnik?.Sifra && e.Email == korisnik?.Email))
            {
                return new Odgovor(false);
            }

            var user = ((PrijaviSe)oso).Entity;

            if (user == null)
            {
                return new Odgovor(false);
            }

            SessionStorage.Instance.Korisnici.Add(user as Korisnik);

            return new Odgovor(true, user);
        }

        private Odgovor PretraziRacuneSo(IEntity entity)
        {
            OpstaSistemskaOperacija oso = new PretraziRacune();
            oso.Execute(entity);
            return new Odgovor(true, ((PretraziRacune)oso).Entities);
        }

        private Odgovor PretraziPrenosneRacunareSo(IEntity entity)
        {
            OpstaSistemskaOperacija oso = new PretraziPrenosneRacunare();
            oso.Execute(entity);
            return new Odgovor(true, ((PretraziPrenosneRacunare)oso).Entities);
        }

        private Odgovor PretraziMarkePrenosnihRacunaraSo(IEntity entity)
        {
            OpstaSistemskaOperacija oso = new PretraziMarkePrenosnihRacunara();
            oso.Execute(entity);
            return new Odgovor(true, ((PretraziMarkePrenosnihRacunara)oso).Entities);
        }

        private Odgovor ObrisiPrenosniRacunarSo(IEntity entity)
        {
            OpstaSistemskaOperacija oso = new ObrisiPrenosniRacunar();
            oso.Execute(entity);
            return new Odgovor(true);
        }

        private Odgovor DodajPrenosniRacunarSo(IEntity entity)
        {
            OpstaSistemskaOperacija oso = new DodajPrenosniRacunar();
            oso.Execute(entity);

            if (((DodajPrenosniRacunar)oso).ExistSame)
            {
                return new Odgovor(false, "Postoji prenosni racunar sa istim nazivom");
            }

            return new Odgovor(true);
        }
    }
}
