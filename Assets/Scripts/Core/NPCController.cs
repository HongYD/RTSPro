using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTSPro.UtilityAI;
using System;

namespace RTSPro.Core
{
    public class NPCController : MonoBehaviour
    {
        [SerializeField]
        private MovementController movement { get; set; }
        [SerializeField]
        private AIBrain aiBrain { get; set; }

        [SerializeField]
        private AIAction[] actionAvailable;

        private void Start()
        {
            movement = GetComponent<MovementController>();
            aiBrain = GetComponent<AIBrain>();
        }

        private void Update()
        {
            
        }

        #region Action Excute Coroutines
        public void DoWork(int time)
        {
            StartCoroutine(WorkCoroutine(time));
        }

        public void DoSleep(int time)
        {
            StartCoroutine(SleepCoroutine(time));
        }

        private IEnumerator EatCoroutine(int time)
        {
            int counter = time;
            while (counter > 0)
            {

                yield return new WaitForSeconds(1);
                counter--;
            }
            Debug.Log("I Just harvest 1 resources");
        }

        private IEnumerator WorkCoroutine(int time)
        {
            int counter = time;
            while(counter > 0)
            {

                yield return new WaitForSeconds(1);
                counter--;
            }
            Debug.Log("I Just harvest 1 resources");
            //Logic to update things involved with work
        }

        private IEnumerator SleepCoroutine(int time)
        {
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            Debug.Log("I slept and gained 1 energy");
            //Logic to update energy
        }
        #endregion
    }
}