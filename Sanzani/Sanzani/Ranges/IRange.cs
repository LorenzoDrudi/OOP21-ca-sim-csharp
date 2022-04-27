namespace Sanzani.Ranges {
    public interface IRange<T> : IEnumerable<T> {
        public IQueryable<T> Stream() {
            return this.AsQueryable();
        }
    }
}