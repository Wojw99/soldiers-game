using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granades 
{
    GameObject granade0Image;
    GameObject granade1Image;
    GameObject granade2Image;

    bool[] granades;

    public Granades(GameObject granadeOne, GameObject granadeTwo, GameObject granadeThree)
    {
        granade0Image = granadeOne;
        granade1Image = granadeTwo;
        granade2Image = granadeThree;
        granades = new bool[] { false, false, false };
        UpdateGranadeImg();
    }

    public void UpdateGranadeImg()
    {
        granade0Image.SetActive(granades[0]);
        granade1Image.SetActive(granades[1]);
        granade2Image.SetActive(granades[2]);
    }

    public bool HasGranade()
    {
        foreach (bool x in granades)
        {
            if (x == true)
                return true;
        }

        return false;
    }

    public bool IsFull()
    {
        int number = 0;

        for (int i = 0; i < granades.Length; i++)
        {
            if (granades[i])
                number++;
        }

        if (number == granades.Length)
            return true;
        else
            return false;
    }

    public void RemoveGranade()
    {
        if (granades[2])
            granades[2] = false;
        else if (granades[1])
            granades[1] = false;
        else if (granades[0])
            granades[0] = false;
        
        UpdateGranadeImg();
    }

    public void AddGranade()
    {
        if (!granades[0])
            granades[0] = true;
        else if (!granades[1])
            granades[1] = true;
        else if (!granades[2])
            granades[2] = true;

        UpdateGranadeImg();
    }
}
