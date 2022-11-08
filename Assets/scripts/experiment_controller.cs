using UnityEngine;

public class experiment_controller : MonoBehaviour
{
    private void Start(){
        Invoke("delayedStart", 1.0f);
    }
    void delayedStart(){
        Tajurbah_Gah.StepsLabelController.Instance.UpdateStep(0);
    }
    public static void steps_update(int step)
    {
        Tajurbah_Gah.StepsLabelController.Instance.UpdateStep(step-1,true);
        if (step < Tajurbah_Gah.StepsLabelController.Instance.GetStepCount())
        {   
            Tajurbah_Gah.StepsLabelController.Instance.UpdateStep(step); 
        }
    }

}
