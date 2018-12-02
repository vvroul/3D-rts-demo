using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSetupDefinition info;
    public static PlayerSetupDefinition _default;

    void Start()
    {
        info.ActiveUnits.Add(this.gameObject);
    }

    void OnDestroy()
    {
        info.ActiveUnits.Remove(this.gameObject);
    }

}
