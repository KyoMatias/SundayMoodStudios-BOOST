using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class MENUTRACKERDEBUG : MonoBehaviour
{
    [SerializeField] private DEBUG_STORYCHAP Tracer;
    [SerializeField] private TextMeshPro Header;
    [SerializeField] private TextMeshPro Body;
    private Material BGMAT;
    public  GameObject BG;
    private int tracernum;
    void Awake()
    {
        tracernum = Tracer.CHAPTERCODE;
    }

    // Update is called once per frame
    void Update()
    {
        BG.GetComponent<MeshRenderer>().material = BGMAT;
        if(tracernum == 3)
        {
            BGMAT = Tracer.CHAPTERBG;
            Header.text = Tracer.STORYCHAPTER;
            Body.text = Tracer.CHAPTERSUBTEXT;

        }
        else if(tracernum == 5)
        {
            BGMAT = Tracer.CHAPTERBG;
            Header.text = Tracer.STORYCHAPTER;
            Body.text = Tracer.CHAPTERSUBTEXT;
        }
    }
}
