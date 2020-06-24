﻿using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Home_Assistant_Taskbar_Menu.Entities
{
    public class InputSelect : Entity
    {
        public const string DomainName = "input_select";

        public override string Domain()
        {
            return DomainName;
        }

        protected override Control ToMenuItem(Dispatcher dispatcher, string name)
        {
            var root = new MenuItem
            {
                Header = GetName(name),
                StaysOpenOnClick = true,
                IsEnabled = IsAvailable()
            };
            GetListAttribute("options").ForEach(option =>
                root.Items.Add(CreateMenuItem(dispatcher, "select_option", option, State == option,
                    data: Tuple.Create<string, object>("option", option))));
            return root;
        }
    }
}