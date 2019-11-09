using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo
{
    public static class MessageBoxOvverideController
    {
        public static void Show(string mess = "", string title ="")
        {
            var message = new MessageBoxOvveride(mess, title);
            message.ShowDialog();
        }
    }
}
