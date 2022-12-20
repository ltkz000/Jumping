using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSaw : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;   

    private void Update() 
    {
        transform.Rotate(0, 0, 270 * speed * Time.deltaTime);    
    }
}
