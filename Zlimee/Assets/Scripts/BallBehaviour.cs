using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    Vector3 ogBallPos, ogSlimePos, currentPos;
    public Vector3 mousePos, destiny;

    [SerializeField]
    GameObject slimes, fxChoque;

    float resetted = 1;
    public float speed, slimeSpeed;
    int givenPoints = 0;
    public bool lanzada = false, canGive = false;
    public Renderer render;
    public static BallBehaviour llamada;

    void Awake () {
        ogBallPos = gameObject.transform.position;
        ogSlimePos = slimes.transform.position;
        render = gameObject.GetComponent<Renderer> ();
    }

    void Start() {        
        ResetBall ();        
    }

    // Update is called once per frame
    void Update()
    {
        if (lanzada == true) {
            slimes.transform.rotation = Quaternion.Euler (0f, 0f, RadToGrad (destiny.x, destiny.y));
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
                    speed = Random.Range (6f, 10);
                    slimeSpeed = Random.Range (3f, 5f);
                    destiny = hitInfo.point;
                    lanzada = true;
                }
            }
        }

        if (lanzada == true) {
            currentPos = gameObject.transform.position;
            //gameObject.transform.position = (destiny - currentPos) - new Vector3 (Time.deltaTime * speed, Time.deltaTime * speed, Time.deltaTime * speed);
            gameObject.transform.position = Vector3.MoveTowards (currentPos, destiny, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter (Collision choque) {

        resetted = 1f;

        if (choque.gameObject.tag == "ZonaReset") {
            FootballGame.juego.scorePlayer++;
            gameObject.transform.position = new Vector3 (currentPos.x, currentPos.y, currentPos.z - 1f);
            render.enabled = false;

        } else if (choque.gameObject.tag == "Player") {
            gameObject.transform.position = new Vector3 (currentPos.x, currentPos.y, currentPos.z - 1f);
            render.enabled = false;
            GameManager.controlador.lovePoints += 3;

            if (canGive == true) {
                givenPoints += 3;
            }            
        }

        while (resetted >= 0f) {
            resetted -= Time.deltaTime;
        }

        if (resetted <= 0) {
            ResetBall ();
        }
    }

    public void ResetBall () {
        lanzada = false;
        render.enabled = true;
        gameObject.transform.position = ogBallPos;
        slimes.transform.position = new Vector3 (ogSlimePos.x, ogSlimePos.y, 7.5f);

    }

    public float ScaleSlime (float x) {
        x -= x * .1f;
        return x;
    }

    public float Hipotenusa (float a, float b) {
        float h = Mathf.Sqrt (a * a + b * b);
        Debug.Log (h);
        return h;
    }

    public float RadToGrad (float y, float z) {
        float c = Mathf.Acos (y / Hipotenusa (y, z) * (180f / 3.1415f) - 90f);
        Debug.Log (c);
        return c;
    }
}
