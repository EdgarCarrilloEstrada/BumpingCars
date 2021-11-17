using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmisionHumo : MonoBehaviour
{
    float rangoEmision = 0;

    //Componentes
    Driver driver;
    ParticleSystem particulasHumo;
    ParticleSystem.EmissionModule particulasEmision;

    /// Awake is called when the script instance is being loaded.
    void Awake()
    {
        //Obtener driver
        driver = GetComponentInParent<Driver>();

        //Obtener particlesystem
        particulasHumo = GetComponent<ParticleSystem>();

        //obtener componente de emision
        particulasEmision = particulasHumo.emission;

        //Poner la emision en 0
        particulasEmision.rateOverTime = 0;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Reducir las particulas con el tiempo
        rangoEmision = Mathf.Lerp(rangoEmision, 0, Time.deltaTime * 5);
        particulasEmision.rateOverTime = rangoEmision;

        if(driver.FriccionLlantas(out float velocidadLateral, out bool frenado)){
            //Si el carro esta haciendo friccion frenando se emite el humo
            if(frenado){
                rangoEmision = 30;
            }
            //Si el carro esta haciendo friccion drifteando se emite el humo
            else{
                rangoEmision = Mathf.Abs(velocidadLateral) * 2;
            }
        }
    }
}
