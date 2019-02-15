using System.Collections.Generic;
using UnityEngine;

namespace Definitions
{
    [System.Serializable]
    public class PlayerSetupDefinition
    {
        public string Name;
        public Transform Location;
        public Transform StartingWorkerSpawnPoint;
        public Transform SpawnToPosition;
        public Transform RnDSpawnPoint;
        public Color AccentColor;
        public List<GameObject> StartingUnits = new List<GameObject>();

        public List<GameObject> _activeUnits = new List<GameObject>();

        public List<GameObject> ActiveUnits
        {
            get { return _activeUnits; }
        }

        public bool IsAi;
        public float Credits;
    }
}