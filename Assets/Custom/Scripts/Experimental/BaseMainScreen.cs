using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

/// <summary>
/// Provides screen abstraction for screens, accessible from the panel
/// </summary>
/// <remarks>
/// The Main screens are differ from other ones, in the way, that they have
/// a corresponding button, and it's visual state should be updated, depending
/// on the state of the screen 
/// </remarks>
public abstract class BaseMainScreen : BaseInterfaceElement
{
    // TODO: change en/disable routines, so they don't GetComponent each time

    /// <summary>
    /// Unity Image component, corresponding to button on the panel
    /// </summary>
    [SerializeField]
    private Image buttonImage;

    private void Awake()
    {
        // Make sure, image has been assigned
        Assert.IsNotNull(buttonImage);
    }

    /// <summary>
    /// Performs basic operations to activate Main Screen
    /// </summary>
    public override void Enable()
    {
        // Main screens have more objects in hierarchy, so it's inefficient
        // to dis/enable them by changing state of master object
        // Hence why we use canvas component, to control screen visibility
        GetComponent<Canvas>().enabled = true;
        SetEnabledColor();
    }
    
    /// <summary>
    /// Performs basic operations to deactivate Main Screen
    /// </summary>
    public override void Disable()
    {
        GetComponent<Canvas>().enabled = false;
        SetDisabledColor();
    }
    
    /// <summary>
    /// Sets the color of corresponding button to enabled color
    /// </summary>
    protected virtual void SetEnabledColor()
    {
        buttonImage.color = AppColors.red;
    }

    /// <summary>
    /// Sets the color of corresponding button to disabled color
    /// </summary>
    protected virtual void SetDisabledColor()
    {
        buttonImage.color = AppColors.tenGray;
    }
}
