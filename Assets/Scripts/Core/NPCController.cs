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

        public AIAction[] actionAvailable;

        private void Start()
        {
            movement = GetComponent<MovementController>();
            aiBrain = GetComponent<AIBrain>();
        }

        private void Update()
        {
            if (aiBrain.finishedDeciding)
            {
                aiBrain.finishedDeciding = false;
                aiBrain.bestAction.OnExcute(this);
            }
        }

        public void OnFinishedAction()
        {
            aiBrain.DecideBestAction(actionAvailable);
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
            //Decide our new best action after you finshed this one
            OnFinishedAction();
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
            //Decide our new best action after you finshed this one
            OnFinishedAction();
        }
        #endregion
    }
}