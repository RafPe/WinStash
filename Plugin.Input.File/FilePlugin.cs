using System;
using System.Collections;
using System.Collections.Generic;
using WinStash.Core.plugins;

namespace Plugin.Input.File
{
    [PluginType("file", "FilePlugin")]
    public class FilePlugin : IFilePlugin
    {
        private string g;

        public FilePlugin()
        {
            g = Guid.NewGuid().ToString();
        }

        public List<IDictionary> QueryForData()
        {
            var y = new Dictionary<string, string>();
            y.Add("guid","fileplugin "+ g);

            return new List<IDictionary>() { y };
        }

    }
}
