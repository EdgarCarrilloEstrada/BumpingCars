using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [Header("Car settings")]
    public float drift = 0.55f;
    public float aceleracion = 20.0f;
    public float rotacion = 1.5f;
    public float maxVelocidad = 15;

    //Variables Locales
    float acelerar = 0;
    float direccion = 0;
    float anguloRot = 0;
    float velocidadVsUp = 0;

    //Componentes
    Rigidbody2D carRigidbody2D;

    //Awake is called when the script instance is being loaded
    void Awake() {
        carRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    //Frame-rate independent for physics calculations
    void FixedUpdate() {
        
        ApplyEngineForce();

        KillVelocidadOrtogonal();

        ApplySteering();

    }

    void ApplyEngineForce(){

        //Calcula cuanto hacia adelante vamos a ir con respecto la direccion de nuestra velocidad
        velocidadVsUp = Vector2.Dot(transform.up, carRigidbody2D.velocity);

        //Limita la velocidad maxima hacia adelante
        if(velocidadVsUp > maxVelocidad && acelerar > 0){
            return;
        }

        //Limita la velocidad de reversa para que no vayamos a un mas de 50% de velocidad
        if(velocidadVsUp < -maxVelocidad * 0.5f && acelerar < 0){
            return;
        }

        //Limita la velocidad para no ir mas rapido en cualquier direccion mientras aceleramos
        if(carRigidbody2D.velocity.sqrMagnitude > maxVelocidad * maxVelocidad && acelerar > 0){
            return;
        }

        //Desacelera si no se presiona la tecla
        if(acelerar == 0){
            carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag, 3.0f, Time.fixedDeltaTime * 3);
        }
        else{
            carRigidbody2D.drag = 0;
        }

        //Fuerza para el motor
        Vector2 vectorFuerzaMotor = transform.up * acelerar * aceleracion;

        //Aplica la fuerza y empuja el carro hacia delante
        carRigidbody2D.AddForce(vectorFuerzaMotor, ForceMode2D.Force);

    }

    void ApplySteering(){
        //Limita la habilidad de girar el carro cuando esta quieto
        float minVelocidadGirar = (carRigidbody2D.velocity.magnitude / 8);
        minVelocidadGirar = Mathf.Clamp01(minVelocidadGirar);

        //Actualiza el angulo de rotacion de acuerdo a la entrada
        anguloRot -= direccion * rotacion * minVelocidadGirar;

        //Aplica direccion al rotar el carro
        carRigidbody2D.MoveRotation(anguloRot);
    }

    void KillVelocidadOrtogonal(){
        //Reduce las fuerzas laterales mientras damos vuelta

        Vector2 velocidadAdelante = transform.up * Vector2.Dot(carRigidbody2D.velocity, transform.up);
        Vector2 velocidadDerecha = transform.right * Vector2.Dot(carRigidbody2D.velocity, transform.right);

        carRigidbody2D.velocity = velocidadAdelante + velocidadDerecha * drift;
    }

    float ObtenerVelocidadLateral(){
        //se obtiene que tan rapido se esta moviendo el carro hacia los lados
        return Vector2.Dot(transform.right, carRigidbody2D.velocity);
    }

    public float obtenerMagnitudVelocidad(){
        //se obtiene que tan rapido se esta moviendo el carro hacia enfrente
        return Vector2.Dot(transform.right, carRigidbody2D.velocity);
    }

    public bool FriccionLlantas(out float velocidadLateral, out bool frenado){
        velocidadLateral = ObtenerVelocidadLateral();
        frenado = false;

        //Checa si el carro se mueve hacia delante y el jugador frena o esta frenando
        if(acelerar < 0 && velocidadVsUp > 0){
            frenado = true;
            return true;
        }
        else{
            //Checa si hay mucho movimiento hacia los lados o el jugador hace drift
            if(Mathf.Abs(ObtenerVelocidadLateral()) > 5.5f ){
                return true;
            }
            else{
                return false;
            }
        }
    }

    public void SetVectorEntrada(Vector2 vectorEntrada){
        direccion = vectorEntrada.x;
        acelerar = vectorEntrada.y;
    }
}
