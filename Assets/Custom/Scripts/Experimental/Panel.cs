using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

/// <summary>
/// This class receives and handles click on panel buttons
/// </summary>
public class Panel : BaseInterfaceElement
{
    // Because panel is a meaningful interface element, later we might need
    // to treat it as such. Inheritance from BaseInterfaceElement gives an 
    // ability to operate on it in such manner. We might enqueue a bunch of  
    // such elements, and turn them on/off, through BaseScreen interface
    
    /// <summary>
    /// Should be called by Unity event, when corresponding button is clicked
    /// </summary>
    public void OnMapButtonClick()
    {
        ScreenManager.Instance.TransitionTo(ScreenManager.Instance.mapScreen);
    }
    
    /// <summary>
    /// Should be called by Unity event, when corresponding button is clicked
    /// </summary>
    public void OnCameraButtonClick()
    {
        ScreenManager.Instance.TransitionTo(ScreenManager.Instance.cameraScreen);
    }

    /// <summary>
    /// Should be called by Unity event, when corresponding button is clicked
    /// </summary>
    public void OnInfoButtonClick()
    {
        ScreenManager.Instance.TransitionTo(ScreenManager.Instance.infoScreen);
    }
}
