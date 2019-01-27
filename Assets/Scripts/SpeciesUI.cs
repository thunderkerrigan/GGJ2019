using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HomeGod.Enum;

namespace HomeGod
{

    public class SpeciesUI : MonoBehaviour
    {

        public Text speciesNameText;
        public Text summarySpeciesText;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void showSpecies(Species species)
        {
            speciesNameText.text = species.name;
            string speciesStats = "";
            switch (species.behavior)
            {
                case Behavior.Aggressive:
                    speciesStats += "Aggresive ";
                    break;
                case Behavior.Neutral:
                    speciesStats += "Neutral ";
                    break;
                case Behavior.Pacifist:
                    speciesStats += "Pacifist ";
                    break;
                default:
                    speciesStats += "Inconnu ";
                    break;
            }
            switch (species.foodChainCategory)
            {
                case FoodChain.Parasitic:
                    speciesStats += "Parasite\n";
                    break;
                case FoodChain.Predator:
                    speciesStats += "Predator\n";
                    break;
                case FoodChain.Prey:
                    speciesStats += "Prey\n";
                    break;
                default:
                    speciesStats += "Inconnu!\n";
                    break;
            }
            summarySpeciesText.text = speciesStats;
        }
    }
}
