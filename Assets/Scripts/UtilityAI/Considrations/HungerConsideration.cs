using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeticulousCraft.Core;
using MeticulousCraft.UtilityAI;

namespace MeticulousCraft.UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "HungerConsideration", menuName = "UtilityAI/Considerations/Hunger Consideration")]
    public class HungerConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(NPCController npc)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(npc.stats.hunger / 100f));
            return score;
        }
    }
}
