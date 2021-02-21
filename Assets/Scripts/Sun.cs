using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] int sunsToAdd = 50;
    Transform sunDisplay;
    [SerializeField] float moveSpeed = 1f;
    bool isCollected = false;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
        sunDisplay = FindObjectOfType<SunDisplay>().transform;
    }

    private void Update()
    {
        if (isCollected)
        {
            transform.position = Vector2.MoveTowards(transform.position, sunDisplay.position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, sunDisplay.position) <= 0.001f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        if (!isCollected)
        {
            isCollected = true;
            FindObjectOfType<SunDisplay>().AddSuns(sunsToAdd);
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<BoxCollider2D>());
        }
    }
}
