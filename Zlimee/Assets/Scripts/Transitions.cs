using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.alpha (gameObject, 0f, 0f);
        LeanTween.alpha (gameObject, 1f, .5f).setEaseOutCubic().setOnComplete (() => {
            LeanTween.alpha (gameObject, 0f, .5f).setEaseOutCubic ().setOnComplete (() => {
                gameObject.SetActive (false);
            });
        });
    }
    
    void Update() {        
    }
}
