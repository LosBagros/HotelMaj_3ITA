using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    /*
     
    TODO: Cannot call CreateBuildingPlaceholder from button
     
     */
    Camera mainCamera;

    [SerializeField]
    private GameObject buildingPlaceHolder;

    private GameObject currentPlaceholder;

    public void CreateBuildingPlaceholder(Building buildingPrefab)
    {
        if (currentPlaceholder != null)
        {
            Destroy(currentPlaceholder);
        }
        currentPlaceholder = Instantiate(buildingPrefab.gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlaceholder != null) {
            currentPlaceholder.transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            currentPlaceholder.transform.position = new Vector3(currentPlaceholder.transform.position.x, currentPlaceholder.transform.position.y, 0);
            if(Input.GetMouseButtonDown(0))
            {
                CommandQueue.Instance.EnqueueCommand(new BuildCommand(currentPlaceholder.GetComponent<Building>(), currentPlaceholder.transform.position));
                currentPlaceholder = null;
            }
        }
    }
}