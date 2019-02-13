﻿using ESAPIX.Bootstrapper;
using ESAPIX.Common;
using PlanChecker2.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using V = VMS.TPS.Common.Model.API;

namespace PlanChecker2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            string[] args = e.Args;
            base.OnStartup(e);
            var bs = new AppBootstrapper<MainView>(() => { return V.Application.CreateApplication(); });
            //You can use the following to load a context (for debugging purposes)
            //args = ContextIO.ReadArgsFromFile(@"..\Desktop\context.txt");
            //Might disable (uncomment) for plugin mode
            bs.IsPatientSelectionEnabled = true;
            bs.Run(args);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            AppComThread.Instance.Execute(sac => sac.Dispose());
        }
    }
}
