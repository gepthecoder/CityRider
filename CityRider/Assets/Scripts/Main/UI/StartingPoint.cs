using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

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
        // set color of the marked sprite renderer
        //// enable GO button -> in EndPoint
        //StartingPointManager.Instance.GObtn.interactable = true;
        StartingPointManager.Instance.SET_SEARCH_FIELD_TEXT(Consts.Input_Field_Search_Text_End);
        StartingPointManager.Instance.hasStartPointSelected = true;
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
