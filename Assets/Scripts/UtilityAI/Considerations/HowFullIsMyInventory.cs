using RTSPro.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSPro.UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "HowFullIsMyInventory", menuName = "UtilityAI/Considerations/HowFullIsMyInventory")]
    public class HowFullIsMyInventory : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(NPCController npc)
        {
            Score = responseCurve.Evaluate(Mathf.Clamp01(npc.Inventory.HowFullIsStorage()));
            return Score;
        }
    }
}
