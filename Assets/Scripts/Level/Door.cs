using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsOpen = false;
    [SerializeField]
    private bool IsRotatingDoor = true;
    [SerializeField]
    private float Speed = 1f;
    [Header("Rotation Config")]
    private float RotationAmount = 90f;
    [SerializeField]
    private float ForwardDirection = 0;

    private Vector3 StartRotation;
    private Vector3 Forward;

    private Coroutine AnimationCorutine;

    //Key stuff
    [SerializeField] InventoryManager.AllItems requiredItem;


    private void Awake()
    {
        StartRotation = transform.rotation.eulerAngles;
        //Since "Forward" actually is pointing into the foor frame, choose a direction to think about as "forward"
        Forward = transform.forward;
    }

    public void Open(Vector3 UserPosition)
    {
        if (HasRequiredItem(requiredItem)){
           if (!IsOpen)
            {
                if(AnimationCorutine!= null)
                {
                    StopCoroutine(AnimationCorutine);
                }

                if(IsRotatingDoor)
                {
                    float dot = Vector3.Dot(Forward, (UserPosition - transform.position).normalized);
                    Debug.Log($"Dot: {dot.ToString("N3")}");
                    AnimationCorutine = StartCoroutine(DoRotationOpen(dot));
                }
            }
        }
        
    }

    private IEnumerator DoRotationOpen(float ForwardAmount)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        if(ForwardAmount >= ForwardDirection)
        {
            endRotation = Quaternion.Euler(new Vector3(0, startRotation.y - RotationAmount, 0));
        }
        else
        {
            endRotation = Quaternion.Euler(new Vector3(0, startRotation.y + RotationAmount, 0));
        }

        IsOpen= true;

        float time = 0;
        while(time <1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }

    public void close()
    {
        if (IsOpen)
        {
            if (AnimationCorutine != null)
            {
                StopCoroutine(AnimationCorutine);
            }

            if (IsRotatingDoor)
            {
                AnimationCorutine = StartCoroutine(DoRotationClose());
            }
        }
    }
    private IEnumerator DoRotationClose()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(StartRotation);

        IsOpen = false;

        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }

    public bool HasRequiredItem(InventoryManager.AllItems item)
    {
        if(InventoryManager.Instance.inventoryItems.Contains(item)) return true;
        else
        {
            Debug.Log("You are missing the key!");
            return false;
        }
    }
}
