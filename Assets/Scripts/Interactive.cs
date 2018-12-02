using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    private bool _selected = false;

    public bool selected
    {
        get { return _selected; }
    }

    public bool swap = false;

    public void Select()
    {
        _selected = true;
        foreach(var selection in GetComponents<Interaction>())
        {
            selection.Select();
        }
    }

    public void Deselect()
    {
        _selected = false;
        foreach (var selection in GetComponents<Interaction>())
        {
            selection.Deselect();
        }
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (swap)
        {
            swap = false;
            if (_selected)
            {
                Deselect();
            }
            else
            {
                Select();
            }
        }
	}
}
