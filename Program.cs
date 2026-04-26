using System;
using System.Windows.Forms;
using KR.Forms;

namespace KR
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// Вариант 11: передача текстовых файлов по RS232C (нульмодемный кабель, 2 ПК).
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChatForm());
        }
    }
}
