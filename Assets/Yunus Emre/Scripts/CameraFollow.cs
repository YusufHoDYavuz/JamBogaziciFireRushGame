using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                 // Takip edilecek hedef nesne
    public Transform lookObj;
    public float smoothSpeed = 0.125f;       // Takip hýzý (0.0 - 1.0 aralýðýnda)
    public Vector3 offset;                   // Kamera ve hedef arasýndaki mesafe

    private void FixedUpdate()
    {
        // Hedefin mevcut konumunu alýrken biraz gecikme saðlar
        Vector3 desiredPosition = target.position + offset;

        // Hedefe doðru smooth bir þekilde ilerlerken kamera konumunu yumuþatýr
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Kameranýn mevcut konumunu günceller
        transform.position = smoothedPosition;

        // Kameranýn hedef nesneyi takip etmesini saðlar
        transform.LookAt(lookObj);
    }
}
