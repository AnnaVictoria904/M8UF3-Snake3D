using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFruit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AutoDestroy", 3, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AutoDestroy ()
    {
        Destroy(gameObject);
    }
}
