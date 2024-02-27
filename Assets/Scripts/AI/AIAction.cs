using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSPro.Core
{
    public abstract class AIAction : ScriptableObject
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

        public Consideration[] considerations;

        public virtual void Awake()
        {
            score = 0;
        }

        public abstract void OnStart();


        public abstract void OnExcute();


        public abstract void OnExit();
    }
}
