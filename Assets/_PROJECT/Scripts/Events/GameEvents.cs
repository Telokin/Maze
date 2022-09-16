using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    
    public class GameEvents : MonoBehaviour
    {
        public static GameEvents gameEvents;

        private void Awake()
        {
            gameEvents = this;
        }
        public event Action<int> onDoorTriggerEnter;
        public void DoorTriggerEnter(int index)
        {
            if(onDoorTriggerEnter != null)
            {
                onDoorTriggerEnter.Invoke(index);
            }
        }

        public event Action<int> onDoorTriggerExit;
        public void DoorTriggerExit(int index)
        {
            if (onDoorTriggerExit != null)
            {
                onDoorTriggerExit.Invoke(index);
            }
        }
        public event Action<int> onPlayerDoorTriggerEnter;
        public void PlayerTriggerEnter(int index)
        {
            if (onPlayerDoorTriggerEnter != null)
            {
                onPlayerDoorTriggerEnter.Invoke(index);
            }
        }

        public event Action onPlayerHit;
        public void PlayerHit()
        {
            if (onPlayerHit != null)
            {
                onPlayerHit.Invoke();
            }
        }
        public event Action onPlayerLost;
        public void PlayerLost()
        {
            if (onPlayerLost != null)
            {
                onPlayerLost.Invoke();
            }
        }
        public event Action onPlayerCompleteLvl;
        public void PlayerCompleteLevel()
        {
            if (onPlayerCompleteLvl != null)
            {
                onPlayerCompleteLvl.Invoke();
            }
        }
        public event Action onPlayerWin;
        public void PlayerWin()
        {
            if (onPlayerWin != null)
            {
                onPlayerWin.Invoke();
            }
        }

        public event Action onGetPoint;

        public void GetPoint()
        {
            if (onGetPoint != null)
            {
                onGetPoint.Invoke();
            }
        }

        public event Action onGetHardPoint;

        public void GethardPoint()
        {
            if (onGetHardPoint != null)
            {
                onGetHardPoint.Invoke();
            }
        }

        public event Action onDifficultyChanged;

        public void DifficultyChanged()
        {
            if (onDifficultyChanged != null)
            {
                onDifficultyChanged.Invoke();
            }
        }
    }
}
