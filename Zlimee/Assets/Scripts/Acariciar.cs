using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Acariciar: MonoBehaviour {

    [SerializeField]
    Texture2D cursorTexture;

    [SerializeField]
    GameObject slime, fxCorazones;
    Vector2 mousePos, prevPos;

    float tiempoAcaricia = 2f;
    bool loveGiven = false, petting = false;

    string lastTimePet, nextTimePet;

    DateTime mostRecentPet, timeToPet, currentTime;

    void Start () {

    }


    void Update () {

        if (Application.platform == RuntimePlatform.Android) {
            mousePos = Input.GetTouch (0).position;
        }

        if (timeToPet <= DateTime.Now) {
            loveGiven = false;
        }

        mousePos = Input.mousePosition;

        if (prevPos != null) {
            if (mousePos != prevPos) {
                petting = true;
            } else {
                petting = false;
            }
        }

        prevPos = mousePos;

        Ray moveRay = Camera.main.ScreenPointToRay (mousePos);
        RaycastHit hitInfo;

        slime.SetActive (true);

        if (Input.GetMouseButton (0)) {

            slime.SetActive (true);

            if (Physics.Raycast (moveRay, out hitInfo) == true) {

                if (hitInfo.collider.gameObject.tag == "Player") {
                    OnMouseEnter ();

                    if (petting == true) {
                        Debug.Log ("Acariciando");
                        tiempoAcaricia -= Time.deltaTime;
                    }

                } else {
                    OnMouseExit ();
                }
            }

            slime.SetActive (false);
        } else {
            tiempoAcaricia = 2f;
        }
        //slime.SetActive (false);

        if (tiempoAcaricia <= 0f) {
            tiempoAcaricia = 2f;

            if (loveGiven == false) {
                Instantiate (fxCorazones, slime.transform.position, Quaternion.identity);
                mostRecentPet = DateTime.Now;
                lastTimePet = mostRecentPet.ToString ();
                timeToPet = DateTime.Now.AddSeconds (7200);
                nextTimePet = timeToPet.ToString ();
                GameManager.controlador.lovePoints += 10;
                GameManager.controlador.canBePetted = false;

                PlayerPrefs.SetString ("�ltimas caricias", lastTimePet);
                PlayerPrefs.SetString ("pr�ximas caricias", nextTimePet);
            }

            loveGiven = true;
        }
    }

    public void OnMouseEnter () {
        Cursor.SetCursor (cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void OnMouseExit () {
        Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
    }
}
