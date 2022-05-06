using System;
using System.Collections.Generic;
using System.Linq;
using casim.Chiasserini.Grid;
using casim.Drudi.Cell;
using casim.Zama.Coordinates;

namespace casim.Drudi.AbstractionUtils
{
    /// <summary>
    /// Utility class for the standard neighbors functions.
    /// </summary>
    public static class NeighborsFunctions
    {
        /// <summary>
        /// Method to obtain all the neighbors of a 2D Cell.
        /// </summary>
        /// <param name="cellPair">A <see cref="Tuple"/> <see cref="Coordinates2D"/> + <see cref="AbstractCell{T}"/> implementation;</param>
        /// <param name="grid">The 2D grid where search the neighbors.</param>
        /// <typeparam name="TCell">The <see cref="AbstractCell{T}"/> implementation;</typeparam>
        /// <typeparam name="TState">The states of the cell.</typeparam>
        /// <returns></returns>
        public static List<Tuple<Coordinates2D, TCell>> Neighbors2DFunction<TCell, TState>(Tuple<Coordinates2D, TCell> cellPair, 
            IGrid<Coordinates2D, TCell> grid) where TCell:AbstractCell<TState>
        {
            return CoordinatesUtil.Get2DNeighbors(cellPair.Item1)
                .Where(grid.IsCoordValid)
                .Select(coord => new Tuple<Coordinates2D, TCell>(coord, grid.Get(coord)))
                .ToList();
        }
        
        /// <summary>
        /// Method to obtain all the moore neighbors of a 2D cell.
        /// </summary>
        /// <param name="cellPair">A <see cref="Tuple"/> <see cref="Coordinates2D"/> + <see cref="AbstractCell{T}"/> implementation;</param>
        /// <param name="grid">The 2D grid where search the neighbors.</param>
        /// <typeparam name="TCell">The <see cref="AbstractCell{T}"/> implementation;</typeparam>
        /// <typeparam name="TState">The states of the cell.</typeparam>
        /// <returns></returns>
        public static List<Tuple<Coordinates2D, TCell>> MooreNeighborsFunction<TCell, TState>(Tuple<Coordinates2D, TCell> cellPair, 
            IGrid<Coordinates2D, TCell> grid) where TCell:AbstractCell<TState>
        {
            return new List<Coordinates2D> { CoordinatesUtil.Of(1, 0), CoordinatesUtil.Of(0, 1), CoordinatesUtil.Of(0, -1), CoordinatesUtil.Of(-1, 0),
                    CoordinatesUtil.Of(1, 1), CoordinatesUtil.Of(-1, 1), CoordinatesUtil.Of(1, -1), CoordinatesUtil.Of(-1, -1)}
                .Select(n => n + cellPair.Item1)
                .Where(grid.IsCoordValid)
                .Select(coord => new Tuple<Coordinates2D, TCell>(coord, grid.Get(coord)))
                .ToList();
        }
        
        /// <summary>
        /// Method to obtain all the moore neighbors of a 3D cell.
        /// </summary>
        /// <param name="cellPair">A <see cref="Tuple"/> <see cref="Coordinates3D"/> + <see cref="AbstractCell{T}"/> implementation;</param>
        /// <param name="grid">The 3D grid where search the neighbors.</param>
        /// <typeparam name="TCell">The <see cref="AbstractCell{T}"/> implementation;</typeparam>
        /// <typeparam name="TState">The states of the cell.</typeparam>
        /// <returns></returns>
        public static List<Tuple<Coordinates3D, TCell>> Neighbors3DFunction<TCell, TState>(Tuple<Coordinates3D, TCell> cellPair, 
            IGrid<Coordinates3D, TCell> grid) where TCell:AbstractCell<TState>
        {
            return CoordinatesUtil.Get3DNeighbors(cellPair.Item1)
                .Where(grid.IsCoordValid) 
                .Select(coord => new Tuple<Coordinates3D, TCell>(coord, grid.Get(coord)))
                .ToList();
        }
    }
    
}