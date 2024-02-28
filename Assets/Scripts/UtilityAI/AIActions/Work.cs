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

        public override void SetRequiredDestination(NPCController npc)
        {
            float distance = Mathf.Infinity;
            Transform nearestResource = null;
            List<Transform> resources = npc.context.Destinations[DestinationType.resource];
            foreach (Transform resource in resources)
            {
                float distanceFromResource = Vector3.Distance(resource.position,npc.gameObject.transform.position);
                if(distanceFromResource < distance)
                {
                    distance = distanceFromResource;
                    nearestResource = resource;
                }
            }
            RequiredDestination = nearestResource;
            npc.movement.MoveTo(RequiredDestination.position);
        }
    }
}
