namespace KickAss.Specification
{
    public abstract class SpecificationBase<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T entity);

        public static AndSpecification<T> operator &(SpecificationBase<T> first, SpecificationBase<T> second)
        {
            return new AndSpecification<T>(first, second);
        }

        public static OrSpecification<T> operator |(SpecificationBase<T> first, SpecificationBase<T> second)
        {
            return new OrSpecification<T>(first, second);
        }
    }
}