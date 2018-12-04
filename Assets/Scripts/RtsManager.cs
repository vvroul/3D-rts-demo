using UnityEngine;
using System.Collections.Generic;
using Definitions;
using Interactions;
using UnityEngine.Serialization;


public class RtsManager : MonoBehaviour {

	public static RtsManager Current = null;

	public List<PlayerSetupDefinition> Players = new List<PlayerSetupDefinition>();
    [FormerlySerializedAs("mapCollider")] public TerrainCollider MapCollider;

    public Vector3? ScreenPointToMapPosition(Vector2 point)
    {
        if (Camera.main != null)
        {
            var ray = Camera.main.ScreenPointToRay(point);
            RaycastHit hit;
            if (!MapCollider.Raycast(ray, out hit, Mathf.Infinity))
            {
                return null;
            }
            return hit.point;
        }

        return null;
    }

	// Use this for initialization
    private void Start () {
		Current = this;
        foreach (var p in Players)
        {
            foreach(var u in p.StartingUnits)
            {
                var go = (GameObject) GameObject.Instantiate(u, p.Location.position, p.Location.rotation);
                var player = go.AddComponent<Player>();
                player.Info = p;
                if (p.IsAi) continue;
                if (Player.Default == null)
                {
                    Player.Default = p;
                }
                go.AddComponent<RightClickNavigation>();
            }
        }
	}
	
	// Update is called once per frame
}
