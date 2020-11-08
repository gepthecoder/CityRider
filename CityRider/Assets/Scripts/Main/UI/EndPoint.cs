using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public void SELECTED_ADDRESS_EVENT_HANDLER()
    {
        // Close ViewPort
        CloseSearchPanel();
        // get location
        string location = transform.name;
        // search for location in ljubljana gameobject
        Transform selectedEndPoint = StartingPointManager.Instance.SELECTED_LOCATION_3D(location);
        // move on top of this position with camera
        Transform initial_point = StartingPointManager.Instance.InitialPoint;
        initial_point.position = selectedEndPoint.position;
        // activate sprite for selected location
        selectedEndPoint.GetComponentInChildren<SpriteRenderer>().enabled = true;
        // set color of the marked sprite renderer
        //// enable GO button -> in EndPoint
        StartingPointManager.Instance.hasEndPointSelected = true;
        // TO:DO -> calculate closest distance -> apply to road with texture -> adjust camera pos -> then enable GO
        //StartingPointManager.Instance.GObtn.interactable = true;
        // hide search
        HideSearchStuff();
        StartingPointManager.Instance.SET_SEARCH_FIELD_TEXT(Consts.Input_Field_Search_Text_Start);
        // activate reset/back button
        // reset starting points on go or now?
        StartingPointManager.Instance.hasStartPointSelected = false;
    }

    private void CloseSearchPanel()
    {
        NavigationManagerUI.Instance.DropMenuBtn_Behaviour();
    }

    private void HideSearchStuff()
    {
        NavigationManagerUI.Instance.dropMenuBtn.gameObject.SetActive(false);
        StartingPointManager.Instance.search_input_field.gameObject.SetActive(false);
    }
}
