using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void Switch(int index){
        SceneManager.LoadScene(index);
    }
    public void Switch(string name){
        SceneManager.LoadScene(name);
    }
    public void ExitApplication(){
        Application.Quit();
    }
}
