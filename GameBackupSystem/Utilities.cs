using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackupSystem
{
    static class Utilities
    {
        public static void AssertNotNullOrEmpty(object value)
        {
            if (value == null)
                throw new ArgumentNullException("This value may not be null.");
            else if (Type.Equals(value, "") && value.Equals(""))
                throw new ArgumentException("This value may not be an empty string.");
        }

        public static void AssertNotNullOrEmpty(object[] array)
        {
            if (array == null)
                throw new ArgumentNullException("This array may not be null.");
            else if (array.Length < 1)
                throw new ArgumentException("This array may not be empty.");
        }

        public static void AssertNotNullOrEmpty(ICollection<object> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("This collection may not be null.");
            else if (collection.Count < 1)
                throw new ArgumentException("This collection may not be empty.");
        }

        public static string Plural(decimal count, string singular, string plural)
        {
            if(count == 1) { return singular; }
            else { return plural; }
        }
    }
}
