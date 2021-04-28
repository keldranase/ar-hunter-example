using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Options screen, that get's input from buttons and transfers it to
/// actual handler, to delete, save and share vid or screenshot
/// </summary>
public class CameraOptionsScreen : BaseInterfaceElement
{
    // One might argue about need in this class, because input from buttons
    // can be directly set to actual handler
    // But it's necessary for extensibility and maintainability
    
    [SerializeField]
    private Image imageForPreview;

    // Options screen transfers screenshot handling to this handler
    private AbstractCameraOptionsHandler abstractCameraOptionsHandler;
    private Texture2D screenShotTexture;
    
    public void InjectHandler(AbstractCameraOptionsHandler abstractCameraOptionsHandlerIn)
    {
        abstractCameraOptionsHandler = abstractCameraOptionsHandlerIn;
    }
    
    public void ResetButtonPress()
    {
        abstractCameraOptionsHandler.ResetThing();
    }

    public void SaveButtonPress()
    {
        abstractCameraOptionsHandler.SaveThing();
    }

    public void ShareButtonPress()
    {
        abstractCameraOptionsHandler.ShareThing();
    }
}



