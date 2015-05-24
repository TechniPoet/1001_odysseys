using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using UIWidgets;

public class TestListViewPerformance : MonoBehaviour {
	[SerializeField]
	ListView lv;

	public void Test10 () {
		Debug.Log(DateTime.Now.ToString("HH:mm:ss.fff"));
		lv.Strings = Enumerable.Range(1, 10).Select(x => x.ToString()).ToList();
		Debug.Log(DateTime.Now.ToString("HH:mm:ss.fff"));
	}

	public void Test100 () {
		Debug.Log(DateTime.Now.ToString("HH:mm:ss.fff"));
		lv.Strings = Enumerable.Range(1, 100).Select(x => x.ToString()).ToList();
		Debug.Log(DateTime.Now.ToString("HH:mm:ss.fff"));
	}

	public void Test1000 () {
		Debug.Log(DateTime.Now.ToString("HH:mm:ss.fff"));
		lv.Strings = Enumerable.Range(1, 1000).Select(x => x.ToString()).ToList();
		Debug.Log(DateTime.Now.ToString("HH:mm:ss.fff"));
	}

}
