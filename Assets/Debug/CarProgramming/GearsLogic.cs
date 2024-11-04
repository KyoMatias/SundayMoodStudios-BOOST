using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearsLogic : MonoBehaviour
{
    public enum GearCount
    {
        R = -1,
        N = 0,
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Fifth = 5,
        Sixth = 6,
    }

    [SerializeField] private GearCount gear;




    [SerializeField]private int[] gearlvl;

    public int CurrentGear = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shifter();
    }



    void Shifter()
    {
        ShiftUp();
        //ShiftDown();

    }


    void ShiftUp()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            GearChangeMaster(CurrentGear);
            Debug.Log("Current Gear " +  CurrentGear);
        }
    }

    void  ShiftDown()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            GearChangeMaster(-CurrentGear);
            Debug.Log("Current Gear " +  CurrentGear);
        }
    }


    //IEnumerator ChangeGear(int gear)
    //{

    //}


    void GearChangeMaster(int value)
    {
        for(int i = 0; i < gearlvl.Length; i++)
        {
            gearlvl[i] += value;

            if(gearlvl[i] < 0)
            {
                gearlvl[i] = 0;
            }
        }
    }

}
