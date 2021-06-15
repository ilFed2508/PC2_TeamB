using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActDeact_PowerUp : MonoBehaviour
{
    private PowerUpController MyPowerUp;
    private ScoreController MyScore;
    private MarketShopMenù Market;

    public GameObject SlideTXTon, SlideTXToff, MedKitTXTon, MedKitTXToff, SpeedTXTon, SpeedTXToff, SlowerTXTon, SlowerTXToff, KatanaTXTon, KatanaTXToff;


    void Start()
    {
        MyScore = FindObjectOfType<ScoreController>();
        MyPowerUp = FindObjectOfType<PowerUpController>();

        SlideTXTon.SetActive(false);
        SlideTXToff.SetActive(false);

        MedKitTXTon.SetActive(false);
        MedKitTXToff.SetActive(false);

        SpeedTXTon.SetActive(false);
        SpeedTXToff.SetActive(false);

        SlowerTXTon.SetActive(false);
        SlowerTXToff.SetActive(false);

        KatanaTXTon.SetActive(false);
        KatanaTXToff.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (MyScore.CostScore < MyPowerUp.SlideCost)
        {
            SlideTXTon.SetActive(false);
            SlideTXToff.SetActive(true);
        }

        else
        {
            SlideTXTon.SetActive(true);
            SlideTXToff.SetActive(false);
        }

        if (MyScore.CostScore < MyPowerUp.MedikitCost)
        {
            MedKitTXTon.SetActive(false);
            MedKitTXToff.SetActive(true);
        }

        else
        {
            MedKitTXTon.SetActive(true);
            MedKitTXToff.SetActive(false);
        }

        if (MyScore.CostScore < MyPowerUp.SpeedCost)
        {
            SpeedTXTon.SetActive(false);
            SpeedTXToff.SetActive(true);
        }

        else
        {
            SpeedTXTon.SetActive(true);
            SpeedTXToff.SetActive(false);
        }

        if (MyScore.CostScore < MyPowerUp.SlowerCost)
        {
            SlowerTXTon.SetActive(false);
            SlowerTXToff.SetActive(true);
        }

        else
        {
            SlowerTXTon.SetActive(true);
            SlowerTXToff.SetActive(false);
        }

        if (MyScore.CostScore < MyPowerUp.KatanaCost)
        {
            KatanaTXTon.SetActive(false);
            KatanaTXToff.SetActive(true);
        }

        else
        {
            KatanaTXTon.SetActive(true);
            KatanaTXToff.SetActive(false);
        }
    }
}
