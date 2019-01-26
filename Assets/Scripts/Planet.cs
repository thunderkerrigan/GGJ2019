using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HomeGod.Struct;
using HomeGod.Interface;

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
            if(resourcesComposition.naturalResources <= 0){
                //GAME OVER
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
        public void killPopulation(Species pop)
        {
            pop.gameObject.SetActive(false);
            Destroy(pop.gameObject);
            population.Remove(pop);
        }

        public void populate(Species newSpecies)
        {
            population.Add(newSpecies);
            newSummaryText();
        }

        void newSummaryText()
        {
            planetStats = "Population: " + this.population.Count + "\n" + this.resourcesComposition.ToString();
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