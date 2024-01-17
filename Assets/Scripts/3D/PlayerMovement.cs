using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController charController;
    [SerializeField] float speed = 5.0f, gravity = -7.0f, groundDistance = 0; 
    [SerializeField] Transform ground;
    [SerializeField] LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGroundedAndMove();
    }

    void CheckGroundedAndMove()
    {
        isGrounded = Physics.CheckSphere(ground.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1.5f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        Vector3 newPosition = charController.transform.position + move * speed * Time.deltaTime;
        if (IsWithinTerrainBounds(newPosition))
        {
            charController.Move(move * speed * Time.deltaTime);   
        }
        velocity.y += gravity * Time.deltaTime;
        charController.Move(velocity * Time.deltaTime);    
    }

    bool IsWithinTerrainBounds(Vector3 position)
    {
        Terrain terrain = ground.GetComponent<Terrain>();
        Vector3 terrainSize = terrain.terrainData.size;
        Vector3 terrainPos = terrain.transform.position;
        return (position.x >= terrainPos.x && position.x <= terrainSize.x + terrainPos.x && position.z >= terrainPos.z && position.z <= terrainSize.z + terrainPos.z);
    }
}
