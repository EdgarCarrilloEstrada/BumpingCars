using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    //Serialize para que aparezca en el UNITY
    [SerializeField]float rot = 1;
    [SerializeField]float tran = .1f;

    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(0, 0, 45);
    }

    // Update is called once per frame
    void Update()
    {
        float cantidadDeGiro = Input.GetAxis("Horizontal") * rot * Time.deltaTime; //A ,    D
        float cantidadDeAvance = Input.GetAxis("Vertical") * tran; //W ,    S

        //ROTAR
        transform.Rotate(0, 0, -cantidadDeGiro); //para rreglar la inversion de los ejes se multiplica por -1

        //MOVER ARRIBA
        transform.Translate(0, cantidadDeAvance, 0);
    }
}
