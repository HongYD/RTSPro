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

        public NPCInventory Inventory { get; set; }

        public Stats stats { get; set; }

        private void Start()
        {
            movement = GetComponent<MovementController>();
            aiBrain = GetComponent<AIBrain>();
            Inventory = GetComponent<NPCInventory>();
            stats = GetComponent<Stats>();
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

        internal void DoEat()
        {
            stats.hunger -= 30;
            stats.money -= 10;
            Debug.Log("I ate food");
            OnFinishedAction();
        }

        private IEnumerator WorkCoroutine(int time)
        {
            int counter = time;
            while(counter > 0)
            {

                yield return new WaitForSeconds(1);
                counter--;
            }
            Debug.Log("I AM WORKING");
            //Logic to update things involved with work
            Inventory.AddResource(ResourceType.wood, 10);

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
            stats.energy += 1;
            //Logic to update energy
            //Decide our new best action after you finshed this one
            OnFinishedAction();
        }
        #endregion
    }
}