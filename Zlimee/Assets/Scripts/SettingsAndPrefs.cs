using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class SettingsAndPrefs: MonoBehaviour {

    [SerializeField]
    Slider volumenSlider;

    [SerializeField]
    TMP_InputField inputNombre;

    [SerializeField]
    GameObject canvasAjustes;

    [SerializeField]
    CanvasGroup canvasAlphaColor;

    [SerializeField]
    GameManager controlador;

    Vector3 canvasSize;
    int points;



    private void Awake () {
        inputNombre.text = PlayerPrefs.GetString ("nombre", "");
        volumenSlider.value = PlayerPrefs.GetFloat ("volumen", 1f);
        canvasSize = canvasAjustes.transform.localScale;
    }

    public void Delete () {
        inputNombre.text = "";
        volumenSlider.value = 1f;
        PlayerPrefs.DeleteAll ();
    }
    public void Save () {
        PlayerPrefs.SetString ("nombre", inputNombre.text);
        PlayerPrefs.SetFloat ("volumen", volumenSlider.value);
        Debug.Log (volumenSlider.value);
        Debug.Log (inputNombre);
    }

    public void ExitSettings () {
        LeanTween.scale (canvasAjustes, canvasSize * 0.1f, .25f).setEaseInCubic ();
        LeanTween.alphaCanvas (canvasAlphaColor, 0f, .25f).setOnComplete (() => {
            canvasAjustes.SetActive (false);
        });
    }

    public void ClickedSettings () {
        LeanTween.scale (canvasAjustes, canvasSize * 0.1f, .01f).setOnComplete (() => {
            LeanTween.scale (canvasAjustes, canvasSize, .25f).setEaseOutCubic ();
        });

        LeanTween.alphaCanvas (canvasAlphaColor, 0f, .01f).setOnComplete (() => {
            canvasAjustes.SetActive (true);
            LeanTween.alphaCanvas (canvasAlphaColor, 1f, .25f);
        });
    }

    private void Update () {
        points = controlador.lovePoints;
        PlayerPrefs.SetInt ("puntos", points);
        PlayerPrefs.SetString ("ultimaConexion", DateTime.Now.ToString ());

    }
}
