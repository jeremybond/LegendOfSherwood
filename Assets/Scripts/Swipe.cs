/*using UnityEngine;
using System.Collections;

public class TouchInfo
{
	public Vector2 touchPosition;
	public bool swipeComplete;
	public float timeSwipeStarted;
}

public class Swipe : MonoBehaviour 
{	
	public int swipeLength;
	public int swipeVariance;
	private int activeTouch = -1;

	public float timeToSwipe;

	private GUIText swipeText;

	private TouchInfo[] touchInfoArray;
	
	void Start()	
	{
		swipeText = (GUIText) GetComponent(typeof(GUIText));
		touchInfoArray = new TouchInfo[5];
	}   

	void Update()
	{
		if(AndroidInput.touchCount > 0 && AndroidInput.touchCount < 6)
		{
			foreach(Touch touch in AndroidInput.touches)
			{
				if(touchInfoArray[touch.fingerId] == null)
					touchInfoArray[touch.fingerId] = new TouchInfo();

				if(touch.phase == TouchPhase.Began)
					
				{
					touchInfoArray[touch.fingerId].touchPosition = touch.position;
					touchInfoArray[touch.fingerId].timeSwipeStarted = Time.time;
				}
				
				if(touch.position.y > (touchInfoArray[touch.fingerId].touchPosition.y + swipeVariance))	
				{
					touchInfoArray[touch.fingerId].touchPosition = touch.position;	
				}
				if(touch.position.y < (touchInfoArray[touch.fingerId].touchPosition.y - swipeVariance))
				{
					touchInfoArray[touch.fingerId].touchPosition = touch.position;
				}
				if((touch.position.x > touchInfoArray[touch.fingerId].touchPosition.x + swipeLength) && !touchInfoArray[touch.fingerId].swipeComplete 
				   && activeTouch == -1) 
				{
					SwipeComplete("swipe right",  touch);
				}
				if((touch.position.x < touchInfoArray[touch.fingerId].touchPosition.x - swipeLength) && !touchInfoArray[touch.fingerId].swipeComplete 
				   && activeTouch == -1)
				{
					SwipeComplete("swipe left",  touch);
					
				}
				if(touch.fingerId == activeTouch && touch.phase == TouchPhase.Ended)	
				{
					foreach(Touch touchReset in Input.touches)	
					{
						touchInfoArray[touch.fingerId].touchPosition = touchReset.position; 	
					}
					touchInfoArray[touch.fingerId].swipeComplete = false;
					activeTouch = -1;
				}
			}           	
		}   
	}
	void SwipeComplete(string messageToShow, Touch touch)	
	{
		Reset(touch);
		
		if(timeToSwipe == 0.0f || (timeToSwipe > 0.0f && (Time.time - touchInfoArray[touch.fingerId].timeSwipeStarted) <= timeToSwipe))
		{
			swipeText.text = messageToShow;
		}
	}
	void Reset(Touch touch)
	{
		activeTouch = touch.fingerId;
		touchInfoArray[touch.fingerId].swipeComplete = true;        
	}
	
	
	
}*/