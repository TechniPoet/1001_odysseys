using UnityEngine;
using UIWidgets;

public class UITestSamples : MonoBehaviour
{
	[SerializeField]
	Sprite questionIcon;

	[SerializeField]
	Sprite attentionIcon;

	public void ShowNotifySticky()
	{
		Notify.Template("NotifyTemplateSimple").Show("Sticky Notification. Click on the × above to close.", customHideDelay: 0f);
	}

	public void ShowNotifyAutohide()
	{
		Notify.Template("NotifyTemplateAutoHide").Show("Achievement unlocked. Hide after 3 seconds.", customHideDelay: 3f);
	}

	bool CallShowNotifyAutohide()
	{
		ShowNotifyAutohide();
		return true;
	}

	public void ShowNotifyAutohideRotate()
	{
		Notify.Template("NotifyTemplateAutoHide").Show(
			"Achievement unlocked. Hide after 4 seconds.",
			customHideDelay: 4f,
			hideAnimation: Notify.AnimationRotate
		);
	}

	public void ShowNotifyBlack()
	{
		Notify.Template("NotifyTemplateBlack").Show(
			"Another Notification. Hide after 5 seconds or click on the × above to close.",
			customHideDelay: 5f,
			hideAnimation: Notify.AnimationCollapse,
			slideUpOnHide: false
		);
	}

	bool ShowNotifyYes()
	{
		Notify.Template("NotifyTemplateAutoHide").Show("Action on 'Yes' button click.", customHideDelay: 3f);
		return true;
	}

	bool ShowNotifyNo()
	{
		Notify.Template("NotifyTemplateAutoHide").Show("Action on 'No' button click.", customHideDelay: 3f);
		return true;
	}

	public void ShowDialogSimple()
	{
		Dialog.Template("DialogTemplateSample").Show(
			title: "Simple Dialog",
			message: "Simple dialog with only close button.",
			buttons: new DialogActions(){
				{"Close", Dialog.Close},
			},
			focusButton: "Close"
		);
	}

	bool CallShowDialogSimple()
	{
		ShowDialogSimple();
		return true;
	}

	public void ShowDialogYesNoCancel()
	{
		Dialog.Template("DialogTemplateSample").Show(
			title: "Dialog Yes No Cancel",
			message: "Question?",
			buttons: new DialogActions(){
				{"Yes", ShowNotifyYes},
				{"No", ShowNotifyNo},
				{"Cancel", Dialog.Close},
			},
			focusButton: "Yes",
			icon: questionIcon
		);
	}

	public void ShowDialogExtended()
	{
		Dialog.Template("DialogTemplateSample").Show(
			title: "Another Dialog",
			message: "Same template with another position and long text.\nChange\nheight\nto\nfit\ntext.",
			buttons: new DialogActions(){
				{"Show notification", CallShowNotifyAutohide},
				{"Open simple dialog", CallShowDialogSimple},
				{"Close", Dialog.Close},
			},
			focusButton: "Show notification",
			position: new Vector3(40, -40, 0)
		);
	}

	public void ShowDialogModal()
	{
		Dialog.Template("DialogTemplateSample").Show(
			title: "Modal Dialog",
			message: "Simple Modal Dialog.",
			buttons: new DialogActions(){
				{"Close", Dialog.Close},
			},
			focusButton: "Close",
			modal: true,
			modalColor: new Color(0, 0, 0, 0.8f)
		);
	}

	public void ShowDialogSignIn()
	{
		var dialog = Dialog.Template("DialogSignInTemplateSample");
		var helper = dialog.GetComponent<DialogInputHelper>();
		helper.Refresh();

		dialog.Show(
			title: "Sign into your Account",
			buttons: new DialogActions(){
				{"Sign in", () => SignInNotify(helper)},
				{"Cancel", Dialog.Close},
			},
			focusButton: "Sign in",
			modal: true,
			modalColor: new Color(0, 0, 0, 0.8f)
		);
	}

	bool SignInNotify(DialogInputHelper helper)
	{
		if (!helper.Validate())
		{
			return false;
		}

		var message = "Sign in.\nUsername: " + helper.Username.text + "\nPassword: <hidden>";
		Notify.Template("NotifyTemplateAutoHide").Show(message, customHideDelay: 3f);

		return true;
	}
}