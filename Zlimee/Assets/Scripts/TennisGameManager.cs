using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisGameManager : MonoBehaviour
{
    [SerializeField]
    GameObject slimes, canvasTransicion, entorno, canvasPrincipal, palaSlime, pelota;

    Vector3 ogPos, ogEntorno;

    // Start is called before the first frame update
    void Start() {
        ogEntorno = entorno.transform.position;
        ogPos = slimes.transform.position;
        Reset ();
    }

    // Update is called once per frame
    void Update()
    {
        slimes.transform.position = new Vector3 (.5f + pelota.transform.position.x, -.2f, .765f);
    }

    public void ClickedExit () {
        palaSlime.SetActive (false);
        canvasPrincipal.SetActive (true);
        //canvasTransicion.SetActive (true);
        entorno.transform.position = ogEntorno;
        slimes.transform.position = ogPos;
        gameObject.SetActive (false);
    }

    public void Reset () {
        BallBehaviour.llamada.ResetBall ();
        palaSlime.SetActive (true);
        canvasPrincipal.SetActive (false);
        slimes.transform.position = new Vector3 (ogPos.x, -.2f, .765f);
        entorno.transform.position = new Vector3 (ogEntorno.x, -.25f, ogEntorno.z);
    }
}
