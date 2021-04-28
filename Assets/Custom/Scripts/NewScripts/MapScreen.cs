using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScreen : BaseMainScreen
{
    public AbstractMapHandler abstractMapHandler;

    private void Awake()
    {
        Instance = this;
    }

    public override void EnableScreen()
    {
        abstractMapHandler.ShowMap();
        base.EnableScreen();
    }

    public override void DisableScreen()
    {
        abstractMapHandler.HideMap();
        base.DisableScreen();
    }
}
