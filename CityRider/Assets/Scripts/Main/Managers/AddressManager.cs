using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LocalAddresses;
using System.Globalization;
using System.Linq;
using Common;

public class AddressManager : MonoBehaviour
{
    #region Singleton
    private static AddressManager instance;
    public static AddressManager Instance
    {
        get
        {
            if (instance == null) { instance = FindObjectOfType(typeof(AddressManager)) as AddressManager; }
            return instance;
        }
        set { instance = value; }
    }
    #endregion

    string[,] TypeAddressCityCountry;
    public GameObject location_template;
    public GameObject location_content;
    public Text loadStatusText;

    private int x = 0; // index for recent content
    private int y = 0; // index for favourite content
    private int z = 0; // index for stations content
    private int q = 0; // index for black list content

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        TypeAddressCityCountry = Addresses.getTypeAddressCityCountries();
        loadStatusText.text = "0%";
    }

    public IEnumerator LoadRecentAddressItems()
    {
        while (x < Consts.defaultDisplayNum)
        {
            // get hard coded data -> TO:DO => Get data from Google API => how ? => (Get Address -> Convert -> To Coordinate -> Get satalite data location on map hmm?
            Debug.Log("Type Address: " + TypeAddressCityCountry.Length);
            string type = TypeAddressCityCountry[x, 0];
            string address = TypeAddressCityCountry[x, 1];
            string city = TypeAddressCityCountry[x, 2];
            string country = TypeAddressCityCountry[x, 3]; // maybe for flag or something

            Sprite type_icon = Addresses.getIcon(type);
            if (type_icon == null) { print("Type Icon Default"); type_icon = Resources.Load("Main/UI/AddressTypes/unknown", typeof(Sprite)) as Sprite; }

            print("<color=green>Loading: </color>" + type + ", " + address + ", " + city + ", " + country);
            // create new item and set data
            GameObject newLocationItem = Instantiate(location_template);
            newLocationItem.transform.Find("location_sprite").GetComponent<Image>().sprite = type_icon;
            newLocationItem.transform.Find("location_text").GetComponent<Text>().text = address + ", " + city;
            // move parent object and resize to fit
            newLocationItem.transform.SetParent(location_content.transform);
            newLocationItem.transform.localScale = new Vector3(1f, 1f, 1f);
            // increment
            x++;
            // update loadstatus
            loadStatusText.text = ((x / (TypeAddressCityCountry.Length / 3f)) * 100f).ToString() + "%";
            //rename
            newLocationItem.transform.name = address;
            yield return new  WaitForSeconds(.1f);
        }

        //done!
        print("<color=green>Finnished Generating Searched Locations!</color>");
        x = 0;
        loadStatusText.text = "100%";
    }

    public IEnumerator LoadFavouriteAddressItems()
    {
        while (y < Consts.favouriteDisplayNum)
        {
            // get hard coded data -> TO:DO => Get data from Google API => how ? => (Get Address -> Convert -> To Coordinate -> Get satalite data location on map hmm?
            Debug.Log("Type Address: " + TypeAddressCityCountry.Length);
            string type = TypeAddressCityCountry[y, 0];
            string address = TypeAddressCityCountry[y, 1];
            string city = TypeAddressCityCountry[y, 2];
            string country = TypeAddressCityCountry[y, 3]; // maybe for flag or something

            Sprite type_icon = Addresses.getIcon(type);
            if (type_icon == null) { print("Type Icon Default"); type_icon = Resources.Load("Main/UI/AddressTypes/unknown", typeof(Sprite)) as Sprite; }

            print("<color=green>Loading: </color>" + type + ", " + address + ", " + city + ", " + country);
            // create new item and set data
            GameObject newLocationItem = Instantiate(location_template);
            newLocationItem.transform.Find("location_sprite").GetComponent<Image>().sprite = type_icon;
            newLocationItem.transform.Find("location_text").GetComponent<Text>().text = address + ", " + city;
            // move parent object and resize to fit
            newLocationItem.transform.SetParent(location_content.transform);
            newLocationItem.transform.localScale = new Vector3(1f, 1f, 1f);
            // increment
            y++;
            // update loadstatus
            loadStatusText.text = ((y / (TypeAddressCityCountry.Length / 3f)) * 100f).ToString() + "%";
            //rename
            newLocationItem.transform.name = address;
            yield return new WaitForSeconds(.1f);
        }

        //done!
        print("<color=green>Finnished Generating Searched Locations!</color>");
        y = 0;
        loadStatusText.text = "100%";
    }

    public IEnumerator LoadStationAddressItems()
    {
        while (z < Consts.stationsDisplayNum)
        {
            // get hard coded data -> TO:DO => Get data from Google API => how ? => (Get Address -> Convert -> To Coordinate -> Get satalite data location on map hmm?
            Debug.Log("Type Address: " + TypeAddressCityCountry.Length);
            string type = TypeAddressCityCountry[z, 0];
            string address = TypeAddressCityCountry[z, 1];
            string city = TypeAddressCityCountry[z, 2];
            string country = TypeAddressCityCountry[z, 3]; // maybe for flag or something

            Sprite type_icon = Addresses.getIcon(type);
            if (type_icon == null) { print("Type Icon Default"); type_icon = Resources.Load("Main/UI/AddressTypes/unknown", typeof(Sprite)) as Sprite; }

            print("<color=green>Loading: </color>" + type + ", " + address + ", " + city + ", " + country);
            // create new item and set data
            GameObject newLocationItem = Instantiate(location_template);
            newLocationItem.transform.Find("location_sprite").GetComponent<Image>().sprite = type_icon;
            newLocationItem.transform.Find("location_text").GetComponent<Text>().text = address + ", " + city;
            // move parent object and resize to fit
            newLocationItem.transform.SetParent(location_content.transform);
            newLocationItem.transform.localScale = new Vector3(1f, 1f, 1f);
            // increment
            z++;
            // update loadstatus
            loadStatusText.text = ((z / (TypeAddressCityCountry.Length / 3f)) * 100f).ToString() + "%";
            //rename
            newLocationItem.transform.name = address;
            yield return new WaitForSeconds(.1f);
        }

        //done!
        print("<color=green>Finnished Generating Searched Locations!</color>");
        z = 0;
        loadStatusText.text = "100%";
    }

    public IEnumerator LoadBlackListAddressItems()
    {
        while (q < Consts.blackListDisplayNum)
        {
            // get hard coded data -> TO:DO => Get data from Google API => how ? => (Get Address -> Convert -> To Coordinate -> Get satalite data location on map hmm?
            Debug.Log("Type Address: " + TypeAddressCityCountry.Length);
            string type = TypeAddressCityCountry[q, 0];
            string address = TypeAddressCityCountry[q, 1];
            string city = TypeAddressCityCountry[q, 2];
            string country = TypeAddressCityCountry[q, 3]; // maybe for flag or something

            Sprite type_icon = Addresses.getIcon(type);
            if (type_icon == null) { print("Type Icon Default"); type_icon = Resources.Load("Main/UI/AddressTypes/unknown", typeof(Sprite)) as Sprite; }

            print("<color=green>Loading: </color>" + type + ", " + address + ", " + city + ", " + country);
            // create new item and set data
            GameObject newLocationItem = Instantiate(location_template);
            newLocationItem.transform.Find("location_sprite").GetComponent<Image>().sprite = type_icon;
            newLocationItem.transform.Find("location_text").GetComponent<Text>().text = address + ", " + city;
            // move parent object and resize to fit
            newLocationItem.transform.SetParent(location_content.transform);
            newLocationItem.transform.localScale = new Vector3(1f, 1f, 1f);
            // increment
            q++;
            // update loadstatus
            loadStatusText.text = ((q / (TypeAddressCityCountry.Length / 3f)) * 100f).ToString() + "%";
            //rename
            newLocationItem.transform.name = address;
            yield return new WaitForSeconds(.1f);
        }

        //done!
        print("<color=green>Finnished Generating Searched Locations!</color>");
        q = 0;
        loadStatusText.text = "100%";
    }

    public void DestroyAllContentChildren()
    {
        Transform location_transform = location_content.transform;
        for (int i = 0; i < location_transform.GetChildCount(); i++)
        {
            GameObject child = location_transform.GetChild(i).gameObject;
            Destroy(child);
        }
    }
}
