

namespace RamuneLib
{
    public static class PatchingUtils
    {
        public static void RunSpecificPatch(Type targetType, string methodName, HarmonyMethod patchMethod, HarmonyPatchType patchType)
        {
            var harmony = Variables.harmony;

            if(harmony is null)
                return;

            MethodInfo targetMethod = targetType.GetMethod(methodName);

            if(targetMethod is null)
            {
                LoggerUtils.LogError($">> Manual patch for: '{targetType}.{methodName}' as '{patchType}' not found [0]");
                return;
            }

            switch(patchType)
            {
                case HarmonyPatchType.Prefix:
                    harmony.Patch(targetMethod, prefix: patchMethod);
                    break;

                case HarmonyPatchType.Postfix:
                    harmony.Patch(targetMethod, postfix: patchMethod);
                    break;

                case HarmonyPatchType.Transpiler:
                    harmony.Patch(targetMethod, transpiler: patchMethod);
                    break;
            }

            LoggerUtils.LogFatal($">> Manual patch for: '{targetType}.{methodName}' as '{patchType}' called [1]");
        }
    }
}