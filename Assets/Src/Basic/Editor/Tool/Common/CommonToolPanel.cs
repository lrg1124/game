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
                    ResTool.RefreshABName();
                }

                if (GUILayout.Button("增量打包AB")) {
                    ResTool.BuildReses(EditorUserBuildSettings.activeBuildTarget);
                }

                if (GUILayout.Button("重新打包AB")) {
                    ResTool.BuildReses(EditorUserBuildSettings.activeBuildTarget,true);
                }

                GUILayout.EndHorizontal();
            }

        }



    }
}
