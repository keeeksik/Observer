using Core;
using System.Collections;
using System.Collections.Generic;
using TimerSystem;
using UnityEngine;

namespace RotateSystem
{
    public class SunRotate : MonoBehaviour, IObserver
    {
        [SerializeField] float speed;
        [SerializeField] Vector3 axis = new Vector3(0, 0, 1);
        [SerializeField] Transform point;

        void Start()
        {
            DayTimer timer = FindObjectOfType<DayTimer>();

            if (timer != null)
            {
                timer.AddObserver(this);
                speed = 360f / timer.DayLength;
            }

        }

        void IObserver.Update(float timeOfDay)
        {
            transform.RotateAround(point.position, axis, speed * Time.deltaTime);
        }
    }

}

