namespace casim.Chiasserini.Grid
{
    /// <summary>
    /// The grid.
    /// </summary>
    /// <typeparam name="TCoord">Type of the Coordinates contained in Grid.</typeparam>
    /// <typeparam name="TValue">Type of the elements contained in Grid.</typeparam>
    public interface IGrid<TCoord, TValue>
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
        public TValue Get(TCoord coord);

        /// <summary>
        /// Set an element to a given value.
        /// </summary>
        /// <param name="coord">The Coordinates of the element to set.</param>
        /// <param name="value">the value to insert.</param>
        public void Set(TCoord coord, TValue value);

        /// <summary>
        /// Return true if parameter coord is inside the Grid.
        /// </summary>
        /// <param name="coord">The Coordinates of the point.</param>
        public bool IsCoordValid(TCoord coord);

        /// <summary>
        /// Return a Stream of the elements in Grid.
        /// </summary>
        public IQueryable<TValue> Stream();

        /// <summary>
        /// Return a list containing the pairs Coordinates + value of the Coordinates taken as input.
        /// </summary>
        /// <param name="positions">list containing all the Coordinates of which the method have to get the values.</param>
        public List<Tuple<TCoord, TValue>> GetValuesFrom(IList<TCoord> positions)
        {
            return positions.AsQueryable()
                .Where(x => this.IsCoordValid(x))
                .Select(coord => new Tuple<TCoord, TValue>(coord, this.Get(coord)))
                .ToList();
        }
    }
}