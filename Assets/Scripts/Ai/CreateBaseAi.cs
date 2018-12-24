using System.Linq;
using UnityEngine;

namespace Ai
{
	public class CreateBaseAi : AiBehavior
	{

		public float Cost = 200;
		public int UnitsPerBase = 5;
		public float RangeFromDrone = 30;
		public int TriesPerDrone = 3;
		public GameObject BasePrefab;
		
		private AiSupport _support = null;
		

		public override float GetWeight()
		{
			if (_support == null)  _support = AiSupport.GetSupport(gameObject);
			if (_support.Player.Credits < Cost || _support.Drones.Count == 0) return 0;
			if (_support.CommandBases.Count == 0) return 1;

			var weight = _support.CommandBases.Count / UnitsPerBase * _support.Drones.Count;
			return weight;
		}

		public override void Execute()
		{
			Debug.Log("Creating Base");
			var go = GameObject.Instantiate(BasePrefab);
			go.AddComponent<Player>().Info = _support.Player;

			foreach (var drone in _support.Drones)	{
				for (int i = 0; i < TriesPerDrone; i++)
				{
					var pos = drone.transform.position;
					pos += Random.insideUnitSphere * RangeFromDrone;
					pos.y = Terrain.activeTerrain.SampleHeight(pos);
					go.transform.position = pos;

					if (RtsManager.Current.IsGameObjectSafeToPlace(go))
					{
						_support.Player.Credits -= Cost;
						return;
					}
				}
			}
		}
	}
}
