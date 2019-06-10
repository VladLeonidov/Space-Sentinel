using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [System.Serializable]
    public struct Border2D
    {
        [SerializeField]
        private float minX;
        [SerializeField]
        private float maxX;
        [SerializeField]
        private float minY;
        [SerializeField]
        private float maxY;

        public float MinX { get { return this.minX; } }
        public float MaxX { get { return this.maxX; } }
        public float MinY { get { return this.minY; } }
        public float MaxY { get { return this.maxY; } }
    }
}