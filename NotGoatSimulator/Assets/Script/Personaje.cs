using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Personaje : MonoBehaviour {
    [SerializeField]
    private Rigidbody rb;
    public float delay=3; //El tiempo de delay para el cambio de escena
    
    public float velocidad=70;
    void Awake() { print("EJECUTANDO");}
    void Start() {
        Debug.Log("START");
        rb=GetComponent<Rigidbody>();
        rb.freezeRotation=true;
    }
    void Update() {
        rb.AddForce(new Vector3(.7f,0,0));
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(new Vector3(0,200,0));
        }
    }

    void lateUpdate() {


    }

    void fixedUpdate() {


    }

    // we are using a Couroutine declaration. Execution of couroutine is paused when yield statement is called
    //  IEnumerator is used to declare the declaration itself, using a "return yield" pauses the execution of the method
    // So, in this case as we want the scene to change after a few seconds we use yield command with WaitForSeconds. 

    IEnumerator reset(){
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Game");
    }

    void OnCollisionEnter(Collision c){ //Collision tiene info detallada de la colision 
        UnityEngine.Debug.Log("goatCrash");
        print("onCollisionStart" + c.contacts[0]);
        print(c.transform.name);
        if(c.transform.name=="Cube"){
        //     rb.velocity=Vector3.zero;
            StartCoroutine(reset());
        }

    }
    void OnCollisionStay(Collision c){
        //print("onCollisionStay")    
    }
    void OnCollisionExit(Collision c){  
        print("onCollisionExit");
    }

    void OnTriggerEnter(Collider c){ // collider no tiene info de la fisica, es solo una referencia al collider del objeto 
        print("Trigger Enter");
        //Se destruye un gameobject completo 
    }
    
    void OnTriggerStay(Collider c){
        //print("Trigger Stay");
    }
    
    void OnTriggerExit(Collider c){
        print("Trigger exit");
    }
}
