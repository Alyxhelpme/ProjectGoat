using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 



public class Personaje : MonoBehaviour {

    //atributos publicos que sean primitivos o serializables se pueden exponer al editor 
    //primitivo: tipo de dato basico que se traduce directamente o bytes de memoria: float, int, char
    //serializable: oobjeto representable en texto y viceversa.

    public float velocidad=5;
    public float dummy; 
    
    public Text textito; //Cuando se exponga un objeto que se espera que se mande del editor hay posibilidad de que sea nulo, nullptr

    //CLONACION/INSTACIANDO OBJETOS

    public GameObject original;
    

    //Por que exponer valores al editor? Por la facilidad de cambio de comportamiento sin meterse en el codigo

    // CICLO DE VIDA : métodos que se ejecutan en momentos específicos
    // en la vida de un script.

    // idioms - estándares de escritura en lenguaje

    // se ejecuta al inicio de la vida del script una sola vez
    void Awake() { print("HOLA MUNDO"); }
    // Start is called before the first frame update
    void Start() {
        
        Debug.Log("START");

        textito.fontSize = 30;
        textito.fontStyle = FontStyle.Italic;
        textito.text = "BUENAS BUENAS";
    }

    // Update is called once p.er frame (ENGINE LOOP)
    //realtime - 30fps
    //best fr for a game - 60fps
    void Update() {

        // contador++;
        
        // print("HOLA MUNDO NUM " + contador++);

        
        // for (int j = 0; j < 500; j++) {

        //     print("Trabando el pinche programa culero");

        // }

        //input de usuario (movement and shit)


        // transform.Translate(1f * Time.deltaTime, 0, 0);

        // manejo de entrada
        // polling vs events

        // polling directo a dispositivos 

        // if (Input.GetKey(KeyCode.UpArrow)) {
            
        //     //detona cuando
        //     // cuadro anterior está libre
        //     // cuadro actual esta presionado
        //     transform.Translate(2f * Time.deltaTime, 0, 0);
        //     print("KEY");

        // }

        if (Input.GetKey(KeyCode.Space)) {
            
            //detona cuando
            // cuadro anterior está libre
            // cuadro actual esta presionado
            // print("KEY");
            Instantiate(original);

        }

        // if(Input.GetMouseButtonDown(0)){

        //     print(Input.mousePosition);

        // }

        // limitante del sistema anterior, la logica está asociada directamente con un elemento
        // físico


        //Raw= dessuavizado

        float horizontal = Input.GetAxis("Horizontal");
        //transform.Translate(horizontal * (Time.deltaTime + 0.3f), 0, 0);
        float vertical = Input.GetAxis("Vertical");
        //transform.Translate(0, vertical * (Time.deltaTime + 0.3f), 0);
        transform.Translate(
            velocidad*horizontal*Time.deltaTime, //Agrega el valor de velocidad 
            velocidad*vertical*Time.deltaTime,
            0,
            Space.World 
        );

    }

    void lateUpdate() {


        // for (int j = 0; j < 500; j++) {

        //     print("ey");

        // }

    }

    void fixedUpdate() {

    

    }

    //DIRECCION DE COLISIONES (CON MOTOR DE FISICA)
    //1. Todos los involucrados tienen collider
    //2. Al menos 1 tiene rigid body (y se debe mover)
    //3. 3 momentos en la vida de la colision
    void OnCollisionEnter(Collision c){ //Collision tiene info detallada de la colision 
        UnityEngine.Debug.Log("Start");
        print("onCollisionStart" + c.transform.name);
        print("TAG: " + c.transform.tag);
        print("LAYER: " + c.gameObject.layer);
        

        //destroy - destruye un game object o un 
        

    }
    void OnCollisionStay(Collision c){
        //print("onCollisionStay");
    }
    void OnCollisionExit(Collision c){
        print("onCollisionExit");
    }
    // cuando un involucrado en la colision es trigger el engine de fisica ya no lo toma en cuenta para movimiento

    //la colision con trigger tiene su propio juego de metodos para deteccion

    void OnTriggerEnter(Collider c){ // collider no tiene info de la fisica, es solo una referencia al collider del objeto 
        print("Trigger Enter");
    }
    
    void OnTriggerStay(Collider c){
        print("Trigger Stay");
    }
    
    void OnTriggerExit(Collider c){
        print("Trigger exit");
    }
}
