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

        public PlanetUI planetUI;

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


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}