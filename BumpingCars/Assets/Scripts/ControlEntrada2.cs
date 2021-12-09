using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEntrada2 : MonoBehaviour
{
    //Componentes
    Driver driver2;

    //Awake is called when the script instance is being loaded
    void Awake() {
        driver2 = GetComponent<Driver>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vectorEntrada2 = Vector3.zero;

        vectorEntrada2.x = Input.GetAxis("Horizontal2");
        vectorEntrada2.y = Input.GetAxis("Vertical2");

        driver2.SetVectorEntrada(vectorEntrada2);
    }

}
