using Definitions;
using Interactions;
using UnityEngine;

namespace Battle
{
	public class AttackInRange : MonoBehaviour
	{

		public float FindTargetDelay = 1;
		public float AttackRange = 20;
		public float AttackFrequency = 0.25f;
		public float AttackDamage = 1;
		public float findTargetCounter = 0;
		public float attackCounter = 0;
		public PlayerSetupDefinition player;

		
		private ShowUnitInfo _target;
		
		// Use this for initialization
		void Start ()
		{
			player = GetComponent<Player>().Info;
		}

		void FindTarget()
		{
			if (_target != null) return;

			foreach (var p in RtsManager.Current.Players)
			{
				if (p == player) continue;

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

		void Attack()
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
		void Update ()
		{
			findTargetCounter += Time.deltaTime;
			if (findTargetCounter > FindTargetDelay)
			{
				FindTarget();
				findTargetCounter = 0;
			}

			attackCounter += Time.deltaTime;
			if (attackCounter > AttackFrequency)
			{
				Attack();
				attackCounter = 0;
			}
			
			if (this.gameObject.GetComponent<ShowUnitInfo>().CurrentHealth <= 0) Destroy(this.gameObject);
		}
	}
}
