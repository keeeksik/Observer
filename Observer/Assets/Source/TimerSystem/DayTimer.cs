using Core;
using DaySystem.States;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace TimerSystem
{
    public class DayTimer : MonoBehaviour, IObservable
    {
        [SerializeField] private float dayLength;
        private float _currentTime;

        private List<IObserver> observers = new List<IObserver>();

        public float DayLength => dayLength;

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= dayLength)
                _currentTime = 0f;

            NotifyObservers(_currentTime / dayLength);
        }


        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void NotifyObservers(float currentDayTime)
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(currentDayTime);
            }
        }

    }

}

