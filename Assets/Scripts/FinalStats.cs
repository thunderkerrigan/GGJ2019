using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalStats : MonoBehaviour
{
    // Start is called before the first frame update
    public Text statsText;
    void Start()
    {
        float death = PlayerPrefs.GetInt("killed");
        float born = PlayerPrefs.GetInt("added");
        statsText.text = "Félicitation!\n vous avez donné une maison à " + born + (born > 1 ? " extra-terrestres" : " extra-terrestre") + "\n" + death + (death == 1 ? " est" : " sont") + " mort et " + (born - death) +((born - death) == 1 ? " a" : " ont") + " survécu!";  
    }

    // Update is called once per frame
    void Update()
    {

    }
}
