namespace KickAss.Specification
{
    public class AndSpecification<T> : SpecificationBase<T>
    {
        private readonly ISpecification<T> first;
        private readonly ISpecification<T> second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first;
            this.second = second;
        }

        public override bool IsSatisfiedBy(T entity)
        {
            return first.IsSatisfiedBy(entity) & second.IsSatisfiedBy(entity);
        }
    }
}