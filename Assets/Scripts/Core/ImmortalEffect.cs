using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ImmortalEffect : MonoBehaviour
    {
        [SerializeField]
        private float alfaSpeed;

        private SpriteRenderer _shipSpriteRenderer;
        private float _alfaStep = 1;

        private Color _srcColor;

        private void Awake()
        {
            _shipSpriteRenderer = GetComponent<SpriteRenderer>();
            _srcColor = _shipSpriteRenderer.color;
        }

        public void PlayEffect()
        {
            Color color = _shipSpriteRenderer.color;
            color.a += _alfaStep / this.alfaSpeed;

            if (color.a <= 0)
            {
                _alfaStep = 1;
            }
            else if (color.a >= 1)
            {
                _alfaStep = -1;
            }

            _shipSpriteRenderer.color = color;
        }

        public void SetSourceAlfa()
        {
            Color color = _shipSpriteRenderer.color;
            color.a = _srcColor.a;
            _shipSpriteRenderer.color = color;
        }
    }
}