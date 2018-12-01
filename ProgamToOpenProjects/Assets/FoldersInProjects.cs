using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(FindProjectsFolder))]
public class FoldersInProjects : MonoBehaviour {

    private string projectsPath;
    public string[] folders;
	// Use this for initialization
	void Start () {
        projectsPath = GetComponent<FindProjectsFolder>().GetProjectsFolderPath();
        folders = CheckFolderNames();
	}
	
	void Update () {
        folders = CheckFolderNames();
	}

    private string[] CheckFolderNames()
    {
        string[] f = Directory.GetDirectories(projectsPath);

        for (int i = 0; i < f.Length; i++)
        {
            //Removes the text that is our Current Directory
            f[i] = f[i].Remove(0, projectsPath.Length + 1);
        }

        return f;
    }
    /// <summary>
    /// Gives the Fullpath of a folder
    /// </summary>
    public string GetFolderFullPath(int positionInArray)
    {
        if(positionInArray < 0 || positionInArray > folders.Length - 1)
        {
            throw new System.ArgumentException("Is not inside the array", "positionInArray");
        }
        return projectsPath + @"\" + folders[positionInArray];
    }
}
