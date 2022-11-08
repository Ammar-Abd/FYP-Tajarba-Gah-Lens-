using UnityEngine;

public class Secodary_camera_controller : MonoBehaviour
{
    
    Transform bench_transform;
    Transform camera_transform;
    readonly string search_tag= "bench";
    private void OnEnable()
    {
        GameObject bench = GameObject.FindGameObjectWithTag(search_tag);
        if (bench == null) return;
        bench_transform = bench.transform;
        camera_transform = this.transform;
        camera_transform.position = new Vector3(bench_transform.position.x - (float)0.4, camera_transform.position.y, camera_transform.position.z);
    }
}
