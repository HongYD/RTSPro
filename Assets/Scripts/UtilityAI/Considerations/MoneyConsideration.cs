using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSPro.UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "MoneyConsideration", menuName = "UtilityAI/Considerations/Money Consideration")]
    public class MoneyConsideration : Consideration
    {
        public override float ScoreConsideration()
        {
            return 0.1f;
        }
    }
}
