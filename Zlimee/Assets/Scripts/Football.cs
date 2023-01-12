using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Football: MonoBehaviour {
    Vector3 ogBallPos, ogSlimePos, currentPos;
    public Vector3 mousePos, destiny;

    [SerializeField]
    GameObject slimes, fxChoque;


    public float speed, slimeSpeed;
    public int givenPoints = 0;
    public bool lanzada = false, canGive = true, stop = false;
    public Renderer render;
    public static Football llamada;

    void Awake () {
        ogBallPos = gameObject.transform.position;
        ogSlimePos = slimes.transform.position;
        render = gameObject.GetComponent<Renderer> ();
    }

    void Start () {
        ResetBall ();
    }

    void Update () {
        if (lanzada == true) {
            slimes.transform.rotation = Quaternion.Euler (0f, 0f, (Mathf.Acos (destiny.x / Mathf.Sqrt (destiny.x * destiny.x + destiny.y * destiny.y)) * (180f / 3.1415f) - 90f));
            slimes.transform.position = Vector3.MoveTowards (slimes.transform.position, destiny, slimeSpeed * Time.deltaTime);
        }

        if (slimes.transform.localScale.x <= Vector3.one.x) {
            slimes.transform.localScale = Vector3.one;
        }

        if (givenPoints >= 15) {
            canGive = false;
        }

        if (Application.platform == RuntimePlatform.Android) {
            mousePos = Input.GetTouch (0).position;
        }

        mousePos = Input.mousePosition;

        Ray moveRay = Camera.main.ScreenPointToRay (mousePos);
        RaycastHit hitInfo;

        if (Physics.Raycast (moveRay, out hitInfo) == true) {

            if (Input.GetMouseButtonDown (0)) {

                if (lanzada != true) {
                    Instantiate (fxChoque, gameObject.transform.position, Quaternion.identity);
                    speed = Random.Range (8f, 12f);
                    slimeSpeed = Random.Range (3f, 4f);
                    destiny = hitInfo.point;
                    lanzada = true;
                }
            }
        }

        if (lanzada == true) {
            currentPos = gameObject.transform.position;
            gameObject.transform.position = Vector3.MoveTowards (currentPos, destiny, speed * Time.deltaTime);
        }

        if (gameObject.transform.position == destiny) {
            if (canGive == true) {
                GameManager.controlador.lovePoints += 3;
                givenPoints += 3;
            }
            ResetBall ();
        }
    }

    public void ResetBall () {
        stop = false;
        lanzada = false;
        gameObject.GetComponent<Collider> ().enabled = true;
        render.enabled = true;
        gameObject.transform.position = ogBallPos;
        slimes.transform.rotation = Quaternion.Euler (Vector3.zero);
        slimes.transform.position = new Vector3 (ogSlimePos.x, ogSlimePos.y, 6.915f);
    }

    public float ScaleSlime (float x) {
        x -= x * .1f;
        return x;
    }
}
