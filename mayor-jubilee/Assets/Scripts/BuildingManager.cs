using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    public List<BuildingData> buildings = new List<BuildingData>();
    public GameObject buildingPrefab;
    public GameObject buildingParent;

    // Start is called before the first frame update
    void Start()
    {
        foreach (BuildingData data in buildings)
        {
            CreateBuilding(data);
            buildingParent = GameObject.Find("TownScreen");
        }
    }

    void CreateBuilding(BuildingData data)
    {
        //bring the gameobject into the space
        GameObject buildingObject = Instantiate(buildingPrefab);
        buildingObject.transform.SetParent(buildingParent.transform);

        //set data as needed within the prefab's script
        BuildingBehaviour building = buildingObject.GetComponent<BuildingBehaviour>();
        building.Initialize(data);
    }
}
