using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{ 
    public GameObject SettingPanel;
    public GameObject PanelExit;
    public GameObject Slider;
    private AudioSource _AudioSource;

    

    private void Start() 
    {
     _AudioSource = this.GetComponent<AudioSource>();
     //Cursor.lockState = CursorLockMode.Locked;   
     
    }
    public void Startbtn()
    {
        SceneManager. LoadScene (1) ;
    } 
    public void Exit()
    {
        Application.Quit() ;}

       
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
    private void Update() 
    {
        _AudioSource.volume = Slider.GetComponent<Slider>().value;
        //Cursor.lockState = CursorLockMode.Locked;     
        
    }
    

}