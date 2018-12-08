using System;
using UnityEngine;

namespace Actions
{
	public class CreateBuildingAction : ActionBehavior
	{

		public float Cost = 0;
		public GameObject BuildingPrefab;
		public float MaxBuildingDistance = 30;

		public GameObject GhostBuildingPrefab;

		private GameObject active = null;
		
		public override Action GetClickAction()
		{
			return delegate
			{
				var player = GetComponent<Player>().Info;
//				if (player.Credits < Cost)
//				{
//					Debug.Log("Not enough");
//				}
				var go = GameObject.Instantiate(GhostBuildingPrefab);
				var finder = go.AddComponent<FindBuildingSite>();
				finder.BuildingPrefab = BuildingPrefab;
				finder.MaxBuildingDistance = MaxBuildingDistance;
				finder.Info = player;
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
