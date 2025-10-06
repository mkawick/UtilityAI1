using System.Collections;
using System.Collections.Generic;
using MeticulousCraft.Core;
using UnityEngine;

namespace MeticulousCraft.UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "HowFullIsMyInventory", menuName = "UtilityAI/Considerations/How Full Is My Inventory")]
    public class HowFullIsMyInventory : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;

        public override float ScoreConsideration(NPCController npc)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(npc.Inventory.HowFullIsStorage()));
            return score;
        }
    }
}
