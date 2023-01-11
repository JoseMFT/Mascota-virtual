using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger: MonoBehaviour {

    DateTime lastHunger, nextHunger, nextLoseLove;
    string hourHunger;
    public int pointsGiven = 0, pointsTaken = 0, tiempoPruebaHambre = 1;


    public GameObject mascota;

    public static Hunger controladorHambre;
    // Start is called before the first frame update
    void Start () {
        //pointsLove = controlador.lovePoints;
        hourHunger = DateTime.Now.AddSeconds (tiempoPruebaHambre).ToString ();
        nextHunger = DateTime.Parse (hourHunger);
        Debug.Log ("Ahora mismo: " + currentTime.ToString ());
    }

    // Update is called once per frame
    void Update () {



        if (IsHungry ()) {


            if (pointsGiven > 0) {
                hourHunger = DateTime.Now.AddSeconds (tiempoPreubaHambre).ToString ();
                nextHunger = DateTime.Parse (hourHunger);
            } else if (pointsGiven <= 0) {
                
            }
        }

    }

    public bool IsHungry () {
        return nextHunger <= DateTime.Now;
    }

    public bool LoseLove () {
        return nextLoseLove <= DateTime.Now;
    }

}
