using System.Threading.Tasks;

namespace ContabeeApi.DB
{
    public interface IServicioDB
    {
        Task<bool> EliminaZombies();
    }
}
