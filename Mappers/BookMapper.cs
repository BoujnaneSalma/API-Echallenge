using GestionBiblio.Models;
using GestionBiblio.ViewModels;

namespace GestionBiblio.Mappers
{
    public static class BookMapper
    {
        //Mapper pour l'ajout
        public static Livre ToModel(AddBookVM vm)
        {
            return new Livre
            {
                Id = vm.Id,
                Titre = vm.Titre,
                Auteur = vm.Auteur,
                AnnéePub = vm.AnnéePub,
                ISBN = vm.ISBN,
                NbrExempDispo = vm.NbrExempDispo,
            };
        }
        //Mappper pour Update
        public static void UpdateVM(UpdateBookVM vm, Livre livre)
        {
            livre.Titre = vm.Titre;
            livre.Auteur = vm.Auteur;
            livre.AnnéePub = vm.AnnéePub;
            livre.ISBN = vm.ISBN;
            livre.NbrExempDispo = vm.NbrExempDispo;
        }
        //Mapper Pour Lister
        public static ListBookVM ListViewModel(Livre livre)
        {
            return new ListBookVM
            {
                Id = livre.Id,
                Titre = livre.Titre,
                Auteur = livre.Auteur,
                AnnéePub = livre.AnnéePub,
                ISBN = livre.ISBN,
                NbrExempDispo = livre.NbrExempDispo,
            };
        }
        //Mapper pour delete
        public static DeleteBookVM DeleteViewModel(Livre livre)
        {
            return new DeleteBookVM
            {
                Id = livre.Id,
                Titre = livre.Titre
            };
        }
    }
}
