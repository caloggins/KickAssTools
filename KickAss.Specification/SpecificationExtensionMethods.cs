namespace KickAss.Specification
{
    using Tools.Specification.UnitTests;

    public static class SpecificationExtensionMethods
    {
        public static ISpecification<T> Or<T>(this ISpecification<T> first, ISpecification<T> second)
        {
            return new OrSpecification<T>(first, second);
        }

        public static ISpecification<T> And<T>(this ISpecification<T> first, ISpecification<T> second)
        {
            return new AndSpecification<T>(first, second);
        }

        public static ISpecification<T> Not<T>(this ISpecification<T> original)
        {
            return new NotSpecification<T>(original);
        }
    }
}