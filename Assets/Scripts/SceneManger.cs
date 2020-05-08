using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManger : MonoBehaviour
{


  public void openBoids()
    {

        SceneManager.LoadScene("FlockingBoids", LoadSceneMode.Single);
    }

   public  void openAgents()
    {

        SceneManager.LoadScene("NavMesh", LoadSceneMode.Single);
    }

    public void OpneMainMenu()
    {

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }


}
