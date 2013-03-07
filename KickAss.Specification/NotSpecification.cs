namespace KickAss.Tools.Specification.UnitTests
{
    using KickAss.Specification;

    public class NotSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> specification;

        public NotSpecification(ISpecification<T> specification)
        {
            this.specification = specification;
        }

        public bool IsSatisfiedBy(T entity)
        {
            return !specification.IsSatisfiedBy(entity);
        }
    }
}