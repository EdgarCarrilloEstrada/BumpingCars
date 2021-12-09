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
        Vector2 vectorEntrada = Vector2.zero;

        vectorEntrada.x = Input.GetAxis("Horizontal");
        vectorEntrada.y = Input.GetAxis("Vertical");

        driver.SetVectorEntrada(vectorEntrada);
    }
}
