using System.Drawing;

namespace Sanzani.StateColorMapper;

/// <summary>
/// A mapper which map to a state a specific Color.
/// </summary>
/// <typeparam name="T">the type of the states take as input.</typeparam>
public interface IStateColorMapper<T>
{
    public Color ToColor(T state);
}