using System;

namespace VisualVault_Document_Export.Common
{
    public static class Coalesce
    {
        public static TResult UntilNull<T, TResult>(T obj, Func<T, TResult> func) where TResult : class
        {
            if (obj != null) return func(obj);
            return null;
        }

        public static TResult UntilNull<T1, T2, TResult>(T1 obj, Func<T1, T2> func1, Func<T2, TResult> func2) where TResult : class
        {
            if (obj != null) return UntilNull(func1(obj), func2);
            return null;
        }

        public static TResult UntilNull<T1, T2, T3, TResult>(T1 obj, Func<T1, T2> func1, Func<T2, T3> func2, Func<T3, TResult> func3) where TResult : class
        {
            if (obj != null) return UntilNull(func1(obj), func2, func3);
            return null;
        }

        public static TResult UntilNull<T1, T2, T3, T4, TResult>(T1 obj, Func<T1, T2> func1, Func<T2, T3> func2, Func<T3, T4> func3, Func<T4, TResult> func4) where TResult : class
        {
            if (obj != null) return UntilNull(func1(obj), func2, func3, func4);
            return null;
        }
    }
}
