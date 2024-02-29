using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Infrastructure.Configurations
{
    public static class AssembliesForMediatR
    {
        public static List<Assembly> GetAssembliesForMediatR()
        {
            List<Assembly> listOfAssemblies = new List<Assembly>();
            var mainAsm = Assembly.GetEntryAssembly();
            listOfAssemblies.Add(mainAsm);

            foreach (var refAsmName in mainAsm.GetReferencedAssemblies()
                .Where(t => t.Name.StartsWith("Geofencing.", StringComparison.OrdinalIgnoreCase)))
            {
                listOfAssemblies.Add(Assembly.Load(refAsmName));
            }
            return listOfAssemblies;
        }
    }
}
