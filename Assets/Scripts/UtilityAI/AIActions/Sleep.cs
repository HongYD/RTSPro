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
    }
}
