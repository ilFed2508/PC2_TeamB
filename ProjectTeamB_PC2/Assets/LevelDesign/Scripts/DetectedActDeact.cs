using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedActDeact : MonoBehaviour
{
    public bool isActive;
    public float waiting = 5;
    public GameObject malwereDetected;

    private MalwereTrigger safeArea;

    // Start is called before the first frame update
    void Start()
    {
        safeArea = GameObject.Find("MalwereDetectedTrigger").GetComponent<MalwereTrigger>();
        safeArea.malwereDetected = this;
    }

    public void Update()
    {
        if (isActive == true)
        {
            malwereDetected.SetActive(true);
            StartCoroutine("TurnThatOff");
        }
    }

    public IEnumerator TurnThatOff()
    {
        yield return new WaitForSeconds(waiting);
        gameObject.SetActive(false);
    }
}
