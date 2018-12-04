using System.Collections;
using System.Collections.Generic;
using Interactions;
using UnityEngine;
using UnityEngine.Serialization;

public class Interactive : MonoBehaviour
{
    private bool Selected { get; set; }

    [FormerlySerializedAs("swap")] public bool Swap = false;

    public Interactive()
    {
        Selected = false;
    }

    public void Select()
    {
        Selected = true;
        foreach(var selection in GetComponents<Interaction>())
        {
            selection.Select();
        }
    }

    public void Deselect()
    {
        Selected = false;
        foreach (var selection in GetComponents<Interaction>())
        {
            selection.Deselect();
        }
    }


	// Use this for initialization
    private void Start () {
		
	}
	
	// Update is called once per frame
    private void Update ()
    {
        if (!Swap) return;
        Swap = false;
        if (Selected)
        {
            Deselect();
        }
        else
        {
            Select();
        }
    }
}
