using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HomeGod;


namespace HomeGod
{

    public class GameManager : MonoBehaviour
    {

        public static GameManager instance = null;
        private Coroutine generationCoroutine;
        public Planet[] planets;
        public Species[] speciesPool;

        private Species nextInLine;


        void Awake()
        {
            //Check if instance already exists
            if (instance == null)
            {
                //if not, set instance to this
                instance = this;
            }
            //If instance already exists and it's not this:
            else if (instance != this)
            {
                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);
            }

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
        }
        // Start is called before the first frame update
        void Start()
        {
            planets = GameObject.FindGameObjectsWithTag("Planet");
            generationCoroutine = StartCoroutine("consumeResources");
            nextSpecies();
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator consumeResources()
        {
            while (true)
            {
                print("consumeResources");
                foreach (Planet planet in planets)
                {
                    //TODO
                    planet.lifeCycling();
                }
                yield return new WaitForSeconds(5.0f * Time.fixedDeltaTime);
            }
        }

        public void chooseNewHome(Planet newHome)
        {
            newHome.populate(nextInLine);
            nextInLine = nextSpecies();
        }

        Species nextSpecies()
        {
            int index = Random.Range(0, speciesPool.Length);
            return Instantiate(speciesPool[index]); 
        }
    }
}



