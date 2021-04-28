using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using JetBrains.Annotations;
using NinevaStudios.GoogleMaps.Internal;
using UnityEngine.UI;
using NinevaStudios.GoogleMaps;
using System;
using UnityEngine.Assertions;

/// <summary>
/// GoogleMap implementation of AbstractMap interface
/// </summary>
public class MapHandler : AbstractMapHandler
{
    // Unity UI component, to define map coordinates on the screen
    [SerializeField]
    private RectTransform rect;

    // Data file, containing style for the map
    [SerializeField]
    private TextAsset customStyle;

    // Data for markers on the map
    [SerializeField]
    private TextAsset markerData;
    
    // The map itself!!!
    private static GoogleMapsView map;

    // List of cities, where the content is
    // Naming convention for cities is from ip-api.com, to make future
    // integration ip-based determining of persons city easy
    private enum PossiblePositions
    {
        St_Petersburg  
    }
    
    // Symbol table to make it easy to get corresponding position of city
    private Dictionary<PossiblePositions, LatLng> initialCameraPositions =
        new Dictionary<PossiblePositions, LatLng>
        {
            {
                PossiblePositions.St_Petersburg,
                new LatLng(59.94313665, 30.27534842)
            }
        };
    
    private void Awake()
    {
        InitInstance();
        CheckPermission();
    }

    /// <summary>
    /// Performs a chain of operations to prepare a map, before it's shown
    /// </summary>
    public override void InitializeMap()
    {
        // Perform a basic configuration, and make a map of it
        GoogleMapsOptions options = CreateMapViewOptions();
        map = new GoogleMapsView(options);

        map.Show(RectTransformToScreenSpace(rect), OnMapReady);
    }
    
    /// <summary>
    /// Makes map visible on the screen! Who would have thought :D
    /// </summary>
    public override void ShowMap()
    {
        // Show map must ALWAYS be called after map has been initialized
        // I thought about making show map call InitializeMap, if it's null
        // but such cases should never happen, and needed to be spotted
        // during development
        Assert.IsTrue(map != null);

        map.IsVisible = true;
    }

    /// <summary>
    /// Hides map
    /// </summary>
    public override void HideMap()
    {
        // Hide map must ALWAYS be called after map has been initialized
        Assert.IsTrue(map != null);
        
        map.IsVisible = false;
    }
    
    // This routine sets some things
    private GoogleMapsOptions CreateMapViewOptions()
    {
        var options = new GoogleMapsOptions();
        var initialPos = initialCameraPositions[PossiblePositions.St_Petersburg];
        options.Camera(new CameraPosition(initialPos, 14.0f, 0.0f, 0.0f));
        options.MapType(GoogleMapType.Normal);
        options.CompassEnabled(true);

        return options;
    }
    
    private void OnMapReady()
    {
        SetCustomStyle();

        map.SetOnMarkerClickListener(marker => OnMarkerClick(marker), false);

        AddMarkers();

        map.IsMyLocationEnabled = true;
        map.UiSettings.IsMyLocationButtonEnabled = true;
    }
    
    /// <summary>
    /// Get coordinates on the screen, where map going to be drawn
    /// </summary>
    private Rect RectTransformToScreenSpace(RectTransform rectTransform)
    {
        Vector2 size = Vector2.Scale(rectTransform.rect.size, rectTransform.lossyScale);
        Rect rect = new Rect(rectTransform.position.x, Screen.height - rectTransform.position.y, size.x, size.y);
        rect.x -= rectTransform.pivot.x * size.x;
        rect.y -= (1.0f - rectTransform.pivot.y) * size.y;
        rect.x = Mathf.CeilToInt(rect.x);
        rect.y = Mathf.CeilToInt(rect.y);
        return rect;
    }
    
    private void AddMarkers()
    {
        var paramList = TextDecoder.CreateCustomMarkerParamsList(markerData.text);
        
        foreach (var sth in paramList)
        {
            var options = new MarkerOptions()
                .Position(sth.getLatLng())
                .Title(sth.getTitle())
                .Icon(NewCustomDescriptor())
                .Snippet(sth.getSnippet());
            var marker = map.AddMarker(options);
        }
    }

    private ImageDescriptor NewCustomDescriptor()
    {
        return ImageDescriptor.FromAsset("Pin.png");
    }

    private void OnMarkerClick(Marker marker)
    {
        // It's alright, this method should be impty
    }

    private void SetCustomStyle()
    {
        map.SetMapStyle(customStyle.text); 
    }

    private void CheckPermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
    }
    
    private void InitInstance()
    {
        // Make sure, that there is ONLY ONE instance of this class
        Assert.IsFalse(Instance != null && Instance != this);
        
        Instance = this;
    }
}


