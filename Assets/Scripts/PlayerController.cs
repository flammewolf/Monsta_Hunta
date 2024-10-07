using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    public float mouseSensitivity = 100f;
    public float xRotation = 0f;
    public float yRotation = 0f;

    private Rigidbody playerRb;

    private float verticalInput;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        float verticalMove = verticalInput * speed * Time.deltaTime;
        float horizontalMove = horizontalInput * speed * Time.deltaTime;

        Vector3 direction = new Vector3(horizontalMove, 0, verticalMove);

        playerRb.transform.Translate(direction, Space.Self); 
    }
}
