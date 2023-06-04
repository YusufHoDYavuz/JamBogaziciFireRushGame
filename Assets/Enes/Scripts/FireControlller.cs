using UnityEngine;
using UnityEngine.UI;

public class FireControlller : MonoBehaviour
{
    public bool isFire;

    [SerializeField] private float fireIncreasePerTime;
    [SerializeField] private float fireIncreaseRate;
    [SerializeField] private float fireDecreasePerTime;
    [SerializeField] private float fireDecreaseRate;   

    [SerializeField] private Image fireBar;
    [SerializeField] private GameObject fireEffectGameObject;
    [SerializeField] private ParticleSystem fireEffectParticleSystem;

    private float fireTimer;
    private float fireBarPreviousValue;
 
    private bool isWater;

    private void Awake()
    {
        fireBarPreviousValue = fireBar.fillAmount;
    }

    private void OnEnable()
    {
        fireEffectParticleSystem.Play();
    }

    private void OnDisable()
    {
        fireEffectParticleSystem.Stop();
    }

    private void Update()
    {
        if (isFire)
        {
            SetFire();
        }
    }
    
    private void SetFire()
    {
        if (isWater)
            SetFireBar(-1, fireDecreaseRate);
        else
            SetFireBar(1, fireIncreaseRate);
    }

    private void SetFireBar(int sign, float rate)
    {
        if (fireTimer < fireIncreasePerTime)
        {
            fireBar.fillAmount = Mathf.Lerp(fireBarPreviousValue, fireBarPreviousValue + sign * rate, fireTimer / fireIncreasePerTime);
            fireTimer += Time.deltaTime;
        }
        else
        {
            fireBarPreviousValue = fireBar.fillAmount;
            fireTimer = 0f;
        }

        if (isWater && fireBar.fillAmount <= 0.01f)
        {
            Destroy(gameObject);
            FireHolder.Instance.DecreaseActvFire();
        }
        if (fireBar.fillAmount >= 0.95f)
        {
            //Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isWater = true;
            fireBarPreviousValue = fireBar.fillAmount;
            fireTimer = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isWater = false;
            fireBarPreviousValue = fireBar.fillAmount;
            fireTimer = 0f;
        }
    }
}
