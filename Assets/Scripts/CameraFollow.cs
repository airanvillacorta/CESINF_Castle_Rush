using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;
    // Use this for initialization
    void Start()
    {

        //	player=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;
        /*if(player.transform.position.x <= 0.8695042 && player.transform.position.x >= -0.8695042 )  
		{*/
        posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);

        //}


        /*if(player.transform.position.y <= 3.353147 && player.transform.position.y >= -3.353147)  
		{*/
        posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
        //}
        // posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y,ref velocity.y , smoothTimeY);
        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
