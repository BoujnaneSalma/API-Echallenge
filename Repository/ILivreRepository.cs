using GestionBiblio.Models;

namespace GestionBiblio.Repository
{
    public interface ILivreRepository
    {
        List<Livre> GetAll();
        Livre GetById(int id);
        Livre GetByTitre(string titre);
        void Create(Livre livre);
        void Update(int id, Livre livre);
        void Delete(int id);
    }
}
