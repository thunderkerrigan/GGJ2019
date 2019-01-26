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
            newSummaryText();
        }

        public void depleteThePlanet(Species pop)
        {
            Debug.Log("COUCOU CHATON");
            resourcesComposition += pop.resourcesInteraction;
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