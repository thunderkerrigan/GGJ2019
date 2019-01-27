using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HomeGod;
using UnityStandardAssets;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;

namespace HomeGod
{

    public class GameManager : MonoBehaviour
    {

        public static GameManager instance = null;
        private Coroutine generationCoroutine;
        public List<Planet> planets;
        public Species[] speciesPool;

        private int deathCount = 0;

        private SpeciesUI speciesUI;

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
            GameObject speciesUIObject = GameObject.Find("SpeciesPanel");
            speciesUI = speciesUIObject.GetComponent<SpeciesUI>();
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Planet");
            planets = new List<Planet>();
            foreach (GameObject item in gameObjects)
            {
                planets.Add(item.GetComponent<Planet>());
            }
            generationCoroutine = StartCoroutine("consumeResources");

            nextInLine = nextSpecies();
            PlayerPrefs.SetInt("added", 0);
            PlayerPrefs.SetInt("killed", 0);
            
        }

        // Update is called once per frame
        void Update()
        {
            if (deathCount >= 3)
            {
                //GAME OVER
                SceneManager.LoadScene("EndScene" , LoadSceneMode.Single);
                this.gameObject.SetActive(false);
            }
        }

        IEnumerator consumeResources()
        {
            while (true)
            {
                print("consumeResources");
                foreach (Planet planet in planets.ToList())
                {
                    //TODO
                    planet.lifeCycling();
                }

                yield return new WaitForSeconds(250.0f * Time.fixedDeltaTime);
            }
        }

        public void chooseNewHome(Planet newHome)
        {
            newHome.populate(nextInLine);
            nextInLine.initiateScroll(new Vector3(1000, 0, 0));
            nextInLine = nextSpecies();
        }

        public Species nextSpecies()
        {
            int index = Random.Range(0, speciesPool.Length);
            Species newSpecies = Instantiate(speciesPool[index]);
            newSpecies.name = speciesPool[index].name;
            speciesUI.showSpecies(newSpecies);
            return newSpecies;
        }
        public void newPlanetDeath(Planet planet){
            deathCount++;
            planets.Remove(planet);
        }
    }
}



