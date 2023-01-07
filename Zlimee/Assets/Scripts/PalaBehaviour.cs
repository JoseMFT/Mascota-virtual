using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalaBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject pala, slimes, pelota;
    Vector3 mousePos;
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
        pala.SetActive (false);

        if (Physics.Raycast (moveRay, out hitInfo) == true) {
            pala.transform.position = new Vector3 (hitInfo.point.x, pala.transform.position.y, pala.transform.position.z);
            pala.transform.rotation = Quaternion.Euler (new Vector3 (pala.transform.position.x / (.25f / -30f), -90f, 90f));
            //hitInfo.point + Vector3.up * cube.transform.localScale.y / 2f;
        }
        pala.SetActive (true);
    }
}
