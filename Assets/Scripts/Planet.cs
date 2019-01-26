using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HomeGod.Struct;
using HomeGod.Interface;

namespace HomeGod
{
    public class Planet : MonoBehaviour, IConsummable
    {

        public ResourcesComposition resourcesComposition;
        public List<Species> population = new List<Species>();

        //IConsummable Interface
        public void lifeCycling()
        {
            throw new System.NotImplementedException();
        }

        public void populate(Species newSpecies)
        {
            population.Add(newSpecies);
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