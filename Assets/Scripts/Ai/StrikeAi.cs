using Interactions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ai
{
	public class StrikeAi : AiBehavior
	{

		public int DronesRequired = 10;
		public float TimeDelay = 5;
		public float SquadSize = 0.5f;
		[FormerlySerializedAs("IncreasePerwWave")] public int IncreasePerWave;
		
		public override float GetWeight()
		{
			if (TimePassed < TimeDelay) return 0;
			TimePassed = 0;

			var ai = AiSupport.GetSupport(gameObject);
			if (ai.Drones.Count < DronesRequired) return 0;
			return 1;
		}

		public override void Execute()
		{
			var ai = AiSupport.GetSupport(gameObject);
			Debug.Log(ai.Player.Name + " is attacking");

			var wave = (int) (ai.Drones.Count * SquadSize);
			DronesRequired += IncreasePerWave;
			
			//Cheating
			foreach (var p in RtsManager.Current.Players)
			{
				if (p.IsAi) continue;

				for (var i = 0; i < wave; i++)
				{
					var drone = ai.Drones[i];
					var nav = drone.GetComponent<RightClickNavigation>();
					nav.SendToTarget(p.Location.position);
				}
				return;
			}
		}
	}
}
