using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class menu : MonoBehaviour
{
    [SerializeField] ThrowingThing[] throwingThings;
    [SerializeField] MovingThing[] movingThings;
    [SerializeField] Button[] buttons;

    [SerializeField] TextMeshPro minTimeText;
    [SerializeField] TextMeshPro maxTimeText;
    
    //ThrowingThings

    public void IncreseThrowngThingObjectSize(){
        foreach(ThrowingThing throwingThing in throwingThings){
            throwingThing.transform.localScale += new Vector3(0.2f,0.2f,0); 
        }
    }
    public void DecreaseThrowingThingObjectSize(){
        foreach(ThrowingThing throwingThing in throwingThings){
            throwingThing.transform.localScale -= new Vector3(0.2f,0.2f,0); 
        }
    }
    public void IncreseThrowngThingColliderSize(){
        foreach(ThrowingThing throwingThing in throwingThings){
            throwingThing.GetComponent<CapsuleCollider2D>().size += new Vector2(0.2f,0.2f); 
        }
    }
    public void DecreaseThrowingThingColliderSize(){
        foreach(ThrowingThing throwingThing in throwingThings){
            throwingThing.GetComponent<CapsuleCollider2D>().size -= new Vector2(0.2f,0.2f); 
        }
    }
    public void IncreseThrowingThingMaxTimeBetweenClicks(){
        foreach(ThrowingThing throwingThing in throwingThings){
            throwingThing.maxTimeBetweenClicks += 0.1f;
        }
    }
    public void DecreseThrowingThingMaxTimeBetweenClicks(){
        foreach(ThrowingThing throwingThing in throwingThings){
            throwingThing.maxTimeBetweenClicks -= 0.1f;
        }
    }
    public void IncreseThrowingThingThrowingForce(){
        foreach(ThrowingThing throwingThing in throwingThings){
            throwingThing.throwMultiplier += 1f;
        }
    }
    public void DecreseThrowingThingThrowingForce(){
        foreach(ThrowingThing throwingThing in throwingThings){
            throwingThing.throwMultiplier -= 1f;
        }
    }

    //MovingThings
    public void IncreseMovingThingColliderSize(){
        foreach(MovingThing movingThing in movingThings){
            movingThing.GetComponent<BoxCollider2D>().size += new Vector2(0.2f,0.2f); 
        }
    }
    public void DecreaseMovingThingColliderSize(){
        foreach(MovingThing movingThing in movingThings){
            movingThing.GetComponent<BoxCollider2D>().size -= new Vector2(0.2f,0.2f); 
        }
    }


    //Buttons
    public void IncreseButtonMaxTimeBetweenClicks(){
        foreach(Button b in buttons){
            b.maxTimeBetweenClicks += 0.1f;
        }
    }
    public void DecreseButtonMaxTimeBetweenClicks(){
        foreach(Button b in buttons){
            b.maxTimeBetweenClicks -= 0.1f;
        }
    }
    public void IncreseButtonMinTimeBeforeHold(){
        foreach(Button b in buttons){
            b.minTimeBeforeHold += 0.1f;
        }
    }
    public void DecreseButtonMinTimeBeforeHold(){
        foreach(Button b in buttons){
            b.minTimeBeforeHold -= 0.1f;
        }
    }


    public void Update(){
        minTimeText.text = buttons[0].minTimeBeforeHold.ToString();
        maxTimeText.text = buttons[0].maxTimeBetweenClicks.ToString();
    }
}