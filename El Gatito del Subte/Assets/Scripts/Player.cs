using UnityEngine;

public class Player : BaseClass
{
    public int movementSpeed;

    void FixedUpdate()
    {
        Vector2 movementDirection = Vector2.zero;
        if(!globalScript.isPlayingIntro)
        {
            int animationToDisplay = 0;
            if (Input.GetKey(KeyCode.W))
            {
                movementDirection += Vector2.up;
                animationToDisplay = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movementDirection += Vector2.down;
                animationToDisplay = 2;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movementDirection += Vector2.right;
                animationToDisplay = 3;
            }
            if (Input.GetKey(KeyCode.A))
            {
                movementDirection += Vector2.left;
                animationToDisplay = 4;
            }
            if (movementDirection.magnitude == 0) animationToDisplay = 0;
            GetComponent<CharacterAnimator>().setCurrentAnimation(animationToDisplay);
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + movementDirection.normalized * movementSpeed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Train"))
        {
            globalScript.gameOver();
        }
        if (col.gameObject.CompareTag("Coin"))
        {
            globalScript.increaseScore(1);
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("TunnelLimit"))
        {
            globalScript.switchCurrentTimer(col.gameObject.name);
        }
        if (col.gameObject.CompareTag("BottomPlatform"))
        {
            GetComponent<SpriteRenderer>().sortingOrder = 5;
        }
        if (col.gameObject.CompareTag("StationRewardIndicator"))
        {
            globalScript.increaseScore(col.gameObject.GetComponent<StationReward>().coinAmount);
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("DisableTrainIndicators"))
        {
            globalScript.setTrainIndicatorsVisibility(false);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DontSpawnTrainsIn"))
        {
            globalScript.setTrainSpawn(false);
        }
        if (col.gameObject.CompareTag("DontSpawnTrainsOut"))
        {
            globalScript.setTrainSpawn(true);
        }
        if (col.gameObject.CompareTag("BottomPlatform"))
        {
            GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }
}
