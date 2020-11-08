using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;

public class NavigationManagerUI : MonoBehaviour
{
    #region Singleton
    private static NavigationManagerUI instance;
    public static NavigationManagerUI Instance
    {
        get
        {
            if (instance == null) { instance = FindObjectOfType(typeof(NavigationManagerUI)) as NavigationManagerUI; }
            return instance;
        }
        set { instance = value; }
    }
    #endregion


    public enum NAVIGATION_CONTENT { Recent, Favourites, BikeStations, BlackList, }

    // DROP MENU BTN
    [Header("DROP MENU BTNS")]
    [Space(5)]
    [SerializeField]
    public Button dropMenuBtn;
    private Image dropMenuBtnImage;
    private float dropImageTime = 1f;
    private Animator switch_image_drop_menuAnime;
    [Space(10)]
    [SerializeField]
    private Button recentDataBtn;
    [Space(5)]
    [SerializeField]
    private Button favouriteDataBtn; //home at this time
    [Space(5)]
    [SerializeField]
    private Button stationsDataBtn;
    [Space(5)]
    [SerializeField]
    private Button blackListDataBtn;

    [Space(5)]
    [Header("DROP DOWN/UP ANIME")]
    [SerializeField]
    private Animator dropDownAnime;


    private AddressManager addressManager;

    private bool isSearchMenuShown = false;
    
    private void Awake()
    {
        instance = this;
        addressManager = GetComponent<AddressManager>();
        dropMenuBtnImage = dropMenuBtn.GetComponentInChildren<Image>();
        switch_image_drop_menuAnime = dropMenuBtn.GetComponent<Animator>();
    }

    void Start()
    {
        StartingPointManager.Instance.GObtn.interactable = false;
    }

    public void DropMenuBtn_Behaviour()
    {
        if (isSearchMenuShown)
        {// dropUp
            isSearchMenuShown = false;
            PlayDropDownAnimation(isSearchMenuShown);
            RotateBtnImage(false);
            PopulateContentWithRecentAddresses(true);
        }
        else
        {// dropDown
            isSearchMenuShown = true;
            PlayDropDownAnimation(isSearchMenuShown);
            RotateBtnImage(true);
            //load recent first
            SET_NAVIGATION_CONTENT(NAVIGATION_CONTENT.Recent);
        }
    }

    private void SET_NAVIGATION_CONTENT(NAVIGATION_CONTENT type)
    {
        switch (type)
        {
            case NAVIGATION_CONTENT.Recent:
                //clear
                addressManager.DestroyAllContentChildren();
                //update
                PopulateContentWithRecentAddresses();
                //show that recent is presented hmm -> lower alpha on others
                FocusOnContentByTypeSelected(NAVIGATION_CONTENT.Recent);
                break;
            case NAVIGATION_CONTENT.Favourites:
                //clear
                addressManager.DestroyAllContentChildren();
                //update
                PopulateContentWithFavouriteAddresses();
                //show that recent is presented hmm -> lower alpha on others
                FocusOnContentByTypeSelected(NAVIGATION_CONTENT.Favourites);
                break;
            case NAVIGATION_CONTENT.BikeStations:
                //clear
                addressManager.DestroyAllContentChildren();
                //update
                PopulateContentWithStationAddresses();
                //show that recent is presented hmm -> lower alpha on others
                FocusOnContentByTypeSelected(NAVIGATION_CONTENT.BikeStations);
                break;
            case NAVIGATION_CONTENT.BlackList:
                //clear
                addressManager.DestroyAllContentChildren();
                //update
                PopulateContentWithBlackListAddresses();
                //show that recent is presented hmm -> lower alpha on others
                FocusOnContentByTypeSelected(NAVIGATION_CONTENT.BlackList);
                break;
        }
    }

    private void FocusOnContentByTypeSelected(NAVIGATION_CONTENT type)
    {
        switch (type)
        {
            case NAVIGATION_CONTENT.Recent:
                Outline recent = recentDataBtn.GetComponent<Outline>();
                recent.effectColor = new Color(recent.effectColor.r, recent.effectColor.g, recent.effectColor.b, 1);

                // lower alpha TO:DO => smooth transition
                Outline favourite = favouriteDataBtn.GetComponent<Outline>();
                favourite.effectColor = new Color(favourite.effectColor.r, favourite.effectColor.g, favourite.effectColor.b, .2f);
                Outline stations = stationsDataBtn.GetComponent<Outline>();
                stations.effectColor = new Color(stations.effectColor.r, stations.effectColor.g, stations.effectColor.b, .2f);
                Outline blackList = blackListDataBtn.GetComponent<Outline>();
                blackList.effectColor = new Color(blackList.effectColor.r, blackList.effectColor.g, blackList.effectColor.b, .2f);
                break;
            case NAVIGATION_CONTENT.Favourites:
                Outline favourite0 = favouriteDataBtn.GetComponent<Outline>();
                favourite0.effectColor = new Color(favourite0.effectColor.r, favourite0.effectColor.g, favourite0.effectColor.b, 1);

                // lower alpha TO:DO => smooth transition
                Outline recent0 = recentDataBtn.GetComponent<Outline>();
                recent0.effectColor = new Color(recent0.effectColor.r, recent0.effectColor.g, recent0.effectColor.b, .2f);
                Outline stations0 = stationsDataBtn.GetComponent<Outline>();
                stations0.effectColor = new Color(stations0.effectColor.r, stations0.effectColor.g, stations0.effectColor.b, .2f);
                Outline blackList0 = blackListDataBtn.GetComponent<Outline>();
                blackList0.effectColor = new Color(blackList0.effectColor.r, blackList0.effectColor.g, blackList0.effectColor.b, .2f);
                break;

            case NAVIGATION_CONTENT.BikeStations:
                Outline stations00 = stationsDataBtn.GetComponent<Outline>();
                stations00.effectColor = new Color(stations00.effectColor.r, stations00.effectColor.g, stations00.effectColor.b, 1);

                // lower alpha TO:DO => smooth transition
                Outline recent00 = recentDataBtn.GetComponent<Outline>();
                recent00.effectColor = new Color(recent00.effectColor.r, recent00.effectColor.g, recent00.effectColor.b, .2f);
                Outline favourite00 = favouriteDataBtn.GetComponent<Outline>();
                favourite00.effectColor = new Color(favourite00.effectColor.r, favourite00.effectColor.g, favourite00.effectColor.b, .2f);
                Outline blackList00 = blackListDataBtn.GetComponent<Outline>();
                blackList00.effectColor = new Color(blackList00.effectColor.r, blackList00.effectColor.g, blackList00.effectColor.b, .2f);
                break;

            case NAVIGATION_CONTENT.BlackList:
                Outline blackList000 = blackListDataBtn.GetComponent<Outline>();
                blackList000.effectColor = new Color(blackList000.effectColor.r, blackList000.effectColor.g, blackList000.effectColor.b, 1);

                // lower alpha TO:DO => smooth transition
                Outline recent000 = recentDataBtn.GetComponent<Outline>();
                recent000.effectColor = new Color(recent000.effectColor.r, recent000.effectColor.g, recent000.effectColor.b, .2f);
                Outline favourite000 = favouriteDataBtn.GetComponent<Outline>();
                favourite000.effectColor = new Color(favourite000.effectColor.r, favourite000.effectColor.g, favourite000.effectColor.b, .2f);
                Outline stations000 = stationsDataBtn.GetComponent<Outline>();
                stations000.effectColor = new Color(stations000.effectColor.r, stations000.effectColor.g, stations000.effectColor.b, .2f);
                break;

            default:
                print("No type defined for content :(");
                break;
        }
    }

    #region NAVIGATION BUTTONS

    //TO:DO => Make functions for specific content
    public void RecentBtn_Behaviour()
    {
        SET_NAVIGATION_CONTENT(NAVIGATION_CONTENT.Recent);
    }

    public void FavouriteBtn_Behaviour()
    {
        SET_NAVIGATION_CONTENT(NAVIGATION_CONTENT.Favourites);
    }

    public void StationsBtn_Behaviour()
    {
        SET_NAVIGATION_CONTENT(NAVIGATION_CONTENT.BikeStations);
    }

    public void BlackListBtn_Behaviour()
    {
        SET_NAVIGATION_CONTENT(NAVIGATION_CONTENT.BlackList);
    }
    #endregion

    private void PlayDropDownAnimation(bool drop_down)
    {
        dropDownAnime.SetBool(Consts.Anime_Bool_DropDown, drop_down);
    }

    #region POPULATE CONTENT - NAVIGATION
    private void PopulateContentWithRecentAddresses()
    {
        bool hasStartPoint = !StartingPointManager.Instance.hasStartPointSelected;
        StartCoroutine(addressManager.LoadRecentAddressItems(hasStartPoint));
    }
    private void PopulateContentWithRecentAddresses(bool clear)
    {    //overload
        if (clear)
        {
            addressManager.DestroyAllContentChildren();
            return;
        }
        PopulateContentWithRecentAddresses();
    }

    private void PopulateContentWithFavouriteAddresses()
    {
        bool hasStartPoint = !StartingPointManager.Instance.hasStartPointSelected;
        StartCoroutine(addressManager.LoadFavouriteAddressItems(hasStartPoint));
    }
    private void PopulateContentWithFavouriteAddresses(bool clear)
    {    //overload
        if (clear)
        {
            addressManager.DestroyAllContentChildren();
            return;
        }
        PopulateContentWithFavouriteAddresses();
    }

    private void PopulateContentWithStationAddresses()
    {
        bool hasStartPoint = !StartingPointManager.Instance.hasStartPointSelected;
        StartCoroutine(addressManager.LoadStationAddressItems(hasStartPoint));
    }
    private void PopulateContentWithStationAddresses(bool clear)
    {    //overload
        if (clear)
        {
            addressManager.DestroyAllContentChildren();
            return;
        }
        PopulateContentWithStationAddresses();
    }

    private void PopulateContentWithBlackListAddresses()
    {
        bool hasStartPoint = !StartingPointManager.Instance.hasStartPointSelected;
        StartCoroutine(addressManager.LoadBlackListAddressItems(hasStartPoint));
    }
    private void PopulateContentWithBlackListAddresses(bool clear)
    {    //overload
        if (clear)
        {
            addressManager.DestroyAllContentChildren();
            return;
        }
        PopulateContentWithBlackListAddresses();
    }
#endregion

    private void RotateBtnImage(bool downwards)
    {
        //best
        switch_image_drop_menuAnime.SetBool(Consts.Anime_Bool_SwitchDropDownImage, downwards);

        //2nd: 

        //Quaternion from = dropMenuBtnImage.transform.rotation;
        //Quaternion to = downwards ? new Quaternion(0f, 0f, 0f, 0f) : new Quaternion(180f, 0f, 0f, 0f);
        //Debug.Log(from + "  " + to);
        //dropMenuBtnImage.transform.rotation = Quaternion.Slerp(from, to, dropImageTime);

        //1st:

        //if (downwards)
        //{
        //    // default rotation - points down
        //    Image pointer_img = dropMenuBtn.GetComponentInChildren<Image>();
        //    Quaternion from = pointer_img.transform.rotation;
        //    Quaternion to = new Quaternion(0f,0f,0f,0f);
        //    float time = 1f;
        //    pointer_img.transform.rotation = Quaternion.Slerp(from, to, time);
        //}
        //else
        //{
        //    // default rotation - points up
        //    Image pointer_img = dropMenuBtn.GetComponentInChildren<Image>();
        //    Quaternion from = pointer_img.transform.rotation;
        //    Quaternion to = new Quaternion(180f, 0f, 0f, 0f);
        //    float time = 1f;
        //    pointer_img.transform.rotation = Quaternion.Slerp(from, to, time);
        //}
    }

    

}
