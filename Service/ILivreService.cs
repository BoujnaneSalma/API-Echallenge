using GestionBiblio.Models;
using GestionBiblio.ViewModels;

namespace GestionBiblio.Service
{
    public interface ILivreService
    {
        List<ListBookVM> GetAll();
        ListBookVM GetById(int id);
        Livre GetByTitre(string titre);
        void Create(AddBookVM livrevm);
        void Update(UpdateBookVM updatevm);
        DeleteBookVM Delete(int id);
    }
}
