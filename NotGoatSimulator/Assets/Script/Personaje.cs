using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


[RequireComponent(typeof(Rigidbody))]
public class Personaje : MonoBehaviour {
    [SerializeField]
    private Rigidbody rb;
    
    
    public float velocidad=70;
    void Awake() { print("EJECUTANDO");}
    void Start() {
        Debug.Log("START");
        rb=GetComponent<Rigidbody>();
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(new Vector3(0,1000,0));
        }
    }

    void lateUpdate() {


    }

    void fixedUpdate() {


    }

    void OnCollisionEnter(Collision c){ //Collision tiene info detallada de la colision 
        UnityEngine.Debug.Log("Start");
        print("onCollisionStart" + c.contacts[0]);
        print(c.transform.name);
        

    }
    void OnCollisionStay(Collision c){
        //print("onCollisionStay");
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
