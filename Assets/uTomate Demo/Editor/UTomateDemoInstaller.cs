using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

[InitializeOnLoad]
public class UTomateDemoInstaller
{

#if UNITY_3_5
	private const string DLL_SRC_NAME = "uTomateDemo_Unity_3_5.dll.ignore";
#elif UNITY_4_0 || UNITY_4_0_1 
	private const string DLL_SRC_NAME = "uTomateDemo_Unity_4_0.dll.ignore";
#elif UNITY_4_1
	private const string DLL_SRC_NAME = "uTomateDemo_Unity_4_1.dll.ignore";
#elif UNITY_4_2
	private const string DLL_SRC_NAME = "uTomateDemo_Unity_4_2.dll.ignore";
#elif UNITY_4_3
	private const string DLL_SRC_NAME = "uTomateDemo_Unity_4_3.dll.ignore";
#else
	private const string DLL_SRC_NAME = "uTomateDemo_Unity_4_5.dll.ignore";
#endif

	static UTomateDemoInstaller ()
	{
		string installationRoot = Application.dataPath + "/uTomate Demo/Editor";
		string installerFiles = installationRoot+"/InstallerFiles";
		FileInfo dllFile = new FileInfo (installationRoot + "/uTomateDemo.dll");
		FileInfo sourceFile = new FileInfo (installerFiles + "/" + DLL_SRC_NAME);

		// Check if the DLL is missing and if we got a matching source file. If so
		// copy over the matching source file to the DLL name.
		if (!dllFile.Exists && sourceFile.Exists) {
			Debug.Log ("Installing correct uTomate DLL file for current Unity version " + Application.unityVersion);
			sourceFile.CopyTo (dllFile.FullName);
			Debug.Log ("Installation complete. If you switch unity versions please delete " + 
			           dllFile.FullName + ". This installer will then run again.");
			AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
		}
	}
}
