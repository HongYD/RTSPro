using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSPro.UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "HungerConsideration", menuName = "UtilityAI/Considerations/HungerConsideration Consideration")]
    public class HungerConsideration : Consideration
    {
        public override float ScoreConsideration()
        {
            return 0.2f;
        }
    }
}
