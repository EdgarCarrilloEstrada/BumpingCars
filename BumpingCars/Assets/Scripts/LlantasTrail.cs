using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlantasTrail : MonoBehaviour
{

    //Componentes
    Driver driver;
    TrailRenderer llantasTrail;

    /// Awake is called when the script instance is being loaded.
    void Awake()
    {
     //Obtener driver
     driver = GetComponentInParent<Driver>();

     //obtener llantasTrail 
    llantasTrail = GetComponentInParent<TrailRenderer>();

    //Desactivar el trail al inicio
    //llantasTrail.enabled  = false;
    llantasTrail.emitting = false;

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si el carro esta haciendo friccion se ponen las particulas o se emite el trail
        if(driver.FriccionLlantas(out float velocidadLateral, out bool frenado)){
            llantasTrail.emitting = true;
        }
        else{
            llantasTrail.emitting = false;
        }
        
    }
}
