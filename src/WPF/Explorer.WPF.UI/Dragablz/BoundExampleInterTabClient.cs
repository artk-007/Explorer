﻿using System.Collections.Generic;
using System.Windows;
using Dragablz;
using ExplorER;

namespace Explorer.WPF.UI
{
    public class BoundExampleInterTabClient : IInterTabClient, ITabClient
    {
        public INewTabHost<Window> GetNewHost(IInterTabClient interTabClient, object partition, TabablzControl source)
        {
            MainWindow view = new();
            var model = ExplorerEr.Instance.CreateMainViewModel(new List<DirectoryTabItemViewModel>());
            view.DataContext = model;
            return new NewTabHost<Window>(view, view.InitMainView.InitialTabablzControl);
        }

        public TabEmptiedResponse TabEmptiedHandler(TabablzControl tabControl, Window window)
        {
            return TabEmptiedResponse.CloseWindowOrLayoutBranch;
        }
    }
}