using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                 // Takip edilecek hedef nesne
    public Transform lookObj;
    public float smoothSpeed = 0.125f;       // Takip h�z� (0.0 - 1.0 aral���nda)
    public Vector3 offset;                   // Kamera ve hedef aras�ndaki mesafe

    private void FixedUpdate()
    {
        // Hedefin mevcut konumunu al�rken biraz gecikme sa�lar
        Vector3 desiredPosition = target.position + offset;

        // Hedefe do�ru smooth bir �ekilde ilerlerken kamera konumunu yumu�at�r
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Kameran�n mevcut konumunu g�nceller
        transform.position = smoothedPosition;

        // Kameran�n hedef nesneyi takip etmesini sa�lar
        transform.LookAt(lookObj);
    }
}
