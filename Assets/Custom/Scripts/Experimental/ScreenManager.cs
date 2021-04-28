using UnityEngine;
using System;
using System.Reflection;
using UnityEngine.Assertions;

/// <summary>
/// Performs correct transitioning from one screen to another
/// </summary>

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager Instance;
    
    // Its debatable, if those field should be public
    public MapScreen mapScreen;
    public CameraScreen cameraScreen;
    public InfoScreen infoScreen;

    private BaseMainScreen previousScreen;
    
    
    // Gets called script gets activated first time
    private void Awake()
    {
        InitInstance();
        AssertMembers();

        // The first screen on startup is a mapScreen
        previousScreen = mapScreen;
    }

    private void AssertMembers()
    {
        Assert.IsNotNull(mapScreen);
        Assert.IsNotNull(cameraScreen);
        Assert.IsNotNull(infoScreen);
    }
    
    private void InitInstance()
    {
        if (Instance != null && Instance != this)
        {
            throw new Exception("More than one object of a class, that is meant to be a Singleton");
        }
        else
        {
            Instance = this;
        }   
    }

    /// <summary>
    /// Disable old screen, and enable new screen
    /// </summary>
    public void TransitionTo(BaseMainScreen screenTransitionTo)
    {
        Assert.IsNotNull(screenTransitionTo);
        if (screenTransitionTo == previousScreen)
        {
            return;
        }

        Debug.Log("From:: " + previousScreen + " to:: " + screenTransitionTo);
        previousScreen.Disable();
        screenTransitionTo.Enable();
        previousScreen = screenTransitionTo;
    }
}
