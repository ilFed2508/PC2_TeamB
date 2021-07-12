using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    //public GameObject Sound, Controls, Video;
    //public bool isSound, isControls, isVideo;

    public AudioMixer AudioMixer;
    public Slider AudioSlider;
    public Slider SFXSlider;
    public Dropdown ResolutionDropdown;
    Resolution[] Resolutions;
    [Header("Mouse Sensibility")]
    public Slider MouseS;
    public float MouseSMin;
    public float MouseSMax;
    public float AugmentedMouseS;
    public float RangeMouseS;
    public float MouseSens;
    //[Header("Controller Sensibility")]
    //public Slider ControllerS;
    //public float ControllerSMin;
    //public float ControllerSMax;
    //public float AugmentedControllerS;
    //public float RangeControllerS;
    //public float ControllerSens;

    [Header("Resolution lists")]
    public List<int> widths = new List<int>();
    public List<int> heights = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        AudioSlider.value = PlayerPrefs.GetFloat("GeneraL");
        SFXSlider.value = PlayerPrefs.GetFloat("SFX");
        ResolutionDropdown.value = PlayerPrefs.GetInt("Resolution");

        AugmentedMouseS = MouseSMin - 0;
        RangeMouseS = MouseSMax - MouseSMin;
        MouseS.value = (PlayerPrefs.GetFloat("MouseS") - AugmentedMouseS) / RangeMouseS;
        PersistantObject.MouseS = MouseSens;
        // AugmentedControllerS = ControllerSMin - 0;
        // RangeControllerS = ControllerSMax - ControllerSMin;
        // ControllerS.value = (PlayerPrefs.GetFloat("ControllerS") - AugmentedControllerS) / RangeControllerS;
        // PersistantObject.ControllerS = ControllerSens;

        PersistantObject.ResolutionDropdownValue = ResolutionDropdown.value;

        Resolutions = Screen.resolutions;
        //ResolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int CurrentResolutionIndex = 0;
        for (int i = 0; i < Resolutions.Length; i++)
        {
            string option = Resolutions[i].width + "x" + Resolutions[i].height;
            options.Add(option);

            if (Resolutions[i].width == Screen.currentResolution.width && Resolutions[i].height == Screen.currentResolution.height)
            {
                CurrentResolutionIndex = i;
            }
        }
        //ResolutionDropdown.AddOptions(options);
        //ResolutionDropdown.value = CurrentResolutionIndex;
        //ResolutionDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("GeneraL", AudioSlider.value);
        PlayerPrefs.SetFloat("SFX", SFXSlider.value);
        SetMouseS();
        //SetControllerS();
        //CheckBools();
        PlayerPrefs.SetInt("Resolution", ResolutionDropdown.value);
        PersistantObject.ResolutionDropdownValue = ResolutionDropdown.value;
    }

    public void SetFullScreen(bool IsFullScreen)
    {
        Screen.fullScreen = IsFullScreen;
    }

    public void SetGeneral(float Gen)
    {
        AudioMixer.SetFloat("General", Gen);
    }

    public void SetMouseS()
    {
        MouseSens = (MouseS.value * RangeMouseS) + AugmentedMouseS;
        PlayerPrefs.SetFloat("MouseS", MouseSens);
        PersistantObject.MouseS = MouseSens;
    }
    public void SetControllerS()
    {
       //ControllerSens = (ControllerS.value * RangeControllerS) + AugmentedControllerS;
       //PlayerPrefs.SetFloat("ControllerS", ControllerSens);
       //PersistantObject.ControllerS = ControllerSens;
    }

    public void SetResolution(int ResolutionIndex)
    {
        int width = widths[ResolutionIndex];
        int height = heights[ResolutionIndex];
        Screen.SetResolution(width, height, Screen.fullScreen);
        //Resolution resolution = Resolutions[ResolutionIndex];
        //Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int QualityIndex)
    {
        //QualitySettings.SetQualityLevel(QualityIndex);
    }

    //public void CheckBools()
    //{
    //    if (isSound == true)
    //    {
    //        Sound.SetActive(true);
    //        Controls.SetActive(false);
    //        Video.SetActive(false);
    //    }
    //    else if (isControls == true)
    //    {
    //        Sound.SetActive(false);
    //        Controls.SetActive(true);
    //        Video.SetActive(false);
    //    }
    //    else if (isVideo == true)
    //    {
    //        Sound.SetActive(false);
    //        Controls.SetActive(false);
    //        Video.SetActive(true);
    //    }
    //}
}
