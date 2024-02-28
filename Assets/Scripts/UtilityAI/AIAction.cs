using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTSPro.Core;

namespace RTSPro.UtilityAI
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

        public Transform RequiredDestination { get; protected set; }

        public virtual void Awake()
        {
            score = 0;
        }

        public abstract void OnStart();


        public abstract void OnExcute(NPCController npc);


        public abstract void OnExit();

        public abstract void SetRequiredDestination(NPCController npc);
    }
}
