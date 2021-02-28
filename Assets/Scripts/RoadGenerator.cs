using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public GameObject RoadPrefab;
    private List<GameObject> roads = new List<GameObject>();
    public int maxRoadCount = 15;
    public PublicParams Params;
    void Start()
    {
        ResetLevel();
        StartLevel();
    }
    void StartLevel(){
        Params.currentPlaneSpeed = Params.maxPlaneSpeed;
    }
    void Update()
    {
        if (Params.currentPlaneSpeed == 0) return;

        foreach (GameObject road in roads){
            road.transform.position -= new Vector3(0,0, Params.currentPlaneSpeed * Time.deltaTime);
        }

        if(roads[0].transform.position.z < -29.68f){
            Destroy(roads[0]);
            roads.RemoveAt(0);
            CreateNextRoad();
        }
    }

    private void CreateNextRoad()
    {
        Vector3 pos = Vector3.zero;
        if (roads.Count > 0) {
            pos = roads[roads.Count - 1].transform.position + new Vector3(0,0,29.68f);
        }
        GameObject go = Instantiate(RoadPrefab, pos, Quaternion.identity);
        go.transform.SetParent(transform);
        roads.Add(go);
    }

    public void ResetLevel()
    {
        Params.currentPlaneSpeed = 0;
        while (roads.Count > 0){
            Destroy(roads[0]);
            roads.RemoveAt(0);
        }
        for(int i=0; i < maxRoadCount; i++){
            CreateNextRoad();
        }
    }
}
