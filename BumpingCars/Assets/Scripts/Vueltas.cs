using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Vueltas : MonoBehaviour
{
    int numCheckpointPasado = 0;
    int totalCheckpoints = 0;
    int vueltasCompletadas = 0;
    const int completar = 2;
    float tiempoUltimoCP = 0;

    bool terminarCarrera = false;

    //Evento (para avisar al script que algo sucedio)
    public event Action<Vueltas> CheckpointCruzado;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Checkpoint")){

            if(terminarCarrera){
                SceneManager.LoadScene("SampleScene");
            }
            else{
                Checkpoint checkPoint = other.GetComponentInParent<Checkpoint>();

                //Checar que el carro vaya siguiendo la ruta
                if(numCheckpointPasado + 1 == checkPoint.checkpointNum){
                    numCheckpointPasado = checkPoint.checkpointNum;

                    totalCheckpoints++;

                    //Almacena el tiempo en el que cruzo el checkpoint
                    tiempoUltimoCP = Time.time;

                    if(checkPoint.meta){
                        numCheckpointPasado = 0;
                        vueltasCompletadas++;

                        if(vueltasCompletadas >= completar){
                            terminarCarrera = true;
                        }
                    }

                    CheckpointCruzado?.Invoke(this);
                }
            }
        }
    }
}
