using System.Collections;
using System.Collections.Generic;
using Definitions;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("info")] public PlayerSetupDefinition Info;
    public static PlayerSetupDefinition Default;

    private void Start()
    {
        Info.ActiveUnits.Add(this.gameObject);
    }

    private void OnDestroy()
    {
        Info.ActiveUnits.Remove(this.gameObject);
    }

}
