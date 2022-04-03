using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Personaje : MonoBehaviour {
    [SerializeField] private Rigidbody rb;

    [SerializeField] private GameObject obstaculo;
    [SerializeField] private Text deathscounter;
    private int cont;

    
    void Awake() { 
        print("EJECUTANDO");
    }
    void Start() {
        rb=GetComponent<Rigidbody>();
        //rb.freezeRotation=true;

            float PosX= -89.76f;
            float PosY= 0.5f;
            float PosZ= 116.7f;

            // para clonar utilizamos el método instantiate
            //Instantiate(original);
            for(int i = 0; i <7; i++){
                PosX = Random.Range(-70.76f, 7);
                PosY = Random.Range(1,3);
                Instantiate(
                    obstaculo,
                    new Vector3(PosX,PosY,PosZ),
                    new Quaternion()
                );
            }
    }
    void Update() {
        float v = Input.GetAxis("Horizontal");
        float h = Input.GetAxis("Vertical");

        transform.Rotate(h,v,0);
        
        if(Input.GetKeyUp(KeyCode.Space)){
            rb.AddForce(new Vector3(50,200,0));

        }

    }

    void lateUpdate() {


    }

    void fixedUpdate() {

    }

    // we are using a Couroutine declaration. Execution of couroutine is paused when yield statement is called
    //  IEnumerator is used to declare the declaration itself, using a "return yield" pauses the execution of the method
    // So, in this case as we want the scene to change after a few seconds we use yield command with WaitForSeconds. 

    private IEnumerator reset(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Game");
    }

    void OnCollisionEnter(Collision c){ //Collision tiene info detallada de la colision 
        print(c.transform.name);
        if(c.transform.name=="Cube" || c.transform.name=="Cube(Clone)"){
        //     rb.velocity=Vector3.zero;
            deathscounter.fontStyle=FontStyle.Bold;
            deathscounter.text="You crashed!";
            StartCoroutine(reset());
            //rb.freezeRotation=false;
        }

    }
    void OnCollisionStay(Collision c){
        //print("onCollisionStay")    
    }
    void OnCollisionExit(Collision c){  
        //print("onCollisionExit");
    }
}
