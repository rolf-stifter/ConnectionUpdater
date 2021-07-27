using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace ConnectionUpdater
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Connection updater"),
        ExportMetadata("Description", "Update your connection to access the new Dynamics service."),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAA3QAAAN0BcFOiBwAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAJ2SURBVFiFtdc7a1RBGMbx38Q0iogX1IhLUniLKIJiI9iIjQjBC4ig30ALwcIy+BFEkCB2Qiy8IBG0UqxFiCIoiYmmSYgpEm+NFmYszsmymezuOZtsBqbYnffd//Oe884zsyHGqN0jhNCHsziMPfiKd3geY3y0KDjG2LaJLXiA2GQOoaua00Z4L6YK4AtzBtvbJiCHT5eEL8wnMUZhpT0QQujFa3QlS79wGx9wANewMYk5s1qVj6Enie3B9yTu3mrBKw1ybiaxw8uF72oVnuddSOJ/d7T+1pFtt0+Yq/luHCdijJNN8g4ln0fasQO6cVq+rZrE9eBn8gQGOlspO4SwD8dwBDvwBW/wLMb4r0leBS+xIVl6WrbKtbiFefX39FdcbJBbkfVGmnO/lBHJuv1zA3A6r5eET2FzoQCtO9w0Ogvg0+itMpYB/ys7UAZkO6F2bQ7rysIbCmgCH5PZ6oKFr8FVjOZ9cFm2K8bLwOsKKIBXcCmHjeIKOvK8gIOYKAtfIqAEfB1mk7X3uIPH+NMKfJGAInge04lvJRuyEF4VgM3qXyaWeLvsWG3kB6k3NIXXChgsA68RcRKTDcDzeIhNZUwuyHz8ucWj8GAJIazHeRzHTtkF5CMGY4wTjfLqjbtJBT/QXWBQW3PhTeNK2ry3iYD+goTUZGbxCkeWK+B3IqCvBXhtt+9ejoAO2UFTO/Y3eOcV2eVzd7L0TdYv4+Xf+uKR9sAMtiWVdzepvHCrFb2Cc3V+eAY30Id+WWO2HV7rA0N1ACtyuFYFdOVVl4FPtQteFVAjouhJDMpvMu2aS/6ahRDO4RSOYi9GMIyhGOOLsp1ddvwH0t0pWQM+GpkAAAAASUVORK5CYII="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Orange"),
        ExportMetadata("PrimaryFontColor", "White"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class ConnectionUpdater : PluginBase, INoConnectionRequired
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new ConnectionUpdaterControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public ConnectionUpdater()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}