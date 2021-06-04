using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private MarketShopMenù SlideButton;
    [HideInInspector]
    public GameObject SlideButtonCopy;

    private void Awake()
    {
        SlideButton = FindObjectOfType<MarketShopMenù>();
        SlideButtonCopy = SlideButton.SlideButton;
    }
}
