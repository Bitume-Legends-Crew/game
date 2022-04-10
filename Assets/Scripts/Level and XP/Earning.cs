using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Earning : MonoBehaviour
{
    public int position = 0; // Enter here the finished position
    LevelSystem EarningLVL = LevelSystem.instance; 
    // private LevelSystem name = new LevelSystem(); // Name must be a name of a pilote
    
    
    // WE NEED TO TELL EarningLVL IS A PILOT !!!!! FIX


    // Positions : 
    // 1 = fisrt
    // 2 = second
    // 3 = third
    // 0 = hasn't finished
    
    // Add XP to "name" thank's to his position at the of the end race
    public void EarnXP(int pos, string name)
    {
        if (pos == 1)
            EarningLVL.AddExperience(100);
        if (pos == 2)
            EarningLVL.AddExperience(75);
        if (pos == 3)
            EarningLVL.AddExperience(50);
        if (pos == 0)
            EarningLVL.AddExperience(10);
        if (pos < 3)
            EarningLVL.AddExperience(25);
    }

    
    
}
