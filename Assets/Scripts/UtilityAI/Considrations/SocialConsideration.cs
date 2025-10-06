using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeticulousCraft.Core;
using MeticulousCraft.UtilityAI;

namespace MeticulousCraft.UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "SocialConsideration", menuName = "UtilityAI/Considerations/Money Consideration")]
    public class SocialConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(NPCController npc)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(npc.stats.lonliness / 1000f));
            return score;
        }
    }
}
