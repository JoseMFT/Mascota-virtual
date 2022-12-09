using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScaler: MonoBehaviour {
    Vector3 ogSize;

    void Start () {
        ogSize = gameObject.transform.localScale;
    }

    public void ScaleUp () {
        LeanTween.scale (gameObject, ogSize * 1.1f, .25f).setEaseOutCubic ();
    }

    public void ScaleDown () {
        LeanTween.scale (gameObject, ogSize, .25f).setEaseInCubic ();
    }
}
