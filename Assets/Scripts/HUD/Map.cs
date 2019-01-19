using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Serialization;

public class Map : MonoBehaviour
{
    [FormerlySerializedAs("viewPort")] public RectTransform ViewPort;
    [FormerlySerializedAs("corner1")] public Transform Corner1;
    [FormerlySerializedAs("corner2")] public Transform Corner2;
    [FormerlySerializedAs("blipPrefab")] public GameObject BlipPrefab;
    public static Map Current;

    private Vector2 _terrainSize;
    private RectTransform _mapRect;

    public Map()
    {
        Current = this;
    }

    // Use this for initialization
    private void Start()
    {
        _terrainSize = new Vector2(
        Corner2.position.x - Corner1.position.x,
        Corner2.position.z - Corner1.position.z);
        _mapRect = GetComponent<RectTransform>();
    }

    public Vector2 WorldPositionToMap(Vector3 point)
    {
        //var pos = point - Corner1.position;
        var mapPos = new Vector2(
        point.x / _terrainSize.x * _mapRect.rect.width,
        point.z / _terrainSize.y * _mapRect.rect.height);
        return mapPos;
    }

    // Update is called once per frame
    [SuppressMessage("ReSharper", "Unity.InefficientCameraMainUsage")]
    private void Update()
    {
        // ReSharper disable once Unity.InefficientCameraMainUsage
        if (Camera.main != null) 
            ViewPort.position = WorldPositionToMap(Camera.main.transform.position);
    }
}