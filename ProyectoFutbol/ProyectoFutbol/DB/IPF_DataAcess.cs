using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoFutbol.DB
{
    public interface IPF_DataAcess
    {
        Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString);
        Task SaveData<T>(string sql, T parameters, string connectionString);


    }
}