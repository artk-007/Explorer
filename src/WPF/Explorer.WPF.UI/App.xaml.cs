using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using ExplorER;
using GongSolutions.Wpf.DragDrop;

namespace Explorer.WPF.UI
{
    public partial class App 
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ExplorerEr.CreateExplorerEr(new WpfSynchronizationHelper());

            var mainWindow = new MainWindow();

            mainWindow.Show();
        }
    }

    public class ExplorerDragDrop : IDropTarget
    {
        private static IDropTarget _instance;
        public static IDropTarget Instance => _instance ??= new ExplorerDragDrop(); 
        public void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.TargetCollection is ObservableCollection<FileEntityViewModel> targetCollection)
            {
                if (dropInfo.Data is FileEntityViewModel sourceItem)
                {
                    if (dropInfo.TargetItem == null && !targetCollection.Contains(sourceItem))
                    {
                        dropInfo.Effects = DragDropEffects.Move;
                        dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
                        dropInfo.EffectText = "Move to";
                        dropInfo.DestinationText = "В папку";
                    }

                    if (dropInfo.TargetItem is DirectoryViewModel targetFolder && targetFolder != sourceItem)
                    {
                        dropInfo.Effects = DragDropEffects.Move;
                        dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                        dropInfo.EffectText = "Move to";
                        dropInfo.DestinationText = "В папку2";
                    }
                }

                if (dropInfo.Data is ICollection<object> sourceItems)
                {

                }
            }
        }

        public void Drop(IDropInfo dropInfo)
        {
            
        }
    }
}
