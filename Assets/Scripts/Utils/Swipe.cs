/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HomeGod.Struct;
using HomeGod.Enum;

namespace HomeGod
{
    public class Species : MonoBehaviour
    {
        public ResourcesComposition resourcesInteraction;
        public Behavior behavior;
        public FoodChain foodChainCategory;
        private Coroutine movingSpeciesCoroutine;
        public Transform XenoLife_Panel;

        // Start is called before the first frame update
        void Start()
        {
            born();
        }

        void born()
        {
            //Création de L'objet XENOPANEL 
            Instantiate(XenoLife_Panel,new Vector3(-210,180,0),Quaternion.identity);

            //Ajout d'une Species à l'objet créé
            GetComponent<Image>().sprite = newSpecies;



            //transform.position = new Vector3(-2, 0);
            //movingSpeciesCoroutine = moving(CENTER_OF_CAM);
        }
        void die()
        {
           // movingSpeciesCoroutine = moving(OUT_OF_SCREEN);
            //create new species on left 
            //stock les variables du nouveau ET 

        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator moving(Vector3 nextPosition)
        {
            // while
        }
    }
}
 */