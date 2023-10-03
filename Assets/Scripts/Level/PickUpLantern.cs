using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLantern : MonoBehaviour
{
    [SerializeField] GameObject playerLantern;
    public void pickUp()
    {
        this.gameObject.SetActive(false);
        playerLantern.SetActive(true);
    }
}
