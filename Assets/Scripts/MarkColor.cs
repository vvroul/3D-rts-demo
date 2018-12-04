using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MarkColor : MonoBehaviour
{

    [FormerlySerializedAs("renderers")] public MeshRenderer[] Renderers;

	// Use this for initialization
    private void Start ()
    {
        var color = GetComponent<Player>().Info.AccentColor;
        foreach(var r in Renderers)
        {
            foreach(var c in r.materials)
            {
                c.color = color;
            }
        }
	}
}
