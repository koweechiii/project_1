
using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public GameObject player;
    public int number;
   public float playerspeed = 5f;


    private int number67;
    int number69;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       

    }


    // Update is called once per frame
    void Update()
    {
      
        Move();





    }
    /// <summary>
    /// movingtheplayer
    /// </summary>

    void Move()
    {
        //Debug.Log("movecalled");
        Vector3 newPosition = new Vector3();
        if (Keyboard.current[Key.W].isPressed)
        {
            //Debug.Log("up");
            newPosition.y = newPosition.y + 1;


        }
        if (Keyboard.current[Key.A].isPressed)
        {
            //Debug.Log("left");
            newPosition.x = newPosition.x - 1;
        }
        if (Keyboard.current[Key.S].isPressed)
        {
            //Debug.Log("down");
            newPosition.y = newPosition.y - 1;
        }
        if (Keyboard.current[Key.D].isPressed)
        {
            //Debug.Log("right");
         
            
            
            newPosition.x = newPosition.x + 1;
        }


        newPosition = newPosition.normalized;
        player.transform.position += newPosition * playerspeed * Time.deltaTime; 
        
    }














}