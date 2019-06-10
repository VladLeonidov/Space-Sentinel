using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Managers
{
    public abstract class AbstractManager : MonoBehaviour
    {
        public abstract void Initialization();
        public abstract void Finalization();
    }
}