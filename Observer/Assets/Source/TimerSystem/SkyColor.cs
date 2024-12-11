using Core;
using UnityEngine;

namespace TimerSystem
{
    public class Sky : MonoBehaviour, IObserver
    {
        [SerializeField] private Color morningColor;
        [SerializeField] private Color dayColor;
        [SerializeField] private Color eveningColor;
        [SerializeField] private Color nightColor;

        private Camera sky;
        private void Start()
        {
            DayTimer timer = FindObjectOfType<DayTimer>();
            if (timer != null)
            {
                timer.AddObserver(this);
            }

            sky = GetComponent<Camera>();
        }
        void IObserver.Update(float timeOfDay)
        {
            Color targetColor;

            if (timeOfDay < 0.25f)
            {
                targetColor = Color.Lerp(nightColor, morningColor, timeOfDay / 0.25f);
            }
            else if (timeOfDay < 0.5f)
            {
                targetColor = Color.Lerp(morningColor, dayColor, (timeOfDay - 0.25f) / 0.25f);
            }
            else if (timeOfDay < 0.75f)
            {
                targetColor = Color.Lerp(dayColor, eveningColor, (timeOfDay - 0.5f) / 0.25f);
            }
            else
            {
                targetColor = Color.Lerp(eveningColor, nightColor, (timeOfDay - 0.75f) / 0.25f);
            }

            sky.backgroundColor = targetColor;
        }
    }
}