using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTutorial : MonoBehaviour
{
    public float waiting;

    private void Start()
    {
        StartCoroutine("Wait");
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(waiting);
        gameObject.SetActive(false);
    }
}
