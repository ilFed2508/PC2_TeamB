using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipAnimationNick : MonoBehaviour
{
    public GameObject Nick, AnimationText, TextImage, FakeBackground, Skip;

    void Start()
    {
        StartCoroutine(Animation());
        TextImage.SetActive(false);
        FakeBackground.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            StopCoroutine(Animation());
            Destroy(AnimationText);
            FakeBackground.SetActive(false);
            TextImage.SetActive(true);
            Skip.SetActive(false);
        }
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(4);
        Destroy(AnimationText);
        FakeBackground.SetActive(false);
        TextImage.SetActive(true);
        Skip.SetActive(false);
    }
}
