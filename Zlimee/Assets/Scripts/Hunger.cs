using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger: MonoBehaviour {

    DateTime currentTime, nextHunger, nextLoseLove;
    string hourHunger;
    int pointsGiven = 0, pointsTaken = 0, tiempoPruebaHambre = 1;

    public int pointsLove;

    public GameObject mascota;

    // Start is called before the first frame update
    void Start () {
        //pointsLove = controlador.lovePoints;
        currentTime = DateTime.Now;
        hourHunger = currentTime.AddSeconds (tiempoPruebaHambre).ToString ();
        nextHunger = DateTime.Parse (hourHunger);
        Debug.Log ("Ahora mismo: " + currentTime.ToString ());
    }

    // Update is called once per frame
    void Update () {

        pointsLove = GameManager.controlador.lovePoints;

        if (IsHungry ()) {
            if (nextLoseLove < currentTime) {
                //Debug.Log ("Tengo hambre");
                if (pointsTaken < 50) {
                    pointsLove--;
                    pointsTaken++;
                    Debug.Log ("Puntos de Amor: " + pointsLove);
                }
                nextLoseLove = currentTime.AddSeconds (tiempoPruebaHambre);
            }
        }

        currentTime = DateTime.Now;
        if (pointsLove >= 100) {
            pointsLove = 100;
        } else if (pointsLove <= 0) {
            pointsLove = 0;
        }

        currentTime = DateTime.Now;


    }

    public bool IsHungry () {
        return nextHunger < DateTime.Now;
    }

    public void GaveFood () {

        if (pointsGiven >= 9) {
            pointsLove += 0;

            if (mascota.transform.localScale.x <= 1.5f) {
                LeanTween.scale (mascota, new Vector3 (mascota.transform.localScale.x + mascota.transform.localScale.x * .1f, 0f, mascota.transform.localScale.z + mascota.transform.localScale.z * .1f), .1f);
            }

        } else {
            pointsLove += 3;
            pointsGiven += 3;
        }

        pointsTaken = 0;

        if (IsHungry ()) {
            pointsGiven = 0;
            nextHunger = currentTime.AddHours (3);

        }
    }
}
