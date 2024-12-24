using GestionBiblio.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GestionBiblio.Repository
{
    public class LivreRepository : ILivreRepository
    {
        public static List<Livre> livreList = new List<Livre>
    {
        new Livre { Id = 1, Titre = "1984", Auteur = "George Orwell", AnnéePub = 1949, ISBN = "1234567890", NbrExempDispo = 5 },
        new Livre { Id = 2, Titre = "To Kill a Mockingbird", Auteur = "Harper Lee", AnnéePub = 1960, ISBN = "0987654321", NbrExempDispo = 3 }
    };

        public void Create(Livre livre)
        {
            
            livreList.Add(livre);
        }

        public void Delete(int id)
        {
            Livre livreToRemove = GetById(id);
            if (livreToRemove != null)
            {
                livreList.Remove(livreToRemove);
            }
            else
            {
                throw new Exception($"Le livre avec l'ID {id} n'a pas été trouvé.");
            }
        }
        public List<Livre> GetAll()
        {
            return livreList;
        }


        public Livre GetById(int id)
        {
            return livreList.FirstOrDefault(l => l.Id == id);
        }

        public Livre GetByTitre(string titre)
        {
            return livreList.FirstOrDefault(l => l.Titre.Equals(titre, StringComparison.OrdinalIgnoreCase));

        }

        public void Update(int id, Livre livre)
        {
            var existingLivre = GetById(id);
            if (existingLivre != null)
            {
                existingLivre.Titre = livre.Titre;
                existingLivre.Auteur = livre.Auteur;
                existingLivre.AnnéePub = livre.AnnéePub;
                existingLivre.NbrExempDispo = livre.NbrExempDispo;
            }
        }
    }
}
