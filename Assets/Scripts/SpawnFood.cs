using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;

    [SerializeField] private Transform borderTop;
    [SerializeField] private Transform borderLeft;
    [SerializeField] private Transform borderRight;
    [SerializeField] private Transform borderBottom;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn food every 4 seconds, starting in 3
        InvokeRepeating("Spawn", 3, 4);
    }
    // Spawn one piece of food
    void Spawn()
    {
        // x position between left & right border
        float x = Random.Range(borderLeft.position.x + 2f,
                                  borderRight.position.x - 2f);

        // y position between top & bottom border
        float z = Random.Range(borderBottom.position.z + 2f,
                                  borderTop.position.z - 2f);

        // Instantiate the food at (x, y)
        Instantiate(foodPrefab,
                    new Vector3(x, 1f, z),
                    Quaternion.Euler(0, 0, 90)); // default rotation
    }
}
