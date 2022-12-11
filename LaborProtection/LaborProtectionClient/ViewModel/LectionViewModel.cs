using LaborProtectionClient.Extensions;
using LaborProtectionClient.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LaborProtectionClient.ViewModel
{
    public class LectionViewModel
    {
        WebBrowser viewer;
        private string lectionsPath = Path.Combine(Environment.CurrentDirectory, "Lections");
        public CollectionViewSource Lections { get; set; }
        public LectionViewModel(WebBrowser web)
        {
            viewer = web;
            var list = new List<Lection>();
            foreach (var file in Directory.GetFiles(lectionsPath,"", SearchOption.AllDirectories))
            {
                list.Add(new Lection() {Group = Path.GetDirectoryName(file).Replace(lectionsPath, "").TrimStart('\\'), Name = Path.GetFileName(file), Url = file });
            }
            var view = new CollectionViewSource();
            view.GroupDescriptions.Add(new PropertyGroupDescription("Group"));
            view.Source = list;
            Lections = view;
        }

        Command openLectionCommand;
        public Command OpenLectionCommand
        {
            get
            {
                return openLectionCommand ??
                    (openLectionCommand = new Command(obj =>
                    {
                        viewer.Navigate(new Uri(obj.ToString()));
                    }));
            }
        }
    }
}
