using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public int CurrentLevel;
    [SerializeField] private LevelData _levelData;
    private TextMeshProUGUI _textMeshPro;
    private Image _image;

    public void Start()
    {
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        _image = GetComponent<Image>();

        _textMeshPro.text = _levelData.LevelName;
        _image.sprite = _levelData.Sprite;
        CurrentLevel = _levelData.Level;
    }
}
