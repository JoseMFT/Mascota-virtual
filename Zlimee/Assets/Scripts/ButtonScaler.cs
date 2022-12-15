using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScaler: MonoBehaviour {
    Vector3 ogSize, ogRot;

    void Start () {
        ogSize = gameObject.transform.localScale;
        ogRot = gameObject.transform.localEulerAngles;
    }

    public void ScaleUp () {
        LeanTween.scale (gameObject, ogSize * 1.1f, .25f).setEaseOutCubic ();
    }

    public void ScaleDown () {
        LeanTween.scale (gameObject, ogSize, .25f).setEaseInCubic ();
    }

    public void Rotate () {
        LeanTween.rotate (gameObject, new Vector3 (ogRot.x, ogRot.y, ogRot.z + 45f), .25f).setEaseOutCubic ();
    }

    public void RotateBack () {
        LeanTween.rotate (gameObject, ogRot, .25f).setEaseInCubic ();
    }


}
