using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private GameObject panelDifculty;
    private GameObject panelSound;
    private GameObject panelPause;


    // Start is called before the first frame update
    private void Awake()
    {
        panelDifculty.SetActive(false);
        panelSound.SetActive(false);
        panelPause.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void Exit()
    {
        Application.Quit();
    }
}
