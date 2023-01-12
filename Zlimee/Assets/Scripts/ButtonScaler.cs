using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScaler: MonoBehaviour {
    Vector3 ogSize, ogRot;

    [SerializeField]
    GameObject textoMuerte;

    void Start () {
        ogSize = gameObject.transform.localScale;
        ogRot = gameObject.transform.localEulerAngles;
    }

    public void ScaleUp () {

        if (Application.platform == RuntimePlatform.Android) {
            ScaleMobile ();

        } else {
            LeanTween.scale (gameObject, ogSize * 1.1f, .25f).setEaseOutCubic ();
        }
    }

    public void ScaleDown () {
        LeanTween.scale (gameObject, ogSize, .25f).setEaseInCubic ();
    }

    public void Rotate () {

        if (Application.platform == RuntimePlatform.Android) {
            RotateMobile ();

        } else {
            LeanTween.rotate (gameObject, new Vector3 (ogRot.x, ogRot.y, ogRot.z + 45f), .25f).setEaseOutCubic ();
        }
    }

    public void RotateBack () {
        LeanTween.rotate (gameObject, ogRot, .25f).setEaseInCubic ();
        ;
    }

    public void ScaleMobile () {
        LeanTween.scale (gameObject, ogSize * 1.1f, .25f).setEaseOutCubic ().setOnComplete ( () => {
            LeanTween.scale (gameObject, ogSize, .25f).setEaseInCubic ();
        });
    }

    public void RotateMobile () {
        LeanTween.rotate (gameObject, new Vector3 (ogRot.x, ogRot.y, ogRot.z + 45f), .25f).setEaseOutCubic ().setOnComplete ( () => {
            LeanTween.rotate (gameObject, ogRot, .25f).setEaseInCubic ();
        });
    }

    public void RestartGame () {
        LeanTween.alphaCanvas (textoMuerte.GetComponent<CanvasGroup>(), 0f, 1.5f);
            LeanTween.alphaCanvas (gameObject.GetComponent<CanvasGroup>(), 0f, 1.5f).setDelay(.75f).setOnComplete (() => {
                float f = 1.5f;
                while (f >= 0) {
                    f -= Time.deltaTime;
                }
                if (f < 0) {
                    SceneManager.LoadScene (0);
                }
            });        
    }


}
