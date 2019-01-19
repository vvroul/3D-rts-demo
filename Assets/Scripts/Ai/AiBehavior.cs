using UnityEngine;

namespace Ai
{
    public abstract class AiBehavior : MonoBehaviour
    {
        public float WeightMultiplier = 1;
        public float TimePassed;
        public abstract float GetWeight();
        public abstract void Execute();
    }
}
