using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FootballGame : MonoBehaviour
{
    [SerializeField]
    GameObject slimes, canvasTransicion, canvasPrincipal, pelota;

    [SerializeField]
    TextMeshProUGUI scoreMatch;

    public Vector3 ogPos;

    public int scorePlayer = 0;

    public static FootballGame juego;

    // Start is called before the first frame update
    void Start() {
        ogPos = slimes.transform.position;
        Reset ();
    }

    // Update is called once per frame
    void Update() {
        scoreMatch.text = scorePlayer.ToString();
    }

    public void ClickedExit () {
        canvasPrincipal.SetActive (true);
        //canvasTransicion.SetActive (true);
        //BallBehaviour.llamada.stop = true;
        //BallBehaviour.llamada.render.enabled = false;
        slimes.transform.position = ogPos;
        gameObject.SetActive (false);
    }

    public void Reset () {
        //BallBehaviour.llamada.ResetBall ();
        canvasPrincipal.SetActive (false);
        slimes.transform.position = new Vector3 (ogPos.x, .064f, 4.4f);

    }
}
