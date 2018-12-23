using System;
using UnityEngine;
using System.Collections.Generic;
using Definitions;
using Random = UnityEngine.Random;

namespace Ai
{
	public class AiController : MonoBehaviour
	{
		public String PlayerName;
		public float Confusion = 0.3f;
		public float Frequency = 1;

		private PlayerSetupDefinition player;
		private float _waited = 0;
		private readonly List<AiBehavior> _ais = new List<AiBehavior>();

		public PlayerSetupDefinition Player
		{
			get { return player; }

		}

		// Use this for initialization
		private void Start () {
			foreach (var ai in GetComponents<AiBehavior>())
			{
				_ais.Add(ai);
			}

			foreach (var p in RtsManager.Current.Players)
			{
				if (p.Name == PlayerName) player = p;
			}
		}
	
		// Update is called once per frame
		private void Update ()
		{
			_waited += Time.deltaTime;
			if (_waited < Frequency) return;
			var bestAiValue = float.MinValue;
			AiBehavior bestAi = null;

			foreach (var ai in _ais)
			{
				ai.TimePassed += _waited;
				
				var aiValue = ai.GetWeight() * ai.WeightMultiplier + Random.Range(0, Confusion);
				if (!(aiValue > bestAiValue)) continue;
				bestAiValue = aiValue;
				bestAi = ai;
			}

			if (bestAi != null) bestAi.Execute();
			_waited = 0;
		}
	}
}
