using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Handles creation of building prefabs.
 * On runtime, will create all buildings provided in the list.
 */

public class BuildingManager : MonoBehaviour
{
    //ADD ALL BUILDINGS INTENDED FOR GAMEPLAY IN THE BELOW LIST
    public List<BuildingData> buildings = new List<BuildingData>();

    //prefab of the building template and its parent in the scene
    public GameObject buildingPrefab;
    public GameObject buildingParent; //should be the TownScreen object.

    void Start()
    {
        //for each entry in the list, create an associated prefab with its data
        foreach (BuildingData data in buildings)
        {
            CreateBuilding(data);
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
