namespace CsharpMonads.Tags
{
    using System;

    public static class TagExtensions
    {
        public static Tag<TColor, TSource> Roll<TColor, TSource>(
            this Tag<TColor, Tag<TColor, TSource>> tags)
        {
            return Bind(tags, x => x);
        }

        public static Tag<TResultColor, TResult> Bind
            <TSourceColor, TSource, TResultColor, TResult>(
            this Tag<TSourceColor, TSource> source,
            Func<TSource, Tag<TResultColor, TResult>> selector)
        {
            var result = new Tag<TResultColor, TResult>();

            foreach (var item in source)
            {
                foreach (var newItem in selector(item))
                {
                    result.Add(newItem);
                }
            }
            return result;
        }
    }
}