using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPoint : MonoBehaviour
{
    public void SELECTED_ADDRESS_EVENT_HANDLER()
    {
        // Close ViewPort
        CloseSearchPanel();
        // bg_panel alpha to 0
        DisplayMap();
        // get location
        string location = transform.name;
        // search for location in ljubljana gameobject
        Transform selectedStartPoint = StartingPointManager.Instance.SELECTED_LOCATION_3D(location);
        // move on top of this position with camera
        Transform initial_point = StartingPointManager.Instance.InitialPoint;
        initial_point.position = selectedStartPoint.position;
        // activate sprite for selected location
        selectedStartPoint.GetComponentInChildren<SpriteRenderer>().enabled = true;
        // enable GO button
        StartingPointManager.Instance.GObtn.interactable = true;
    }

    private void CloseSearchPanel()
    {
        NavigationManagerUI.Instance.DropMenuBtn_Behaviour();
    }

    private void DisplayMap()
    {
        StartingPointManager.Instance.mainPanelImageBackground.color
           = Color.Lerp(StartingPointManager.Instance.mainPanelImageBackground.color,
           new Color(0f, 0f, 0f, 0f), 2f);
    }
}
