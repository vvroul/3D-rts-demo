using UnityEngine;
using System.Collections.Generic;
using Definitions;
using Interactions;
using UnityEngine.Serialization;
using System.Linq;
using UnityEngine.AI;


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

    public bool IsGameObjectSafeToPlace(GameObject go)
    {
        var verts = go.GetComponent<MeshFilter>().mesh.vertices;

        var obstacles = GameObject.FindObjectsOfType<NavMeshObstacle>();
        var cols = new List<Collider>();
        foreach (var o in obstacles)
        {
            if (o.gameObject != go)
            {
                cols.Add(o.gameObject.GetComponent<Collider>());
            }
        }

        foreach (var v in verts)
        {
            NavMeshHit hit;
            var vReal = go.transform.TransformPoint(v);
            NavMesh.SamplePosition(vReal, out hit, 20, NavMesh.AllAreas);

            bool onXaxis = Mathf.Abs(hit.position.x - vReal.x) < 0.5f;
            bool onZaxis = Mathf.Abs(hit.position.z - vReal.z) < 0.5f;
            bool hitCollider = cols.Any(c => c.bounds.Contains(vReal));

            if (!onXaxis || !onZaxis || hitCollider)
            {
                return false;
            }
        }
        
        return true;
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
                if (!p.IsAi)
                {
                    if (Player.Default == null) Player.Default = p;
                    go.AddComponent<RightClickNavigation>();
                    go.AddComponent<ActionSelect>();
                }
            }
        }
	}
	
	// Update is called once per frame
}
