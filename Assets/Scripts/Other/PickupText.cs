using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupText : MonoBehaviour
{
    [SerializeField] string pickUpText;


    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            TextManager.instance.changeText(pickUpText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TextManager.instance.disableText();
    }

    private void OnDisable()
    {
        TextManager.instance.disableText();
    }
}
