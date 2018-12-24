using UnityEngine;
using System.Collections;

public class Level1 : Generator {

	protected override void setMessages () {

		h.Add(0, "Hi there!");
		h.Add(1, "Hold *space* to lock the basket in place");
		h.Add(3, "Try to catch these placeholders");

		h.Add(5, "The stack GROWS with each block");
		h.Add(6, "1 if you catch || 2 if you fail");


		h.Add (10, "On the right we have our hook");
		h.Add (11, "OK! ... Just pretend it looks like one!!");
		h.Add (12, "Release *space* and it'll drop anything loaded");

		h.Add (16, "");

		h.Add (18, "Right is like Tetris");
		h.Add (19, "You'll lose if the squares reach the top :(");
		h.Add (20, "But you'll get extra lifes foreach line");

		h.Add (22, "");

		h.Add (26, "Now, you can hold some cargo on the stack");
		h.Add (27, "But more than 10 and you'll start to lose lifes");
		h.Add (28, "(that thing on the top-right)");

		h.Add (30, "");



		h.Add (43, "Well Done");









	}

	protected override void step(){
		if(i >= 3 && i <= 4)
			spawn(1);

		if(i >= 7 && i <= 9)
			spawn(1);

		if(i >= 13 && i <= 16)
			spawn(1);

		if(i >= 21 && i <= 24)
			spawn(1);

		if (i >= 29 && i <= 42)
			spawn(1);

	}
}
