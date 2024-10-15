using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    public interface IEntity
    {
        int Id { get; set; }
        string NazivTabele();
        string NazivTabeleAnotacija();
        string Dodaj();
        string Izmeni();
        string Join();
        string Where(string searchText = default);
        List<IEntity> VratiObjekte(SqlDataReader reader);
    }
}
