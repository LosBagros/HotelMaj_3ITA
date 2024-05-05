using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    Camera mainCamera;

    [SerializeField]
    private GameObject buildingPlaceHolder;

    private GameObject currentPlaceholder;

    [SerializeField]
    private List<GameObject> allowedAreas;

    [SerializeField]
    private Money money;

    private int buildingPrice;
    public void CreateBuildingPlaceholder(Building buildingPrefab, int price)
    {
        if(!money.CanAfford(price))
        {
            return;
        }
        buildingPrice = price;
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
            if (Input.GetKeyDown("escape"))
            {
                Debug.Log("Destroying placeholder");
                Destroy(currentPlaceholder);
                currentPlaceholder = null;
            }
            if(Input.GetMouseButtonDown(0) && CheckPlaceholderPosition(currentPlaceholder.transform.position))
            {
                CommandQueue.Instance.EnqueueCommand(new BuildCommand(currentPlaceholder.GetComponent<Building>(), currentPlaceholder.transform.position));
                currentPlaceholder = null;
                money.SpendMoney(buildingPrice);
            }
        }
    }
    bool CheckPlaceholderPosition(Vector2 position)
    {
        foreach (GameObject area in allowedAreas)
        {
            PolygonCollider2D polygonCollider = area.GetComponent<PolygonCollider2D>();
            if (polygonCollider != null && polygonCollider.OverlapPoint(position))
            {
                return true;
            }
        }
        return false;
    }

}