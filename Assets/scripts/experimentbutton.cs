using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class experimentbutton : MonoBehaviour
{

    // Start is called before the first frame update
    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(clicked);
    }
    //public void expbutton()
    //{
        //SceneManager.LoadScene("scene3");
       // Debug.Log("scene changed");
    //}

    private void clicked()
    {
        Debug.Log("back button pressed");
        //SceneManager.LoadScene("scene3");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Debug.Log("scene changed");
    }


}
