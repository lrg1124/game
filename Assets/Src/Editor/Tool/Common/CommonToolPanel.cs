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
                    RefreshResKeys();
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


        public static void RefreshResKeys() {
            // 找到之前标记号好AB名称的路径
            Dictionary<string, string> oldAbNameMap = new Dictionary<string, string>();
            foreach (var abName in AssetDatabase.GetAllAssetBundleNames()) {
                foreach (var assetPath in AssetDatabase.GetAssetPathsFromAssetBundle(abName)) {
                    oldAbNameMap[assetPath] = abName;
                }
            }
            HashSet<string> pathSet = new HashSet<string>();
            List<string> abNameList = new List<string>();
            List<Object> assetList = new List<Object>();
            foreach (var item in AssetDatabase.FindAssets("l:Pack")) {
                var path = AssetDatabase.GUIDToAssetPath(item);
                if (path.IndexOf(".") == -1) {
                    continue;
                }
                if (path.StartsWith("Assets/Res/") && pathSet.Add(path)) {
                    var abName = path.Replace("Assets/Res/", "").ToLower();
                    abName = abName.Substring(0, abName.IndexOf("."));
                    var import = AssetImporter.GetAtPath(path);
                    if (import.assetBundleName != abName) {
                        import.assetBundleName = abName;
                        import.assetBundleVariant = "";
                    }
                    abNameList.Add(abName);
                    assetList.Add(AssetDatabase.LoadMainAssetAtPath(path));
                }
            }
            foreach (var path in pathSet) {
                if (oldAbNameMap.ContainsKey(path)) {
                    oldAbNameMap.Remove(path);
                }
            }
            foreach (var abName in oldAbNameMap.Values) {
                AssetDatabase.RemoveAssetBundleName(abName, true);
            }
            AssetDatabase.RemoveUnusedAssetBundleNames();
            abNameList.Sort();

            var keyDataList = new List<KeyValuePair<string, Object>>();
            for (int i = 0; i < abNameList.Count; i++) {
                var keyData = new KeyValuePair<string, Object>(abNameList[i], assetList[i]);
                keyDataList.Add(keyData);
            }

        }

    }
}
