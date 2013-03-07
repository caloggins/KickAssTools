namespace KickAss.Specification
{
    public class OrSpecification<T> : SpecificationBase<T>
    {
        private readonly ISpecification<T> spec1;
        private readonly ISpecification<T> spec2;

        public OrSpecification(ISpecification<T> spec1, ISpecification<T> spec2)
        {
            this.spec1 = spec1;
            this.spec2 = spec2;
        }

        public override bool IsSatisfiedBy(T entity)
        {
            return spec1.IsSatisfiedBy(entity) | spec2.IsSatisfiedBy(entity);
        }
    }
}