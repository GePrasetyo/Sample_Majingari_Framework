using System.Reflection;
using UnityEditor;

namespace Majingari.Framework.World {
    //[CustomEditor(typeof(WorldConfig))]
    //public class WorldConfigEditor : Editor {
        //public override void OnInspectorGUI() {
        //    base.OnInspectorGUI();

        //    var targetClass = (WorldConfig)target;
        //    var startMapField = typeof(WorldConfig).GetField("startMap");
        //    var startMapNameField = typeof(WorldConfig).GetField("startMapName");
            

        //    if (startMapField != null && startMapNameField !=null) {
        //        var mapAsset = (SceneAsset)startMapField.GetValue(targetClass);
        //        startMapNameField.SetValue(targetClass, mapAsset == null ? "" : mapAsset.name);
        //    }

            //var mapListField = typeof(WorldConfig).GetField("mapList");
            //if (mapListField != null) {
            //    var mapList = (WorldConfigList[])mapListField.GetValue(targetClass);

            //    for (int i = 0; i < mapList.Length; i++) {
            //        mapList[i].mapName = mapList[i].Map == null ? "" : mapList[i].Map.name;
            //    }
            //}
        //}
    //}
}