using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.Jobs;
using UnityEngine;
using Unity.Burst;
using System;
using UnityEngine.UI;
using UnityEditor;


public class CameraScreen : BaseMainScreen
{
    public Vuforia.VuforiaBehaviour vuforiaBehaviour;

    public GameObject cameraNote;

    public AbstractPhotoHandler abstractPhotoHandler;
    public AbstractVideoHandler abstractVideoHandler;

    
    private void Awake()
    {
        Instance = this;
    }


    public void PhotoButtonPress()
    {
        abstractPhotoHandler.TakePhoto();
    }

    public void VideoButtonPress()
    {

    }
}



