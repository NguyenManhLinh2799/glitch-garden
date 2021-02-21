using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunProducer : MonoBehaviour
{
    [SerializeField] float secondsDelay = 1f;
    [SerializeField] Sun sunPrefab;
    [SerializeField] bool produce = true;
    Coroutine produceRepeatedly;

    // Start is called before the first frame update
    void Start()
    {
        produceRepeatedly = StartCoroutine(ProduceSunRepeatedly());
    }

    IEnumerator ProduceSunRepeatedly()
    {
        while (produce)
        {
            yield return new WaitForSeconds(secondsDelay);
            var sun = Instantiate(sunPrefab, transform.position, Quaternion.identity);
            sun.GetComponent<Rigidbody2D>().velocity = Vector2.up;
        }
    }

    public void StopProducing()
    {
        produce = false;
        StopCoroutine(produceRepeatedly);
    }
}
