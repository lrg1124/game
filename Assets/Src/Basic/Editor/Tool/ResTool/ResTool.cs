using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class ResTool {

    public static void RefreshABName() {
        Dictionary<string, string> oldABNameMap = new Dictionary<string, string>();
        foreach (var abName in AssetDatabase.GetAllAssetBundleNames()) {
            foreach (var assetPath in AssetDatabase.GetAssetPathsFromAssetBundle(abName)) {
                oldABNameMap[assetPath] = abName;
            }
        }
        HashSet<string> assetPathSet = new HashSet<string>();
        foreach (var assetGUID in AssetDatabase.FindAssets("l:Pack")) {
            var assetPath = AssetDatabase.GUIDToAssetPath(assetGUID);
            //不是res里面的文件不处理
            if (!assetPath.StartsWith("Assets/Res/")) {
                continue;
            }
            //没有.后缀的文件不处理
            if (assetPath.IndexOf(".") == -1) {
                continue;
            }
            if (assetPathSet.Add(assetPath)) {
                var abName = assetPath.Replace("Assets/Res/", "").ToLower();
                abName = abName.Substring(0, abName.IndexOf("."));
                var importer = AssetImporter.GetAtPath(assetPath);
                if (importer.assetBundleName != abName) {
                    importer.assetBundleName = abName;
                    importer.assetBundleVariant = "";
                }
                if (oldABNameMap.ContainsKey(assetPath)) {
                    oldABNameMap.Remove(assetPath);
                }
            }
        }
        foreach (var abName in oldABNameMap.Values) {
            AssetDatabase.RemoveAssetBundleName(abName, true);
        }
        AssetDatabase.RemoveUnusedAssetBundleNames();
        AssetDatabase.Refresh();
    }

    public static void BuildReses(BuildTarget target, bool reset = false) {
        Debug.Log(GetOutputPath(target));
    }

    public static void BuildABs() {

    }

    public static string GetOutputPath(BuildTarget target) {
        Debug.Log(Application.dataPath);
        Debug.Log(target.ToString());
        var p = Path.Combine(Application.dataPath, "../ResTemp/" + target.ToString());
        p = Path.Combine(p, "res");
        return Path.GetFullPath(p);
    }

}
