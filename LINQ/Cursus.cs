namespace LINQ
{
    public class Cursus
    {
        public string Naam { get; set; }
        public int StudiePunten { get; set; }
        public Cursus(string naam, int studiePunten) => (Naam, StudiePunten) = (naam, studiePunten);
        public override string ToString()
        {
            return $" {this.Naam} | {this.StudiePunten}";
        }
    }
}
