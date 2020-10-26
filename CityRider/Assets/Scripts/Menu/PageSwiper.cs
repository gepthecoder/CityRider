using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    // drag threshold
    public float percentThreshold = 0.2f;
    private Vector3 panelLocation;
    public float easing = 0.5f;
    // info slide
    public int numOfPanels = 3;
    private int currentChild;


    // Start is called before the first frame update
    void Start()
    {
        panelLocation = transform.position;
    }

    public void OnDrag(PointerEventData data)
    {
        float difference = data.pressPosition.x - data.position.x;
        //move the panel in the direction of the swipe
        transform.position = panelLocation - new Vector3(difference, 0, 0); //substracting the idle position to its drag -> end -> new state
    }

    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width; // -value -> left__right || +value -> right__left
        if(Mathf.Abs(percentage)>= percentThreshold){
            Vector3 newLocation = panelLocation;
            bool is_not_last = currentChild < transform.childCount - 1;
            bool is_not_first = currentChild > 0;
            if (percentage > 0 && is_not_last)
            {
                newLocation += new Vector3(-Screen.width, 0, 0);
                currentChild++;
                Debug.Log("currentChild: " + currentChild);
            }else if(percentage < 0 && is_not_first)
            {
                newLocation += new Vector3(Screen.width, 0, 0);
                currentChild--;
                Debug.Log("currentChild: " + currentChild);
            }
            //transform.position = newLocation;
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        }
        else // jump to the previous slide if not above threshold
        {
            //transform.position = panelLocation;
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));

        }
    }

    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float sec)
    {
        float t = 0f;
        while(t <= 1.0f)
        {
            t += Time.deltaTime / sec;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0F, 1F, t));
            yield return null;
        }
    }
}
