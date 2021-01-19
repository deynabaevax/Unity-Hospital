using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneIndex);
	}
	public void ResetStats()
	{
		ResourceManager.nrOfHealthyPats = 0;
		ResourceManager.nrOfSickPats = 0;
		ResourceManager.quarantinedPats = 0;
		ResourceManager.nrOfDeadPats = 0;
	}

	//For unit testing ResetStats()
	public int Reset()
	{
		ResourceManager.nrOfHealthyPats = 0;
		ResourceManager.nrOfSickPats = 0;
		ResourceManager.quarantinedPats = 0;
		ResourceManager.nrOfDeadPats = 0;
		return (ResourceManager.nrOfHealthyPats + ResourceManager.nrOfSickPats + ResourceManager.quarantinedPats + ResourceManager.nrOfDeadPats);
	}
}
