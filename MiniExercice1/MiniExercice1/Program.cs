namespace MiniExercice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ligue<Superheros> ligueSuperheros = new();
            ligueSuperheros.AjouterMembre(new Superheros("Captain Marvel", "Force et vol"));
            ligueSuperheros.DevoilerPouvoirs();
            Ligue<Vilain> ligueVilains = new();
            ligueVilains.AjouterMembre(new Vilain("Dr. Doom", "Arts mystiques"));
            ligueVilains.DevoilerPouvoirs();
            Console.WriteLine(new Humain("Gab").Nom);
            // new Humain().DevoilerPouvoirs(); // Ne compile pas
            // new Personnage("Gab"); // Ne compile pas
        }
    }
    public abstract class Personnage
    {
        public string Nom { get; protected set; }

        protected Personnage(string nom)
        {
            Nom = nom;
        }
    }
    public class Humain : Personnage
    {
        public Humain(string nom) : base(nom) { }
    }
    public class Superheros : Personnage, IPouvoirSpécial
    {
        private string Pouvoirs {  get; set; }
        public Superheros(string nom, string pouvoir) : base(nom)
        {
            Pouvoirs = pouvoir;
        }
        public string DévoilerPouvoir()
        {
            return $"Le superhéros « {Nom} » utilise son pouvoir spécial « {Pouvoirs} »";
        }
    }
    public class Vilain : Personnage, IPouvoirSpécial
    {
        private string Pouvoirs { get; set; }
        public Vilain(string nom, string pouvoir) : base(nom)
        {
            Pouvoirs = pouvoir;
        }
        public string DévoilerPouvoir()
        {
            return $"Le vilain « {Nom} » utilise son pouvoir diabolique « {Pouvoirs} »";
        }
    }
    public class Ligue<T> where T : IPouvoirSpécial
    {
        private List<T> _ligue = new List<T>();
        public void AjouterMembre(T personnage)
        {
            _ligue.Add(personnage);
        }
        public void DevoilerPouvoirs()
        {
            foreach (T personnage in _ligue)
            {
                Console.WriteLine(personnage.DévoilerPouvoir());
            }
        }
    }
    public interface IPouvoirSpécial
    {
        public string DévoilerPouvoir();
    }
}
