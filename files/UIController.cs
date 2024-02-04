using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UlController : MonoBehaviour
{ 
    public GameObject SettingPanel;
    public GameObject PanelExit;
    private AudioSource _AudioSource;

    private void Start() 
    {
     _AudioSource = this.GetComponent<AudioSource>();   
    }
    public void Startbtn()
    {
        SceneManager. LoadScene (0) ;
    } 
    public void Settingbtn()
    {
        SettingPanel.SetActive(true) ;
        PanelExit.SetActive(true);
    }   
    public void Exitsettingbent() 
    {
        SettingPanel.SetActive (false); 
        PanelExit.SetActive (false);
    }
    public void Audiobtn()
    {
        _AudioSource.Play();
    }


}