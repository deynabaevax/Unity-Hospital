using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TimeScale : MonoBehaviour
{
	public Text tsVal;

	// Start is called before the first frame update
	void Start()
    {
		Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void ChangeTS(float toSet)//changing time scale (pause - speed up)
	{
		Time.timeScale = toSet;
		tsVal.text = $"Time scale: {toSet}";
	}
}
