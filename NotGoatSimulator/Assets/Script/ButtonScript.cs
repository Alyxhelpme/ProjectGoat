using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
    
{
    void Awake(){
        GameObject.FindGameObjectWithTag("nintendo");    
    }
    public void onClick(){
        SceneManager.LoadScene("Game"); 
    }
}
