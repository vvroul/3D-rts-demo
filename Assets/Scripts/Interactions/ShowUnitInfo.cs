﻿using UnityEngine;

namespace Interactions
{
    public class ShowUnitInfo : Interaction
    {
        public string Name;
        public float MaxHealth, CurrentHealth;
        public Sprite ProfilePic;

        private bool _showData;

        public override void Select()
        {
            _showData = true;
        }

        private void Update()
        {
            if (!_showData) return;
            InfoManager.Current.SetPic(ProfilePic);
            InfoManager.Current.SetLines(Name, CurrentHealth + "/" + MaxHealth, "Owner " + GetComponent<Player>().Info.Name);
        }

        public override void Deselect()
        {
            InfoManager.Current.ClearPic();
            InfoManager.Current.ClearLines();
            _showData = false;
        }
    }
}