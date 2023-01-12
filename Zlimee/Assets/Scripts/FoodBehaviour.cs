using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviour : MonoBehaviour
{

    [SerializeField]
    GameObject fxStar, fxExplosion, fxHeart, mascota;
    float speed;
    Vector3 objPos;

    void Start()
    {
        speed = Random.Range (.75f, 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        objPos = transform.position;

        if (transform.position.y >= -2f) {
            transform.position = new Vector3 (objPos.x, objPos.y - (Time.deltaTime * speed), objPos.z);

        } else {
            Destroy (gameObject);
        }
    }

    void OnCollisionEnter (Collision choque) {

        if (choque.gameObject.tag == "Player") {
            gameObject.GetComponent<MeshRenderer> ().enabled = false;

            if (gameObject.tag == "Food") {
                Instantiate (fxStar, transform.position, Quaternion.identity);

                GameManager.controlador.pointsGiven += 3;

                if (GameManager.controlador.pointsGiven <= 12) {
                    GameManager.controlador.lovePoints += 3;
                } else if (GameManager.controlador.pointsGiven > 12) {
                    mascota.transform.localScale += .1f * Vector3.one;
                }

            } else if (gameObject.tag == "Rubbish") {
                Instantiate (fxExplosion, transform.position, Quaternion.identity);
                Instantiate (fxHeart, transform.position, Quaternion.identity);
                GameManager.controlador.pointsGiven -= 1;
                GameManager.controlador.lovePoints -= 1;
            }
            Destroy (gameObject);            
        }
    } 
}
