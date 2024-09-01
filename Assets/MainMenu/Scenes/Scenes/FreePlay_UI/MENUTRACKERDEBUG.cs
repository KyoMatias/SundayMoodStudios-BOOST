using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class MENUTRACKERDEBUG : MonoBehaviour
{
    public enum Chapter
    {
        Prologue,
        Chap1,
        Chap2,
        Chap3,
        Chap4,
        Chap5,
        Chap6,
        Chap7,
        Chap8,
        Chap9,
        Chap10,
        Chap11,
        Chap12,
        Chap13,
        Chap14,
        Chap15,
        Chap16,
        Chap17,
        Chap18,
        Chap19,
        Chap20,
        Chap21,

        
    }

    [Header("Current Story Chapter")]
    [SerializeField] private Chapter Current;
    [Header("Chapter Array List")]
    [SerializeField] private DEBUG_STORYCHAP[] Chapters;

    [SerializeField] private DEBUG_STORYCHAP Tracer;
    [SerializeField] private TextMeshPro Header;
    [SerializeField] private TextMeshPro Body;
    private Material BGMAT;
    public  GameObject BG;
    public int tracernum;
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        BG.GetComponent<MeshRenderer>().material = BGMAT;
        CurrentChapter();
        ChangeStats();

    }

    public void ChangeStats()
    {
        Header.text = Tracer.STORYCHAPTER;
        Body.text = Tracer.CHAPTERSUBTEXT;
        BGMAT = Tracer.CHAPTERBG;
    }

    public void CurrentChapter()
    {
        switch (Current)
        {
            case Chapter.Prologue:
                tracernum = 0;
            break;
            case Chapter.Chap1:
                tracernum = 1;
            break;
            case Chapter.Chap2:
                 tracernum = 2;
            break;
            case Chapter.Chap3:
                 tracernum = 3;
            break;
            case Chapter.Chap4:
                 tracernum = 4;
            break;
            case Chapter.Chap5:
                 tracernum = 5;
            break;
            case Chapter.Chap6:
                 tracernum = 6;
            break;
            case Chapter.Chap7:
                 tracernum = 7;
            break;
            case Chapter.Chap8:
                 tracernum = 8;
            break;
            case Chapter.Chap9:
                 tracernum = 9;
            break;
            case Chapter.Chap10:
                tracernum = 10;
            break;
            case Chapter.Chap11:
                tracernum = 11;
            break;
            case Chapter.Chap12:
                tracernum = 12;
            break;
            case Chapter.Chap13:
                tracernum = 13;
            break;           
            case Chapter.Chap14:
                tracernum = 14;
            break; 
            case Chapter.Chap15:
                tracernum = 15;
            break;     
            case Chapter.Chap16:
                tracernum = 16;
            break;
            case Chapter.Chap17:
                tracernum = 17;
            break;
            case Chapter.Chap18:
                tracernum = 18;
            break;     
            case Chapter.Chap19:
                tracernum = 19;
            break;
            case Chapter.Chap20:
                tracernum = 20;
            break;
            case Chapter.Chap21:
                tracernum = 21;
            break;
            default:
            break;
        }
        

    }
    
}
