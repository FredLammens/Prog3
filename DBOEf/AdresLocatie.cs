namespace DBOEf
{
    class AdresLocatie
    {
        private static int counter = 0;
        public AdresLocatie(int ID, double x, double y)
        {
            if (ID == -1) 
            {
                counter++;
                this.ID = counter;
            }else
            this.ID = ID;

            this.x = x;
            this.y = y;
        }
        public AdresLocatie(double x, double y)
        {
            counter++;
            this.ID = counter;
            this.x = x;
            this.y = y;
        }

        public int ID { get; private set; }
        public double x { get; private set; }
        public double y { get; private set; }
    }
}
