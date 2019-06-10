using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Core.Managers;

namespace Core
{
    public class PlayerMover : Mover
    {
        [SerializeField]
        private Border2D border;
        [SerializeField]
        private Vector2 startPos;
        [SerializeField]
        private float smoothing;

        private Vector2 _touchStartPos;
        private Vector2 _smoothDirection;

        private float _distaneToStartPos = 1f;

        private bool _gameStarted;

        public override void OnSpawn()
        {
            Direction = Vector2.zero;
        }

        public override void OnDespawn()
        {
            Direction = Vector2.zero;
        }

        protected override void Move()
        {
            if (!_gameStarted)
            {
                MoveToStartPosition();
            }
            else
            {
#if PC
                PcMove();
#endif
#if Mobile
                MobileMove();
#endif
                Rb.velocity = Direction * base.speed;

                float positionX = Mathf.Clamp(Rb.position.x, this.border.MinX, this.border.MaxX);
                float positionY = Mathf.Clamp(Rb.position.y, this.border.MinY, this.border.MaxY);
                Rb.position = new Vector2(positionX, positionY);
            }
        }

        private void PcMove()
        {
            float directionX = Input.GetAxis("Horizontal");
            float directionY = Input.GetAxis("Vertical");

            Direction = new Vector2(directionX, directionY);
        }

        private void MobileMove()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _touchStartPos = Camera.main.ScreenToWorldPoint(touch.position);
                        break;
                    case TouchPhase.Stationary:
                        Direction = (_touchStartPos - Rb.position).normalized;
                        break;
                    case TouchPhase.Moved:
                        Vector2 currentPos = Camera.main.ScreenToWorldPoint(touch.position);
                        Vector2 directionRaw = currentPos - _touchStartPos;
                        _smoothDirection = Vector2.MoveTowards(_smoothDirection, directionRaw.normalized, smoothing);
                        Direction = _smoothDirection;
                        break;
                    case TouchPhase.Ended:
                        Direction = Vector2.zero;
                        break;
                }
            }
        }

        private void MoveToStartPosition()
        {
            Rb.MovePosition(Vector2.Lerp(Rb.position, this.startPos, Time.deltaTime * 2));

            Vector2 distance = this.startPos - Rb.position;

            if (distance.magnitude < _distaneToStartPos * _distaneToStartPos)
            {
                StartCoroutine(StartGameTimer());
            }
        }

        private IEnumerator StartGameTimer()
        {
            yield return new WaitForSeconds(3f);
            ManagerProvider.EventManager.GameStartedEvent.OnEvent();
            _gameStarted = true;
        }
    }
}