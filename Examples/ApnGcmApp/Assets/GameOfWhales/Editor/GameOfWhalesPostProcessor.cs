using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;
using System.Xml;

#if UNITY_IOS
using UnityEditor.iOS.Xcode;
#endif

public class GameOfWhalesPostProcessor {


#if UNITY_IOS
    [PostProcessBuild(9999)]
    public static void OnPostprocessBuild(BuildTarget buildTarget, string pathToBuiltProject)
    {
        if (buildTarget == BuildTarget.iOS)
        {
            GameOfWhalesSettings settings = GameOfWhalesSettings.instance;

            string plistPath = Path.Combine(pathToBuiltProject, "Info.plist");
            PlistDocument plist = new PlistDocument();
            plist.ReadFromString(File.ReadAllText(plistPath));




            PlistElementDict rootDict = plist.root;
            string projPath = Path.Combine(pathToBuiltProject, Path.Combine("Unity-iPhone.xcodeproj",  "project.pbxproj"));


            PBXProject project = new PBXProject();
            project.ReadFromString(File.ReadAllText(projPath));

            string targetGUID = project.TargetGuidByName("Unity-iPhone");
            string projectString = project.WriteToString ();



            if (settings.notificationsEnabled)
            {
                var buildKey = "UIBackgroundModes";
                var backgroundModes = rootDict.CreateArray(buildKey);
                backgroundModes.AddString ("remote-notification");
                File.WriteAllText(plistPath, plist.WriteToString());

                projectString = projectString.Replace ("SystemCapabilities = {\n", "SystemCapabilities = {\n\t\t\t\t\t\t\tcom.apple.Push = {\n\t\t\t\t\t\t\t\tenabled = 1;\n\t\t\t\t\t\t\t};");
                File.WriteAllText(projPath, projectString);
            }


        }


    }


#endif

}
