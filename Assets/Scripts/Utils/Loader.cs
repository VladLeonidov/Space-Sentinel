using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Lean.Pool;

namespace Utils
{
    public class Loader : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] prefabsToLoad;

        private void Awake()
        {
            //GameObject pools = new GameObject("Pools");
            //Transform poolsTransform = pools.transform;
            //foreach (GameObject prefab in this.prefabsToLoad)
            //{
            //    CreateLeanObjectPool(prefab, 30, poolsTransform);
            //}
        }

        //private GameObject CreateLeanObjectPool
        //    (
        //        GameObject prefab, 
        //        int capacity,
        //        Transform parent = null
        //    )
        //{
        //    GameObject go = new GameObject("Pool:" + prefab.name);
        //    go.AddComponent<LeanGameObjectPool>();
        //    if (parent != null)
        //    {
        //        parent = go.transform;
        //    }

        //    LeanGameObjectPool pool = go.GetComponent<LeanGameObjectPool>();
        //    pool.Notification = LeanGameObjectPool.NotificationType.PoolableEvent;
        //    pool.Capacity = capacity;
        //    pool.Prefab = prefab;

        //    return go;
        //}
    }
}