using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowUp : MonoBehaviour
{
    [SerializeField] private Transform goatchan;
    private GameObject God;
    Quaternion finalR=Quaternion.Euler(10.657f,180f,0);
    float rotationTotalT=5f;
    bool isRotating=false;
    bool justInCaseVal=false;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(justInCaseVal==false){
            transform.position=goatchan.transform.position + new Vector3(-3,1,-1);
        }
        if(justInCaseVal==true){
            transform.position=goatchan.transform.position + new Vector3(-1,1,3);
        }
        
    }
    void LateUpdate(){
        if(goatchan.transform.position.z<=110f && !isRotating){
            print("Im actually working");
            StartCoroutine(rotateOBJ());
        }
    }

    void FixedUpdate(){
        if(goatchan.transform.position.x>=-40f && !isRotating){ //This is for the camera to rotate when the goat reaches certain point
            justInCaseVal=true;
            transform.position=goatchan.transform.position + new Vector3(-1,1,3);
            transform.rotation=finalR;
        }
    }
    IEnumerator rotateOBJ(){
    print("Couroutine");
    finalR = Quaternion.Euler(-20f, 160f, 0);
    Quaternion startRot = transform.rotation;
    float rot_elapsedTime = 0.0F;
    while (rot_elapsedTime < rotationTotalT){
        transform.rotation = Quaternion.Slerp(startRot, finalR, rot_elapsedTime / rotationTotalT);
        rot_elapsedTime += Time.deltaTime;
        yield return null;
        }
    isRotating = true;
    }
}
