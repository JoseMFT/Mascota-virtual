using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFood: MonoBehaviour {
    public Camera gameCamera;
    string[] arrayComida = { "nuevaComida = Comida.donut,", "nuevaComida = Comida.pimiento," , "nuevaComida = Comida.soda," , "nuevaComida = Comida.curry," ,
        "nuevaComida = Comida.piruleta,", "nuevaComida = Comida.tomate,", "nuevaComida = Comida.udon,"};
    string[] arrayBasura = { "nuevaBasura = Basura.rosa", "nuevaBasura = Basura.azul", "nuevaBasura = Basura.verde", "nuevaBasura = Basura.gris",
        "nuevaBasura = Basura.amarillo", "nuevaBasura = Basura.naranja", "nuevaBasura = Basura.rojo"};


    float spawnComida = 6.25f, spawnBasura = 7.33f;
    public int posArray;
    //arrayComida[posArray];

    [SerializeField]
    GameObject comidaDonut, comidaPimiento, comidaCurry, comidaSoda, comidaPiruleta,
        comidaTomate, comidaUdon, coheteRosa, coheteAzul, coheteVerde, coheteGris,
        coheteAmarillo, coheteNaranja, coheteRojo;

    public enum Comida {
        donut, //0
        pimiento, //1
        soda, //2
        curry, //3
        piruleta, //4
        tomate, //5
        udon, //6
        none
    }

    public enum Basura {
        rosa, //0
        azul, //1
        verde, //2
        gris, //3
        amarillo, //4
        naranja, //5
        rojo, //6
        none,
    }
    public Basura nuevaBasura;
    public Comida nuevaComida;

    void Start () {
        nuevaComida = Comida.none;
        nuevaBasura = Basura.none;
        gameCamera.GetComponent<GameManager> ();
    }

    // Update is called once per frame
    void Update () {

        switch (nuevaComida) {

            case Comida.donut:
                Instantiate (comidaDonut, new Vector3 (Random.Range (-2.7f, 2.7f), 6f, 0f), Quaternion.identity);
                nuevaComida = Comida.none;
                break;

            case Comida.pimiento:
                Instantiate (comidaPimiento, new Vector3 (Random.Range (-2.7f, 2.7f), 6f, 0f), Quaternion.identity);
                nuevaComida = Comida.none;
                break;

            case Comida.soda:
                Instantiate (comidaSoda, new Vector3 (Random.Range (-2.7f, 2.7f), 6f, 0f), Quaternion.identity);
                nuevaComida = Comida.none;
                break;

            case Comida.curry:
                Instantiate (comidaCurry, new Vector3 (Random.Range (-2.7f, 2.7f), 6f, 0f), Quaternion.identity);
                nuevaComida = Comida.none;
                break;

            case Comida.piruleta:
                Instantiate (comidaPiruleta, new Vector3 (Random.Range (-2.7f, 2.7f), 6f, 0f), Quaternion.identity);
                nuevaComida = Comida.none;
                break;

            case Comida.tomate:
                Instantiate (comidaTomate, new Vector3 (Random.Range (-2.7f, 2.7f), 6f, 0f), Quaternion.identity);
                nuevaComida = Comida.none;
                break;

            case Comida.udon:
                Instantiate (comidaUdon, new Vector3 (Random.Range (-2.7f, 2.7f), 6f, 0f), Quaternion.identity);
                nuevaComida = Comida.none;
                break;

            case Comida.none:
                break;
        }

        switch (nuevaBasura) {

            case Basura.rosa:
                Instantiate (coheteRosa, new Vector3 (Random.Range (-2.7f, 2.7f), 6f, 0f), Quaternion.identity);
                nuevaBasura = Basura.none;
                break;

            case Basura.verde:
                Instantiate (coheteVerde, new Vector3 (Random.Range (-2.7f, 2.7f), 6f, 0f), Quaternion.identity);
                nuevaBasura = Basura.none;
                break;

            case Basura.azul:
                Instantiate (coheteAzul, new Vector3 (Random.Range (-2.7f, 2.7f), 6f, 0f), Quaternion.identity);
                nuevaBasura = Basura.none;
                break;

            case Basura.gris:
                Instantiate (coheteGris, new Vector3 (Random.Range (-2.7f, 2.7f), 6f, 0f), Quaternion.identity);
                nuevaBasura = Basura.none;
                break;

            case Basura.amarillo:
                Instantiate (coheteAmarillo, new Vector3 (Random.Range (-2.7f, 2.7f), 6f, 0f), Quaternion.identity);
                nuevaBasura = Basura.none;
                break;

            case Basura.naranja:
                Instantiate (coheteNaranja, new Vector3 (Random.Range (-2.7f, 2.7f), 6f, 0f), Quaternion.identity);
                nuevaBasura = Basura.none;
                break;

            case Basura.rojo:
                Instantiate (coheteRojo, new Vector3 (Random.Range (-2.7f, 2.7f), 6f, 0f), Quaternion.identity);
                nuevaBasura = Basura.none;
                break;

            case Basura.none:
                break;
        }

        if (spawnBasura <= 0) {


        }
    }

    void Randomizer () {
        posArray = (int) Mathf.Floor (Random.Range (0, 6));
    }
}
