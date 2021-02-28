using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flue : MonoBehaviour
{
    public GameObject Player;

    public PublicParams Params;

    private Transform child;
    void Start() {
        Player = GameObject.FindWithTag("Player");
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag  == "Player")
        {
            if (gameObject.GetComponent<MeshCollider>()) {
                gameObject.GetComponent<MeshCollider>().enabled = false;
            }
            else if (gameObject.GetComponent<CapsuleCollider>()) {
                gameObject.GetComponent<CapsuleCollider>().enabled = false;
            }
            else if (gameObject.GetComponent<BoxCollider>()) {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.transform.parent.GetComponent<Animator>().enabled = false;
                gameObject.transform.parent.SetParent(other.gameObject.transform);
            }
            else if (gameObject.GetComponent<SphereCollider>()) {
                gameObject.GetComponent<SphereCollider>().enabled = false;
            }
            gameObject.transform.SetParent(other.gameObject.transform);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Player.GetComponent<PlayerController>().score += Params.pointsForSmall;
        }
    }
}
