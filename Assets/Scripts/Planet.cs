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
           Debug.Log("PLANETE" + this.planetName + " REPORT FOR DUTY");
        }

        public void populate(Species newSpecies)
        {
            population.Add(newSpecies);
            newSummaryText();
            planetUI.changeSummaryText(planetStats);
        }

        void newSummaryText(){
            planetStats = "Population: "+ this.population.Count;
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