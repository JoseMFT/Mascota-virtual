using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class GameManager: MonoBehaviour {
    // Start is called before the first frame update
    public int lovePoints;
    public float lastConnection;
    DateTime currentTime, nextHunger, nextLoseLove;
    string hourHunger;
    int pointsGiven = 0, pointsTaken = 0, tiempoPruebaHambre = 1;
    Vector3 ogSize;

    bool animating = false;

    public static GameManager controlador;

    [SerializeField]
    GameObject ajustes, skinBebe, skinJunior, skinSenior, skinQueen, emptySlime;

    [SerializeField]
    TextMeshProUGUI puntos;

    private void Awake () {
        ogSize = emptySlime.transform.localScale;
        skinBebe.SetActive (false);
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
            if (nextLoseLove < currentTime) {
                //Debug.Log ("Tengo hambre");
                if (pointsTaken < 50) {
                    lovePoints--;
                    pointsTaken++;
                    Debug.Log ("Puntos de Amor: " + lovePoints);
                }
                nextLoseLove = currentTime.AddSeconds (tiempoPruebaHambre);
            }
        }

        currentTime = DateTime.Now;
        if (lovePoints >= 100) {
            lovePoints = 100;
        } else if (lovePoints <= 0) {
            lovePoints = 0;
        }

        currentTime = DateTime.Now;

        if (lovePoints == 1 || lovePoints == 5) {
            skinJunior.SetActive (false);

            if (animating == false) {
                AnimationSlime ();
            }
            skinBebe.SetActive (true); 
            
            
        } else if (lovePoints == 6 || lovePoints == 20) {
            skinBebe.SetActive (false);
            skinSenior.SetActive (false);

            if (animating == false) {
                AnimationSlime ();
            }
            skinJunior.SetActive (true);

        } else if (lovePoints == 21 || lovePoints == 60) {
            skinQueen.SetActive (false);
            skinJunior.SetActive (false);

            if (animating == false) {
                AnimationSlime ();
            }
            skinSenior.SetActive (true);
            

        } else if (lovePoints == 61 || lovePoints == 100) {
            skinSenior.SetActive (false);

            if (animating == false) {
                AnimationSlime ();
            }
            skinQueen.SetActive (true);
        }

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
        return nextHunger < DateTime.Now;
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
        animating = true;
        ogSize = emptySlime.transform.localScale;
        LeanTween.scale (emptySlime, new Vector3 (.1f, .1f, ogSize.z), .25f).setEaseInCubic ().setOnComplete (() => {
            LeanTween.scale (emptySlime, ogSize, .25f).setEaseOutCubic ().setOnComplete (() => {
                animating = false;
            });
        });
        
    }
}
