using Dasync.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batch_Uploader
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
        public static void Move<T>(this List<T> List, int FromIndex, int ToIndex)
        {
            T Item = List[FromIndex];

            List.RemoveAt(FromIndex);
            List.Insert(ToIndex, Item);
        }

        public static string ToCapital(this string String)
        {
            if (String.Length <= 1)
                return String.ToUpperInvariant();

            char First = String.First();
            First = char.ToUpperInvariant(First);
            char[] Arr = new char[] { First };
            Arr = Arr.Concat(String.Skip(1).ToArray()).ToArray();

            return new string(Arr);
        }


        public static async Task<object> SingleOrNothing<T>(this IAsyncEnumerable<T> source) where T : notnull
        {
            object result = null;
            bool Many = false;
            
           await source.ForEachAsync((Item) => {
               
               if (result != null)
               {
                   Many = true;
                   ForEachAsync.Break();
               }

                result = Item;
            });

            if (Many)
                return null;

            return result;
        }
    }
}
