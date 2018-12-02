using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapBlip : MonoBehaviour
{
    private GameObject blip;

	// Use this for initialization
	void Start ()
    {
        blip = Instantiate(Map.current.blipPrefab);
        blip.transform.SetParent(Map.current.transform);
        var color = GetComponent<Player>().info.AccentColor;
        blip.GetComponent<Image>().color = color;
	}
	
	// Update is called once per frame
	void Update ()
    {
        blip.transform.position = Map.current.WorldPositionToMap(transform.position);
	}

    void OnDestroy()
    {
        GameObject.Destroy(blip);
    }
}
