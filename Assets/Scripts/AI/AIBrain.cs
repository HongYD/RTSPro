using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSPro.Core
{
    public class AIBrain : MonoBehaviour
    {
        private AIAction bestAction { get; set; }
        private NPCController npcController;
        // Start is called before the first frame update
        void Start()
        {
            npcController = GetComponent<NPCController>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Loop through all the available actions
        /// give me the highest scoring action
        /// </summary>
        /// <param name="actionsAvailable"></param>
        private void DecideBestAction(AIAction[] actionsAvailable)
        {
            
        }

        /// <summary>
        /// loop through all the considerations of the action
        /// score all the considerations
        /// </summary>
        /// <param name="aiAction"></param>
        private void ScoreAction(AIAction aiAction)
        {

        }
    }
}
