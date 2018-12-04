using System;
using UnityEngine;

namespace Actions
{
	public abstract class ActionBehavior : MonoBehaviour
	{
		public abstract Action GetClickAction();
		public Sprite ButtonPic;
	}
}
