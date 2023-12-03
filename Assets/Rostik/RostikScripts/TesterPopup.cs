using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterPopup : MonoBehaviour
{
    public UIManager _uiManager;

    private void Start()
    {
        _uiManager.Show(UIPopupType.POPUP1);
    }
}
