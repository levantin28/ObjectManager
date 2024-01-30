namespace OM.Common.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Executes the give predicate on all elements of the enumerable
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="predicate">A lambda function containing the predicate which will be executed</param>
        public static void ForEach<TType>(this IEnumerable<TType> enumerable, Action<TType> predicate)
        {
            foreach (var element in enumerable)
            {
                predicate(element);
            }
        }

        /// <summary>
        /// Executes the give predicate on all elements of the enumerable
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="predicate">A lambda function containing the predicate which will be executed</param>
        public static async Task ForEachAsync<TType>(this IEnumerable<TType> enumerable, Func<TType, Task> predicate)
        {
            foreach (var element in enumerable)
            {
                await predicate(element);
            }
        }
    }
}
