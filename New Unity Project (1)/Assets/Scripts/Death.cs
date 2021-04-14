using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    
   // public SpriteRenderer namex;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag=="Box"||other.collider.tag == "Player")
        {
            Debug.Log(other.collider.name);
            Destroy(other.gameObject);
        }
        
    }
}
