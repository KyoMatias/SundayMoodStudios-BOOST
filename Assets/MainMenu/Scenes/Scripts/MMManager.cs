using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ChapterManager  : MonoBehaviour
{
     // Reference to the Chapter Storage script
    public ChapterStorage chapterStorage;
    public StoryChapter[] Instancechapters;

    [Header("Active Chapter")]
    public StoryChapter CurrentChapter;

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
            if(!indexChap.Completed)
            {
                CurrentChapter = indexChap;
            }
        }
    }




static bool AreChaptersFinished(IEnumerable<StoryChapter> myChapters)
{
    foreach (var chapter in myChapters)
    {
        if (chapter.Completed) return true;
    }

    return false;
}
}
