using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    interface IObservable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(float currentDayTime);
    }
}


