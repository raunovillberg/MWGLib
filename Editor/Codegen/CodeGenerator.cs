using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace MWG
{
    public static class CodeGenerator
    {
        private const string WARNING_TEMPLATE =
            @"//------------------------------------------------------------------------------
// <auto-generated>
//    Generated by EFACodeGen.
//    Changing this code by hand is not recommended.
//    Any hand-made changes will be lost after generating the code again.
// </auto-generated>
//------------------------------------------------------------------------------
";

        [MenuItem("Tools/MWG/Code Generation/Generate all")]
        public static void GenerateAll()
        {
            var fullPath = Path.Combine(
                Application.dataPath,
                "Sources",
                "EFAGenerated"
            );
            GenerateAll(fullPath);
        }

        public static void GenerateAll(string path)
        {
            var instances = FilesToBeGenerated();
            for (var index = 0; index < instances.Count; index++)
            {
                var instance = instances[index];
                var fileName = instance.FileName();
                EditorUtility.DisplayProgressBar(
                    "Generating code",
                    $"Generating {fileName}",
                    (index + 1) / (float) instances.Count
                );
                WriteFile(path, instance.Namespace(), fileName, instance.FileContent());
            }

            EditorUtility.ClearProgressBar();
        }

        public static List<ICodeGenerator> FilesToBeGenerated()
        {
            var instances = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(ICodeGenerator).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Select(e => e as ICodeGenerator)
                .ToList();
            return instances;
        }

        private static void WriteFile(string intoPath, string intoNamespace, string fileName, string content)
        {
            intoPath = HandleNamespace(intoNamespace, intoPath);
            content = content.Insert(0, WARNING_TEMPLATE);

            File.WriteAllText(
                Path.Combine(intoPath, fileName) + ".cs",
                content
            );
        }

        private static string HandleNamespace(string intoNamespace, string intoPath)
        {
            if (string.IsNullOrWhiteSpace(intoNamespace))
                return intoPath;

            var intoNamespaceParts = intoNamespace.Split('.');
            foreach (var part in intoNamespaceParts)
            {
                intoPath = Path.Combine(intoPath, part);
                if (Directory.Exists(intoPath) == false)
                    Directory.CreateDirectory(intoPath);
            }

            return intoPath;
        }
    }
}