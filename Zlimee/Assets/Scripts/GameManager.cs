using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager: MonoBehaviour {
    public void ClickedPlay () {
        SceneManager.LoadScene (2);
    }
    public void ClickedFeed () {
        SceneManager.LoadScene (1);
    }
}
