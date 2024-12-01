using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{

    public Story[] StoryChapters;
    // Start is called before the first frame update

    private void Update()
    {
        CheckChapterList();
    }

    void CheckChapterList()
    {
        foreach (var chapter in StoryChapters)
        {
            chapter.Parameters.ChapterName = chapter.ChapterSO.GetName();
            chapter.Parameters.ChapterCode = chapter.ChapterSO.GetCode();
            chapter.Parameters.Completed = chapter.ChapterSO.GetCompletion();
        }
    }

    [System.Serializable]
    public class Story
    {
        public BOOST_Chapter ChapterSO;
        public ChapterParameters Parameters;

    }
    
    [System.Serializable]
    public class ChapterParameters
    {
        public string ChapterName;
        public int ChapterCode;
        public bool Completed;
    }
}
