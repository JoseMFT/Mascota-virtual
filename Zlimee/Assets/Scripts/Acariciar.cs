using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Acariciar : MonoBehaviour
{

    [SerializeField]
    Texture2D cursorPet;

    [SerializeField]
    GameObject slime;

    float tiempoAcaricia = 2f;
    bool loveGiven = false;

    string lastTimePet, nextTimePet;

    DateTime mostRecentPet, timeToPet;

    void Start()
    {
        
    }


    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) {
            mousePos = Input.GetTouch (0).position;
        }

        if (timeToPet <= DateTime.Now()) {
            loveGiven = false;
        }

        mousePos = Input.mousePosition;

        Ray moveRay = Camera.main.ScreenPointToRay (mousePos);
        RaycastHit hitInfo;
        slime.SetActive (false);

        if (Physics.Raycast (moveRay, out hitInfo) == true) {

            if (hitInfo.gameObject.tag == "Player") {
                OnMouseEnter ();

                if (Input.GetMouseButton(0)) {
                    tiempoAcaricia -= Time.deltaTime;

                    if (Input.GetMouseButtonUp(0)) {
                        tiempoAcaricia = 2f;
                    }
                }

            } else {
                OnMouseExit ();
            }

        }
        slime.SetActive (true);

        if (tiempoAcaricia <= 0f) {            
            tiempoAcaricia = 2f;

            if (loveGiven == false) {
                Instantiate (fxCorazones, slime.transform.position, Quaternion.identity);
                mostRecentPet = DateTime.Now ();
                lastTimePet = mostRecentPet.ToString();
                timeToPet = DateTime.Now.AddSeconds (7200);
                nextTimePet = timeToPet.ToString();
                GameManager.controlador.lovePoints += 10;

                PlayerPrefs.SetString ("últimas caricias", lastTimePet);
                PlayerPrefs.SetString ("próximas caricias", nextTimePet);
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
