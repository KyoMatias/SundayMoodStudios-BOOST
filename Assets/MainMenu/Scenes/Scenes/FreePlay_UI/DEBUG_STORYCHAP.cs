
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Chapters",menuName = "MenuMain/ChapterStats")]
public class DEBUG_STORYCHAP : ScriptableObject
{
        public string STORYCHAPTER;
        public string CHAPTERSUBTEXT;
        public int CHAPTERCODE;

        public Material CHAPTERBG;
        public bool IsChapterMarked;
}
