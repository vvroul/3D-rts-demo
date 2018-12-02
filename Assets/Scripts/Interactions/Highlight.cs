using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : Interaction
{

    public GameObject displayItem;

    public override void Deselect()
    {
        displayItem.SetActive(false);
    }

    public override void Select()
    {
        displayItem.SetActive(true);
    }

    // Use this for initialization
    void Start()
    {
        displayItem.SetActive(false);
    }

}
