using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGameMovement : MonoBehaviour
{
    Vector3 mousePos;
    [SerializeField]
    GameObject slime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) {
            mousePos = Input.GetTouch (0).position;
        }

        mousePos = Input.mousePosition;

        Ray moveRay = Camera.main.ScreenPointToRay (mousePos);
        RaycastHit hitInfo;
        slime.SetActive (false);

        if (Physics.Raycast (moveRay, out hitInfo) == true) {
            slime.transform.position = new Vector3 (hitInfo.point.x, slime.transform.position.y, slime.transform.position.z); 
                //hitInfo.point + Vector3.up * cube.transform.localScale.y / 2f;
        }
        slime.SetActive (true);
    }
}
