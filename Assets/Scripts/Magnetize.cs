using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetize : MonoBehaviour
{
    public GameObject slicedRock;
    void Update() {
        slicedRock = GameObject.FindWithTag("SlicedRock");
    }
    void FixedUpdate()
    {
        for(int i = 0; i < slicedRock.transform.childCount; i++){
            Transform child = slicedRock.transform.GetChild(i);
            child.gameObject.GetComponent<Rigidbody>().AddForce((transform.position - child.transform.position).normalized * 50, ForceMode.Force);
            child.gameObject.GetComponent<MeshCollider>().enabled = false;
        }
    }
}
