using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveNameUI : MonoBehaviour
{
    public InputField NameImputField;
    public Button ButtonNameUI;
    public GameObject LoadingAnim;

    // Start is called before the first frame update
    void Start()
    {
        NameImputField = GetComponentInChildren<InputField>();
        if (NameImputField == null)
        {
            Debug.Log("Input field reference not found in SaveNameUI!");
        }
        else if(ButtonNameUI == null)
        {
            Debug.Log("Name Button reference not found in SaveNameUI!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(NameImputField.text.Length >= 5)
        {
            ButtonNameUI.gameObject.SetActive(true);

            if (Input.GetKey(KeyCode.Return))
            {
                AudioManager.instance.Play("SelectButton");
                LoadingAnim.SetActive(true);
            }
        }
        else
        {
            ButtonNameUI.gameObject.SetActive(false);
        }
    }

    public void SaveName()
    {
        string Name = NameImputField.text;

        if(PlayerPrefs.HasKey("PlayerName") == false)
        {
            PlayerPrefs.SetString("PlayerName", Name);
            PlayerPrefs.Save();
            Debug.Log("Ho salvato il nuovo nome prode Tester!");
        }
        else
        {
            if(PlayerPrefs.GetString("PlayerName") == Name)
            {
                Debug.Log("Hai gia inserito questo nome!");
            }
            else
            {
                PlayerPrefs.SetString("PlayerName", Name);
                PlayerPrefs.Save();
                Debug.Log("Ho salvato il nuovo nome prode Tester!");
            }
        }

        LoadingAnim.SetActive(true);
        //SceneManager.LoadScene("3DMenuTestP");
    }
}
