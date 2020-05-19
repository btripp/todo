using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Todo
{
    public static class EnumerableExtensions
    {
        public static ObservableCollection<T> AsObservable<T>(this IEnumerable<T> collection)
        {
            return new ObservableCollection<T>(collection);
        }
    }
}
