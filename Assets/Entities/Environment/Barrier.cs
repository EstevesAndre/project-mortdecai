using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public void Interact()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }      
    }
}
