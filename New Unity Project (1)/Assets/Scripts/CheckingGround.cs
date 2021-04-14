using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingGround : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D Trigger){
        if(Trigger.gameObject.tag!="Player"&&Trigger.gameObject.tag!="MainCamera")
        {
          gameObject.GetComponentInParent<Penguin>().Ground = false;
          
        }
    }
    private void OnTriggerStay2D(Collider2D Trigger)
    {
        if(Trigger.gameObject.tag!="Player"&&Trigger.gameObject.tag!="MainCamera")
        {
          gameObject.GetComponentInParent<Penguin>().Ground = true;
        }
    }
}
