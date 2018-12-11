using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonekcijaNaBazu.Helpers
{
  class ReflectionClass
  {
    #region reflectionMethods

    public static dynamic GetResultFromStaticMethod(string className, string methodName, object[] methodParameters)
    {
      Type staticClassType = Type.GetType(className);
      MethodInfo methodInfo = staticClassType.GetMethod(methodName);
      var methodResult = methodInfo.Invoke(null, methodParameters);
      return methodResult;
    }

    public static dynamic GetClassObject(string className, object[] classParameters)
    {
          
                Type classType = Type.GetType(className);
                return Activator.CreateInstance(classType, classParameters);
           
           
      
    }

    public static dynamic GetClassType(string className)
    {
      Type classType = Type.GetType(className);
      return classType;
    }

    #endregion
    
    public static string GetFqTypeName(string shortTypeName)
        {
            return AppDomain.CurrentDomain.GetAssemblies().ToList().SelectMany(x => x.GetTypes()).Where(x => x.Name == shortTypeName)
                .Select(x => x.FullName).FirstOrDefault();
        }
  }
}
