using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PosicionCarro : MonoBehaviour
{
    public List<Vueltas> vueltasContador = new List<Vueltas>();

    // Start is called before the first frame update
    void Start()
    {
        //obtener todos los objetos que tengan el script Vueltas
        Vueltas[] vueltasArray = FindObjectsOfType<Vueltas>();

        //Almacenar los carros o sus vueltas en una lista para manipular mas facil
        vueltasContador = vueltasArray.ToList<Vueltas>();

        //Conectar el evento de checkpoint pasado
        foreach(Vueltas contador in vueltasContador){
            contador.CheckpointCruzado += CheckpointCruzado;
        }

    }

    void CheckpointCruzado(Vueltas vueltasCont){
        Debug.Log($"Evento: El carro {vueltasCont.gameObject.name} paso un checkpoint");
    }
}
