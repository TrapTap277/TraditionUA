using UnityEngine;

public class RoofControl : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _objectForFade;
    [SerializeField, Range(0, 1)] private float _fade = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        ChangeFadeBuilding();
    }

    // Додати плавність за допомогою DoTween

    private void ChangeFadeBuilding()
    {
        Color spriteColor = _objectForFade.color;
        spriteColor.a = _fade;
        _objectForFade.color = spriteColor;
    }
}