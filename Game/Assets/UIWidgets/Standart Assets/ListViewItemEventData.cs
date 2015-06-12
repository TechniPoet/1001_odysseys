using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ListViewItemEventData : BaseEventData {
	public GameObject NewSelectedObject;

	public ListViewItemEventData(EventSystem eventSystem) : base(eventSystem)
	{
	}
}
