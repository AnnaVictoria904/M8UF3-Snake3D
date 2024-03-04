using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float bodySpeed;
    [SerializeField] private float steerSpeed;
    [SerializeField] private GameObject bodyPrefab;

    private int gap = 10;
    private bool ate = false;
    private List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> positionHistory = new List<Vector3>();
    private int score = 0;
    private bool waiter = false;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("Multiplayer") == 1)
        {
            transform.position = new Vector3(3.92f, 1f, 0f);
        }
    }
    void Start()
    {
        waiter = true;
        PlayerPrefs.SetInt("Score", 0);
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        StartCoroutine(eatTimer());

        positionHistory.Insert(0, transform.position);
        InvokeRepeating("UpdatePositionHistory", 0f, 0.01f);

    }

    void Update()
    {
        //move forward
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        //steer
        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * steerSpeed * Time.deltaTime);

        int index = 0;
        foreach (GameObject body in bodyParts)
        {
            Vector3 point = positionHistory[Math.Min(index * 10, positionHistory.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * bodySpeed * Time.deltaTime;

            body.transform.LookAt(point);

            index++;
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            GrowSnake();
        }*/

        if (ate)
        {
            waiter = true;
            GrowSnake();
            ate = false;
            StartCoroutine(eatTimer());
        }

    }

    void UpdatePositionHistory()
    {
        //Debug.Log("UpdatePositionHistory");
        // Añadir la posición actual al inicio de la lista
        positionHistory.Insert(0, transform.position);

        // Si la lista excede el número máximo de posiciones, elimina la última
        if (positionHistory.Count > 500)
        {
            positionHistory.RemoveAt(positionHistory.Count - 1);
        }
    }

    private void GrowSnake()
    {
        GameObject body = Instantiate(bodyPrefab);
        bodyParts.Add(body);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            ate = true;
            score++;
            PlayerPrefs.SetInt("Score", score);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Body") && waiter == false)
        {
            PlayerPrefs.SetInt("Finish", 1);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            PlayerPrefs.SetInt("Finish", 1);
        }
    }
    IEnumerator eatTimer()
    {
        float timeWait = 1;
        float counter = 0;

        while (counter < timeWait)
        {
            counter += Time.deltaTime;
            yield return null;
        }

        waiter = false;
    }
}
