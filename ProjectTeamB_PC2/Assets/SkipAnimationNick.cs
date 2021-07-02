﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipAnimationNick : MonoBehaviour
{
    public GameObject Nick, AnimationText, TextImage, FakeBackground, Skip;

    void Start()
    {
        AudioManager.instance.Play("StartUp");
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
            AudioManager.instance.Stop("StartUp");
        }
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(3);
        Destroy(AnimationText);
        FakeBackground.SetActive(false);
        TextImage.SetActive(true);
        Skip.SetActive(false);
    }
}
