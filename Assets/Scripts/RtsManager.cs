using UnityEngine;
using System.Collections.Generic;
using Definitions;
using Interactions;
using UnityEngine.Serialization;
using System.Linq;
using UnityEngine.AI;


public class RtsManager : MonoBehaviour {

	public static RtsManager Current;

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

    public static bool IsGameObjectSafeToPlace(GameObject go)
    {
        var verts = go.GetComponent<MeshFilter>().mesh.vertices;

        var obstacles = FindObjectsOfType<NavMeshObstacle>();
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

            var onXaxis = Mathf.Abs(hit.position.x - vReal.x) < 0.5f;
            var onZaxis = Mathf.Abs(hit.position.z - vReal.z) < 0.5f;
            var hitCollider = cols.Any(c => c.bounds.Contains(vReal));

            if (!onXaxis || !onZaxis || hitCollider)
            {
                return false;
            }
        }
        
        return true;
    }


    public RtsManager()
    {
        Current = this;
    }

	// Use this for initialization
    private void Start () {
		//Current = this;
        foreach (var p in Players)
        {
            foreach(var u in p.StartingUnits)
            {
//                if (u.GetComponent<ShowUnitInfo>().Name == "Command Center") continue;
                //TO_DO
                var go = Instantiate(u, p.Location.position, p.Location.rotation);
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
}
