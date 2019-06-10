using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(MeshRenderer))]
    public class BackgroundMover : MonoBehaviour
    {
        [SerializeField]
        private Vector2 direction;
        [SerializeField]
        private float speed;

        private MeshRenderer _backGround;
        private Vector2 _beginTextureOffset;

        private void Awake()
        {
            _backGround = GetComponent<MeshRenderer>();
            this.direction = Vector3.Normalize(this.direction);
            _beginTextureOffset = _backGround.sharedMaterial.GetTextureOffset("_MainTex");
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector2 textureOffset = Vector2.zero;
            float tmp = Mathf.Repeat(Time.time * this.speed, 1);

            if (this.direction == Vector2.up)
            {
                textureOffset = new Vector2(_beginTextureOffset.x, -tmp);
            }
            else if (this.direction == Vector2.down)
            {
                textureOffset = new Vector2(_beginTextureOffset.x, tmp);
            }
            else if (this.direction == Vector2.right)
            {
                textureOffset = new Vector2(-tmp, _beginTextureOffset.y);
            }
            else if (this.direction == Vector2.left)
            {
                textureOffset = new Vector2(tmp, _beginTextureOffset.y);
            }

            _backGround.sharedMaterial.SetTextureOffset("_MainTex", textureOffset);
        }

        void OnDisable()
        {
            _backGround.sharedMaterial.SetTextureOffset("_MainTex", _beginTextureOffset);
        }
    }
}