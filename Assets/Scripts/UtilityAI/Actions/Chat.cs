using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeticulousCraft.UtilityAI;
using MeticulousCraft.Core;

namespace MeticulousCraft.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Chat", menuName = "UtilityAI/Actions/Work")]
    public class Chat : Action
    {
        public override void Execute(NPCController npc)
        {
            npc.SeekCompanionship(3);
        }

        public override void SetRequiredDestination(NPCController npc)
        {
            npc.mover.destination = npc.gameObject.transform;
          /*  float distance = Mathf.Infinity;
            Transform nearestResource = null;

            List<Transform> resources = npc.context.Destinations[DestinationType.resource];
            foreach (Transform resource in resources)
            {
                float distanceFromResource = Vector3.Distance(resource.position, npc.transform.position);
                if (distanceFromResource < distance)
                {
                    nearestResource = resource;
                    distance = distanceFromResource;
                }
            }

            RequiredDestination = nearestResource;
            npc.mover.destination = RequiredDestination;*/
        }
    }
}
