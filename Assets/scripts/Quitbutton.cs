using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitbutton : MonoBehaviour
{
   public void Quitgame()
   {
        Application.Quit();
        Debug.Log("Quit");

   }
}
