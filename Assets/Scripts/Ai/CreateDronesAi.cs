using Actions;
using UnityEngine;

namespace Ai
{
	public class CreateDronesAi : AiBehavior
	{
		public int DronesPerBase = 5;
		public float Cost = 25;
		private AiSupport _support;
		
		public override float GetWeight()
		{
			if (_support == null) _support = AiSupport.GetSupport(gameObject);
			if (_support.Player.Credits < Cost) return 0;
			var drones = _support.Drones.Count;
			var bases = _support.CommandBases.Count;

			if (bases == 0) return 0;
			if (drones >= bases * DronesPerBase) return 0;

			return 1;
		}

		public override void Execute()
		{
			Debug.Log(_support.Player.Name + " is creating a drone");
			var bases = _support.CommandBases;
			var index = Random.Range(0, bases.Count);
			var commandBase = bases[index];

			commandBase.GetComponent<CreateUnitAction>().GetClickAction()();
		}
	}
}
