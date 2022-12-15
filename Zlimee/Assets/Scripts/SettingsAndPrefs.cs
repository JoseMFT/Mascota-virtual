using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsAndPrefs: MonoBehaviour {

    [SerializeField]
    Slider volumenSlider;

    [SerializeField]
    TMP_InputField inputNombre;

    [SerializeField]
    GameObject canvasAjustes;

    [SerializeField]
    CanvasGroup canvasAlphaColor;



    private void Awake () {
        inputNombre.text = PlayerPrefs.GetString ("nombre", "");
        volumenSlider.value = PlayerPrefs.GetFloat ("volumen", 1f);
    }

    public void Delete () {
        PlayerPrefs.DeleteAll ();
    }
    public void Save () {
        PlayerPrefs.SetString ("nombre", inputNombre.text);
        PlayerPrefs.SetFloat ("volumen", volumenSlider.value);
        Debug.Log (volumenSlider.value);
        Debug.Log (inputNombre);
    }

    public void ExitSettings () {
        LeanTween.alphaCanvas (canvasAlphaColor, 0f, .25f).setOnComplete (() => {
            canvasAjustes.SetActive (false);
        });
    }

    public void ClickedSettings () {
        LeanTween.alphaCanvas (canvasAlphaColor, 0f, .01f).setOnComplete (() => {
            canvasAjustes.SetActive (true);
            LeanTween.alphaCanvas (canvasAlphaColor, 1f, .25f);
        });
    }
}
