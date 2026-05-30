
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        Printerist("fml pls");
    }


    // Update is called once per frame
    void Update()
    {

    }

   void Printerist(string expectedstring)
    {
       
        string receivedstring = expectedstring;

        
        Debug.Log(receivedstring);



      
        


    }

        







}
