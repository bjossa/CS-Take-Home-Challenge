﻿namespace CS_Take_Home_Challenge.fileCommunication
{
    public interface IFileWrapper
    {
        bool FileExists(string filePath);

        string[] ReadAllLinesFromFile(string filePath);
    }
}
