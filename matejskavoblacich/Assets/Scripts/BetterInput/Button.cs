using UnityEngine;
using UnityEngine.Events;

public class Button : BaseHoldable
{
    [SerializeField] SpriteRenderer sprite;

    [Header("Button properties")]
    [SerializeField, Tooltip("If true, OnClick is called only once even when holding for long time")] bool clickOnce = false;
    [Header("Colors")]
    [SerializeField] Color baseColor = Color.white;
    [SerializeField] Color hoverColor = Color.white;
    [SerializeField] Color selectedColor = Color.white;
    [Header("OnClick event")]
    [SerializeField] UnityEvent onClick;

    bool clickedThisHold = false;
    public void Start(){
        minTimeBeforeHold = 0.3f;
        maxTimeBetweenClicks = 0.4f;
        sprite.color = baseColor;
    }

    protected override void OnPress(Vector2 hitPosition)
    {
        sprite.color = hoverColor;
    }

    protected override void OnHold(Vector2 hitPosition)
    {
        if(clickOnce && clickedThisHold){
            return;
        }
        onClick.Invoke();
        clickedThisHold = true;
        sprite.color = selectedColor;
    }

    protected override void OnRelease(Vector2 hitPosition)
    {
        clickedThisHold = false;
        sprite.color = baseColor;
    }
}