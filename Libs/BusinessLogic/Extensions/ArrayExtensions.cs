using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Extensions
{
    public static class ArrayExtensions
    {
        public static void ForEach<TItem>(this TItem[] array, Action<TItem> perItemAction)
        {
            foreach (var item in array)
            {
                perItemAction(item);
            }
        }
    }
}
