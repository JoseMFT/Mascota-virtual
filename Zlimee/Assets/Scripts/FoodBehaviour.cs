using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviour : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = Random.Range (1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= -2f) {
            transform.Translate (transform.position.x, transform.position.y - Time.deltaTime * speed, transform.position.z);
        } else {
            Destroy (gameObject);
        }
    }
}
