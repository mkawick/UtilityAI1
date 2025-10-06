using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeticulousCraft.Core;
using MeticulousCraft.UtilityAI;

namespace MeticulousCraft.UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "MoneyConsideration", menuName = "UtilityAI/Considerations/Money Consideration")]
    public class MoneyConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(NPCController npc)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(npc.stats.money / 1000f));
            return score;
        }
    }
}
