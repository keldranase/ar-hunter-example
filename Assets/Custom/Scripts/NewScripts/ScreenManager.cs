using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager Instance;

    public MapScreen mapScreen;
    public CameraScreen cameraScreen;
    public InfoScreen infoScreen;

    private BaseMainScreen previousScreen;

    private void Awake()
    {
        Instance = this;

        previousScreen = mapScreen;
    }

    public void TransitionTo(BaseMainScreen screenTransitionTo)
    {
        if (screenTransitionTo == previousScreen)
        {
            return;
        }

        Debug.LogError("From:: " + previousScreen + " to:: " + screenTransitionTo);
        previousScreen.DisableScreen();
        screenTransitionTo.EnableScreen();
        previousScreen = screenTransitionTo;
    }
}
