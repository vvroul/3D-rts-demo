using System;
using System.Collections.Generic;
using Definitions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Actions
{
	public class ConsumeUnit : ActionBehavior
	{
		public List<GameObject> Workers =  new List<GameObject>();
		public int WorkerCount = 0;
		
		private PlayerSetupDefinition _player;
		private GameObject _go;

		private void Start()
		{
			_player = GetComponent<Player>().Info;
		}

		public override Action GetClickAction()
		{
			return delegate
			{
				if (_player.IsAi) return;	//for safety reasons
				foreach (var u in _player._activeUnits)
				{
					if (u.name.Contains("Drone Unit"))
						_go = u;
				}
				if (_player._activeUnits.Contains(_go))
				{
					if (Workers.Count <= 15)
					{
						Workers.Add(_go);
						++WorkerCount;
						Destroy(_go);
						gameObject.GetComponent<Earnings>().CreditsPerSecond += 1;
					}
				}
			};
		}
	}
}
