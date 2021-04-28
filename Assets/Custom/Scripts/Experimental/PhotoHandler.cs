using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public abstract class AbstractPhotoHandler : MonoBehaviour
{
    public abstract Texture2D TakePhoto();
}

public abstract class AbstractVideoHandler
{
    public abstract object TakeVideo();
}

public class PhotoHandler : AbstractPhotoHandler
{
    public static PhotoHandler Instance;

    public Canvas canvasCam;
    public Canvas canvasPanel;
    

    private Texture2D screenShotTexture;
    public Image screenShotPreview;


    private Rect rectForSS;

    public CameraOptionsScreen cameraOptionsScreen;
    
    private void Awake()
    {
        InitInstance();
    }
    
    private void InitInstance()
    {
        bool isAlone = !(Instance != null && Instance != this);
        Assert.IsTrue(isAlone);
        
        Instance = this;
    }

    /// <summary>
    /// Take photo, and set OptionsScreen
    /// </summary>
    /// <returns></returns>
    public override Texture2D TakePhoto()
    {
        StartCoroutine(TakeScreenShootCrt());
        return null;
    }

    // internal routine to make a screenshot
    private IEnumerator TakeScreenShootCrt()
    {
        // Turns elements off, to make a "clean" screenshot
        SetUIElementsActive(false);
        
        // Wait for the next frame
        yield return new WaitForEndOfFrame();

        // Make a screenshot itself
        var screenShotTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenShotTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenShotTexture.Apply();
        
        // Turn elements back
        SetUIElementsActive(true);

        // Entity, responsible for handling delete, save and share for screenshot
        var photoOptionsHandler = new PhotoOptionsHandler(screenShotTexture,
            screenShotPreview, cameraOptionsScreen);
        // Pass handler to the options screen, so the screen is relies on handler
        cameraOptionsScreen.InjectHandler(photoOptionsHandler);
        cameraOptionsScreen.Enable();
    }

    private void SetUIElementsActive(bool setActive)
    {
        // TODO: consider changing the way UI elements are disabled
        // It's ugly, but it's the best way I've found
        
        canvasCam.enabled = setActive;
        canvasPanel.enabled = setActive;
    }
}




