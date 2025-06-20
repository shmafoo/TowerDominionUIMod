// using System.Linq;
// using HarmonyLib;
// using System.Reflection;
// using Il2CppCopper.ViewManager.Code;
// using Il2CppNvizzio.Game.UI.Views.Data;
// using MelonLoader;
//
// namespace TowerDominionUIMod.Patches
// {
//     [HarmonyPatch(typeof(ViewManager))]
//     internal class ViewManager_Patch
//     {
//         [HarmonyPatch(nameof(ViewManager.AddView), new [] { typeof(int) }), HarmonyPostfix]
//         private static void AddView_int_Postfix(int viewID)
//         {
//         }
//     }
//
//     [HarmonyPatch(typeof(ViewManager))]
//     internal class ViewManager_Patch2
//     {
//         private static MethodBase TargetMethod()
//         {
//             var type = typeof(ViewManager);
//             var method = type
//                 .GetMethods()
//                 .Where(m => m.Name == "AddView" && m.IsGenericMethod)
//                 .FirstOrDefault(m => m.GetParameters().Length == 2)
//                 .MakeGenericMethod(typeof(OnBoardingViewData));
//             
//             return method;
//         }
//
//         private static void Prefix(int viewID, OnBoardingViewData viewData)
//         {
//         }
//     }
// }