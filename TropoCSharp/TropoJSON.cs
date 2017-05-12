﻿using System.Web;
using Newtonsoft.Json;
using System;

namespace TropoCSharp.Tropo
{
    /// <summary>
    /// A utility class to render a Tropo object as JSON.
    /// </summary>
    public static class TropoJSONExtensions
    {
        public static void RenderJSON(this Tropo tropo, HttpResponse response)
        {
            tropo.Language = null;
            tropo.Voice = null;
            JsonSerializerSettings settings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore };
            Version v = GetVersion();
            //response.AddHeader("WebAPI-Lang-Ver", "CSharp V15.7.1 " +v.Build.ToString() +"." + v.Revision.ToString()  + "-SNAPSHOT");
            response.AddHeader("WebAPI-Lang-Ver", "CSharp V15.8.0 SNAPSHOT");
            response.Write(JsonConvert.SerializeObject(tropo, Formatting.None, settings).Replace("\\", "").Replace("\"{", "{").Replace("}\"", "}"));

        }

        public static Version GetVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Reflection.AssemblyName assemblyName = assembly.GetName();
            Version version = assemblyName.Version;
            return version;
        }

    }

}