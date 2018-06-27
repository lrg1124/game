using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Src.Editor.Tool.Common {

    class CommonToolPanel : ToolPanel {

        GUIStyle style;

        public CommonToolPanel() {
            style = new GUIStyle();
            style.normal.textColor = new Color(255, 255, 255);
            style.fontSize = 15;
            style.alignment = TextAnchor.MiddleCenter;
        }


        public override void OnGUI() {

            var h = GUILayout.Height(26f);
            var w0 = GUILayout.Width(45f);
            var w1 = GUILayout.Width(120f);
            var w2 = GUILayout.Width(182f);

            {
                GUILayout.Label("打包", style);
                GUILayout.Space(2);
                GUILayout.BeginHorizontal();

                if (GUILayout.Button("更新AB名称")) {
                    RefreshABName();
                }

                if (GUILayout.Button("增量打包AB")) {
                    //GameEditorTools.BuildReses(EditorUserBuildSettings.activeBuildTarget);
                }

                if (GUILayout.Button("重新打包AB")) {
                    //GameEditorTools.BuildReses(EditorUserBuildSettings.activeBuildTarget, true);
                }

                GUILayout.EndHorizontal();
            }

        }

        static void RefreshABName() {
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

    }
}
