using UnityEngine;

public class player_collision : MonoBehaviour

{
    public player_movement Movement;

    void OnCollisionEnter(Collision collision_info)
    {
        if (collision_info.collider.tag == "Obstacle")
        {

            Movement.enabled = false;
            FindObjectOfType<GameManager>().end_game();
            
        }
        


    }
}
