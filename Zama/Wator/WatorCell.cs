using System;

namespace Zama.Wator
{
    public class WatorCell
    {
        private const int MinHealth = 0;
        private const int MaxHealth = 10;

        private int _health;

        /// <summary>
        /// Initializes a new instance of the <see cref="WatorCell"/> class.
        /// </summary>
        /// <param name="state">the <see cref="WatorCellState"/> of the cell</param>
        /// <param name="health">the health of the cell</param>
        public WatorCell(WatorCellState state, int health)
        {
            State = state;
            Health = health;
        }
        
        public WatorCellState State { get; private set; }
        
        /// <summary>
        /// The health of the <see cref="WatorCell"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If the value if less than 0 or greater than 10.</exception>
        public int Health
        {
            get => _health;
            set
            {
                if (value > MaxHealth || value < MinHealth)
                {
                    throw new ArgumentException("Health value must be > 0 and < 10");
                }

                _health = value;
            }
        }

        /// <summary>
        /// Returns true is the health of the cell has reached 0.
        /// </summary>
        public bool IsDead => Health == MinHealth;

        /// <summary>
        /// True if the <see cref="WatorCell"/> has moved.
        /// </summary>
        public bool HasMoved { get; set; }
        
        /// <summary>
        /// Diminishes the health of the <see cref="WatorCell"/> by
        /// 1 if health isn't at minimum.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the current <see cref="WatorCellState"/>
        ///         of the cell is <see cref="WatorCellState.Prey"/></exception>
        public void Starve()
        {
            if (State == WatorCellState.Prey)
            {
                throw new InvalidOperationException($"{State} cell cannot starve.");
            }

            Health -= IsDead ? 0 : 1;
        }

        /// <summary>
        /// Returns the <see cref="WatorCell"/> that will be left
        /// behind after a movement and changes health accordingly.
        /// </summary>
        /// <returns>a new <see cref="WatorCell"/> with the same state
        ///         if the calling cell can reproduce, <see cref="WatorCellState.Dead"/>
        ///         otherwise.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public WatorCell reproduce()
        {
            if (Health == MaxHealth)
            {
                switch (State)
                {
                    case WatorCellState.Prey:
                        Health = MinHealth + 1;
                        return new WatorCell(State, MinHealth + 1);
                    case WatorCellState.Predator:
                        Health = MaxHealth / 2;
                        return new WatorCell(State, MaxHealth / 2);
                    default:
                        throw new InvalidOperationException($"The state {State} has no reproduce operation.");
                }
            }
            else
            {
                return new WatorCell(WatorCellState.Dead, MinHealth);
            }
        }

        /// <summary>
        /// Copies the state, health and moved states
        /// of another <see cref="WatorCell"/>.
        /// </summary>
        /// <param name="other">the <see cref="WatorCell"/> to copy the
        ///         fields from.</param>
        public void Clone(WatorCell other)
        {
            State = other.State;
            Health = other.Health;
            HasMoved = other.HasMoved;
        }
    }
}