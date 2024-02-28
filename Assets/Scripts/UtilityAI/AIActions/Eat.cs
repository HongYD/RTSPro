using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTSPro.Core;


namespace RTSPro.UtilityAI.AIActions
{
    [CreateAssetMenu(fileName = "Eat", menuName = "UtilityAI/AIActions/Eat")]
    public class Eat : AIAction
    {
        public override void OnStart()
        {

        }

        public override void OnExcute(NPCController npc)
        {
            npc.DoEat();
            //Logic for updating every thing involved eating.
        }

        public override void OnExit()
        {

        }

        public override void SetRequiredDestination(NPCController npc)
        {
            RequiredDestination = npc.transform;
        }
    }
}
