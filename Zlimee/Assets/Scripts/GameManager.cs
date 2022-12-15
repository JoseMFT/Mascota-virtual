using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager: MonoBehaviour {
    // Start is called before the first frame update
    public int lovePoints;
    public float lastConnection;

    [SerializeField]
    GameObject ajustes;

    private void Awake () {
        lovePoints = PlayerPrefs.GetInt ("puntos", 75);
        lastConnection = PlayerPrefs.GetFloat ("ultimaConexion");
        Debug.Log (lastConnection);

    }

}
