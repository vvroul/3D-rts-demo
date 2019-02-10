using UnityEngine;

namespace Ai
{
	public class CreateBaseAi : AiBehavior
	{

		public float Cost = 200;
		public float RangeFromDrone = 30;
		public GameObject BasePrefab;
		
		private AiSupport _support;
		

		public override float GetWeight()
		{
			if (_support == null)  _support = AiSupport.GetSupport(gameObject);
			if (_support.Player.Credits < Cost || _support.Drones.Count == 0) return 0;

			return 1;
		}

		public override void Execute()
		{
			Debug.Log("Creating Base " + BasePrefab.name);
			var go = Instantiate(BasePrefab);
			go.AddComponent<Player>().Info = _support.Player;

			foreach (var drone in _support.Drones)	{
				var pos = drone.transform.position;
				pos += Random.insideUnitSphere * RangeFromDrone;
				pos.y = Terrain.activeTerrain.SampleHeight(pos);
				go.transform.position = pos;

				if (RtsManager.IsGameObjectSafeToPlace(go))
				{
					_support.Player.Credits -= Cost;
					return;
				}
			}
			
			Destroy(go) ;
		}
	}
}
