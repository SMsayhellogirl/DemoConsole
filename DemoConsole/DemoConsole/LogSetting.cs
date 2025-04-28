using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DemoConsole
{
    public class LogSetting
    {
        private Font _font = new Font();
        public enum LogLevel
        {
            Info,       // 0
            Warning,    // 1
            Error,      // 2
        }

        // 處理 log 記錄功能
        public void Log(bool isLoggingEnabled, string message, LogLevel type)
        {
            //預設
            ConsoleColor color = ConsoleColor.Gray;

            switch (type)
            {
                case LogLevel.Info:
                    color = ConsoleColor.Green;
                    break;
                case LogLevel.Warning:
                    color = ConsoleColor.Yellow;
                    break;
                case LogLevel.Error:
                    color = ConsoleColor.Red;
                    break;
                    default:
                    color = ConsoleColor.Gray;
                    break;
            }

            if (isLoggingEnabled)
            {
                // 如果 log 開關啟用，顯示 log 訊息
                _font.PrintMessage($"[LOG]: {message}", color);
                WriteLog(type, message);
            }
        }

        // 寫入錯誤訊息的函式
        public void WriteLog(LogLevel status, string message)
        {
            // 取得今天的日期來命名檔案
            string currentDate = DateTime.Now.ToString("yyyyMMdd");
            string logDirectory = @"D:\Logs"; // 指定日誌目錄路徑
            string logFileName = Path.Combine(logDirectory, $"Log_{currentDate}.txt"); // 檔案名為 "Log_yyyyMMdd.txt"

            // 構造日誌內容
            string logContent = $"======時間: {DateTime.Now:yyyyMMdd HH:mm:ss.fff} =====\n" +
                                $"狀況: {status.ToString()}\n" +
                                $"訊息: {message}\n" +
                                "=============================\n";

            // 寫入檔案
            try
            {
                // 如果檔案不存在，會自動創建，並且使用追加模式寫入
                File.AppendAllText(logFileName, logContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing log: {ex.Message}");
            }
        }
    }
}
