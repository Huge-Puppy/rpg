using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using PixelCrushers;

[System.Serializable]
public class OnBattleStart : UnityEvent { }

[System.Serializable]
public class OnBattleWin : UnityEvent { }

[RequireComponent(typeof(DestructibleSaver))]
public class MonsterArea : MonoBehaviour
{
    public string monsterAreaUniqueID;

    public int minSecondsToBattleStart;
    public int maxSecondsToBattleStart;
    public Sprite backgroundImage;
    public AudioClip musicClip;
    public bool isOneTimeBattle;
    public List<EnemiesList> enemies;

    private float probability;
    private bool active;
    private Battle currentBattle;
    private ScenePortal scenePortal;

    private float t;

    public OnBattleStart onBattleStart;
    public OnBattleWin onBattleWin;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            active = true;
            t = 0;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            active = false;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (active)
        {
            
            if(t > 1)
            {
                float randVal = Random.Range(minSecondsToBattleStart, maxSecondsToBattleStart);
                if (randVal <= probability)
                {
                    OnBattleSignal();
                }
                else
                {
                    probability++;
                }
                t = 0;
            }
            else
            {
                t += Time.deltaTime;
            }
        }
    }

    public void OnBattleSignal()
    {
        if (active)
        {
            float randVal = Random.value;
            float tempProb = 0.0f;
            // choose the monster to battle
            foreach (EnemiesList enemy in enemies)
            {
                tempProb += enemy.enemyProbability;
                currentBattle.enemy = enemy.enemy;
                if (randVal < tempProb)
                {
                    break;
                }
            }
            // navigate to battle scene
            StartCoroutine(StartBattle());
        }
    }

    IEnumerator StartBattle()
    {
        if (monsterAreaUniqueID == null)
            monsterAreaUniqueID = gameObject.name;
        currentBattle.monsterAreaObject = monsterAreaUniqueID;
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        playerObj.GetComponent<Player>().Freeze();

        probability = 0f;
        onBattleStart.Invoke();
        FlashImage flashImage = (FlashImage)FindObjectOfType(typeof(FlashImage));
        if(flashImage != null)
        {   
            flashImage.StartFlash(2f, 0.99f, Color.white);
        }


        CharStats player = playerObj.GetComponent<CharStats>();

        currentBattle.playerBaseHealth = player.healthBase;
        currentBattle.playerCurrentHealth = player.healthTotal;
        currentBattle.playerBaseMagic = player.magicBase;
        currentBattle.playerCurrentMagic = player.magicTotal;
        currentBattle.playerAttackBase = player.attackBase;
        currentBattle.playerDefenseBase = player.defenseBase;
        currentBattle.playerSpeedBase = player.speedBase;
        currentBattle.music = musicClip;

        currentBattle.level = player.level;
        currentBattle.backgroundImage = backgroundImage;

        yield return new WaitForSeconds(1f);

        

        scenePortal.UsePortal();
    }


    void Start()
    {
        probability = 0;
        currentBattle = GameObject.Find("SceneManager").GetComponent<ObjectHolder>().currentBattle;

        if(currentBattle.monsterAreaObject == monsterAreaUniqueID && currentBattle.wonBattle)
        {
            onBattleWin.Invoke();

            if (isOneTimeBattle)
            {
                Destroy(this.gameObject);
            }
        }

        

        scenePortal = gameObject.AddComponent<ScenePortal>();
        scenePortal.requiredTag = "Player";
        scenePortal.destinationSceneName = "Battle";

        currentBattle.wonBattle = false;
        currentBattle.monsterAreaObject = null;
    }


    void BattleStarted()
    {
        Debug.Log("Battle started");
    }

}


[System.Serializable]
public struct EnemiesList
{
    public Enemy enemy;
    [Range(0f,1.0f)]
    public float enemyProbability;
}



/*----------------------------- OVERVIEW -------------------------------//
 *   <<< NAME >>>
 *       -- Ranged Float.
 *       
 *   <<< DESCRIPTION >>>
 *       -- Class intended to be an alternative to Vector2 for inspector usage of ranged values.
 *
 *   <<< DEPENDENCIES >>>
 *       -- Plugins: None.
 *       -- Module: 
 *          -- None.
//----------------------------------------------------------------------*/


[System.Serializable]
public class RangedInt
{
    //------------------------------------------------------------------------------------//
    //----------------------------------- FIELDS -----------------------------------------//
    //------------------------------------------------------------------------------------//

    public int min;
    public int max;

    //------------------------------------------------------------------------------------//
    //---------------------------------- METHODS -----------------------------------------//
    //------------------------------------------------------------------------------------//

    public void Init()
    {
        min = 0;
        max = 1;
    }//End of Init()


    public RangedInt()
    {
        Init();
    }//End of MinMaxFloat()


    public RangedInt(int min, int max)
    {
        this.min = min;
        this.max = max;
    }//End of MinMaxFloat(float min, float max)


    public int GetRandomValue()
    {
        return Random.Range(min, max);
    }//End of getRandomValue


    public override string ToString()
    {
        return string.Format("[Class: {0}, Min: {1}, Max: {2}]", typeof(RangedInt).Name, min, max);
    }//End of ToString()


    public static implicit operator int(RangedInt someRangedInt)
    {
        return someRangedInt.GetRandomValue();
    }//End of implicit operator float

}//End of MinMaxFloat

[System.Serializable]
public class RangedIntAttribute : PropertyAttribute
{

    //------------------------------------------------------------------------------------//
    //----------------------------- ENUM DECLARATIONS ------------------------------------//
    //------------------------------------------------------------------------------------//

    public enum RangeDisplayType // [1]
    {
        LockedRanges,
        EditableRanges,
        HideRanges
    }

    //------------------------------------------------------------------------------------//
    //----------------------------------- FIELDS -----------------------------------------//
    //------------------------------------------------------------------------------------//

    public int max;
    public int min;
    public RangeDisplayType rangeDisplayType;

    //------------------------------------------------------------------------------------//
    //---------------------------------- METHODS -----------------------------------------//
    //------------------------------------------------------------------------------------//

    public RangedIntAttribute(int min, int max, RangeDisplayType rangeDisplayType = RangeDisplayType.LockedRanges)
    {
        this.min = min;
        this.max = max;
        this.rangeDisplayType = rangeDisplayType;
    }//End of RangedIntAttribute()

}//End of class