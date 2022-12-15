using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateManager : MonoBehaviour
{
    string hourHambreString;
    int pointsLove = 0;
    // Start is called before the first frame update
    void Start()
    {

        //Para probar el funcionamiento lo primero que hago
        //es calcular cuando va a tener hambre para simplificarlo 
        //le digo que será en 15 segundos....
        DateTime cuandoTendraHambre = DateTime.Now.AddSeconds(15);
        
        //Almaceno en un string la hora de cuando tendrá hambre
        //esto lo hago para poder guardar como string en playerprefs
        //las diferentes fechas.
        hourHambreString = cuandoTendraHambre.ToString();
        Debug.Log("Tendra hambre a las " + hourHambreString);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Carga desde un string (podría ser un string sacado desde player prefs...) la fecha (con hora mes y dias...)

        DateTime cuandoTendraHambre = DateTime.Parse(hourHambreString);

        //Comparo la fecha de cuando tendrá hambre con la actual.
        //En caso de haberse pasado la hora de comer, se mostrará el mensaje.
        if (cuandoTendraHambre < DateTime.Now)
        {
            Debug.Log("Tiene Hambre");
        }
    }


    public bool IsHungry()
    {
        DateTime cuandoTendraHambre = DateTime.Parse(hourHambreString);
        return cuandoTendraHambre < DateTime.Now;
    }

    public void GiveFood()
    {
        if (IsHungry())
        {
            DateTime cuandoTendraHambre = DateTime.Now.AddSeconds(15);
            hourHambreString = cuandoTendraHambre.ToString();
            pointsLove += 10;
        }
        else
        {
            Debug.Log("Estoy engordando...");
        }
    
    }
}
