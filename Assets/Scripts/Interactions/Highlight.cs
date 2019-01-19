using UnityEngine;
using UnityEngine.Serialization;

namespace Interactions
{
    public class Highlight : Interaction
    {
        [FormerlySerializedAs("displayItem")] public GameObject DisplayItem;

        public override void Deselect()
        {
            DisplayItem.SetActive(false);
        }

        public override void Select()
        {
            DisplayItem.SetActive(true);
        }

        // Use this for initialization
        private void Start()
        {
            DisplayItem.SetActive(false);
        }

    }
}
