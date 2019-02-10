using Actions;
using UnityEngine;
using UnityEngine.UI;

namespace Ai
{
	public class ConsumeUnitAi : AiBehavior 
	{
		private AiSupport _support;
		
		public override float GetWeight()
		{
			if (_support == null)  _support = AiSupport.GetSupport(gameObject);
			if (_support.ResourceCenters.Count == 0) return 0;
			return _support.Drones.Count == 0 ? 0 : 1;
		}

		public override void Execute()
		{
			Debug.Log("Consuming unit ");
			var centers = _support.ResourceCenters;
			var index = Random.Range(0, centers.Count);
			var center = centers[index];
			center.GetComponent<ConsumeUnit>().GetClickAction()();
		}
	}
}
