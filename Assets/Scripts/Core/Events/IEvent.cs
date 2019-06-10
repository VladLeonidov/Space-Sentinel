using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Core.Events
{
    public interface IEvent
    {
        void OnEvent();
        void Subscribe(Action handler);
        void Unsubscribe(Action handler);
    }

    public interface IEvent<T>
    {
        void OnEvent(T type);
        void Subscribe(Action<T> handler);
        void Unsubscribe(Action<T> handler);
    }
}