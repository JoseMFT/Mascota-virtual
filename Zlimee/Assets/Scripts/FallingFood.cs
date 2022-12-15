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
    public Vector3 spawnPoint;
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
                Randomizer ();
                Instantiate (comidaDonut, spawnPoint, Quaternion.identity);
                nuevaComida = Comida.none;
                break;

            case Comida.pimiento:
                Randomizer ();
                Instantiate (comidaPimiento, spawnPoint, Quaternion.identity);
                nuevaComida = Comida.none;
                break;

            case Comida.soda:
                Randomizer ();
                Instantiate (comidaSoda, spawnPoint, Quaternion.identity);
                nuevaComida = Comida.none;
                break;

            case Comida.curry:
                Randomizer ();
                Instantiate (comidaCurry, spawnPoint, Quaternion.identity);
                nuevaComida = Comida.none;
                break;

            case Comida.piruleta:
                Randomizer ();
                Instantiate (comidaPiruleta, spawnPoint, Quaternion.identity);
                nuevaComida = Comida.none;
                break;

            case Comida.tomate:
                Randomizer ();
                Instantiate (comidaTomate, spawnPoint, Quaternion.identity);
                nuevaComida = Comida.none;
                break;

            case Comida.udon:
                Randomizer ();
                Instantiate (comidaUdon, spawnPoint, Quaternion.identity);
                nuevaComida = Comida.none;
                break;

            case Comida.none:
                break;
        }

        switch (nuevaBasura) {

            case Basura.rosa:
                Randomizer ();
                Instantiate (coheteRosa, spawnPoint, Quaternion.identity);
                nuevaBasura = Basura.none;
                break;

            case Basura.verde:
                Randomizer ();
                Instantiate (coheteVerde, spawnPoint, Quaternion.identity);
                nuevaBasura = Basura.none;
                break;

            case Basura.azul:
                Randomizer ();
                Instantiate (coheteAzul, spawnPoint, Quaternion.identity);
                nuevaBasura = Basura.none;
                break;

            case Basura.gris:
                Randomizer ();
                Instantiate (coheteGris, spawnPoint, Quaternion.identity);
                nuevaBasura = Basura.none;
                break;

            case Basura.amarillo:
                Randomizer ();
                Instantiate (coheteAmarillo, spawnPoint, Quaternion.identity);
                nuevaBasura = Basura.none;
                break;

            case Basura.naranja:
                Randomizer ();
                Instantiate (coheteNaranja, spawnPoint, Quaternion.identity);
                nuevaBasura = Basura.none;
                break;

            case Basura.rojo:
                Randomizer ();
                Instantiate (coheteRojo, spawnPoint, Quaternion.identity);
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
        spawnPoint = new Vector3 (Random.Range (-2.7f, 2.7f), 6f, 0f);

    }
}
