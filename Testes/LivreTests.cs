using GestionBiblio.Models;
using GestionBiblio.Repository;
using Xunit;

namespace GestionBiblio.Tests
{
    public class LivreRepositoryTests
    {
        private LivreRepository _repository;

        public LivreRepositoryTests()
        {
            // Réinitialiser la liste avant chaque test
            _repository = new LivreRepository();
        }

        [Fact]
        public void GetAll_RetourneTousLesLivres()
        {
            // Act
            var livres = _repository.GetAll();

            // Assert
            Assert.NotNull(livres);
            Assert.Equal(2, livres.Count);
        }

        [Fact]
        public void GetById_LivreExistant_RetourneLeLivre()
        {
            // Arrange
            int idRecherche = 1;

            // Act
            var livre = _repository.GetById(idRecherche);

            // Assert
            Assert.NotNull(livre);
            Assert.Equal(idRecherche, livre.Id);
            Assert.Equal("1984", livre.Titre);
        }

        [Fact]
        public void GetById_LivreInexistant_RetourneNull()
        {
            // Arrange
            int idRecherche = 999;

            // Act
            var livre = _repository.GetById(idRecherche);

            // Assert
            Assert.Null(livre);
        }

        [Fact]
        public void GetByTitre_LivreExistant_RetourneLeLivre()
        {
            // Arrange
            string titreCherche = "1984";

            // Act
            var livre = _repository.GetByTitre(titreCherche);

            // Assert
            Assert.NotNull(livre);
            Assert.Equal(titreCherche, livre.Titre);
        }

        [Fact]
        public void GetByTitre_LivreInexistant_RetourneNull()
        {
            // Arrange
            string titreCherche = "Livre Inexistant";

            // Act
            var livre = _repository.GetByTitre(titreCherche);

            // Assert
            Assert.Null(livre);
        }

        [Fact]
        public void Create_AjoutNouveauLivre_AugmenteLaListeDUnLivre()
        {
            // Arrange
            var nouveauLivre = new Livre
            {
                Id = 3,
                Titre = "Le Petit Prince",
                Auteur = "Antoine de Saint-Exupéry",
                AnnéePub = 1943,
                ISBN = "9782070612758",
                NbrExempDispo = 4
            };

            // Act
            _repository.Create(nouveauLivre);
            var livres = _repository.GetAll();

            // Assert
            Assert.Equal(3, livres.Count);
            Assert.Contains(nouveauLivre, livres);
        }

        [Fact]
        public void Update_LivreExistant_MettreAJourLesInformations()
        {
            // Arrange
            int idLivreAModifier = 1;
            var livreModifie = new Livre
            {
                Titre = "1984 (Édition Révisée)",
                Auteur = "George Orwell",
                AnnéePub = 1949,
                NbrExempDispo = 10
            };

            // Act
            _repository.Update(idLivreAModifier, livreModifie);
            var livreApresModification = _repository.GetById(idLivreAModifier);

            // Assert
            Assert.Equal("1984 (Édition Révisée)", livreApresModification.Titre);
            Assert.Equal(10, livreApresModification.NbrExempDispo);
        }

        
       

        [Fact]
        public void Delete_LivreInexistant_JeterUneException()
        {
            // Arrange
            int idLivreInexistant = 999;

            // Act & Assert
            Assert.Throws<Exception>(() => _repository.Delete(idLivreInexistant));
        }
    }
}