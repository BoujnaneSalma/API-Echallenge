using GestionBiblio.Mappers;
using GestionBiblio.Models;
using GestionBiblio.Repository;
using GestionBiblio.ViewModels;

namespace GestionBiblio.Service
{
    public class LivreService : ILivreService
    {
        private readonly ILivreRepository livreRepository;

        public LivreService(ILivreRepository livreRepository) 
        {
             this.livreRepository = livreRepository;
        }


        public List<ListBookVM> GetAll()
        {
            var books = livreRepository.GetAll();
            return books.Select(BookMapper.ListViewModel).ToList();
        }

        public ListBookVM GetById(int id)
        {
            Livre livre = livreRepository.GetById(id);
            if (livre == null) throw new Exception("Book not found");

            return BookMapper.ListViewModel(livre);
        }


        public Livre GetByTitre(string titre)
        {
            Livre livre = livreRepository.GetByTitre(titre);
            if (livre == null)
                throw new KeyNotFoundException("Livre avec ce titre non trouvé");
            return livre;
        }


        public void Create(AddBookVM livrevm)
        {
            Livre livre = BookMapper.ToModel(livrevm);
            livreRepository.Create(livre);
        }

        public DeleteBookVM Delete(int id)
        {
            Livre livre = livreRepository.GetById(id);
            if (livre == null)
            {
                throw new Exception($"Le livre avec l'ID {id} n'a pas été trouvé.");
            }

            livreRepository.Delete(id);
            return BookMapper.DeleteViewModel(livre);
        }

        public void Update(UpdateBookVM updatevm)
        {
            Livre livre = livreRepository.GetById(updatevm.Id);
            if (livre == null)
            {
                throw new Exception("Le livre n'a pas été trouvé");
            }

            BookMapper.UpdateVM(updatevm, livre);
            livreRepository.Update(updatevm.Id, livre);
        }
    }
}
