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
    [SerializeField] private GameObject NintendoGod;
    public bool justOneNintendoGod;

    
    void Awake() { 
        print("EJECUTANDO");
        DontDestroyOnLoad(NintendoGod);
    }
    void Start() {
        justOneNintendoGod=true;
        rb=GetComponent<Rigidbody>();
        //rb.freezeRotation=true;

            float PosX;
            float PosY;
            float PosZ= 116.7f;

            // para clonar utilizamos el método instantiate
            //Instantiate(original);
            for(int i = 0; i <6; i++){
                PosX = Random.Range(-104.35f, -36.32f);
                PosY = Random.Range(1,3);
                PosZ = Random.Range(124.11f,112.29f);
                Instantiate(
                    obstaculo,
                    new Vector3(PosX,PosY,PosZ),
                    new Quaternion()
                );
            }
    }
    void Update() {
        //For the rotation of the goat whe're not using raycast since it forefully needs the cast to hit with something for it to face it.
        Vector3 mouseScreenPosition=new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.y);
        var mousePosition=Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        transform.LookAt(mousePosition);
        float v = Input.GetAxis("Horizontal");
        float h = Input.GetAxis("Vertical");

        //transform.Rotate(h,v,0);
        
        if(Input.GetKeyUp(KeyCode.Space)){
            mousePosition.Normalize();
            rb.AddForce(mousePosition*70);
            rb.AddForce(new Vector3(0,200,0));

        }

    }

    void LateUpdate() {
        if(transform.position.z<=107f && transform.position.x>=-30){
            while(justOneNintendoGod==true){
                Instantiate(
                NintendoGod,
                new Vector3(-19.7f,27.86f,72.91f),
                Quaternion.Euler(39.34f,-16.252f,3.302f)
            );
                justOneNintendoGod=false;
            }
            
        }
        if(transform.position.z<=80f && transform.position.y>=24f){
            SceneManager.LoadScene(0);
        }

    }

    void fixedUpdate() {

    }

    // we are using a Couroutine declaration. Execution of couroutine is paused when yield statement is called
    //  IEnumerator is used to declare the declaration itself, using a "return yield" pauses the execution of the method
    // So, in this case as we want the scene to change after a few seconds we use yield command with WaitForSeconds. 

    private IEnumerator reset(){
        yield return new WaitForSeconds(2);
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
    public bool getGod(){
        return this.justOneNintendoGod;
    }
}
