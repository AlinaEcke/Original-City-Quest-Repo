﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	GameObject gameManagers;
	EnvironmentManager envMgr;
	GameplayManager gpMgr;
	CQ_Interface cqInterface;

	// Use this for initialization
	void Start () {
		gameManagers = GameObject.Find ("GameManagers");
		envMgr = gameManagers.GetComponent<EnvironmentManager> ();
		gpMgr = gameManagers.GetComponent<GameplayManager> ();

		/*
		GameObject interfaceGO = GameObject.Find ("Interface");
		cqInterface = interfaceGO.GetComponent<CQ_Interface> ();
		*/
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void PlayNavigation() {
		Play (GameplayManager.GameplayType.Navigation);

		DataContainer.SetFileName("Sessions\\currentSession" + ".ses");
		DataContainer.SaveToFile();
	}

	public void PlayObstacleAvoidance() {
		Play (GameplayManager.GameplayType.ObstacleAvoidance);
	}

	public void Play(GameplayManager.GameplayType gameplayType) {
		gpMgr.gameplayType = gameplayType;

		//To load xml string from given file name:
		string filePath = "./Configurations/xml\\scene.xml";
		string configText = System.IO.File.ReadAllText(filePath);

		//To load xml file into EnvironmentManager object, call (passing in the xml as a string):
		//envMgr.LoadConfigXml(configText);
		//envMgr.LoadConfiguration ();
		gameManagers.SendMessage("LoadConfiguration", configText);

		//To create the DataContainer from the EnvironmentManager, call:
		envMgr.StartCreateEnvironment();


	}
}