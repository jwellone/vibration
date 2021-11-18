using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
#if UNITY_IOS
using UnityEditor.iOS.Xcode;
#endif

namespace jwelloneEditor
{

	public static class PostProcessBuildForVibration
	{
		[PostProcessBuild]
		public static void OnPostprocessBuild(BuildTarget buildTarget, string path)
		{
#if UNITY_IOS
			var projectPath = PBXProject.GetPBXProjectPath(path);
			var pbxProject = new PBXProject();
			pbxProject.ReadFromString(File.ReadAllText(projectPath));
			var targetGUID = pbxProject.GetUnityFrameworkTargetGuid();
			pbxProject.AddFrameworkToProject(targetGUID, "CoreHaptics.framework", false);
			File.WriteAllText(projectPath, pbxProject.WriteToString());
#endif
		}
	}
}
