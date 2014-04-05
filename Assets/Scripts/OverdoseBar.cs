using UnityEngine;
using System.Collections;

public class OverdoseBar {
    
    public int drugLevel = 0;

    private int[] levels;

	// Use this for initialization
    public OverdoseBar ()
    {
        levels = new int[] {10, 30, 50, 70, 100};
	}
	
	// Add drug level and return new multiplicator level (or not)
	public int addDrugLevel (int additionalDrugLevel)
    {
        int oldDrugLevel = drugLevel;
        int additionalMultiplicator = 0;

        drugLevel += additionalDrugLevel;

        int levelIndex = 0;
        bool newLevelFound = false;

        while(levelIndex < levels.Length && !newLevelFound)
        {
            int level = levels[levelIndex];

            if (level > oldDrugLevel && level <= drugLevel) {
                additionalMultiplicator++;
                newLevelFound = true;
            }
            levelIndex++;
        }

        return additionalMultiplicator;
	}

    public void reduceDrugLevel(int reducedDrugLevel)
    {
        drugLevel -= reducedDrugLevel;
    }

    public int calculateMultiplicator()
    {
        int multiplicator = 1;
                
        foreach (int i in levels)
        {
            if (i <= drugLevel) {
                multiplicator++;
            }
        }

        Debug.Log("drug level " + drugLevel);
        Debug.Log("multiplicator " + multiplicator);

        return multiplicator;
    }
}
