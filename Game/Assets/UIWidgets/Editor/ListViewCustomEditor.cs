﻿using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;

namespace UIWidgets
{
	public class ListViewCustomEditor : Editor
	{
		protected Dictionary<string,SerializedProperty> SerializedProperties = new Dictionary<string,SerializedProperty>();
		
		protected List<string> Properties = new List<string>{
			"customItems",
			"Multiple",
			"selectedIndex",
			
			"DefaultItem",
			"Container",

			"defaultColor",
			"defaultBackgroundColor",

			"HighlightedColor",
			"HighlightedBackgroundColor",

			"selectedColor",
			"selectedBackgroundColor",
		};
		
		protected virtual void OnEnable()
		{
			Properties.ForEach(x => {
				SerializedProperties.Add(x, serializedObject.FindProperty(x));
			});
		}
		
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			SerializedProperties.ForEach(x => EditorGUILayout.PropertyField(x.Value, true));

			serializedObject.ApplyModifiedProperties();
		}
	}
}