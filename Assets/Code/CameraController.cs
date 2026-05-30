using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject camera;
    public Transform target;
    public Vector3 offset;
    public float smooth = 0.3f;
    Vector3 vel= Vector3.zero;  
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = camera.transform.position - target.position;


    }

    // Update is called once per frame
    void Update()
    {


        camera.transform.position = Vector3.SmoothDamp(camera.transform.position, target.position+offset,ref vel, smooth); 
    
    
    
    
    
    
    }
}




