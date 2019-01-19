using Definitions;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("info")] public PlayerSetupDefinition Info;
    public static PlayerSetupDefinition Default;

    private void Start()
    {
        Info.ActiveUnits.Add(gameObject);
    }

    private void OnDestroy()
    {
        Info.ActiveUnits.Remove(gameObject);
    }

}
