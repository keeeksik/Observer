using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public interface IObserver
    {
        void Update(float timeOfDay);
    }
}