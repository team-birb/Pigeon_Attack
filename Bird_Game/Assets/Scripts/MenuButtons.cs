using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
  public void PlayGame()
  {
      SceneManager.LoadScene(1);
  }

  public void QuitGame()
  {
      Application.Quit();
  }

  public void BackToMenu()
  {
      SceneManager.LoadScene(0);
  }
}
