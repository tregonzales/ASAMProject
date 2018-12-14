using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textLiner : MonoBehaviour {

    public int charactersPerLine;
    public int linesPerBlock;
    public TextMesh leftBlock;
    public TextMesh rightBlock;
    public string text;
    int blockBreakInd = 0;
    
	// Use this for initialization
	void Start () {
        string textWlines = addLines(text);
        if (blockBreakInd != 0) {
            string leftText = textWlines.Substring(0, blockBreakInd);
            string rightText = textWlines.Substring(blockBreakInd);
            leftBlock.text = leftText;
            rightBlock.text = rightText;
        }
        else
        {
            string leftText = textWlines.Substring(0, textWlines.Length);
            leftBlock.text = leftText;
        }
        
        
        
	}

    public string addLines(string s) {
        string newString = s;
        int lineCounter = 0;
        for (int i = charactersPerLine; i < s.Length; i+=charactersPerLine)
        {
            int index = i;
            while (newString[index] != ' ')
            {
                index--;
            }

            lineCounter++;
            if (lineCounter == linesPerBlock) {
                blockBreakInd = index;
            }
            newString = newString.Insert(index, System.Environment.NewLine);
        }
        return newString; 
    }
	
	// Update is called once per frame
	// void Update () {
		
	// }
}
