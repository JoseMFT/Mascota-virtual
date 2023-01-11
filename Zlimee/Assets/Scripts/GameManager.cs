using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class GameManager: MonoBehaviour {
    
    public int lovePoints;
    public float lastConnection;
    DateTime currentTime, nextHunger, nextLoseLove;
    string hourHunger;
    int pointsGiven = 0, pointsTaken = 0, tiempoHambre = 3600, tiempoPerdidaAmor = 1200;
    Vector3 ogSize;

    bool animating = false;

    public static GameManager controlador;

    [SerializeField]
    GameObject ajustes, skinBebe, skinJunior, skinSenior, skinQueen, emptySlime, fxTransform;

    [SerializeField]
    TextMeshProUGUI puntos;

    private void Awake () {
        ogSize = emptySlime.transform.localScale;
        animating = true;
        skinBebe.SetActive (true);
        skinJunior.SetActive (false);
        skinSenior.SetActive (false);
        skinQueen.SetActive (false);
        //lovePoints = PlayerPrefs.GetInt ("puntos", 75);
        lovePoints = 65;
        lastConnection = PlayerPrefs.GetFloat ("ultimaConexion");
        Debug.Log (lastConnection);
    }

    void Start () {
        currentTime = DateTime.Now;
        hourHunger = currentTime.AddSeconds (tiempoPruebaHambre).ToString ();
        nextHunger = DateTime.Parse (hourHunger);
        Debug.Log ("Ahora mismo: " + currentTime.ToString ());
    }

    void Update () {

        if (IsHungry ()) {
            if (pointsGiven > 0) {
                hourHunger = DateTime.Now.AddSeconds (tiempoPreubaHambre).ToString ();
                nextHunger = DateTime.Parse (hourHunger);
            } else if (pointsGiven <= 0) {
                if (nextLoseLove <= DateTime.Now) {
                    lovePoints--;
                    nextLoseLove = DateTime.Now.AddSeconds (tiempoPerdidaAmor);
                }
            }
        }

        currentTime = DateTime.Now;
        if (lovePoints >= 100) {
            lovePoints = 100;
        } else if (lovePoints <= 0) {
            lovePoints = 0;
        }


        /*if (lovePoints == 1 || lovePoints == 5) {
            skinJunior.SetActive (false);

            if (animating == false) {
                animating = true;
                AnimationSlime ();
            }
            skinBebe.SetActive (true); 
            
            
        } else if (lovePoints == 6 || lovePoints == 20) {
            skinBebe.SetActive (false);
            skinSenior.SetActive (false);

            if (animating == false) {
                animating = true;
                AnimationSlime ();
            }
            skinJunior.SetActive (true);

        } else if (lovePoints == 21 || lovePoints == 60) {
            skinQueen.SetActive (false);
            skinJunior.SetActive (false);

            if (animating == false) {
                animating = true;
                AnimationSlime ();
            }
            skinSenior.SetActive (true);
            

        } else if (lovePoints == 61 || lovePoints == 100) {
            skinSenior.SetActive (false);

            if (animating == false) {
                animating = true;
                AnimationSlime ();
            }
            skinQueen.SetActive (true);
        }*/

        if (Input.GetKey ("escape")) {
            if (ajustes.activeSelf) {
                ScaleUpSettings ();
            } else {
                ScaleDownSettings ();
            }
        }

        puntos.text = lovePoints.ToString();
        PlayerPrefs.SetInt ("puntos", lovePoints);
    }

    public void ScaleUpSettings () {
        ajustes.SetActive (true);
        LeanTween.scale (ajustes, Vector3.zero, 0.1f).setOnComplete (() => {
            LeanTween.scale (ajustes, Vector3.one, .75f).setEaseOutCubic ();
        });
    }

    public void ScaleDownSettings () {
        LeanTween.scale (ajustes, Vector3.zero, .75f).setEaseInCubic().setOnComplete (() => {
            ajustes.SetActive (false);
        });
    }

    public bool IsHungry () {
        return nextHunger <= DateTime.Now;
    }

    public bool LoseLove () {
        return nextLoseLove <= DateTime.Now;
    }

    public void GaveFood () {

        if (pointsGiven >= 9) {
            lovePoints += 0;

            if (emptySlime.transform.localScale.x <= 1.5f) {
                LeanTween.scale (emptySlime, new Vector3 (emptySlime.transform.localScale.x + emptySlime.transform.localScale.x * .1f, 0f, emptySlime.transform.localScale.z + emptySlime.transform.localScale.z * .1f), .1f);
            }

        } else {
            lovePoints += 3;
            pointsGiven += 3;
        }

        pointsTaken = 0;

        if (IsHungry ()) {
            pointsGiven = 0;
            nextHunger = currentTime.AddHours (3);

        }
    }

    public void AnimationSlime () {
        ogSize = emptySlime.transform.localScale;
        Instantiate (fxTransform, emptySlime.transform.position, Quaternion.identity);
        LeanTween.scale (emptySlime, new Vector3 (0f, 0f, 0f), .5f).setEaseInCubic().setOnComplete (() => {
            LeanTween.scale (emptySlime, ogSize, .5f).setEaseOutCubic ().setOnComplete (() => {
                animating = false;
            });
        });        
    }
}