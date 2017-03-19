using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class ScoreMaster {

//returns a list of cumulative scores, like a normal score card
public static List<int>ScoreCumulative (List<int> rolls)
    {
	List<int> cumulativesScores = new List<int>();
	int runningTotal = 0;
	foreach ( int frameScore in ScoreFrames(rolls))
    {
		runningTotal += frameScore;
		cumulativesScores.Add(runningTotal);
	}
		return cumulativesScores;
}

public static List<int> ScoreFrames (List<int>rolls){

List<int> frameList = new List<int>();
bool firstFrame = true;

    for(int i = 0; i < rolls.Count; i++)
    {
	    if (firstFrame && rolls[i] == 10)
            {  
            if(rolls.Count > i + 2) {frameList.Add(rolls[i] + rolls[i+1] + rolls[i+2]); }
	        }
            else
            {
			if (!firstFrame&& frameList.Count < 10)
                {
				int frameScore = rolls[i-1] + rolls[i]; 
		 		    if (frameScore == 10 && rolls.Count > i+1) {frameScore += rolls[i+1];
                }
					if(frameScore!= 10 || rolls.Count > i + 1) {frameList.Add(frameScore);} //frame score equals 10, because next is zero
				}
	     firstFrame = !firstFrame;
	    }
	}
	return frameList;
}
}
