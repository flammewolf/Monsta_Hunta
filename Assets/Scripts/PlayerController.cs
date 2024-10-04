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
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        FollowPlayerMouse();
    }

    private void Move()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        float verticalMove = verticalInput * speed * Time.deltaTime;
        float horizontalMove = horizontalInput * speed * Time.deltaTime;

        Vector3 direction = new Vector3(horizontalMove, 0, verticalMove);

        transform.position += direction;
    }

    private void FollowPlayerMouse()
    {
        // Récupère les mouvements de la souris
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Applique la rotation verticale (axe Y) pour la caméra (regard vers le haut ou bas)
        xRotation += mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limite le mouvement pour éviter que la caméra fasse des tours complets

        // Applique la rotation à la caméra
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Applique la rotation horizontale (axe X) pour le corps du joueur (regard gauche ou droite)
        transform.Rotate(Vector3.up * mouseY);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);

        transform.Rotate(Vector3.right * mouseX);


    }
}
