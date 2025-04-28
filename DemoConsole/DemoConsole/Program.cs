using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using static DemoConsole.LogSetting;


namespace DemoConsole
{
    internal class Program
    {
        // 開關 log 功能
        private static bool isLoggingEnabled = true;
        private static LogSetting _log = new LogSetting();

        static void Main(string[] args)
        {
            // 嘗試執行程式
            try
            {
                // 載入設定檔
                LoadSettings();

                // 啟動程式，顯示歡迎訊息
                LogInfo("程式啟動中...");

                // 執行其他功能，這裡示範記錄 log
                LogWarry("這是一個簡單的 log 訊息");

                // 模擬一個錯誤
                int result = 10 / int.Parse("0"); // 這會觸發例外

            }
            catch (Exception ex)
            {
                // 如果有例外發生，記錄錯誤訊息
                LogError($"錯誤發生: {ex.Message}");
            }
            finally
            {
                // 程式結束時顯示結束訊息
                LogInfo("程式結束");
            }
        }
        // 載入設定檔
        static void LoadSettings()
        {
            //載入json
            LoadJson();
        }

        static void LoadJson()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)  // 設定 base path，通常放在根目錄
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)  // 載入 appsettings.json
                .Build();

            // 讀取設定檔中的 IsLoggingEnabled
            string loggingSection = configuration.GetSection("Logging").GetSection("IsLoggingEnabled").Value;
            if (bool.TryParse(loggingSection, out isLoggingEnabled))
            {
            }
        }

        //LOG
        static void LogInfo(string message)
        {
            LogSwitch(message, LogLevel.Info);
        }
        static void LogWarry(string message)
        {
            LogSwitch(message, LogLevel.Warning);
        }
        static void LogError(string message)
        {
            LogSwitch(message, LogLevel.Error);
        }
        static void LogSwitch(string message, LogLevel type)
        {
            _log.Log(isLoggingEnabled, message, type);
        }
    }
}
