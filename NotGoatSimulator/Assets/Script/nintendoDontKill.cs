using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nintendoDontKill : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    void Awake(){
        DontDestroyOnLoad(transform.gameObject);
        audioSource=GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
