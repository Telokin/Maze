using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    public class DoorController : MonoBehaviour
    {
        [SerializeField] private int _index;
        private Vector3 _doorDown;
        private Vector3 _doorUp;
        [SerializeField] private float _doorYPosition = 6;
        [SerializeField] private float _duration = 0.5f;

        public int Index { get => _index;}

        private void Start()
        {
            GameEvents.gameEvents.onDoorTriggerEnter += OnDoorOpen;
            GameEvents.gameEvents.onDoorTriggerExit += OnDoorClose;
            _doorDown = gameObject.transform.localPosition;
            _doorUp = new Vector3(_doorDown.x, _doorYPosition, _doorDown.z);
        }
        private void OnDestroy()
        {
            GameEvents.gameEvents.onDoorTriggerEnter -= OnDoorOpen;
            GameEvents.gameEvents.onDoorTriggerExit -= OnDoorClose;
        }

        private void OnDoorOpen(int index)
        {
            if (index == _index)
            {
                StartCoroutine(OnDoorOpenCoroutine());
            }
        }

        private void OnDoorClose(int index)
        {
            if (index == _index)
            {
                StartCoroutine(OnDoorCloseCoroutine());
            }
        }
        private IEnumerator OnDoorOpenCoroutine()
        {
            float journey = 0f;
            while (journey <= _duration)
            {
                journey = journey + Time.deltaTime;
                float percent = Mathf.Clamp01(journey / _duration);

                transform.position = Vector3.Lerp(_doorDown, _doorUp, percent);

                yield return null;
            }
        }
        private IEnumerator OnDoorCloseCoroutine()
        {
            float journey = 0f;
            while (journey <= _duration)
            {
                journey = journey + Time.deltaTime;
                float percent = Mathf.Clamp01(journey / _duration);

                transform.position = Vector3.Lerp(_doorUp, _doorDown, percent);

                yield return null;
            }
        }
    }
}
