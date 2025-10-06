using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeticulousCraft.Core;
using MeticulousCraft.UtilityAI;

namespace MeticulousCraft.UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "EnergyConsideration", menuName = "UtilityAI/Considerations/Energy Consideration")]
    public class EnergyConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(NPCController npc)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(npc.stats.energy / 100f));
            return score;
        }
    }
}
