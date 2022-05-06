namespace casim.Chiasserini.Grid
{
    /// <summary>
    /// The grid.
    /// </summary>
    /// <param name="K">Type of the Coordinates contained in Grid.</param>
    /// <param name="V">Type of the elements contained in Grid.</param>
    public interface IGrid<K, V>
    {
        /// <summary>
        /// Return the width of the cell.
        /// </summary>
        public int Width { get; }
        
        /// <summary>
        /// Return the height of the cell.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Return the value at given coordinates.
        /// </summary>
        /// <param name="coord">The Coordinates of the point.</param>
        public V Get(K coord);

        /// <summary>
        /// Set an element to a given value.
        /// </summary>
        /// <param name="coord">The Coordinates of the element to set.</param>
        /// <param name="value">the value to insert.</param>
        public void Set(K coord, V value);

        /// <summary>
        /// Return true if parameter coord is inside the Grid.
        /// </summary>
        /// <param name="coord">The Coordinates of the point.</param>
        public bool IsCoordValid(K coord);

        /// <summary>
        /// Return a Stream of the elements in Grid.
        /// </summary>
        public IQueryable<V> Stream();

        /// <summary>
        /// Return a list containing the pairs Coordinates + value of the Coordinates taken as input.
        /// </summary>
        /// <param name="positions">list containing all the Coordinates of which the method have to get the values.</param>
        public List<Tuple<K, V>> GetValuesFrom(IList<K> positions)
        {
            return positions.AsQueryable()
                .Where(x => this.IsCoordValid(x))
                .Select(coord => new Tuple<K, V>(coord, this.Get(coord)))
                .ToList();
        }
    }
}