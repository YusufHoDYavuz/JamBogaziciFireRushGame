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




    public List<Transform> fires = new();             //t�m yang�nlar�n tutuldur�u liste

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

    public void AddFire(Transform fireTransform)        //rasgele yang�n olu�unca bunu �a��racaz ve yang�n listeye dahil olacak - yak�nl�k hesaplamas� i�in
    {
        fires.Add(fireTransform);
    }

    public void RomoveFire(Transform fireTransform)     //rasgele yang�n s�nd�r�l�nce bunu �a��racaz ve yang�n listeden ��kart�lacak - bo�una yer kaplamas�na gerek yok
    {
        fires.Remove(fireTransform);
    }
}
