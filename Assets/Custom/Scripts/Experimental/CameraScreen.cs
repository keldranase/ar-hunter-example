using System;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// This class is responsible for handling high-level interactions
/// with CameraScreen, such as dis/enabling it and pressing buttons
/// </summary>

public class CameraScreen : BaseMainScreen
{
    [SerializeField]
    private Vuforia.VuforiaBehaviour vuforiaBehaviour;

    [SerializeField]
    private AbstractPhotoHandler abstractPhotoHandler;
    [SerializeField]
    private AbstractVideoHandler abstractVideoHandler;

    public static CameraScreen Instance;
    
    private void Awake()
    {
        InitInstance();
    }
    
    private void InitInstance()
    {
        bool isAlone = !(Instance != null && Instance != this);
        Assert.IsTrue(isAlone);
        
        Instance = this;
        // TODO:: change all other InitInstances to the same kind
    }

    /// <summary>
    /// Should be called, when UI button is pressed 
    /// </summary>
    public void PhotoButtonPress()
    {
        // Curse the day, I made this aberration
        // But it was fun experience
        abstractPhotoHandler.TakePhoto();
    }

    /// <summary>
    /// Should be called, when UI button is pressed 
    /// </summary>
    public void VideoButtonPress()
    {
        throw new NotImplementedException("Video recording isn't implemented in this version");
    }

    public override void Enable()
    {
        VuforiaBehaviourSetActive(true);
        base.Enable();
    }

    public override void Disable()
    {
        VuforiaBehaviourSetActive(false);
        base.Disable();
    }

    private void VuforiaBehaviourSetActive(bool newState)
    {
        vuforiaBehaviour.enabled = newState;
    }
}



