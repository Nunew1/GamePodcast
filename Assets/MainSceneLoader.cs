using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Tutorial()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Gameplay()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Quit()
    {
        Quit();
    }

    public void MM()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
