using System.Collections.Generic;
using UnityEngine;

public class UIPopupsManager : MonoBehaviour
{
    [SerializeField] private List<UIPopup> _uiPopups = new List<UIPopup>();

    public UIPopup Show(UIPopupType type)
    {
        UIPopup _popup = _uiPopups.Find(x => x.UIPopupType == type);
        if (_popup != null)
        {
            _popup.Show();
        }

        return _popup;
    }

    public void Hide(UIPopupType type)
    {
        UIPopup _popup = _uiPopups.Find(x => x.UIPopupType == type);
        if (_popup != null)
        {
            _popup.Hide();
        }
    }
}

public class UIPopup : MonoBehaviour
{
    public UIPopupType UIPopupType;

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}

public enum UIPopupType
{
    None,
    POPUP1
}
