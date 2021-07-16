using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesTrigger : MonoBehaviour
{
    private DetectedActDeact end, hud;
    private GameObject guns, hitContainer, ePickUp, pausePanel, deathPanel, HUD, crosshair;
   

    // Start is called before the first frame update
    void Start()
    {
        end = GameObject.Find("WIN").GetComponent<DetectedActDeact>();
        hud = GameObject.Find("HUD").GetComponent<DetectedActDeact>();
        guns = GameObject.Find("WeaponSlot");
        crosshair = GameObject.Find("Canvas Cross");
        hitContainer = GameObject.Find("HitContainer");
        ePickUp = GameObject.Find("E-Pickup");
        pausePanel = GameObject.Find("Main_PausePanel");
        deathPanel = GameObject.Find("DeathPanel");
        HUD = GameObject.Find("HUD");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //get player reference
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            //save life for the end of level 3 and add the relative score
            playerController.playerScore.AddValueScore((int)playerController.playerLife.PlayerCurrentHP * (3 * playerController.playerScore.GetActionValue(ScoreAction.EndLevelLifeGain)));
            //add the current points to the totalscore
            playerController.playerScore.AddTotalScore(playerController.playerScore.GetCurrentScore());
            if (playerController.playerScore.GetHighScore() < playerController.playerScore.GetTotalScore())
            {
                PlayerPrefs.SetInt("PlayerHighScore", playerController.playerScore.GetTotalScore());
                PlayerPrefs.Save();
                playerController.playerScore.AddHighScoreToLeaderboard();
            }
            Destroy(guns);
            Destroy(HUD);
            Destroy(pausePanel);
            Destroy(deathPanel);
            Destroy(hitContainer);
            Destroy(crosshair);
            end.thing.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            hud.thing.SetActive(false);
            //guns.SetActive(false);
            //hitContainer.SetActive(false);
            ePickUp.SetActive(false);
        }
    }
}
