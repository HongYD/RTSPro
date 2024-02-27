using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTSPro.Core;

namespace RTSPro.UtilityAI
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
            float score = 0f;
            int nextBestActionIndex = 0;
            for(int i = 0; i < actionsAvailable.Length; i++)
            {
                if (ScoreAction(actionsAvailable[i]) > score)
                {
                    nextBestActionIndex = i;
                    score = actionsAvailable[i].Score;
                }
            }
            bestAction = actionsAvailable[nextBestActionIndex];

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
                float considerationScore = aiAction.considerations[i].ScoreConsideration();
                score *= considerationScore;
                if(score == 0)
                {
                    aiAction.Score = 0;
                    return aiAction.Score;
                }
            }
            //Averaing scheme of overall score
            float originalScore = score;
            float modFactor = 1 - (1 / aiAction.considerations.Length);//LengthԽ����modFactorԽ��
            float makeupValue = (1 - originalScore) * modFactor;//originalScoreԽ��,makeupValueԽС
            aiAction.Score = originalScore + (makeupValue * originalScore);
            return aiAction.Score;
        }
    }
}
