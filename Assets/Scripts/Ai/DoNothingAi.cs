using UnityEngine;

namespace Ai
{
	public class DoNothingAi : AiBehavior
	{
		public float ReturnWeight = 0.2f;
		
		public override float GetWeight()
		{
			return ReturnWeight;
		}

		public override void Execute()
		{
			Debug.Log("Doing Nothing");
		}
	}
}
