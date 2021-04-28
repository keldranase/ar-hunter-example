using UnityEngine.UI;
using UnityEngine;
using System.IO;

/// <summary>
/// Interface for class, responsible for handling operations on photo and
/// video (e.g. saving, sharing)
/// </summary>
public abstract class AbstractCameraOptionsHandler : MonoBehaviour
{
    public abstract void ResetThing();
    public abstract void SaveThing();
    public abstract void ShareThing();
}

/// <summary>
/// Concrete class, responsible for handling operations on photo
/// (e.g. saving, sharing)
/// </summary>
public class PhotoOptionsHandler : AbstractCameraOptionsHandler
{
    private Texture2D screenShotTexture;
    private BaseInterfaceElement optionsScreen;
    private Image previewImage;
    
    /// <summary>
    /// Initialize class with screenshot texture, Unity Image component to
    /// to preview this screenshot, and options screen to disable
    /// </summary>
    public PhotoOptionsHandler(Texture2D screenShotTexture, Image previewImage, BaseInterfaceElement optionsScreen)
    {
        previewImage.gameObject.SetActive(true);
        previewImage.sprite = Sprite.Create(screenShotTexture, new Rect(0, 0, Screen.width, Screen.height), new Vector2(0f, 0f));
        this.screenShotTexture = screenShotTexture;
        this.previewImage = previewImage;
        this.optionsScreen = optionsScreen;
    }

    /// <summary>
    /// Delete screenshot texture and hide options screen
    /// </summary>
    public override void ResetThing()
    {
        previewImage.gameObject.SetActive(true);
        Destroy(screenShotTexture);
        optionsScreen.Disable();
        ScreenManager.Instance.cameraScreen.Enable();

        var a = new PhotoOptionsHandler(null, null, null);
    }

    /// <summary>
    /// Save image to via NativeGallery plugin
    /// </summary>
    public override void SaveThing()
    {
        NativeGallery.SaveImageToGallery(screenShotTexture, "ARHunter", "Image.png");
        ResetThing();
    }

    /// <summary>
    /// Share image via NativeShare plugin
    /// </summary>
    public override void ShareThing()
    {
        var filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, screenShotTexture.EncodeToPNG());
        new NativeShare().AddFile(filePath).Share();
        ResetThing();
    }
}