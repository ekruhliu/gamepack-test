using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRock : MonoBehaviour
{
    public GameObject rock;
    public GameObject slicedRock;
    public GameObject Player;

    public PublicParams Params;
    
    void Start()
    {
        slicedRock.SetActive(false);
        Player = GameObject.FindWithTag("Player");

    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag  == "Player"){
            Instantiate(slicedRock, rock.transform.position, Quaternion.identity);
            
            Destroy(rock);
            slicedRock.SetActive(true);
            Debug.Log("lel");
            if (Player.transform.localScale.x < Params.maxBallScale)
            {
                Player.transform.localScale = new Vector3(Player.transform.localScale.x + Params.ballScale,
                    Player.transform.localScale.y + Params.ballScale, Player.transform.localScale.z + Params.ballScale);
            }
            Player.GetComponent<PlayerController>().score += Params.pointsForBig;
        }
    }
}
