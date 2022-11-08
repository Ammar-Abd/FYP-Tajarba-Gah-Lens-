using UnityEngine;

public class switchCam : MonoBehaviour
{
    public Camera main;
    public Camera secondary;
    private bool state = false;
    private void Start()
    {
        main.enabled = true;
        secondary.enabled = false;
    }
    // Update is called once per frame
    public void switchCameras() {
        if (state)
        {
            secondary.enabled = true;
            main.enabled = false;
            state = !state;
        }
        else
        {
            main.enabled = true;
            secondary.enabled = false;
            state = !state;
        }
    }

}
