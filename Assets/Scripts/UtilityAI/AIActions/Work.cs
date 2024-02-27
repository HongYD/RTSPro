using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTSPro.Core;

namespace RTSPro.UtilityAI.AIActions
{
    [CreateAssetMenu(fileName = "Work",menuName = "UtilityAI/AIActions/Work")]
    public class Work : AIAction
    {
        int workTime = 3;
        public override void OnStart()
        {

        }

        public override void OnExcute(NPCController npc)
        {
            npc.DoWork(workTime);
        }

        public override void OnExit()
        {

        }


    }
}
