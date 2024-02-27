using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSPro.Core
{
    public abstract class Consideration : ScriptableObject
    {
        public string Name;
        private float score;
        public float Score
        {
            get { return score; }
            set
            {
                this.score = Mathf.Clamp01(value);
            }
        }

        public virtual void Awake()
        {
            score = 0;
        }

        public abstract float ScoreConsideration();
    }
}
