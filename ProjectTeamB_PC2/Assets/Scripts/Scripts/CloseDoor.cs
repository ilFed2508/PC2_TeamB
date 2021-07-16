using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public GameObject open;
    public GameObject trigger;
    public GameObject closed;
    public GameObject self;
    public string SuonoChiusura;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            open.SetActive(false);
            trigger.SetActive(false);
            closed.SetActive(true);
            AudioManager.instance.Play(SuonoChiusura);
            StartCoroutine("distruggi");
        }
    }

    public IEnumerator distruggi()
    {
        yield return new WaitForSecondsRealtime(1);
        self.SetActive(false);
    }
}
