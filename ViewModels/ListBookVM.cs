namespace GestionBiblio.ViewModels
{
    public class ListBookVM
    {
        
            public int Id { get; set; }
            public string Titre { get; set; }
            public string Auteur { get; set; }
            public int AnnéePub { get; set; }
            public string ISBN { get; set; }
            public int NbrExempDispo { get; set; }

        
    }
}
