using Definitions;
using Interactions;
using UnityEngine;

public class FindBuildingSite : MonoBehaviour
{
	public float Cost = 200;
	public float MaxBuildingDistance = 5000;
	public GameObject BuildingPrefab;
	public PlayerSetupDefinition Info;
	public GameObject Worker;
	public Transform Source;
	
	private Renderer _rend;
	private readonly Color _red = new Color(1, 0, 0, 0.5f);
	private readonly Color _green = new Color(0, 1, 0, 0.5f);

	private void Start()
	{
		MouseManager.Current.enabled = false;
		_rend = GetComponent<Renderer>();
	}

	// Update is called once per frame
	private void Update ()
	{
		var tempTarget = RtsManager.Current.ScreenPointToMapPosition(Input.mousePosition);
		if (tempTarget.HasValue == false)
			return;
		transform.position = tempTarget.Value;

//		if (Vector3.Distance(transform.position, Source.position) > MaxBuildingDistance)
//		{
//			rend.material.color = Red;
//			return;
//		}

		if (RtsManager.IsGameObjectSafeToPlace(gameObject))
		{
			_rend.material.color = _green;
			if (Input.GetMouseButtonDown(0))
			{
				Worker.GetComponent<RightClickNavigation>().SendToTarget(transform.position);
				var go = Instantiate(BuildingPrefab);
				go.AddComponent<ActionSelect>();
				go.transform.position = transform.position;
				Info.Credits -= Cost;
				go.AddComponent<Player>().Info = Info;
				Destroy(gameObject);
			}
		}
		else
		{
			_rend.material.color = _red;
		}
	}

	private void OnDestroy()
	{
		MouseManager.Current.enabled = true;
	}
}
