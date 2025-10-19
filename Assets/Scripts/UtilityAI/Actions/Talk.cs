using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeticulousCraft.UtilityAI;
using MeticulousCraft.Core;

namespace MeticulousCraft.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Talk", menuName = "UtilityAI/Actions/Talk")]
    public class Talk : Action
    {
        public override void Execute(NPCController npc)
        {
            // use chat script

            Debug.Log("I am talking");
            // Logic for updating everything involved with eating
            npc.stats.hunger -= 30;
            npc.stats.money -= 10;
            npc.aiBrain.finishedExecutingBestAction = true;
            //npc.OnFinishedAction();
        }

        public override void SetRequiredDestination(NPCController npc)
        {
            RequiredDestination = npc.transform;
        }
    }
}
