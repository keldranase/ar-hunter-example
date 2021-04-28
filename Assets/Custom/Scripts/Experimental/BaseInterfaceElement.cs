using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Base class, for all kinds of elements, providing an abstraction
/// of an element, that can be turned on and off.
/// </summary>
public abstract class BaseInterfaceElement : MonoBehaviour
{
    /// <summary>
    /// Parent object of all other objects for the given element 
    /// in the hierarchy. 
    /// </summary>
    public GameObject masterOfElement;

    private void Awake()
    {
        // Make sure, screenMaster has been assigned via inspector
        Assert.IsNotNull(masterOfElement);
    }
    
    /// <summary>
    /// Enables master object of the given screen.
    /// </summary>
    public virtual void Enable()
    {
        masterOfElement.SetActive(true);
    }

    /// <summary>
    /// Disables master object of the given screen.
    /// </summary>
    public virtual void Disable()
    {
        masterOfElement.SetActive(false);
    }
}

