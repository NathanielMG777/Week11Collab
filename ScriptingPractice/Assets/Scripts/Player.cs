using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    //1. access level: public or private
    //2. type: int (ex: 2, 74, 143), float (ex: 3.4, 3.756) 
    //3. name (1) start with lowercase (2) if it is multiple words, then the other words start with upper case (camelCase)
    //4. (optional): Give it an initial value

    private float horizontalInput;
    private float verticalInput;
    public float speed = 4f;
    public int lives = 3;

    public GameObject bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 15f;
        lives = 3;
        //transform.position = new Vector3(Random.Range(0,9), Random.Range(0, 9), Random.Range(0, 9));
    }


    // Update is called once per frame
    void Update()
    {
        Moving();
        Shooting();

    }

    void Moving()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);

        //if my x position is bigger than 11.5f I am outside the screen from the right
        if (transform.position.x > 9.5f || transform.position.x <= -9.5f)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        if (transform.position.y > -0.7f)
        {
            transform.position = new Vector3(transform.position.x, -0.7f, 0);
        }

        if (transform.position.y <= -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, 0);
        }
    }

    void Shooting()
    {
        //if SPACE key is pressed create a bullet; what is a bullet?
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //create a bullet object at my position with my rotation
            Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
