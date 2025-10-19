using System;
using System.Collections;
using System.Collections.Generic;
using MeticulousCraft.Core;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace MeticulousCraft.UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "DoesSomeoneWantToTalk", 
        menuName = "UtilityAI/Considerations/Does Someone Want To Talk")]
    public class DoesSomeoneWantToTalk
        : Consideration
    {
        [SerializeField] private TalkTargetType talkTarget;
        [SerializeField] public GameObject conversor;
        [SerializeField] private AnimationCurve responseCurve;

        public override float ScoreConsideration(NPCController npc)
        {
            score = 0;// reset
            npc.mover.stopRadius = 0;

            //Collider finder = npc.finder;
            Vector3 position = npc.transform.position;
            float radius = 5;
            int playersLayer = LayerMask.NameToLayer("Players");
            int layerMask = 1 << playersLayer;
            Collider[] colliders = Physics.OverlapSphere(position, radius, layerMask);
            var radiusSquared = radius* radius;


            GameObject selection = null;
            float hillClimbingDist = 0;

            for (int i=0; i<colliders.Length; i++)
            {
                var collider = colliders[i];
                var potentialGameObject = collider.transform.parent.gameObject;
                if (collider.transform.parent.gameObject.GetComponent<PlayerComponent>())
                { 
                    var distanceSquared = (collider.transform.position - position).sqrMagnitude;
                    var inversescore = 1 - distanceSquared / radiusSquared;
                    if(inversescore > hillClimbingDist)
                    {
                        hillClimbingDist = inversescore;
                        selection = potentialGameObject;
                    }
                }
            }

            if(selection != null)
            {
                score = hillClimbingDist;
                npc.mover.destination = selection.transform;// todo, make it shorter
                npc.mover.stopRadius = 0.5f;
                conversor = selection;
            }

            return score;
        }

        private float Response(bool invertResponse, bool defaultValue)
        {
            if (invertResponse)
            {
                return Convert.ToInt32(!defaultValue);
            }
            return Convert.ToInt32(defaultValue);
        }
      
    }
}