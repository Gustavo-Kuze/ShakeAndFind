﻿using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace CadeMeuMouse.Settings
{
    internal class Parser
    {
        internal static SettingsModel createSettingsIfNeeded()
        {
            if(!Directory.Exists (Application.StartupPath + "\\resources\\settings\\"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\resources\\settings\\");
            }
            if (!File.Exists(Application.StartupPath + "\\resources\\settings\\cademeumouse.json"))
            {
                SettingsModel model = new SettingsModel();
                model.ScanningInterval = 100;
                model.EnabledTime = 300;
                model.Sensitivity = "normal";
                model.CursorImagePath = Application.StartupPath + "\\resources\\imgs\\mouse_cursor.png";
                model.CursorAnimationStartSize = 35;
                model.CursorAnimationEndSize = 100;
                model.OpenAtStartup = false;


                string json = JsonConvert.SerializeObject(model);
                File.AppendAllText(Application.StartupPath + "\\resources\\settings\\cademeumouse.json",
                    json);
            }

            return load();
        }


        internal static void save(SettingsModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            File.WriteAllText(Application.StartupPath + "\\resources\\settings\\cademeumouse.json",
                json);
        }

        internal static SettingsModel load()
        {
            string fileContent = File.ReadAllText(Application.StartupPath + "\\resources\\settings\\cademeumouse.json");
            SettingsModel model = JsonConvert.DeserializeObject<SettingsModel>(fileContent);
            return model;
        }

    }
}
