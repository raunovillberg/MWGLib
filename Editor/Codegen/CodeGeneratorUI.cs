using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace MWG
{
    public class CodeGeneratorUI : EditorWindow
    {
        private string path = "";
        private Button generateAllButton;

        [MenuItem("Tools/MWG/Code Generation/Editor Window")]
        static void Init()
        {
            var window = GetWindow<CodeGeneratorUI>("MWG Code Generator");
            window.Show();
        }

        private void OnEnable()
        {
            generateAllButton = new Button(
                () =>
                {
                    CodeGenerator.GenerateAll(path);
                    AssetDatabase.Refresh();
                }
            )
            {
                text = "Generate all"
            };
            rootVisualElement.Add(generateAllButton);

            var field = new TextField("Path")
            {
                viewDataKey = "pathField"
            };
            field.RegisterValueChangedCallback(e => path = e.newValue);
            rootVisualElement.Add(field);

            var pickPathButton = new Button(
                () =>
                {
                    path = EditorUtility.OpenFolderPanel(
                        "Pick generated code directory",
                        Application.dataPath,
                        ""
                    );
                    field.value = path;
                }
            )
            {
                text = "Pick generated code directory"
            };
            rootVisualElement.Add(pickPathButton);

            AddInfoAboutFiles();
        }

        private void AddInfoAboutFiles()
        {
            var files = CodeGenerator.FilesToBeGenerated();
            if (files.Count > 0)
            {
                var info = files.Select(e => e.FileName() + ".cs");
                var text = $"Files to be generated: {string.Join(", ", info)}";
                var visualElement = new Label(text);
                rootVisualElement.Add(visualElement);
            }
        }
    }
}