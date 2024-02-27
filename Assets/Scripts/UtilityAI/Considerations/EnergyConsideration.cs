using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSPro.UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "EnergyConsideration", menuName = "UtilityAI/Considerations/EnergyConsideration Consideration")]
    public class EnergyConsideration : Consideration
    {
        public override float ScoreConsideration()
        {
            return 0.9f;
        }
    }
}
