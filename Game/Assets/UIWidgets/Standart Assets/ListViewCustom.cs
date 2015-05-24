using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;
using System.Linq;

namespace UIWidgets
{
	/// <summary>
	/// Custom ListView event.
	/// </summary>
	public class ListViewCustomEvent : UnityEvent<int> {
		
	}

	/// <summary>
	/// Base class for custom ListView.
	/// </summary>
	public class ListViewCustom<TComponent,TItem> : ListViewBase where TComponent : ListViewItem {

		[SerializeField]
		List<TItem> customItems = new List<TItem>();

		/// <summary>
		/// Gets or sets the items.
		/// </summary>
		/// <value>Items.</value>
		new public List<TItem> Items {
			get {
				return new List<TItem>(customItems);
			}
			set {
				UpdateItems(value);
			}
		}

		/// <summary>
		/// The default item.
		/// </summary>
		[SerializeField]
		public TComponent DefaultItem;

		List<TComponent> components = new List<TComponent>();

		List<TComponent> componentsCache = new List<TComponent>();

		List<UnityAction<PointerEventData>> callbacksEnter = new List<UnityAction<PointerEventData>>();

		List<UnityAction<PointerEventData>> callbacksExit = new List<UnityAction<PointerEventData>>();

		/// <summary>
		/// Gets the selected item.
		/// </summary>
		/// <value>The selected item.</value>
		public TItem SelectedItem {
			get {
				if (SelectedIndex==-1)
				{
					return default(TItem);
				}
				return customItems[SelectedIndex];
			}
		}

		/// <summary>
		/// Gets the selected items.
		/// </summary>
		/// <value>The selected items.</value>
		public List<TItem> SelectedItems {
			get {
				if (SelectedIndex==-1)
				{
					return null;
				}
				return SelectedIndicies.ConvertAll(x => customItems[x]);
			}
		}

		/// <summary>
		/// Gets the selected component.
		/// </summary>
		/// <value>The selected component.</value>
		public TComponent SelectedComponent {
			get {
				if (SelectedIndex==-1)
				{
					return null;
				}
				return components[SelectedIndex];
			}
		}

		/// <summary>
		/// Gets the selected components.
		/// </summary>
		/// <value>The selected components.</value>
		public List<TComponent> SelectedComponents {
			get {
				if (SelectedIndex==-1)
				{
					return null;
				}
				return SelectedIndicies.ConvertAll(x => components[x]);
			}
		}

		/// <summary>
		/// Sort function.
		/// </summary>
		public Func<List<TItem>,List<TItem>> SortFunc;
		
		/// <summary>
		/// What to do when the object selected.
		/// </summary>
		public ListViewCustomEvent OnSelectObject = new ListViewCustomEvent();
		
		/// <summary>
		/// What to do when the object deselected.
		/// </summary>
		public ListViewCustomEvent OnDeselectObject = new ListViewCustomEvent();
		
		/// <summary>
		/// What to do when the event system send a pointer enter Event.
		/// </summary>

		public ListViewCustomEvent OnPointerEnterObject = new ListViewCustomEvent();
		
		/// <summary>
		/// What to do when the event system send a pointer exit Event.
		/// </summary>
		public ListViewCustomEvent OnPointerExitObject = new ListViewCustomEvent();
		
		bool start_called = false;

		[SerializeField]
		Color defaultBackgroundColor = Color.white;
		
		[SerializeField]
		Color defaultColor = Color.black;
		
		/// <summary>
		/// Default background color.
		/// </summary>
		public Color DefaultBackgroundColor {
			get {
				return defaultBackgroundColor;
			}
			set {
				defaultBackgroundColor = value;
				UpdateColors();
			}
		}
		
		/// <summary>
		/// Default text color.
		/// </summary>
		public Color DefaultColor {
			get {
				return defaultColor;
			}
			set {
				DefaultColor = value;
				UpdateColors();
			}
		}
		
		/// <summary>
		/// Color of background on pointer over.
		/// </summary>
		[SerializeField]
		public Color HighlightedBackgroundColor = new Color(203, 230, 244, 255);
		
		/// <summary>
		/// Color of text on pointer text.
		/// </summary>
		[SerializeField]
		public Color HighlightedColor = Color.black;
		
		[SerializeField]
		Color selectedBackgroundColor = new Color(53, 83, 227, 255);
		
		[SerializeField]
		Color selectedColor = Color.black;
		
		/// <summary>
		/// Background color of selected item.
		/// </summary>
		public Color SelectedBackgroundColor {
			get {
				return selectedBackgroundColor;
			}
			set {
				selectedBackgroundColor = value;
				UpdateColors();
			}
		}
		
		/// <summary>
		/// Text color of selected item.
		/// </summary>
		public Color SelectedColor {
			get {
				return selectedColor;
			}
			set {
				selectedColor = value;
				UpdateColors();
			}
		}

		/// <summary>
		/// Start this instance.
		/// </summary>
		public override void Start()
		{
			if (start_called)
			{
				return ;
			}
			start_called = true;
			
			base.Start();

			DestroyGameObjects = false;

			if (DefaultItem==null)
			{
				throw new NullReferenceException(String.Format("DefaultItem is null. Set component of type {0} to DefaultItem.", typeof(TComponent).FullName));
			}

			UpdateItems();
			
			DefaultItem.gameObject.SetActive(false);

			OnSelect.AddListener(OnSelectCallback);
			OnDeselect.AddListener(OnDeselectCallback);
		}
		
		void OnSelectCallback(int index, ListViewItem item)
		{
			OnSelectObject.Invoke(index);

			SelectColoring(components[index]);
		}
		
		void OnDeselectCallback(int index, ListViewItem item)
		{
			OnDeselectObject.Invoke(index);

			DefaultColoring(components[index]);
		}
		
		void OnPointerEnterCallback(int index)
		{
			OnPointerEnterObject.Invoke(index);

			if (!IsSelected(index))
			{
				HighlightColoring(components[index]);
			}
		}
		
		void OnPointerExitCallback(int index)
		{
			OnPointerExitObject.Invoke(index);

			if (!IsSelected(index))
			{
				DefaultColoring(components[index]);
			}
		}
		
		/// <summary>
		/// Updates thitemsms.
		/// </summary>
		public override void UpdateItems()
		{
			UpdateItems(customItems);
		}

		/// <summary>
		/// Clear items of this instance.
		/// </summary>
		public override void Clear()
		{
			customItems.Clear();
			UpdateItems();
		}

		/// <summary>
		/// Add the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		/// <returns>Index of added item.</returns>
		public virtual int Add(TItem item)
		{
			var newItems = customItems;
			newItems.Add(item);
			UpdateItems(newItems);
			
			var index = customItems.FindIndex(x => x.Equals(item));
			
			return index;
		}
		
		/// <summary>
		/// Remove the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		/// <returns>Index of removed TItem.</returns>
		public virtual int Remove(TItem item)
		{
			var index = customItems.FindIndex(x => x.Equals(item));
			if (index==-1)
			{
				return index;
			}

			Remove(index);

			return index;
		}

		/// <summary>
		/// Remove item by specifieitemsex.
		/// </summary>
		/// <returns>Index of removed item.</returns>
		/// <param name="index">Index.</param>
		public virtual void Remove(int index)
		{
			var newItems = customItems;
			newItems.RemoveAt(index);
			UpdateItems(newItems);			
		}
		
		void RemoveCallbacks()
		{
			base.Items.ForEach((item, index) => {
				if (item==null)
				{
					return ;
				}
				if (callbacksEnter.Count > index)
				{
					item.onPointerEnter.RemoveListener(callbacksEnter[index]);
				}
				if (callbacksExit.Count > index)
				{
					item.onPointerExit.RemoveListener(callbacksExit[index]);
				}
			});
			callbacksEnter.Clear();
			callbacksExit.Clear();
		}
		
		void AddCallbacks()
		{
			base.Items.ForEach((item, index) => AddCallback(item, index));
		}
		
		void AddCallback(ListViewItem item, int index)
		{
			callbacksEnter.Add(ev => OnPointerEnterCallback(index));
			callbacksExit.Add(ev => OnPointerExitCallback(index));
			
			item.onPointerEnter.AddListener(callbacksEnter[index]);
			item.onPointerExit.AddListener(callbacksExit[index]);
		}
		
		List<TItem> SortItems(List<TItem> newItems)
		{
			var temp = newItems;
			if (SortFunc!=null)
			{
				temp = SortFunc(temp);
			}
			
			return temp;
		}

		/// <summary>
		/// Sets component data with specified item.
		/// </summary>
		/// <param name="component">Component.</param>
		/// <param name="item">Item.</param>
		protected virtual void SetData(TComponent component, TItem item)
		{
		}

		void Items2Components(List<TItem> newItems)
		{
		}

		void UpdateItems(List<TItem> newItems)
		{
			RemoveCallbacks();

			newItems = SortItems(newItems);
			
			componentsCache = componentsCache.Where(x => x!=null).ToList();
			var new_components = new List<TComponent>();
			newItems.ForEach((x, i) => {
				if (components.Count > 0)
				{
					new_components.Add(components[0]);
					components.RemoveAt(0);
				}
				else if (componentsCache.Count > 0)
				{
					componentsCache[0].gameObject.SetActive(true);
					new_components.Add(componentsCache[0]);
					componentsCache.RemoveAt(0);
				}
				else
				{
					var component = Instantiate(DefaultItem) as TComponent;
					
					Utilites.FixInstantiated(DefaultItem, component);
					
					component.gameObject.SetActive(true);
					
					new_components.Add(component);
				}
			});
			components.ForEach(x => x.gameObject.SetActive(false));
			componentsCache.AddRange(components);
			components.Clear();
			

			var selected_indicies = new List<int>();
			SelectedIndicies.ForEach(index => {
				var new_index = newItems.FindIndex(x => x.Equals(customItems[index]));
				if (new_index!=-1)
				{
					selected_indicies.Add(index);
				}
			});

			customItems = newItems;
			components = new_components;

			var base_items = new List<ListViewItem>();
			components.ForEach(x => {
				//var item = x.GetComponent<ListViewItem>() ?? x.gameObject.AddComponent<ListViewItem>();
				base_items.Add(x);
			});

			base.Items= base_items;

			new_components.ForEach((x, i) => {
				SetData(x, newItems[i]);
				DefaultColoring(x);
			});

			selected_indicies.ForEach(x => Select(x));
			
			AddCallbacks();
		}

		void UpdateColors(ICollection<int> selectedIndicies)
		{
			components.ForEach((component, index) => {
				if (selectedIndicies.Contains(index))
				{
					SelectColoring(component);
				}
				else
				{
					DefaultColoring(component);
				}
			});
		}

		/// <summary>
		/// Set highlights colors of specified component.
		/// </summary>
		/// <param name="component">Component.</param>
		protected virtual void HighlightColoring(TComponent component)
		{
			component.Background.color = HighlightedBackgroundColor;
		}

		/// <summary>
		/// Set select colors of specified component.
		/// </summary>
		/// <param name="component">Component.</param>
		protected virtual void SelectColoring(TComponent component)
		{
			component.Background.color = SelectedBackgroundColor;
		}

		/// <summary>
		/// Set default colors of specified component.
		/// </summary>
		/// <param name="component">Component.</param>
		protected virtual void DefaultColoring(TComponent component)
		{
			component.Background.color = DefaultBackgroundColor;
		}


		void UpdateColors()
		{
			UpdateColors(SelectedIndicies);
		}

		/// <summary>
		/// This function is called when the MonoBehaviour will be destroyed.
		/// </summary>
		protected override void OnDestroy()
		{
			OnSelect.RemoveListener(OnSelectCallback);
			OnDeselect.RemoveListener(OnDeselectCallback);
			
			RemoveCallbacks();
			
			base.OnDestroy();
		}
	}
}