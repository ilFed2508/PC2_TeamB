using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalwereTrigger : MonoBehaviour
{
    public string toFind;
    private DetectedActDeact tutorial;

    // Start is called before the first frame update
    void Start()
    {
        tutorial = GameObject.Find(toFind).GetComponent<DetectedActDeact>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            tutorial.thing.SetActive(true);

            Destroy(gameObject);
        }
    }
}
