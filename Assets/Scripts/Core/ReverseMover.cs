using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ReverseMover : Mover
    {
        protected override void Move()
        {
            base.Rb.velocity = -Direction * base.speed;
        }
    }
}