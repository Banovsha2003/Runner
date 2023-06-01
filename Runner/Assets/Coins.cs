using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    void Start()
    {
        
    }
    private void Update()
    {
        transform.Rotate(Vector3.up, Space.World);
    }
    
           
}
