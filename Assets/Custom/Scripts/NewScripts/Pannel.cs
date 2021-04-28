using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class Pannel : BaseScreen
{
    public GameObject map;
    public GameObject photo;
    public GameObject info;

    public Image mapImage;
    public Image photoImage;
    public Image infoImage;

    private void Awake()
    {
        Instance = this;
    }

    public void OnMapButtonClick()
    {
        ScreenManager.Instance.TransitionTo(ScreenManager.Instance.mapScreen);
    }

    public void OnCameraButtonClick()
    {
        ScreenManager.Instance.cameraScreen.SetColor();
        ScreenManager.Instance.TransitionTo(ScreenManager.Instance.cameraScreen);
    }

    public void OnInfoButtonClick()
    {
        ScreenManager.Instance.TransitionTo(ScreenManager.Instance.infoScreen);
    }
}
