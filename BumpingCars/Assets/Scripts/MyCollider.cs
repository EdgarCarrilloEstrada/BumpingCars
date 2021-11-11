using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCollider : MonoBehaviour
{

    private AudioSource audioSource;

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other){
        Debug.Log("OnCollisionEnter 2d enter");
        if(other.gameObject.tag == "Crash"){
            audioSource.Play();
        }

        //if(other.gameObject.tag == "Square"){
          //  Destroy(other.gameObject, .01f);

        //}
    }
}
