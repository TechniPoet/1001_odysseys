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
	/// ListView sources.
	/// </summary>
	public enum ListViewSources {
		/// <summary>
		/// The list. Use strings as source for list.
		/// </summary>
		List = 0,
		/// <summary>
		/// The file. Use file as source for list.
		/// </summary>
		File = 1,
	}

	/// <summary>
	/// List view event.
	/// </summary>
	public class ListViewEvent : UnityEvent<int,string>
	{

	}

	[AddComponentMenu("UI/ListView", 250)]
	/// <summary>
	/// List view.
	/// http://ilih.ru/images/unity-assets/UIWidgets/ListView.png
	/// </summary>
	public class ListView : ListViewBase {
		[SerializeField]
		List<string> strings = new List<string>();

		/// <summary>
		/// Gets the strings.
		/// </summary>
		/// <value>The strings.</value>
		public List<string> Strings {
			get {
				return new List<string>(strings);
			}
			set {
				UpdateItems(value);
			}
		}

		[SerializeField]
		TextAsset file;

		/// <summary>
		/// Gets or sets the file with strings for ListView. One string per line.
		/// </summary>
		/// <value>The file.</value>
		public TextAsset File {
			get {
				return file;
			}
			set {
				file = value;
				if (file!=null)
				{
					UpdateItems(file);
				}
			}
		}

		/// <summary>
		/// The comments in file start with specified strings.
		/// </summary>
		[SerializeField]
		public List<string> CommentsStartWith = new List<string>(){"#", "//"};

		/// <summary>
		/// The source.
		/// </summary>
		[SerializeField]
		public ListViewSources Source = ListViewSources.List;

		/// <summary>
		/// Allow only unique strings.
		/// </summary>
		[SerializeField]
		public bool Unique = true;

		/// <summary>
		/// Allow empty strings.
		/// </summary>
		[SerializeField]
		public bool AllowEmptyItems;

		[SerializeField]
		Color backgroundColor = Color.white;

		[SerializeField]
		Color textColor = Color.black;

		/// <summary>
		/// Default background color.
		/// </summary>
		public Color BackgroundColor {
			get {
				return backgroundColor;
			}
			set {
				backgroundColor = value;
				UpdateColors();
			}
		}

		/// <summary>
		/// Default text color.
		/// </summary>
		public Color TextColor {
			get {
				return textColor;
			}
			set {
				textColor = value;
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
		public Color HighlightedTextColor = Color.black;

		[SerializeField]
		Color selectedBackgroundColor = new Color(53, 83, 227, 255);

		[SerializeField]
		Color selectedTextColor = Color.black;

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
		public Color SelectedTextColor {
			get {
				return selectedTextColor;
			}
			set {
				selectedTextColor = value;
				UpdateColors();
			}
		}

		/// <summary>
		/// The default item.
		/// </summary>
		[SerializeField]
		public ImageAdvanced DefaultItem;

		List<ImageAdvanced> itemsImages = new List<ImageAdvanced>();
		List<Text> itemsText = new List<Text>();

		List<UnityAction<PointerEventData>> callbacksEnter = new List<UnityAction<PointerEventData>>();
		List<UnityAction<PointerEventData>> callbacksExit = new List<UnityAction<PointerEventData>>();

		/// <summary>
		/// Sort items.
		/// </summary>
		[SerializeField]
		public bool Sort = true;

		/// <summary>
		/// Sort function.
		/// </summary>
		public Func<IEnumerable<string>,IEnumerable<string>> SortFunc = items => items.OrderBy(x => x);

		/// <summary>
		/// OnSelect event.
		/// </summary>
		public ListViewEvent OnSelectString = new ListViewEvent();

		/// <summary>
		/// OnDeselect event.
		/// </summary>
		public ListViewEvent OnDeselectString = new ListViewEvent();

		bool start_called = false;

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
				throw new NullReferenceException("DefaultItem is null. Set component of type ImageAdvanced to DefaultItem.");
			}
			if (DefaultItem.GetComponentInChildren<Text>()==null)
			{
				throw new MissingComponentException("DefaultItem don't have child with 'Text' component. Add child with 'Text' component to DefaultItem.");
			}

			UpdateItems();

			DefaultItem.gameObject.SetActive(false);

			OnSelect.AddListener(OnSelectCallback);
			OnDeselect.AddListener(OnDeselectCallback);
		}

		void OnSelectCallback(int index, ListViewItem item)
		{
			OnSelectString.Invoke(index, strings[index]);
		}

		void OnDeselectCallback(int index, ListViewItem item)
		{
			OnDeselectString.Invoke(index, strings[index]);
		}

		/// <summary>
		/// Updates the items.
		/// </summary>
		public override void UpdateItems()
		{
			if (Source==ListViewSources.List)
			{
				UpdateItems(strings);
			}
			else
			{
				UpdateItems(File);
			}
		}

		/// <summary>
		/// Clear strings list.
		/// </summary>
		public override void Clear()
		{
			strings.Clear();
			UpdateItems(strings);
		}

		/// <summary>
		/// Updates the items.
		/// </summary>
		/// <param name="newFile">File.</param>
		void UpdateItems(TextAsset newFile)
		{
			if (file==null)
			{
				return ;
			}
			var new_items = new List<string>(newFile.text.Split(new string[] {"\r\n", "\r", "\n"}, StringSplitOptions.None));
			UpdateItems(new_items);
		}

		/// <summary>
		/// Add the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		/// <returns>Index of added item.</returns>
		public virtual int Add(string item)
		{
			var newStrings = Strings;
			newStrings.Add(item);
			UpdateItems(newStrings);

			var index = strings.FindIndex(x => x==item);

			return index;
		}

		/// <summary>
		/// Remove the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		/// <returns>Index of removed item.</returns>
		public virtual int Remove(string item)
		{
			var index = strings.FindIndex(x => x==item);
			if (index==-1)
			{
				return index;
			}

			var newStrings = Strings;
			newStrings.Remove(item);
			UpdateItems(newStrings);

			return index;
		}

		void RemoveCallbacks()
		{
			itemsImages.ForEach((x, index) => {
				if (x==null)
				{
					return ;
				}
				if (callbacksEnter.Count > index)
				{
					x.onPointerEnter.RemoveListener(callbacksEnter[index]);
				}
				if (callbacksExit.Count > index)
				{
					x.onPointerExit.RemoveListener(callbacksExit[index]);
				}
			});
			callbacksEnter.Clear();
			callbacksExit.Clear();
		}

		void AddCallbacks()
		{
			itemsImages.ForEach((image, index) => AddCallback(image, index));
		}

		void AddCallback(ImageAdvanced image, int index)
		{
			callbacksEnter.Add(ev => ImageOver(index));
			callbacksExit.Add(ev => ImageOut(index));
			
			image.onPointerEnter.AddListener(callbacksEnter[index]);
			image.onPointerExit.AddListener(callbacksExit[index]);
		}
		
		void ImageOver(int index)
		{
			if (!IsValid(index))
			{
				var message = string.Format("Index must be between 0 and Items.Count ({0})", Items.Count);
				throw new IndexOutOfRangeException(message);
			}

			if (IsSelected(index))
			{
				return ;
			}

			itemsImages[index].color = HighlightedBackgroundColor;
			itemsText[index].color = HighlightedTextColor;
		}

		void ImageOut(int index)
		{
			if (!IsValid(index))
			{
				var message = string.Format("Index must be between 0 and Items.Count ({0})", Items.Count);
				throw new IndexOutOfRangeException(message);
			}

			if (IsSelected(index))
			{
				return ;
			}

			itemsImages[index].color = backgroundColor;
			itemsText[index].color = textColor;
		}

		List<string> FilterItems(IEnumerable<string> newItems)
		{
			var temp = newItems;
			if (Source==ListViewSources.File)
			{
				temp = temp.Select(x => x.Trim());
				if (Unique)
				{
					temp = temp.Distinct();
				}

				if (!AllowEmptyItems)
				{
					temp = temp.Where(x => x!=string.Empty);
				}

				if (CommentsStartWith.Count > 0)
				{
					temp = temp.Where(line => {
						return !CommentsStartWith.Any(comment => line.StartsWith(comment, StringComparison.InvariantCulture));
					});
				}
			}

			if (Sort && SortFunc!=null)
			{
				temp = SortFunc(temp);
			}

			return temp.ToList();
		}

		void UpdateItems(List<string> newItems)
		{
			newItems = FilterItems(newItems);

			RemoveCallbacks();

			CreateItems(newItems.Count);

			var selected_indicies = UpdateTextes(newItems);

			UpdateColors(selected_indicies);

			strings = newItems;

			var base_items = new List<ListViewItem>();
			itemsImages.ForEach(x => {
				var item = x.GetComponent<ListViewItem>() ?? x.gameObject.AddComponent<ListViewItem>();
				base_items.Add(item);
			});

			base.Items = base_items;

			selected_indicies.ForEach(x => Select(x));

			AddCallbacks();
		}

		List<int> UpdateTextes(IList<string> newItems)
		{
			//duplicated items should not be selected more than at start
			var new_items_copy = new List<string>(newItems);

			var selected_items = SelectedIndicies.Select(x => strings[x]);

			selected_items = selected_items.Where(x => {
				var is_valid_item = newItems.Contains(x);
				if (is_valid_item)
				{
					new_items_copy.Remove(x);
				}
				return is_valid_item;
			}).ToList();

			var selected_indicies = new List<int>();

			var selected_items_copy = new List<string>(selected_items);

			int index = 0;
			itemsImages.ForEach(image => {
				var is_selected = selected_items_copy.Contains(newItems[index]);

				selected_items_copy.Remove(newItems[index]);

				var text = itemsText[index];
				text.text = newItems[index];
				
				if (is_selected)
				{
					selected_indicies.Add(index);
				}
				
				index++;
			});

			return selected_indicies;
		}

		ImageAdvanced CreateImage()
		{
			var image = Instantiate(DefaultItem) as ImageAdvanced;

			image.gameObject.SetActive(true);
			image.color = backgroundColor;

			Utilites.FixInstantiated(DefaultItem, image);

			itemsImages.Add(image);

			var text = image.GetComponentInChildren<Text>();
			text.color = textColor;
			itemsText.Add(text);

			return image;
		}
		
		void CreateItems(int newItemsCount)
		{
			//add new ui elements if necessary
			if (newItemsCount > itemsText.Count)
			{
				for (var i = itemsText.Count; i < newItemsCount; i++)//each (var i in Enumerable.Range(itemsText.Count, newItemsCount - itemsText.Count))
				{
					CreateImage();
				}
			}
			//del existing ui elements if necessary

			if (newItemsCount < itemsText.Count)
			{
				for (var i = itemsText.Count - 1; i >= newItemsCount; i--)//each (var i in Enumerable.Range(newItemsCount, itemsText.Count - newItemsCount).Reverse())
				{
					Destroy(itemsImages[i].gameObject);

					itemsImages.RemoveAt(i);
					itemsText.RemoveAt(i);
				}
			}

		}

		void UpdateColors(ICollection<int> selectedIndicies)
		{
			itemsImages.ForEach((image, index) => {
				var text = itemsText[index];
				if (selectedIndicies.Contains(index))
				{
					image.color = selectedBackgroundColor;
					text.color = selectedTextColor;
				}
				else
				{
					image.color = backgroundColor;
					text.color = textColor;
				}
			});
		}

		void UpdateColors()
		{
			UpdateColors(SelectedIndicies);
		}

		protected override void SelectItem(int index)
		{
			itemsImages[index].color = selectedBackgroundColor;
			itemsText[index].color = selectedTextColor;
		}
		
		protected override void DeselectItem(int index)
		{
			itemsImages[index].color = backgroundColor;
			itemsText[index].color = textColor;
		}

		protected override void OnDestroy()
		{
			OnSelect.RemoveListener(OnSelectCallback);
			OnDeselect.RemoveListener(OnDeselectCallback);

			RemoveCallbacks();

			base.OnDestroy();
		}

#if UNITY_EDITOR
		[UnityEditor.MenuItem("GameObject/UI/ListView")]
		static void CreateObject()
		{
			Utilites.CreateObject("Assets/UIWidgets/Prefabs/ListView.prefab");
		}
#endif
	}
}