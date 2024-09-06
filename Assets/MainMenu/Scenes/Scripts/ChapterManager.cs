using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MMManager : MonoBehaviour
{
     // Reference to the Chapter Storage script
    public ChapterStorage chapterStorage;
    public StoryChapter[] Instancechapters;

    [Header("Active Chapter")]
    public StoryChapter CurrentChapter;

    public bool MasterToggle;

    // Method to populate the Instancechapters variable

    void Awake()
    {
        chapterStorage = GetComponent<ChapterStorage>();
    }
    void Update()
    {
        Instancechapters = PopulateChapters();
        Debug.Log(PopulateChapters());
        FindRecentChapter();
        ChapterToggle();


    }

    private void ChapterToggle()
    {
        if(MasterToggle)
        {
            MarkCurrentChapter();
        }
        else if(!MasterToggle)
        {
            DefaultCurrentChapter();
        }

    }
    public StoryChapter[] PopulateChapters()
    {
            // Get the chapters from the Chapter Storage script
            return chapterStorage.GetStoryChapters();
            
    }
    public void FindRecentChapter()
    {
        foreach(StoryChapter indexChap in Instancechapters)
        {
            if(!indexChap.Completed && indexChap.InProgress)
            {
                CurrentChapter = indexChap;
            }
        }
    }


    public void DefaultCurrentChapter()
    {
        CurrentChapter.InProgress = true;
        CurrentChapter.Completed = false;
    }
    public void MarkCurrentChapter()
    {
        CurrentChapter.Completed = true;
        CurrentChapter.InProgress = false;
    }

    
}
