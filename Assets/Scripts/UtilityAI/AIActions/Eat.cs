using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTSPro.Core;


namespace RTSPro.UtilityAI.AIActions
{
    [CreateAssetMenu(fileName = "Eat", menuName = "UtilityAI/AIActions/Eat")]
    public class Eat : AIAction
    {
        int eatTime = 5;
        public override void OnStart()
        {

        }

        public override void OnExcute(NPCController npc)
        {
            Debug.Log("I ate food");
            //Logic for updating every thing involved eating.
        }

        public override void OnExit()
        {

        }
    }
}
