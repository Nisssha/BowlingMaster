using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class ScoreMaster {


//returns a list of cumulative scores, like a normal score card
public static List<int>ScoreCumulative (List<int> rolls) {

	List<int> cumulativesScores = new List<int>();
	int runningTotal = 0;
	foreach ( int frameScore in ScoreFrames(rolls)) {
		runningTotal += frameScore;
		cumulativesScores.Add(runningTotal);
	}
		return cumulativesScores;
}

public static List<int> ScoreFrames (List<int>rolls){

List<int> frameList = new List<int>();
bool firstFrame = true;

for(int i = 0; i < rolls.Count; i++){
	
	if (firstFrame && rolls[i] == 10){  

		if(rolls.Count > i + 2) {frameList.Add(rolls[i] + rolls[i+1] + rolls[i+2]); }
	}else{
			if (!firstFrame&& frameList.Count < 10){
				int frameScore = rolls[i-1] + rolls[i]; 
		 		if (frameScore == 10 && rolls.Count > i+1) {frameScore += rolls[i+1];}

					if(frameScore!= 10 || rolls.Count > i + 1) {frameList.Add(frameScore);} //frame score equals 10, because next is zero
				}
	 firstFrame = !firstFrame;
	}
	}
	return frameList;


}
}

//return a list of individual frame scores, not like a normal score card
//public static List<int>ScoreFrames (List<int> rolls) {
//	List<int> frameList = new List<int>();
//
//int positionHelper = 2;
//int rollerHelper = 0;
//int position0;
//int position1;
//int position2; 
//int position3;
//int decrementPosition = 0;
//
//for (int i = 0; i < (rolls.LongCount()/2 + rollerHelper); i++){
//		
//			position0 = 0+positionHelper*i - decrementPosition;
//			position1 = 1+positionHelper*i - decrementPosition;
//			position2 = 2+positionHelper*i - decrementPosition; 
//			position3 = 3+positionHelper*i - decrementPosition; 
//
//	if(rolls.ElementAt(position0) == 10 && rolls.ElementAt(position1) == 10 && rolls.LongCount() >= (position0)+3){ //Strike in first bowl, adds 3 next bowls, skips one frame
//
//				frameList.Add(rolls.ElementAt(position0) + rolls.ElementAt(position1) + rolls.ElementAt(position2));
//				frameList.Add(rolls.ElementAt(position1) + rolls.ElementAt(position2) + rolls.ElementAt(position3));
//				i ++;
//				rollerHelper++;
//				decrementPosition++; decrementPosition++;
//
//
//			}else if(rolls.ElementAt(position0) == 10 && rolls.LongCount() >= (position0)+3){ //Strike in first bowl, adds 3 next bowls, skips one frame
//
//				if ( i == 9){
//					frameList.Add(rolls.ElementAt(position0) + rolls.ElementAt(position1) + rolls.ElementAt(position2));
//					return frameList;
//				}
//				frameList.Add(rolls.ElementAt(position0) + rolls.ElementAt(position1) + rolls.ElementAt(position2));
//				if(rolls.ElementAt(position1) + rolls.ElementAt(position2) < 10){
//				frameList.Add(rolls.ElementAt(position1) + rolls.ElementAt(position2));
//				i++;
//				rollerHelper++;
//
//				}
//				decrementPosition++;
//
//				//w pidu dziwny dodatek
////			}else if(rolls.ElementAt(18) == 10 && rolls.LongCount() >= (18)+2){ //Strike in first bowl, adds 3 next bowls, skips one frame
////				frameList.Add(rolls.ElementAt(18) + rolls.ElementAt(19) + rolls.ElementAt(20));
////				i++;
////				rollerHelper++;
////				decrementPosition++;
////
//			}else if((rolls.ElementAt(position0) + rolls.ElementAt(position1) >= 10) ){ //Strike in two bowls
//				
//				if(rolls.LongCount() >= 3+positionHelper*i){												//There are next two bowls to add
//								frameList.Add(rolls.ElementAt(position0) + rolls.ElementAt(position1) + rolls.ElementAt(position2)); //adds 3 bowls
//			}else if(rolls.LongCount() < 3+positionHelper*i) {
//					return frameList;											//there aren't 2 next bowls to add, return current scores 
//			}
//	}else{
//			frameList.Add(rolls.ElementAt(position0) + rolls.ElementAt(position1)); //standard behavious, adds two bowls
//	}
//}
//	return frameList;
//}
	// returns a list of individual frame scores
//public static List<int> ScoreFrames(List<int> rolls)
//{
//    List<int> frameScores = new List<int>();
//    bool newFrame = true;
//    for (int i = 0; i < rolls.Count; i++ )
//    {            
//        if(newFrame && rolls[i] == 10)  // Strike!
//        {                
//            if(rolls.Count > i + 2)     // If we have the next 2 rolls completed, add them as bonuses and complete score for frame (10 for strike plus scores for next frame)
//            {
//                frameScores.Add(10 + rolls[i + 1] + rolls[i + 2]);
//            } 
//        } else {
//            if(!newFrame && frameScores.Count < 10) // find score for frame, checking that we're not in the end of game bonus section
//            {
//                int frameScore = rolls[i] + rolls[i - 1]; // frame complete, take score from this bowl and previous
//                if (frameScore == 10 && rolls.Count > i + 1) frameScore += rolls[i + 1]; // if we have a spare and next roll is available, add next roll
//                if (frameScore != 10 || rolls.Count > i + 1) frameScores.Add(frameScore); // add frame score, unless it's a spare and next row not yet available
//            }
//            newFrame = !newFrame; // toggle whether it's a new frame, not done if strike as next will be new
//        }
//    }
//    return frameScores;
//}



