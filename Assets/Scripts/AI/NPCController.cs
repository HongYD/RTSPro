using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSPro.Core
{
    public class NPCController : MonoBehaviour
    {
        [SerializeField]
        private MovementController movement { get; set; }
        [SerializeField]
        private AIBrain aiBrain { get; set; }

        [SerializeField]
        private AIAction[] actionAvailable;

        private void Start()
        {
            movement = GetComponent<MovementController>();
            aiBrain = GetComponent<AIBrain>();
        }
    }
}