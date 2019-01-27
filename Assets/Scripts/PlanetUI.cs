using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HomeGod
{
    public class PlanetUI : MonoBehaviour
    {
        private Planet parentPlanet;
        public Text titleText;
        public Text summaryText;

        public Button chooseHomeButton;

        void Awake()
        {
            parentPlanet = transform.parent.GetComponent<Planet>();
            titleText.text = this.parentPlanet.planetName;
            summaryText.text = this.parentPlanet.planetStats;
        }

        public void handleClick()
        {
            GameManager.instance.chooseNewHome(parentPlanet);
        }

        public void changeSummaryText(string newContent){
            summaryText.text = newContent;
        }
    }
}
