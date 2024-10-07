using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;  // Sensibilité de la souris
    public Transform playerBody;           // Référence au corps du joueur

    float xRotation = 0f;

    void Start()
    {
        // Verrouiller le curseur au centre de l'écran
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Récupère les mouvements de la souris
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Applique la rotation verticale (axe Y) pour la caméra (regard vers le haut ou bas)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Limite le mouvement pour éviter que la caméra fasse des tours complets

        // Applique la rotation à la caméra
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Applique la rotation horizontale (axe X) pour le corps du joueur (regard gauche ou droite)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
