using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour {
    
    public int lovePoints, pointsGiven = 0, pointsTaken = 0, prevLovePoints;
    public float lastConnection;
    DateTime currentTime, nextHunger, nextLoseLove, nextPets, nextLoseToPets, canPet;
    string hourHunger;
    int tiempoHambre = 3, tiempoPerdidaAmor = 1, tiempoCaricias = 2, tiempoSinAcariciar = 24, tiempoPerderCaricias = 1;
    Vector3 ogSize, currentSize, ogPos;
    public bool canBePetted = true;

    public static GameManager controlador;

    [SerializeField]
    GameObject ajustes, jugar, alimentar, acariciar, skinBebe, skinJunior, skinSenior, 
        skinQueen, emptySlime, fxGrow, fxDecrease, fxDeath, ogCanvas, fondoNegro, fxHeart, suelo;

    GameObject activeObject, prevObject, activeSkin, prevSkin;

    [SerializeField]
    TextMeshProUGUI puntos;

    private void Awake () {
        ogPos = emptySlime.transform.position;
        ogSize = emptySlime.transform.localScale;
        //lovePoints = PlayerPrefs.GetInt ("puntos", 75);
        lovePoints = 65;
        lastConnection = PlayerPrefs.GetFloat ("ultimaConexion");
        Debug.Log (lastConnection);
    }

    void Start () {
        if (lovePoints >= 1 && lovePoints <= 5) {
            skinBebe.SetActive (true);
        } else if (lovePoints >= 6 && lovePoints <= 20) {
            skinJunior.SetActive (true);
        } else if (lovePoints >= 21 && lovePoints <= 60) {
            skinSenior.SetActive (true);
        } else if (lovePoints >= 61) {
            skinQueen.SetActive (true);
        }
        //currentTime = DateTime.Now;
        hourHunger = currentTime.AddSeconds (tiempoHambre).ToString ();
        nextHunger = DateTime.Parse (hourHunger);
        Debug.Log ("Ahora mismo: " + currentTime.ToString ());
    }

    void Update () {

        if (IsHungry ()) {

            if (pointsGiven > 0) {
                hourHunger = DateTime.Now.AddSeconds (tiempoHambre).ToString ();
                nextHunger = DateTime.Parse (hourHunger);
            
            } else if (pointsGiven <= 0) {

                if (nextLoseLove <= DateTime.Now) {
                    lovePoints--;
                    nextLoseLove = DateTime.Now.AddSeconds (tiempoPerdidaAmor);
                }
            }
        }

        if (lovePoints >= 61 && lovePoints <= 100) {
            activeSkin = skinQueen;
        } else if (lovePoints >= 21 && lovePoints <= 60) {
            activeSkin = skinSenior;
        } else if (lovePoints >= 6 && lovePoints <= 20) {
            activeSkin = skinJunior;
        } else if (lovePoints >= 1 && lovePoints <= 5) {
            activeSkin = skinBebe;
        }

        if (prevLovePoints > lovePoints) {

            if (lovePoints == 60 || lovePoints == 20 || lovePoints == 5 || lovePoints == 0) {
                if (lovePoints == 60) {
                    prevSkin = skinQueen;
                    activeSkin = skinSenior;
                } else if (lovePoints == 20) {
                    prevSkin = skinSenior;
                    activeSkin = skinJunior;
                } else if (lovePoints == 5) {
                    prevSkin = skinJunior;
                    activeSkin = skinBebe;
                } else if (lovePoints == 0) {
                    prevSkin = skinBebe;
                    activeSkin = null;
                }
                AnimationSlime ();
            }

        }

        if (prevLovePoints < lovePoints) {
            Instantiate (fxHeart, emptySlime.transform.position, Quaternion.identity);

            if (lovePoints == 61 || lovePoints == 21 || lovePoints == 6) {
                if (lovePoints == 61) {
                    prevSkin = skinSenior;
                    activeSkin = skinQueen;                    
                } else if (lovePoints == 21) {
                    prevSkin = skinJunior;
                    activeSkin = skinSenior;
                } else if (lovePoints == 6) {
                    prevSkin = skinBebe;
                    activeSkin = skinJunior;
                }
                AnimationSlime ();
            }
        }

        prevLovePoints = lovePoints;
        currentTime = DateTime.Now;

        if (lovePoints >= 100) {
            lovePoints = 100;
        } else if (lovePoints <= 0) {
            lovePoints = 0;
        }

        puntos.text = lovePoints.ToString();
        PlayerPrefs.SetInt ("puntos", lovePoints);
    }

    public bool IsHungry () {
        return nextHunger <= DateTime.Now;
    }

    public bool NeedsPets () {
        return nextPets <= DateTime.Now;
    }

    public bool LoseLove () {
        return nextLoseLove <= DateTime.Now;
    }

    public void GaveFood () {

        if (pointsGiven >= 9) {
            lovePoints += 0;

            if (emptySlime.transform.localScale.x <= 1.5f) {
                currentSize = emptySlime.transform.localScale;
                LeanTween.scale (emptySlime, new Vector3 (currentSize.x + currentSize.x * .1f, 0f, currentSize.z + currentSize.z * .1f), .1f);
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
        
        if (lovePoints != 0) {
            if (prevLovePoints < lovePoints) {
                Instantiate (fxGrow, emptySlime.transform.position, Quaternion.Euler (Vector3.zero));
            } else if (prevLovePoints > lovePoints) {
                Instantiate (fxDecrease, emptySlime.transform.position, Quaternion.Euler (Vector3.zero));
            }
        } else {
            Instantiate (fxDeath, emptySlime.transform.position, Quaternion.identity);
        }
        
        LeanTween.scale (emptySlime, Vector3.zero, .5f).setEaseInCubic().setOnComplete (() => {
            prevSkin.SetActive (false);
            activeSkin.SetActive (true);
            if (lovePoints != 0) {
                LeanTween.scale (emptySlime, ogSize, .5f).setEaseOutCubic ();
            } else {
                emptySlime.SetActive (false);
                SceneManager.LoadScene (1);
            }
        });
   }

    public void ClickedExitSettings() {
        LeanTween.scale (ajustes, Vector3.zero, .5f).setEaseInCubic ().setOnComplete (() => {
            ajustes.SetActive (false);
        });
    }

    public void ClickedExit () {
        if (suelo.activeSelf == false) {
            suelo.SetActive (true);
        }
        prevObject = activeObject;
        emptySlime.transform.position = ogPos;
        activeObject = ogCanvas;
        Transiciones ();
    }

    public void ClickedPlay() {
        activeObject = jugar;
        prevObject = ogCanvas;
        Transiciones ();
    }

    public void ClickedFeed() {
        suelo.SetActive (false);
        activeObject = alimentar;
        prevObject = ogCanvas;
        Transiciones ();
    }

    public void ClickedPet() {
        activeObject = acariciar;
        prevObject = ogCanvas;
        Transiciones ();
    }

    public void ClickedSettings() {
        ajustes.SetActive (true);
        LeanTween.scale (ajustes, Vector3.zero, 0f).setOnComplete (() => {
            LeanTween.scale (ajustes, Vector3.one, .5f).setEaseOutCubic ();
        });
    }

    public void Transiciones () { 

        if (prevObject != null) {
            fondoNegro.SetActive (true);            
            LeanTween.alphaCanvas (prevObject.GetComponent<CanvasGroup>(), 0f, .75f).setOnComplete (() => {
                LeanTween.alphaCanvas (fondoNegro.GetComponent<CanvasGroup>(), 0f, .75f).setOnComplete (() => {
                    if (activeObject.activeSelf == false) {
                        activeObject.SetActive (true);
                    }
                    LeanTween.alphaCanvas (fondoNegro.GetComponent<CanvasGroup> (), 1f, 0f);
                    LeanTween.alphaCanvas (prevObject.GetComponent<CanvasGroup> (), 1f, 1f);
                    fondoNegro.SetActive (false);
                    prevObject.SetActive (false);
                });
            });
        }
    }
}