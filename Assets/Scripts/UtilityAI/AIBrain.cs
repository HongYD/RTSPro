using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTSPro.Core;
using RTSPro.UI;

namespace RTSPro.UtilityAI
{
    public class AIBrain : MonoBehaviour
    {
        public AIAction bestAction { get; set; }

        public bool finishedDeciding { get; set; }
        public bool finishedExcutingBestAction { get; internal set; }

        private NPCController npcController;
        [SerializeField] private Billboard billBoard;
        [SerializeField] private AIAction[] actionAvailable;
        // Start is called before the first frame update
        void Start()
        {
            npcController = GetComponent<NPCController>();
            finishedDeciding = false;
            finishedExcutingBestAction = false;
        }

        // Update is called once per frame
        void Update()
        {
            //if(bestAction is null)
            //{
            //    DecideBestAction();
            //}
        }

        /// <summary>
        /// Loop through all the available actions
        /// give me the highest scoring action
        /// </summary>
        /// <param name="actionsAvailable"></param>
        public void DecideBestAction()
        {
            finishedExcutingBestAction = false;
            float score = 0f;
            int nextBestActionIndex = 0;
            for(int i = 0; i < actionAvailable.Length; i++)
            {
                if (ScoreAction(actionAvailable[i]) > score)
                {
                    nextBestActionIndex = i;
                    score = actionAvailable[i].Score;
                }
            }
            bestAction = actionAvailable[nextBestActionIndex];
            bestAction.SetRequiredDestination(npcController);
            finishedDeciding = true;
            billBoard.UpdateBestActionText(bestAction.Name);
        }

        /// <summary>
        /// loop through all the considerations of the action
        /// score all the considerations
        /// average all the consideration scores ==> overall action score
        /// </summary>
        /// <param name="aiAction"></param>
        private float ScoreAction(AIAction aiAction)
        {
            float score = 1f;
            for(int i = 0; i<aiAction.considerations.Length; i++)
            {
                float considerationScore = aiAction.considerations[i].ScoreConsideration(npcController);
                score *= considerationScore;
                if(score == 0)
                {
                    aiAction.Score = 0;
                    return aiAction.Score;
                }
            }
            //Averaing scheme of overall score
            float originalScore = score;
            float modFactor = 1 - (1 / aiAction.considerations.Length);//Length越长，modFactor越大
            float makeupValue = (1 - originalScore) * modFactor;//originalScore越大,makeupValue越小
            aiAction.Score = originalScore + (makeupValue * originalScore);
            return aiAction.Score;
        }
    }
}
