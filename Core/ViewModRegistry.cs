using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Il2CppCopper.ViewManager.Code;

namespace TowerDominionUIMod.Core
{
    /// <summary>
    /// Static registry class that manages and provides access to view modifiers in the UI mod system.
    /// </summary>
    public static class ViewModRegistry
    {
        /// <summary>
        /// Dictionary storing view modifiers, keyed by their view names.
        /// </summary>
        private static readonly Dictionary<string, IModifyView> Modifiers = new Dictionary<string, IModifyView>();

        /// <summary>
        /// Static constructor that initializes the registry by discovering and instantiating all view modifiers.
        /// </summary>
        static ViewModRegistry()
        {
            // Find all non-abstract types that implement IModifyView
            var modifierTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t =>
                    typeof(IModifyView).IsAssignableFrom(t) &&
                    !t.IsInterface &&
                    !t.IsAbstract);

            // Create instances of found modifiers and register them by their view names
            foreach (var modifierType in modifierTypes)
            {
                var attr = modifierType.GetCustomAttribute<ViewNameAttribute>();
                if (attr == null)
                    continue;

                var instance = (IModifyView)System.Activator.CreateInstance(modifierType);
                Modifiers[attr.Name] = instance;
            }   
        }

        /// <summary>
        /// Attempts to get the view name from a given view ID using the games ViewManager.
        /// </summary>
        /// <param name="id">The ID of the view to look up.</param>
        /// <param name="name">When this method returns, contains the view name if found; otherwise, null.</param>
        /// <returns>True if the view name was found; otherwise, false.</returns>
        public static bool TryGetNameFromId(int id, out string name)
        {
            name = null;
            
            if (!ViewManager.Instance.registeredViews.TryGetValue(id, out var viewInfo))
                return false;

            name = viewInfo.Name;
            return true;
        }
        
        /// <summary>
        /// Attempts to get a view modifier for a specified view name.
        /// </summary>
        /// <param name="name">The name of the view to get the modifier for.</param>
        /// <param name="modifier">When this method returns, contains the modifier if found; otherwise, null.</param>
        /// <returns>True if the modifier was found; otherwise, false.</returns>
        public static bool TryGetModifier(string name, out IModifyView modifier)
        {
            return Modifiers.TryGetValue(name, out modifier);
        }
    }
}