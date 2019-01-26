using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HomeGod;
using UnityEditor;


namespace HomeGod
{

    public class NewSpecies : MonoBehaviour
{       
  
    public Species xenolife;

    private Species newSpecies;

    // Start is called before the first frame update
    void Start()
    {
        //Choix random de la Species parmis celle spécifiée
       xenolife = GameManager.instance.nextInLine;


        // Ajout des caract de la species 
        //GetComponent<Image>().sprite = newSpecies;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}
