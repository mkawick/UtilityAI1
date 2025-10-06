using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeticulousCraft.UtilityAI;
using MeticulousCraft.Core;

namespace MeticulousCraft.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Sleep", menuName = "UtilityAI/Actions/Sleep")]
    public class Sleep : Action
    {
        public override void Execute(NPCController npc)
        {
            npc.DoSleep(3);
        }

        public override void SetRequiredDestination(NPCController npc)
        {
            RequiredDestination = npc.context.home.transform;
            npc.mover.destination = RequiredDestination;
        }
    }
}
