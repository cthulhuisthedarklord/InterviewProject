using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Row : MonoBehaviour
{
    private float rollTime;// roll move interval
    private float rollSlowTime;//slow down
    bool rollstopped = false;
    private string[] slotContent = new string[9];
    [SerializeField] float rollInterval;
    [SerializeField]float rollspeed;
    [SerializeField]AnimationCurve rollCurve;
    [SerializeField] GameObject[] slot = new GameObject[7];//slot 2,3,4 is the correct result.
    [SerializeField] Vector3 cyclepoint;
    [SerializeField] Vector3 cyclestartpoint;
    [SerializeField] Vector3 startingposition;
    //[SerializeField] GameObject tempSprite;
    int rownum;
    

    // Start is called before the first frame update
    void Start()
    {
        rownum = int.Parse(gameObject.name[3..]);
        //Debug.Log(rownum);
        transform.position = startingposition;

        //Debug.Log(startingposition);
        rollstopped = true;
        GameManager.startGame += StartRoll;

    }
    void StartRoll(string[] curroll) {
        //Debug.Log(string.Concat(curroll));
        rollstopped = false;
        initSlot(curroll);
        StartCoroutine(Roll());
        StartCoroutine(ChangeSprite());
    }
    IEnumerator Roll() {
        if (!rollstopped)
        {
            //Debug.Log("Roll start");
            rollTime = Random.Range(0.5f,1f);
            for (float i = 0;i < 1.0f; i += Time.deltaTime * rollTime) {
                transform.Translate(rollCurve.Evaluate(i) * rollspeed * Time.deltaTime * Vector3.down);
                if (transform.position.y <= cyclepoint.y) {
                    //Debug.Log(transform.position.y);
                    //yield return new WaitForSeconds(5f);
                    
                    transform.position = cyclestartpoint;
                    //Debug.Log(transform.position.y);
                    //yield return new WaitForSeconds(5f);
                }               
                yield return new WaitForSeconds(rollInterval);
            }
            //Debug.Log("Roll Complete");
            for (float i = 0;i<1000f; i++){
                transform.Translate(0.1f * rollspeed  * Time.deltaTime * Vector3.down);
                if (transform.position.y <= cyclepoint.y)
                {
                    transform.position = cyclestartpoint;
                }
                if (transform.position.y <= startingposition.y+0.1&&transform.position.y >= startingposition.y-0.1) { 
                    transform.position = startingposition;
                    break; 
                }
                yield return new WaitForSeconds(rollInterval);
            }
           
            //Debug.Log("Slow Complete");
            rollstopped = true;
            yield break;
        }
        else { 
             yield break;
        }  
    }

    IEnumerator ChangeSprite() {
        yield return new WaitForSeconds(1.5f);
        for (int slotIndex = 0;slotIndex < 9;slotIndex++)
        {
            //Debug.Log("[" + slotIndex + "]slot: " + slot[slotIndex]);
            //Debug.Log("[" + slotIndex + "]slotContent:" + slotContent[slotIndex]);
            //tempSprite.GetComponent<SpriteRenderer>().sprite = SpriteParser.instance.SpriteParse(slotContent[slotIndex]);
            slot[slotIndex].GetComponent<SpriteRenderer>().sprite = SpriteParser.instance.SpriteParse(slotContent[slotIndex]);
            
            yield return new WaitForSeconds(0.25f);
        }
        yield break;
    }

    void initSlot(string[] curroll)
    {
        int temp = Random.Range(0, 17);
        slotContent[0] = SpriteParser.alphabetMap[temp];
        slotContent[6] = slotContent[0];
        temp = Random.Range(0, 17);
        slotContent[1] = SpriteParser.alphabetMap[temp];
        slotContent[7] = slotContent[1];
        temp = Random.Range(0, 17);
        slotContent[5] = SpriteParser.alphabetMap[temp];

        slotContent[2] = curroll[rownum];
        slotContent[8] = slotContent[2];

        slotContent[3] = curroll[rownum + 5];
        slotContent[4] = curroll[rownum + 10];
        Debug.Log(rownum + string.Concat(slotContent));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
