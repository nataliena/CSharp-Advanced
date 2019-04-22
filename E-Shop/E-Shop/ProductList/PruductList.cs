using E_Shop.Models;
using System.Collections.Generic;

namespace E_Shop.ProductList
{
    public static class ProductList
    {
        public static List<Product>GetAllProduct()
        {
        return new List<Product>()
            {
                new Product(01,"The One Cologne",5,100,Vendor.DolceGabbana,Gender.Male),
                new Product(02,"Light Blue",5,120,Vendor.DolceGabbana,Gender.Female),
                new Product(03,"Eternity Cologne",5,90,Vendor.CalvinKlein,Gender.Male),
                new Product(06,"Eternity ",5,100,Vendor.CalvinKlein,Gender.Female),
                new Product(04,"Versace Eros Cologne",5,110,Vendor.Versace,Gender.Female),
                new Product(05,"Crystal Noir Perfume",6,100,Vendor.Versace,Gender.Male),                
                new Product(07,"Burberry Touch Cologne",6,90,Vendor.Burberry,Gender.Male),
                new Product(08,"The Beat",6,100,Vendor.Burberry,Gender.Female),
                new Product(09,"Armani Code",7,120,Vendor.GiorgioArmani,Gender.Female),
                new Product(10,"Acqua Di Gio Cologne",7,85,Vendor.GiorgioArmani,Gender.Male),
                new Product(11,"L'air Du Temps Perfume",8,80,Vendor.NinaRicci,Gender.Female),
                new Product(12,"L'extase",8,95,Vendor.NinaRicci,Gender.Male)
                    


};
    }
}
}