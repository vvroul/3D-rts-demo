using System;
using UnityEngine;

namespace Actions
{
	public class CreateBuildingAction : ActionBehavior
	{
		public float Cost;
		public GameObject BuildingPrefab;
		public float MaxBuildingDistance = 5000;
		public GameObject GhostBuildingPrefab;

		private GameObject _active;
		
		public override Action GetClickAction()
		{
			return delegate
			{
				var player = GetComponent<Player>().Info;
				if (player.Credits < Cost)
				{
					Debug.Log("Not enough" + Cost);
					return;
				}
				var go = Instantiate(GhostBuildingPrefab);
				var finder = go.AddComponent<FindBuildingSite>();
				finder.BuildingPrefab = BuildingPrefab;
				finder.Worker = gameObject;
				finder.MaxBuildingDistance = MaxBuildingDistance;
				finder.Info = player;
				finder.Source = transform;
				_active = go;
			};
		}

		private void Update()
		{
			if (_active == null)
				return;

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Destroy(_active);
			}
		}

		private void OnDestroy()
		{
			if (_active == null)
				return;
			Destroy(_active);
		}
	}
}
