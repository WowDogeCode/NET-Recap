using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages<T>
        where T : IEntity, new()
    {
        public static string Added = string.Format("{0} is added", typeof(T).Name);
        public static string Updated = string.Format("{0} is updated", typeof(T).Name);
        public static string Deleted = string.Format("{0} is deleted", typeof(T).Name);
        public static string CarsListed = string.Format("Cars are listed");
        public static string ColorsListed = string.Format("Colors are listed");
        public static string BrandsListed = string.Format("Brands are listed");
        public static string InformationInvalid = string.Format("{0} information is invalid", typeof(T).Name);
        public static string CarUnavaible = string.Format("The car you picked is not avaible for rent");
        public static string CarRented = string.Format("Car is rented");
    }
}
