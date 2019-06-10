using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

namespace Core.Managers
{
    public class AnimationManager : AbstractManager
    {
        public void PlayAnimatedObject 
            (
                GameObject animatedObjectPrefab, 
                Vector2 position, 
                Quaternion rotation, 
                Transform parent = null
            )
        {
            GameObject animatedObject = LeanPool.Spawn
                (
                    animatedObjectPrefab, 
                    position, 
                    rotation
                );

            if (parent)
            {
                animatedObject.transform.parent = parent;
            }

            LeanPool.Despawn(animatedObject, 1f);
        }

        public void PlayAnimatedObject
            (
                GameObject animatedObjectPrefab, Vector2 position, 
                Quaternion rotation, float animTime, Transform parent = null
            )
        {
            GameObject animatedObject = LeanPool.Spawn
                (
                    animatedObjectPrefab,
                    position,
                    rotation
                );

            if (parent)
            {
                animatedObject.transform.parent = parent;
            }

            LeanPool.Despawn(animatedObject, animTime);
        }

        public override void Initialization()
        {
            
        }

        public override void Finalization()
        {

        }
    }
}