using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosCarro : MonoBehaviour
{
    [Header("Fuentes de audio")]
    public AudioSource friccionCarroAudio;
    public AudioSource motorCarroAudio;
    public AudioSource choqueCarroAudio;

    float tonoMotor = 0.5f;
    float tonoFriccion = 0.5f;

    //Componentes
    Driver driver;

    /// Awake is called when the script instance is being loaded.
    void Awake()
    {
        driver = GetComponentInParent<Driver>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActualizaMotorSonido();
        ActualizaFriccionSonido();

    }

    void ActualizaMotorSonido(){
        //
        float velocidadMagnitud = driver.obtenerMagnitudVelocidad();
        
        //Incrementa el volumen del motor con respecto a su velocidad
        float volumenMotor = velocidadMagnitud * 0.05f;

        //mantiene un nivel minimo para que reproduzca aun cuando no se esta moviendo el carro
        volumenMotor = Mathf.Clamp(volumenMotor, 0.2f, 1.0f);

        motorCarroAudio.volume = Mathf.Lerp(motorCarroAudio.volume, volumenMotor, Time.deltaTime * 10);

        //Cambiar el tono dependiendo rapidez o desaceleracion que haya
        tonoMotor = velocidadMagnitud * 0.2f;
        tonoMotor = Mathf.Clamp(tonoMotor, 0.5f, 2f);
        motorCarroAudio.volume = Mathf.Lerp(motorCarroAudio.volume, tonoMotor, Time.deltaTime * 1.5f);
    }

    void ActualizaFriccionSonido(){

        if(driver.FriccionLlantas(out float velocidadLateral, out bool frenado)){
            //Si el carro frena se aumenta el volumen y se cambia el tono
            if(frenado){
                friccionCarroAudio.volume = Mathf.Lerp(friccionCarroAudio.volume, 1.0f, Time.deltaTime * 10);
                tonoFriccion = Mathf.Lerp(tonoFriccion, 0.5f, Time.deltaTime * 10);
            }
            else{
                //si no esta frenando, aun suena si el jugador esta haciendo drift
                friccionCarroAudio.volume = Mathf.Abs(velocidadLateral) * 0.05f;
                tonoFriccion = Mathf.Abs(velocidadLateral) * 0.1f;
            }
        }
        //Desvanecer el sonido si no estamos haciendo friccion
        else{
            friccionCarroAudio.volume = Mathf.Lerp(friccionCarroAudio.volume, 0, Time.deltaTime * 10);
        }
    }
}
