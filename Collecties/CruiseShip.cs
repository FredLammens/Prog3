namespace OefCollecties
{
    class CruiseShip : Ship
    {
        public int AantalPassagiers { get; private set; }
        public CruiseShip(int aantalPassagiers, float lengte, float breedte, string naam) : base(lengte, breedte, naam)
        {
            AantalPassagiers = aantalPassagiers;
        }
        public override string ToString()
        {
            return base.ToString() + $" Het heeft ook {AantalPassagiers} aantal passagiers.\n";
        }
    }
}
