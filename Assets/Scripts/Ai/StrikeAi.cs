using Interactions;
using UnityEngine;

namespace Ai
{
	public class StrikeAi : AiBehavior
	{

		public int DronesRequired = 10;
		public float TimeDelay = 5;
		public float SquadSize = 0.5f;
		public int IncreasePerwWave;
		
		public override float GetWeight()
		{
			if (TimePassed < TimeDelay) return 0;
			TimePassed = 0;

			var ai = AiSupport.GetSupport(this.gameObject);
			if (ai.Drones.Count < DronesRequired) return 0;
			return 1;
		}

		public override void Execute()
		{
			var ai = AiSupport.GetSupport(this.gameObject);
			Debug.Log(ai.Player.Name + " is attacking");

			int wave = (int) (ai.Drones.Count * SquadSize);
			DronesRequired += IncreasePerwWave;
			
			//Cheating
			foreach (var p in RtsManager.Current.Players)
			{
				if (p.IsAi) continue;

				for (int i = 0; i < wave; i++)
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
