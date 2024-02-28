using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTSPro.UtilityAI;
using System;

namespace RTSPro.Core
{

    public enum PlayerState
    {
        decide,
        move,
        excute,
    }

    public class NPCController : MonoBehaviour
    {
        [SerializeField]
        public MovementController movement { get; set; }
        [SerializeField]
        PlayerState currentState;
        [SerializeField]
        public AIBrain aiBrain { get; set; }

        public NPCInventory Inventory { get; set; }

        public Stats stats { get; set; }

        public Context context;

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
            FSMTick();
        }

        private void FSMTick()
        {
            if(currentState == PlayerState.decide)
            {
                aiBrain.DecideBestAction();
                if (Vector3.Distance(aiBrain.bestAction.RequiredDestination.position, this.transform.position) < 2f)
                {
                    currentState = PlayerState.excute;
                }
                else
                {
                    currentState = PlayerState.move;
                }
            }
            else if(currentState == PlayerState.move)
            {
                if (Vector3.Distance(aiBrain.bestAction.RequiredDestination.position, this.transform.position) < 2f)
                {
                    currentState = PlayerState.excute;
                }
                else
                {
                    movement.MoveTo(aiBrain.bestAction.RequiredDestination.position);
                }
            }
            else if(currentState == PlayerState.excute)
            {
                if(aiBrain.finishedExcutingBestAction == false)
                {
                    aiBrain.bestAction.OnExcute(this);
                }
                else if(aiBrain.finishedExcutingBestAction == true)
                {
                    currentState = PlayerState.decide;
                }
            }
        }

        public void OnFinishedAction()
        {
            aiBrain.DecideBestAction();
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
            aiBrain.finishedExcutingBestAction = true;
            //OnFinishedAction();
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
            aiBrain.finishedExcutingBestAction = true;
            //Decide our new best action after you finshed this one
            //
            //OnFinishedAction();
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
            //OnFinishedAction();
            aiBrain.finishedExcutingBestAction = true;
        }
        #endregion
    }
}