using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject pipePrefab, parentObj;

    [SerializeField]
    [Range(1, 1000)]
    int length;

    [SerializeField]
    float partDist = 0.21f;

    [SerializeField]
    bool reset, spawn, snapFirst, snapLast;

    void Update()
    {
        if (reset)
        {
            foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Pipe"))
            {
                Destroy(tmp);
            }

            reset = false;
        }

        if (spawn)
        {
            Spawn();

            spawn = false;
        }
    }

    public void Spawn()
    {
        int count = (int)(length / partDist);

        for (int i = 0; i < count; i++)
        {
            GameObject tmp;
            Vector3 pos = new (transform.position.x, transform.position.y + partDist * (i + 1), transform.position.z);

            tmp = Instantiate(pipePrefab, pos, Quaternion.identity, parentObj.transform);
            tmp.transform.eulerAngles = new(180, 0, 0);   

            tmp.name = parentObj.transform.childCount.ToString();

            if (i == 0)
            {
                Destroy(tmp.GetComponent<CharacterJoint>());
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = parentObj.transform.Find((parentObj.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }
        }
    }
}