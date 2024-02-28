using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTSPro.Core;

namespace RTSPro.UtilityAI.AIActions
{
    [CreateAssetMenu(fileName = "Sleep", menuName = "UtilityAI/AIActions/Sleep")]
    public class Sleep : AIAction
    {
        int sleepTime = 5;
        public override void OnStart()
        {

        }

        public override void OnExcute(NPCController npc)
        {
            npc.DoSleep(sleepTime);
        }

        public override void OnExit()
        {

        }

        public override void SetRequiredDestination(NPCController npc)
        {
            RequiredDestination = npc.context.home.transform;
            npc.movement.MoveTo(RequiredDestination.position);
        }
    }
}
