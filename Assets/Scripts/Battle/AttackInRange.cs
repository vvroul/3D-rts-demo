using Definitions;
using Interactions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Battle
{
	public class AttackInRange : MonoBehaviour
	{

		public float FindTargetDelay = 1;
		public float AttackRange = 20;
		public float AttackFrequency = 0.25f;
		public float AttackDamage = 1;
		[FormerlySerializedAs("findTargetCounter")] public float FindTargetCounter = 0;
		[FormerlySerializedAs("attackCounter")] public float AttackCounter = 0;
		[FormerlySerializedAs("player")] public PlayerSetupDefinition Player;

		private ShowUnitInfo _target;
		
		// Use this for initialization
		private void Start ()
		{
			Player = GetComponent<Player>().Info;
		}

		private void FindTarget()
		{
			if (_target != null) return;

			foreach (var p in RtsManager.Current.Players)
			{
				if (p == Player) continue;

				foreach (var unit in p.ActiveUnits)
				{
					if (Vector3.Distance(unit.transform.position, transform.position) < AttackRange)
					{
						_target = unit.GetComponent<ShowUnitInfo>();
						return;
					}
				}
			}
		}

		private void Attack()
		{
			if (_target == null) return;
			if (Vector3.Distance(_target.transform.position, transform.position) > AttackRange)
			{
				_target = null;
				return;
			}

			_target.CurrentHealth -= AttackDamage;
			if (_target.CurrentHealth <= 0) Destroy(_target.gameObject);
		}
	
		// Update is called once per frame
		private void Update ()
		{
			FindTargetCounter += Time.deltaTime;
			if (FindTargetCounter > FindTargetDelay)
			{
				FindTarget();
				FindTargetCounter = 0;
			}

			AttackCounter += Time.deltaTime;
			if (AttackCounter > AttackFrequency)
			{
				Attack();
				AttackCounter = 0;
			}
			
			if (gameObject.GetComponent<ShowUnitInfo>().CurrentHealth <= 0) Destroy(gameObject);
		}
	}
}
