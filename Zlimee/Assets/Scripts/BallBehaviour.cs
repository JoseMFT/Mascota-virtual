using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject slimes;

    Rigidbody ballRigidBody;
    float impulseDirection = 2f;
    int givenPoints = 0, canGive = 1;

    public static BallBehaviour llamada;
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody>();
        ResetBall ();        
    }

    // Update is called once per frame
    void Update()
    {
        if (slimes.transform.localScale.x <= Vector3.one.x) {
            slimes.transform.localScale = Vector3.one;
        }

        if (givenPoints >= 15) {
            canGive = 0;
        }
    }

    void OnCollisionEnter (Collision choque) {
        if (choque.gameObject.tag == "Pala") {
            GameManager.controlador.lovePoints +=  3 * canGive;
            givenPoints += 3;
            impulseDirection = -1 * impulseDirection;
            ballRigidBody.AddForce (Random.Range (-.5f, .5f), 1f, impulseDirection, ForceMode.Impulse);
            slimes.transform.localScale -= .05f * slimes.transform.localScale;
        }

        if (choque.gameObject.tag == "Mesa") {
            ballRigidBody.AddForce (0f, 1.5f, 0f, ForceMode.Impulse);
        }
    }

    void OntriggerEnter (Collision punto) {
        if (punto.gameObject.tag == "ZonaReset") {
            impulseDirection = -1 * impulseDirection;
            ResetBall ();
        }
    }

    public void ResetBall () {
        gameObject.transform.position = new Vector3 (0f, .65f, 5.15f);
        ballRigidBody.AddForce (0f, .25f, impulseDirection, ForceMode.Impulse);
    }
}
