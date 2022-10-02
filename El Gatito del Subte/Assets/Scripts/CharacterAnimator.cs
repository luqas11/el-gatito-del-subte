using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Sprite[] backSprites;
    public Sprite[] frontSprites;
    public Sprite[] sideSprites;
    public Sprite[] currentSprites;
    public Sprite idleSprite;
    public float timer;
    public SpriteRenderer character;
    public int index;
    public float animationPeriod;
    public int currentStage = 0;
    public int initialStage = 0;

    private void Start()
    {
        setCurrentAnimation(initialStage);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > animationPeriod)
        {
            updateSprite();
        }
    }

    // Update character sprite to the next one
    public void updateSprite()
    {
        if (index >= currentSprites.Length)
        {
            index = 0;
        }
        timer = 0;
        character.sprite = currentSprites[index];
        index++;
    }

    // Set current animation to display by specifying an index number
    public void setCurrentAnimation(int animation)
    {
        switch (animation)
        {
            case 0:
                currentSprites = new Sprite[] { idleSprite };
                if (currentStage != 0) updateSprite();
                currentStage = 0;
                break;
            case 1:
                currentSprites = backSprites;
                idleSprite = backSprites[0];
                character.flipX = false;
                if (currentStage != 1) updateSprite();
                currentStage = 1;
                break;
            case 2:
                currentSprites = frontSprites;
                idleSprite = frontSprites[0];
                character.flipX = false;
                if (currentStage != 2) updateSprite();
                currentStage = 2;
                break;
            case 3:
                currentSprites = sideSprites;
                idleSprite = sideSprites[0];
                character.flipX = false;
                if (currentStage != 3) updateSprite();
                currentStage = 3;
                break;
            case 4:
                currentSprites = sideSprites;
                idleSprite = sideSprites[0];
                character.flipX = true;
                if (currentStage != 4) updateSprite();
                currentStage = 4;
                break;
            default:
                throw new Exception("Unknown animation index");
        }
    }
}
