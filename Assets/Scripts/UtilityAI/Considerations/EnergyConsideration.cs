using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTSPro.Core;

namespace RTSPro.UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "EnergyConsideration", menuName = "UtilityAI/Considerations/EnergyConsideration Consideration")]
    public class EnergyConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(NPCController npc)
        {
            Score = responseCurve.Evaluate(Mathf.Clamp01(npc.stats.energy / 100f));
            return Score;
        }
    }
}
