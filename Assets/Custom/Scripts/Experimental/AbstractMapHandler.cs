using UnityEngine;

/// <summary>
/// Interface for internal representation of a map
/// </summary>
/// <remarks>
/// Abstract class was chosen over interface, because Unity does not support
/// interfaces as components.
/// </remarks>
public abstract class AbstractMapHandler : MonoBehaviour
{
    public static AbstractMapHandler Instance;
    public abstract void InitializeMap();
    public abstract void ShowMap();
    public abstract void HideMap();
}