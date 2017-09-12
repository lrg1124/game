namespace Assets.Src.Editor.Tool {

    abstract class ToolPanel {

        public virtual void OnEnable() { }

        public abstract void OnGUI();

        public virtual void OnDestroy() { }

    }
}
