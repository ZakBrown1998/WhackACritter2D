using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    //public variables visible in Unity
    public TextMesh displayText;

    //Private variables cna't be touched by other scripts
    private int currentValue = 0;



    // Update both the data value AND the visual display
    public void ChangeValue(int _toChange)
    {
        currentValue = currentValue + _toChange;
        displayText.text = currentValue.ToString();


}
}
