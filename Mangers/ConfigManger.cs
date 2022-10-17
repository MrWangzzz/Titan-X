using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TitanX { 
public class ConfigManger :Singleton<ConfigManger>
{
    
    public T Readjson<T>(string name) 
    {
        var path = string.Format("Json/{0}", name);
        TextAsset json = ResourceManger.Instance.LoadObject<TextAsset>(path);
        return JsonConvert.DeserializeObject<T>(json.text);
    }
}

}