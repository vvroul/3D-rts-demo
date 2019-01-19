using UnityEngine;
using System.Collections.Generic;
using Definitions;
using Random = UnityEngine.Random;

namespace Ai
{
	public class AiController : MonoBehaviour
	{
		public string PlayerName;
		public float Confusion = 0.3f;
		public float Frequency = 1;

		private PlayerSetupDefinition _player;
		private float _waited;
		private readonly List<AiBehavior> _ais = new List<AiBehavior>();

/*
		public PlayerSetupDefinition Player
		{
			get { return _player; }

		}
*/

		// Use this for initialization
		private void Start () {
			foreach (var ai in GetComponents<AiBehavior>())
			{
				_ais.Add(ai);
			}

			foreach (var p in RtsManager.Current.Players)
			{
				if (p.Name == PlayerName) _player = p;
			}

			gameObject.AddComponent<AiSupport>().Player = _player;
		}
	
		// Update is called once per frame
		private void Update ()
		{
			_waited += Time.deltaTime;
			if (_waited < Frequency) return;

			var aiLog = "";
			var bestAiValue = float.MinValue;
			AiBehavior bestAi = null;
			AiSupport.GetSupport(gameObject).Refresh();
			
			foreach (var ai in _ais)
			{
				ai.TimePassed += _waited;
				
				var aiValue = ai.GetWeight() * ai.WeightMultiplier + Random.Range(0, Confusion);
				aiLog += ai.GetType().Name + ": " + aiValue + "\n";
				if (!(aiValue > bestAiValue)) continue;
				bestAiValue = aiValue;
				bestAi = ai;
			}
			
			Debug.Log(aiLog);
			if (bestAi != null) bestAi.Execute();
			_waited = 0;
		}
	}
}
