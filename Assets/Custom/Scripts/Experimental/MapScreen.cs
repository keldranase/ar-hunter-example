using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// This class is responsible for handling high-level interactions
/// with Map Screen, such as dis/enabling it
/// </summary>
public class MapScreen : BaseMainScreen
{
    /// <summary>
    /// Member for interfacing with implementation of maps
    /// </summary>
    /// <remarks>
    /// By decoupling implementation from an interface, we can change
    /// internal mechanisms, without affecting any clients.
    /// It also allows us to swap implementations at run time. For example, on
    /// some devices we might need to use GoogleMap representation, and on some
    /// YandexMap representation, or give the user opportunity to choose one
    /// </remarks>
    [SerializeField]
    private AbstractMapHandler abstractMapHandler;

    public static MapScreen Instance;
    
    private void Awake()
    {
        InitInstance();
    }
    
    public override void Enable()
    {
        abstractMapHandler.ShowMap();
        base.Enable();
    }

    public override void Disable()
    {
        abstractMapHandler.HideMap();
        base.Disable();
    }

    private void InitInstance()
    {
        bool isAlone = !(Instance != null && Instance != this);
        Assert.IsTrue(isAlone);
        
        Instance = this;
    }
}
