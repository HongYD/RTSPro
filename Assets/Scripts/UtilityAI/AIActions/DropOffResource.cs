using RTSPro.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSPro.UtilityAI.AIActions
{
    [CreateAssetMenu(fileName = "DropOffResource", menuName = "UtilityAI/AIActions/DropOffResource")]
    public class DropOffResource : AIAction
    {
        public override void OnExcute(NPCController npc)
        {
            Debug.Log("Dropped off Resource");
            npc.Inventory.RemoveAllResource();
            npc.stats.money += 20;
            npc.aiBrain.finishedExcutingBestAction = true;
        }

        public override void OnExit()
        {
            throw new System.NotImplementedException();
        }

        public override void OnStart()
        {
            throw new System.NotImplementedException();
        }

        public override void SetRequiredDestination(NPCController npc)
        {
            RequiredDestination = npc.context.storage.transform;
            npc.movement.MoveTo(RequiredDestination.position);
        }
    }
}
