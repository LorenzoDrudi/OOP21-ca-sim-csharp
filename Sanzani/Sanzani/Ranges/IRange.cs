namespace Sanzani.Ranges;

/// <summary>
/// Interface that models a range of elements.
/// Used to provide something that can mimic python's range function.
/// </summary>
/// <typeparam name="T">the type of the values that the range iterates over.</typeparam>
public interface IRange<T> : IEnumerable<T> {

    /// <summary>
    /// Return an IQueryable from an IRange instance.
    /// </summary>
    /// <returns>an IQueryable of T.</returns>
    public IQueryable<T> Stream() {
        return this.AsQueryable();
    }
}
