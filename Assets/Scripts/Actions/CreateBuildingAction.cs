using System;
using UnityEngine;

namespace Actions
{
	public class CreateBuildingAction : ActionBehavior
	{

		public GameObject GhostBuildingPrefab;

		private GameObject active = null;
		
		public override Action GetClickAction()
		{
			return delegate
			{
				var go = GameObject.Instantiate(GhostBuildingPrefab);
				go.AddComponent<FindBuildingSite>();
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
