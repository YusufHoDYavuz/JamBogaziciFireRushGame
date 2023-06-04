using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateCable : MonoBehaviour
{
    [SerializeField] private GameObject partPrefab, parentObject;

    [SerializeField] private int length = 1;
    [SerializeField] private float partDistance = 0.21f;
    
    [SerializeField] private bool reset, spawn, snapFirst, snapLast;

    [Header("For Rope Follow Fireman")]
    [SerializeField] GameObject firemanHand;
    [SerializeField][Range(0, 1)] float follofSpeed;

    GameObject firstPart;
    bool canRopeFollow = false;


    void Update()
    {
        if (reset)
        {
            foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Part"))
            {
                Destroy(tmp);
            }

            reset = false;
        }

        if (spawn)
        {
            PartSpawn();

            spawn = false;
        }

        if (canRopeFollow)
        {
            FirstPartOfRope();
        }
    }

    public void PartSpawn()
    {
        int count = (int)(length / partDistance);

        for (int i = 0; i < count; i++)
        {
            GameObject tmp;

            tmp = Instantiate(partPrefab,
                new Vector3(transform.position.x, transform.position.y + partDistance * (i + 1), transform.position.z),
                Quaternion.identity, parentObject.transform);
            tmp.transform.eulerAngles = new Vector3(180, 0, 0);
            
            tmp.name = parentObject.transform.childCount.ToString();

            if (i == 0)
            {
                Destroy(tmp.GetComponent<CharacterJoint>());
                if (snapFirst)
                {
                    tmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }

                firstPart = tmp;
                canRopeFollow = true;
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform
                    .Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }
        }

        if (snapLast)
        {
            parentObject.transform.Find((parentObject.transform.childCount).ToString()).GetComponent<Rigidbody>()
                .constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    void FirstPartOfRope()
    {
        firstPart.transform.position = Vector3.Lerp(firstPart.transform.position, firemanHand.transform.position, follofSpeed);
    }
}
