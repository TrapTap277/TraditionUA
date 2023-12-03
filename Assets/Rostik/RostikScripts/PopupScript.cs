using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupScript : UIPopup
{
    [SerializeField] private Image _popup;
    
    public override void Show()
    {
        base.Show();

        Debug.Log("Show");
    }

    public override void Hide()
    {
        base.Hide();

        Debug.Log("Hide");
    }
}
