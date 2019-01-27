using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HomeGod.Struct;
using HomeGod.Enum;

namespace HomeGod
{

    public class SpeciesComparer : IEqualityComparer<Species>
    {
        public bool Equals(Species x, Species y)
        {
            return x.gameObject.name == y.gameObject.name;
        }

        public int GetHashCode(Species obj)
        {
            return obj.gameObject.name.GetHashCode();
        }
    }
    public class Species : MonoBehaviour
    {
        public ResourcesComposition resourcesInteraction;
        public Behavior behavior;
        public FoodChain foodChainCategory;
        public Needs needs;

        Coroutine scrollCoroutine;
        float scrollSpeed = 750f;

        public void initiateScroll(Vector3 end)
        {
            initiateScroll(this.transform.position, end);
        }
        public void initiateScroll(Vector3 start, Vector3 end)
        {
            StopAllCoroutines();
            this.transform.position = start;
            scrollCoroutine = StartCoroutine("scroll", end);
        }

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            initiateScroll(new Vector3(-1000, 0, 0), new Vector3(0, 0, 0));
        }
        IEnumerator scroll(Vector3 destination)
        {
            Vector3 currentPosition = this.transform.position;
            while (Vector3.Distance(currentPosition, destination) > 0.01f)
            {
                currentPosition = this.transform.position;
                transform.position = Vector3.MoveTowards(currentPosition, destination, Time.fixedDeltaTime * scrollSpeed);
                yield return new WaitForSeconds(Time.fixedDeltaTime);
            }

        }

        public string happiness(EnvironmentComposition planetComposition, List<SecurityBehaviorNeed> behaviorStats, List<SecurityFoodChainNeed> foodChainStats)
        {
            float happiness = resourcesInteraction.environment.wellnessFeeling(planetComposition);
            behaviorStats.ForEach(b => happiness += needs.securityFeeling(b));
            foodChainStats.ForEach(f => happiness += needs.securityFeeling(f));
            return this.gameObject.name + " happiness: " + happiness;
        }

    }
}


