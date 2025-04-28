using System;
using System.Collections.Generic;
using System.Text;

namespace DemoConsole
{
    public class Font
    {
        // 印出訊息並且讓文字變色
        public void PrintMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color; // 設定文字顏色
            Console.WriteLine(message);      // 輸出訊息
            Console.ResetColor();            // 重置顏色
        }
    }
}
