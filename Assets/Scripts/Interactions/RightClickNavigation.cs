using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Interactions
{
    public class RightClickNavigation : Interaction
    {
        private NavMeshAgent _agent;
        private Vector3 _target = Vector3.zero;
        private bool _selected;
        private bool _isActive;

        [FormerlySerializedAs("relaxDistance")]
        public float RelaxDistance = 4;

        public override void Deselect()
        {
            _selected = false;
        }

        public override void Select()
        {
            _selected = true;
        }

        public void SendToTarget(Vector3 pos)
        {
            _target = pos;
            SendToTarget();
        }

        public void SendToTarget()
        {
            _agent.SetDestination(_target);
            _agent.isStopped = false;
            _isActive = true;
        }

        // Use this for initialization
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_selected && Input.GetMouseButtonDown(1))
            {
                var tempTarget = RtsManager.Current.ScreenPointToMapPosition(Input.mousePosition);
                if (tempTarget.HasValue)
                {
                    _target = tempTarget.Value;
                    SendToTarget();
                }
            }

            if (!_isActive || !(Vector3.Distance(_target, transform.position) < RelaxDistance)) return;
            _agent.isStopped = true;
            _isActive = false;
        }
    }
}