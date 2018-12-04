using System;
using UnityEngine;

namespace Actions
{
	public class CreateBuildingAction : ActionBehavior {
		public override Action GetClickAction()
		{
			return delegate { Debug.Log("Create Command Base Attempt"); };
		}
	}
}
