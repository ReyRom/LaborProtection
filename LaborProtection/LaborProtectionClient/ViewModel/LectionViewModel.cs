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

namespace LaborProtectionClient.ViewModel
{
    public class LectionViewModel
    {
        WebBrowser viewer;
        public List<Lection> Lections { get; set; }
        public LectionViewModel(WebBrowser web)
        {
            viewer = web;
            Lections = new List<Lection>();
            foreach (var file in Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "Lections")))
            {
                Lections.Add(new Lection() { Name = Path.GetFileName(file), Url = file });
            }
            
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
