using System;
using UnityEngine;

namespace Actions
{
	public class CreateBuildingAction : ActionBehavior
	{

		public GameObject BuildingPrefab;
		public float MaxBuildingDistance = 30;

		public GameObject GhostBuildingPrefab;

		private GameObject active = null;
		
		public override Action GetClickAction()
		{
			return delegate
			{
				var go = GameObject.Instantiate(GhostBuildingPrefab);
				var finder = go.AddComponent<FindBuildingSite>();
				finder.BuildingPrefab = BuildingPrefab;
				finder.MaxBuildingDistance = MaxBuildingDistance;
				finder.Info = GetComponent<Player>().Info;
				finder.Source = transform;
				active = go;
			};
		}

		void Update()
		{
			if (active == null)
				return;

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				GameObject.Destroy(active);
			}
		}

		private void OnDestroy()
		{
			if (active == null)
				return;
			Destroy(active);
		}
	}
}
