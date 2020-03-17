using System.Collections.Generic;

namespace LINQ
{
    class AddressList
    {
        public static List<Address> GetAllAddresses()
        {
            return new List<Address>()
            {
                new Address{ID = 1 , AddressLine ="Adresseken" },
                new Address{ID = 2 , AddressLine ="Adresseken1" },
                new Address{ID = 3 , AddressLine ="Adresseken2" },
                new Address{ID = 4 , AddressLine ="Adresseken3" },
                new Address{ID = 5 , AddressLine ="Adresseken4" },
                new Address{ID = 6 , AddressLine ="Adresseken5" },
                new Address{ID = 7 , AddressLine ="Adresseken6" },
                new Address{ID = 8 , AddressLine ="Adresseken7" },
                new Address{ID = 9 , AddressLine ="Adresseken8" },
                new Address{ID = 10 , AddressLine ="Adresseken9" },
                new Address{ID = 11 , AddressLine ="Adresseken10" },
            };
        }

    }
}
