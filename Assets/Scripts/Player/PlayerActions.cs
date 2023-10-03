using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    //[SerializeField]
    //private TextMeshPro UseText;
    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private float MaxUseDistance = 5f;
    //[SerializeField]
    //private LayerMask UseLayers;


    public void OnUse()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance)) // returns true if player is looking at door with door layermask
        {
            if (hit.collider.TryGetComponent<Door>(out Door door))// return true if door has door script on it
            {
                if (door.IsOpen)
                {
                    door.close();
                }
                else
                {
                    door.Open(transform.position); //Players pos
                }
            }

            if(hit.collider.TryGetComponent<KeyBehaviour>(out KeyBehaviour key))
            {
                key.PickUp();
            }

            if(hit.collider.TryGetComponent<PickUpLantern>(out PickUpLantern lantern))
            {
                lantern.pickUp();
            }
        }
        
    }
}
