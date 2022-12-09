using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour {
    // Start is called before the first frame update
    public int puntos = 75;

    public void ClickedPlay () {
        SceneManager.LoadScene (2);
    }
    public void ClickedFeed () {
        SceneManager.LoadScene (1);
    }
}
