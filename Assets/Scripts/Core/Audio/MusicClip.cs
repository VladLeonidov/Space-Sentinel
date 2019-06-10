using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Audio
{
    [System.Serializable]
    public class MusicClip
    {
        [SerializeField]
        private AudioClip clip;
        [SerializeField]
        private bool loop;
        [SerializeField]
        private bool interrupt;
        [SerializeField]
        private float interruptDelay;

        public AudioClip Track { get { return this.clip; } }

        public bool IsLoop { get { return this.loop; } }

        public bool IsInterrupt { get { return this.interrupt; } }

        public float InterruptDelay { get { return this.interruptDelay; } }
    }
}