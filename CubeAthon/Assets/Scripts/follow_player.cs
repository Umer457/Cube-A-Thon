using UnityEngine;

public class follow_player : MonoBehaviour
{
    public Transform player_cube;
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        transform.position = player_cube.position + offset;
    }
}
