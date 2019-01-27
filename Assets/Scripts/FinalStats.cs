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
        statsText.text = " ''Well,\n You find a home for " + born +  " new lifeforms before they destroy it." + "\n" + death + (death == 1 ? " is" : " are") + " dead and " + (born - death) + " survive."+ "\n" +"Not easy when you dont know what they need to be happy. I think that what they want it's not what they need. Even more difficult when they kill each others and destroy there own planet."+ "\n\n" +"I wonder what Home means to them ?''";  
    }

    // Update is called once per frame
    void Update()
    {

    }
}
