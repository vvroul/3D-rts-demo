using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkColor : MonoBehaviour
{

    public MeshRenderer[] renderers;

	// Use this for initialization
	void Start ()
    {
        var color = GetComponent<Player>().info.AccentColor;
        foreach(var r in renderers)
        {
            foreach(Material c in r.materials)
            {
                c.color = color;
            }
        }
	}
}
