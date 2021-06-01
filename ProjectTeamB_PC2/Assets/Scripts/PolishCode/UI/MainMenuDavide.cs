using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuDavide : MonoBehaviour
{
    public Animator cameraSuper;

    public void MenuPrincipale()
    {
        cameraSuper.SetInteger("Page", 0);
    }

    public void LevelSelection()
    {
        cameraSuper.SetInteger("Page", 1);
    }

    public void Opzioni()
    {
        cameraSuper.SetInteger("Page", 2);
    }

    public void OpzioniControlli()
    {
        cameraSuper.SetInteger("Page", 3);
    }

    public void OpzioniVideo()
    {
        cameraSuper.SetInteger("Page", 4);
    }

    public void Tastiera()
    {
        cameraSuper.SetInteger("Page", 5);
    }

    public void Controller()
    {
        cameraSuper.SetInteger("Page", 6);
    }

    public void Credits()
    {
        cameraSuper.SetInteger("Page", 7);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
