using UnityEngine;
using System.Collections;

public class Level2 : Generator {
	
	protected override void setMessages () {

		h.Add (8, "Have a break");
		h.Add (9, "");

		h.Add (12, "Why did i named it stack? It's obviously a queue");
		h.Add (14, "");

		h.Add (17, "What is this?");
		h.Add (19, "");

		h.Add (26, "*f* is always for fun");
		h.Add (32, "");

		h.Add (44, "This part is cool");
		h.Add (46, "");

		h.Add (54, "Well done!!");
		h.Add (58, "Let me know that you got this far ...");
		h.Add (60, "... and comment with the word *bacon*");

	}
	
	protected override void step(){
		if (i < 8)
			spawn (1);
		if (i > 8 && i < 17)
			spawn (1);
		if (i >= 17 && i < 25 && i != 18 && i != 22)
			spawn (2);
		if(i >= 24 && i < 29)
			spawn (1);
		if (i >= 29 && i < 37 && i != 30 && i != 34)
			spawn (2);
		if(i == 37 || i == 39 || i == 41 || i == 43)
			spawn (3);
		if(i >= 46 && i < 54)
			spawn (1);
		if(i >= 54	 && i < 58)
			spawn (1);
	}

	protected override void firstQuarterStep(){
		if(i >= 46 && i < 54)
			spawn (1);
	}

	protected override void halfStep(){
		if(i >= 46 && i < 54)
			spawn (1);


	}
	
	protected override void thirdQuarterStep(){
		if(i >= 46 && i < 54)
			spawn (1);
	}
}
