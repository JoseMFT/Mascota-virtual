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
    TextMeshProUGUI nombreMascota;

    [SerializeField]
    GameObject canvasAjustes;

    [SerializeField]
    CanvasGroup canvasAlphaColor;

    [SerializeField]
    GameManager controlador;

    Vector3 canvasSize;



    private void Awake () {
        inputNombre.text = PlayerPrefs.GetString ("nombre", "");
        nombreMascota.text = PlayerPrefs.GetString ("nombre", "");
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
        nombreMascota.text = PlayerPrefs.GetString ("nombre", "");
        Debug.Log (volumenSlider.value);
        Debug.Log (inputNombre);
    }

    private void Update () {
        //PlayerPrefs.SetInt ("puntos", GameManager.controlador.lovePoints);
        PlayerPrefs.SetString ("ultimaConexion", DateTime.Now.ToString ());
    }

}
