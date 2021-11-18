using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEntrada : MonoBehaviour
{
    //Componentes
    Driver driver;

    //Awake is called when the script instance is being loaded
    void Awake() {
        driver = GetComponent<Driver>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
            Vector2 vectorEntrada = Vector2.zero;

            vectorEntrada.x = Input.GetAxis("Horizontal");
            vectorEntrada.y = Input.GetAxis("Vertical");

            driver.SetVectorEntrada(vectorEntrada);
        }*/
        Vector2 vectorEntrada = Vector2.zero;

        vectorEntrada.x = Input.GetAxis("Horizontal");
        vectorEntrada.y = Input.GetAxis("Vertical");

        driver.SetVectorEntrada(vectorEntrada);
    }
}
