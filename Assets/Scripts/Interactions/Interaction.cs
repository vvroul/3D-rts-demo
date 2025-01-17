﻿using UnityEngine;

namespace Interactions
{
    public abstract class Interaction : MonoBehaviour
    {
        public abstract void Select();
        public abstract void Deselect();
    }
}
