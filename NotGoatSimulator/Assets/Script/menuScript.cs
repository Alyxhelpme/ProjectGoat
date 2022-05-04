using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
    
{
    void Awake(){
        GameObject.FindGameObjectWithTag("nintendo");    
    }
    public void onClick(){
        if(Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene("Game");
        }
         
    }
}
