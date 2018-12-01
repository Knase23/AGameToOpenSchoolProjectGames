using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FindProjectsFolder : MonoBehaviour {

    public string customFolderName = "Projects";
    public string executableLocation;
    public string customFolderPath;
    
	// Use this for initialization
	void Start () {

        bool existsProjectsFolder = false;
        executableLocation = Directory.GetCurrentDirectory();

        string[] folders = Directory.GetDirectories(executableLocation);
    
        for (int i = 0; i < folders.Length; i++)
        {
            //Removes the text that is our Current Directory
            folders[i] = folders[i].Remove(0, executableLocation.Length + 1);

            // Make sure we have spesific folder
            if(folders[i] == customFolderName)
            {
                existsProjectsFolder = true;
                //Debug.Log("Projects Exists");
                customFolderPath = executableLocation + @"\" + customFolderName;
            } 
        }

        // Create the spesific folder if it does not exists
        if (!existsProjectsFolder)
        {
            Directory.CreateDirectory(executableLocation + @"\"+ customFolderName);
            //Debug.Log("Projects is Created");
            customFolderPath = executableLocation + @"\" + customFolderName;
        }
    }
    public string GetProjectsFolderPath()
    {
        return customFolderPath;
    }
}
