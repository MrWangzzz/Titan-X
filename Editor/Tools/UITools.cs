using System.Text;
using TitanX;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
namespace TitanX
{
    public class UITools
    {
        public class DoCreateFolder : EndNameEditAction
        {
            public override void Action(int instanceId, string pathName, string resourceFile)
            {
                var name = pathName.Split('/');
                var csname = name[name.Length - 1];
                IOperate.Instance.CreateFile(CreateScripts(csname), string.Format("{0}.cs", csname));
                AssetDatabase.Refresh();
            }
        }
        private static string CreateScripts(string name)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("using System;\r\n");
            builder.Append("using System.Collections;\r\n");
            builder.Append("using System.Collections.Generic;\r\n");
            builder.Append("using UnityEngine;\r\n");
            builder.Append("using UnityEngine.UI;\r\n");
            builder.Append("using TitanX;\r\n");
            builder.Append("\r\n");
            builder.Append("public class " + name + "  : " + "UIBase\r\n");
            builder.Append("{\r\n");
            builder.Append("    #region ΩÁ√Êº”‘ÿ\r\n");
            builder.Append("\r\n");
            builder.Append("    internal override void Init(params object[] dialogArgs)\r\n");
            builder.Append("    {\r\n");
            builder.Append("    }\r\n");
            builder.Append("    #endregion\r\n");
            builder.Append("}\r\n");
            return builder.ToString();
        }

    }
}
