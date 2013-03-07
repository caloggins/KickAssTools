namespace KickAss.Specification
{
    using System;

    public class FunctionSpecification<T> : SpecificationBase<T>
    {
        private readonly Func<T, bool> specification;

        public FunctionSpecification(Func<T, bool> specification)
        {
            this.specification = specification;
        }

        public override bool IsSatisfiedBy(T entity)
        {
            return specification(entity);
        }
    }
}