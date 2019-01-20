using System.Collections.Generic;
using Definitions;
using Interactions;
using UnityEngine;

namespace Ai
{
	public class AiSupport : MonoBehaviour
	{
		public List<GameObject> Drones = new List<GameObject>();
		public List<GameObject> CommandBases = new List<GameObject>();
		public PlayerSetupDefinition Player;

		public static AiSupport GetSupport(GameObject go)
		{
			return go.GetComponent<AiSupport>();
		}

		public void Refresh()
		{
			Drones.Clear();
			CommandBases.Clear();
			foreach (var u in Player.ActiveUnits) {
				Destroy(u.GetComponent<RightClickNavigation>());
				if (u.name.Contains("Drone Unit")) Drones.Add(u);
				if (u.name.Contains("Command Base")) CommandBases.Add(u);
			}
		}
	}
}