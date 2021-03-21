using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AHitmarkerOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Hitten");
    }

    IEnumerator Hitten()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.SetActive(false);
    }
}
