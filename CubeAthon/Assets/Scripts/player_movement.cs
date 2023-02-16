using UnityEngine;

public class player_movement : MonoBehaviour
{
    public Rigidbody rigid_body;
    public float forward_movement = 2000f;
    public float sideways_movement = 500f;
    void Start()
    {
        rigid_body = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rigid_body.AddForce(0, 0, forward_movement*Time.deltaTime);
  

        if (Input.GetKey("d"))
        {
            rigid_body.AddForce(sideways_movement * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
           
        }
        if (Input.GetKey("a"))
        {
            rigid_body.AddForce(-sideways_movement * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (rigid_body.position.y < -1f )
        {
            FindObjectOfType<GameManager>().end_game();
        }
    }
}
