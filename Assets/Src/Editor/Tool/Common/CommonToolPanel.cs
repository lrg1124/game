using UnityEngine;

namespace Assets.Src.Editor.Tool.Common {

    class CommonToolPanel : ToolPanel {

        public override string Title {
            get {
                return "常用工具";
            }
        }

        public override void OnGUI() {

            var h = GUILayout.Height(26f);
            var w0 = GUILayout.Width(45f);
            var w1 = GUILayout.Width(120f);
            var w2 = GUILayout.Width(182f);

            {
                GUILayout.Label("打包");
                GUILayout.BeginHorizontal();

                if (GUILayout.Button("更新AB名称")) {
                    //GameEditorTools.ProcessEnums();
                    //GameEditorTools.ProcessViewCodes();
                    //GameEditorTools.ProcessConfigs();
                    //GameEditorTools.ProcessValues();
                    //AssetDatabase.Refresh();
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

    }
}
