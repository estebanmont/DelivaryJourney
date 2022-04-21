using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsPuntaje : MonoBehaviour
{
    private Text puntaje;
    [SerializeField] string nombre;
    [SerializeField] string requerimiento;


    // Start is called before the first frame update
    void Awake()
    {
        puntaje = GetComponent<Text>();
        puntaje.text = PlayerPrefs.GetInt("Conteo Cajas " + nombre).ToString() + " / " + requerimiento;
    }


 
}
