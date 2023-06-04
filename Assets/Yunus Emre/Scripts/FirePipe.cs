using UnityEngine;

public class FirePipe : MonoBehaviour
{
    [Header("Water VFX")]
    public ParticleSystem water;
    public KeyCode pipeOpenClose;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private CapsuleCollider capsuleCollider;
    [SerializeField] private AudioSource waterSource;
    bool isPipeOpen;

    void Start()
    {
        isPipeOpen = false;
        waterSource.enabled = false;
        //waterMain = water.main;
    }
    private void Update()
    {
        if (Input.GetKeyDown(pipeOpenClose))
        {
            FirePipeOnClose();
        }

        RotateTurret();
    }

    private void RotateTurret()
    {
        float x = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        transform.Rotate(Vector3.up, x);
    }

    void FirePipeOnClose()
    {
        if (isPipeOpen) 
        {
            isPipeOpen = false;
            water.Stop(false);
            capsuleCollider.enabled = false;
            waterSource.enabled = false;

        }
        else
        {
            isPipeOpen = true;
            water.Play(false);
            capsuleCollider.enabled = true;
            waterSource.enabled = true;
        }
    }

    
}
