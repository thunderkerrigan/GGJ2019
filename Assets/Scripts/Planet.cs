using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HomeGod.Struct;
using HomeGod.Interface;
using HomeGod.Enum;


namespace HomeGod
{
    public class Planet : MonoBehaviour, IConsummable
    {
        public string planetName;
        [HideInInspector] public string planetStats = "";
        public ResourcesComposition resourcesComposition;
        public List<Species> population = new List<Species>();

        private PlanetUI planetUI;

        //IConsummable Interface
        public void lifeCycling()
        {
            population.ForEach(depleteThePlanet);
            checkPlanetHealth();
            newSummaryText();
        }

        private void checkPlanetHealth()
        {
            if (resourcesComposition.naturalResources <= 0)
            {
                //GAME OVER
                planetUI.chooseHomeButton.interactable = false;
                GameManager.instance.newPlanetDeath(this);
                population.ForEach(killPopulation);
            }
            if (resourcesComposition.gases.oxygen == 0)
            {
                population.FindAll(pop => pop.resourcesInteraction.gases.oxygen < 0).ForEach(killPopulation);
            }
            if (resourcesComposition.gases.carbon == 0)
            {
                population.FindAll(pop => pop.resourcesInteraction.gases.carbon < 0).ForEach(killPopulation);
            }
            if (resourcesComposition.gases.hydrogen == 0)
            {
                population.FindAll(pop => pop.resourcesInteraction.gases.hydrogen < 0).ForEach(killPopulation);
            }
            population = population.FindAll(pop => pop != null);
        }
        public void depleteThePlanet(Species pop)
        {
            resourcesComposition += pop.resourcesInteraction;
        }

        public string determineWellbeings()
        {
            String wellBeings = "WELLBEINGS:\n";
            HashSet<Species> uniqueSpecies = new HashSet<Species>(population, new SpeciesComparer());
            List<SecurityBehaviorNeed> behaviorStats = new List<SecurityBehaviorNeed>();
            behaviorStats.Add(determineStatsFor(Behavior.Pacifist));
            behaviorStats.Add(determineStatsFor(Behavior.Neutral));
            behaviorStats.Add(determineStatsFor(Behavior.Aggressive));
            List<SecurityFoodChainNeed> foodChainStats = new List<SecurityFoodChainNeed>();
            foodChainStats.Add(determineStatsFor(FoodChain.Parasitic));
            foodChainStats.Add(determineStatsFor(FoodChain.Predator));
            foodChainStats.Add(determineStatsFor(FoodChain.Prey));
           
            foreach (Species species in uniqueSpecies)
            {
                wellBeings += species.happiness(this.resourcesComposition.environment,behaviorStats, foodChainStats) +"\n";
            }
            return wellBeings;
        }
        public void killPopulation(Species pop)
        {
            int killed = PlayerPrefs.GetInt("killed");
            PlayerPrefs.SetInt("killed", killed+1);
            pop.gameObject.SetActive(false);
            Destroy(pop.gameObject);
            population.Remove(pop);
        }

        public SecurityBehaviorNeed determineStatsFor(Behavior behavior){
            float populationWithBehaviorCount = population.FindAll(p => p.behavior == behavior).Count;
            float percentage = populationWithBehaviorCount/population.Count*100f;
            SecurityBehaviorNeed need = new SecurityBehaviorNeed();
            need.category = behavior;
            need.preferencePercentage = percentage;
            return need;
        }
        public SecurityFoodChainNeed determineStatsFor(FoodChain foodChain){
            float populationWithFoodChainCount = population.FindAll(p => p.foodChainCategory == foodChain).Count;
            float percentage = populationWithFoodChainCount/population.Count*100f;
            SecurityFoodChainNeed need = new SecurityFoodChainNeed();
            need.category = foodChain;
            need.preferencePercentage = percentage;
            return need;
        }

        public void populate(Species newSpecies)
        {
            int added = PlayerPrefs.GetInt("added");
            PlayerPrefs.SetInt("added", added+1);
            population.Add(newSpecies);
            newSummaryText();
        }

        void newSummaryText()
        {
            string happiness = determineWellbeings();
            planetStats = "Population: " + this.population.Count + "\n" + this.resourcesComposition.ToString() +"\n" + happiness;
            planetUI.changeSummaryText(planetStats);
        }


        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            this.planetUI = gameObject.GetComponentInChildren<PlanetUI>();
        }
    }
}