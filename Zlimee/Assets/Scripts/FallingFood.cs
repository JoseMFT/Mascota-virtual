using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFood: MonoBehaviour {

    int posArray, cuentaComida = 0, cuentaBasura = 0;
    float spawnBasura, spawnComida, timeElapsed = 30f;
    public Vector3 spawnPoint, prevSpawnPoint;
    Vector3 slimeSize;

    List<GameObject> comida;
    List<GameObject> basura;
    //arrayComida[posArray];

    [SerializeField]
    GameObject comidaDonut, comidaPimiento, comidaCurry, comidaSoda, comidaPiruleta,
        comidaTomate, comidaUdon, coheteRosa, coheteAzul, coheteVerde, coheteGris,
        coheteAmarillo, coheteNaranja, coheteRojo, suelo, slimes, canvasFallingFood, canvasMenu, canvasTransicion;

    void Awake () {
        canvasMenu.SetActive (false);
        slimeSize = slimes.transform.localScale;
        comida = new List<GameObject> { comidaDonut, comidaPimiento, comidaCurry, comidaSoda, comidaPiruleta, comidaTomate, comidaUdon };
        basura = new List<GameObject> { coheteRosa, coheteAzul, coheteVerde, coheteGris, coheteAmarillo, coheteNaranja, coheteRojo };
        slimes.transform.localScale = new Vector3 (slimeSize.x * .5f, slimeSize.y * .5f, slimeSize.z);
        //slimes.transform.position = new Vector3 (slimeS)
        spawnComida = Random.Range (3f, 6.25f);
        spawnBasura = Random.Range (3f, 7.33f);
    }

    void Start () {
    }

    void Update () {

        timeElapsed -= Time.deltaTime;

        if (cuentaComida != 4) {
            if (spawnComida > 0f) {
                spawnComida -= Time.deltaTime;
            } else if (spawnComida <= 0f) {
                Randomizer ();
                Instantiate (comida[posArray], spawnPoint, Quaternion.identity);
                spawnComida = Random.Range (3f, 6.25f);
                cuentaComida++;
            }
        }
        
        if (timeElapsed <= 0f) {
            //canvasTransicion.SetActive (true);
            canvasMenu.SetActive (true);
            slimes.transform.localScale = slimeSize;
            slimes.transform.position = Vector3.zero;
            canvasFallingFood.SetActive (false);
        }

        if (cuentaBasura != 3) {
            if (spawnBasura > 0f) {
                spawnBasura -= Time.deltaTime;
            } else if (spawnBasura <= 0f) {
                Randomizer ();
                Instantiate (basura[posArray], spawnPoint, Quaternion.identity);
                spawnBasura = Random.Range (3f, 7.33f);
                cuentaBasura++;
            }
        }
    }

    void Randomizer () {
        prevSpawnPoint = spawnPoint;
        posArray = (int) Mathf.Floor (Random.Range (0, 6));
        if (prevSpawnPoint == null) {
            spawnPoint = new Vector3 (Random.Range (-.8f, .8f), 1.15f, 5.46f);
        } else {
            spawnPoint = prevSpawnPoint + new Vector3 (Random.Range (-.1f, .1f), 0f, 0f);
            if (spawnPoint.x <= -.8f) {
                spawnPoint.x = -.8f;
            } else if (spawnPoint.x >= .8f) {
                spawnPoint.x = .8f;
            }
        }
    }
}
