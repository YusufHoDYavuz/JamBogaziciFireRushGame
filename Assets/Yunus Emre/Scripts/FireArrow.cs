using System.Collections.Generic;
using UnityEngine;

public class FireArrow : MonoBehaviour
{
    public static FireArrow ins;

    public Transform closestFire;
    public Transform firesHolder;
    public float contTime;

    float shortestDist;
    float contTimer;




    public List<Transform> fires = new();             //tüm yangýnlarýn tutuldurðu liste

    private void Start()
    {
        ins = this;

        for (int i = 0; i < firesHolder.childCount; ++i)
        {
            fires.Add(firesHolder.GetChild(i));
        }
    }
    private void FixedUpdate()
    {
        if (contTimer < 0)
        {
            contTimer = contTime;

            shortestDist = 100000;

            foreach (Transform t in fires)
            {
                float newDist = 100000-1;

                if (t) newDist = Vector3.SqrMagnitude(transform.position - t.position);

                if (shortestDist > newDist)
                {
                    shortestDist = newDist;
                    closestFire = t;
                }
            }
        }
        else
        {
            contTimer -= Time.fixedDeltaTime;
        }

        transform.LookAt(closestFire);
    }

    public void AddFire(Transform fireTransform)        //rasgele yangýn oluþunca bunu çaðýracaz ve yangýn listeye dahil olacak - yakýnlýk hesaplamasý için
    {
        fires.Add(fireTransform);
    }

    public void RomoveFire(Transform fireTransform)     //rasgele yangýn söndürülünce bunu çaðýracaz ve yangýn listeden çýkartýlacak - boþuna yer kaplamasýna gerek yok
    {
        fires.Remove(fireTransform);
    }
}
