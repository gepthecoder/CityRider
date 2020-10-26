using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class StartingPointManager : MonoBehaviour
{
    #region Singleton
    private static StartingPointManager instance;
    public static StartingPointManager Instance
    {
        get
        {
            if (instance == null) { instance = FindObjectOfType(typeof(StartingPointManager)) as StartingPointManager; }
            return instance;
        }
        set { instance = value; }
    }
    #endregion

    public Image mainPanelImageBackground; //scrollable area
    public Transform InitialPoint;
    public Button GObtn;

    public CinemachineVirtualCamera vCam;

    private bool goToStartLocation;
    private CinemachineTransposer transposer;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        transposer = vCam.GetCinemachineComponent<CinemachineTransposer>();
    }

    void Update()
    {
        if (goToStartLocation)
        {
            //transposer.m_FollowOffset = Vector3.MoveTowards(transposer.m_FollowOffset, new Vector3(transposer.m_FollowOffset.x, 65f, transposer.m_FollowOffset.z), Time.deltaTime * .8f);
            transposer.m_FollowOffset = new Vector3(transposer.m_FollowOffset.x,
                Mathf.Lerp(transposer.m_FollowOffset.y, 65f, Time.deltaTime * 1f),
                transposer.m_FollowOffset.z
                );

            if(transposer.m_FollowOffset.y <= 65.2f)
            {
                goToStartLocation = false;
            }
        }
    }

    public Transform SELECTED_LOCATION_3D(string address)
    {
        GameObject locations_go = GameObject.FindGameObjectWithTag("Locations");
        Transform locations_t = locations_go.transform;
        for (int i = 0; i < locations_t.childCount; i++)
        {
            if(locations_t.GetChild(i).name == address)
            {
                // we found our location
                Transform selected_location = locations_t.GetChild(i);
                return selected_location;
            }
            else { continue; }
        }

        return null;
    }

    public void GO_START()
    { // TO:DO we need an end location first then activate GO.. but for the time being
        GObtn.interactable = false; // do something with the button (example: change it to Menu Btn idk)
        goToStartLocation = true;
        
    }
}
