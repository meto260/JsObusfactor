using System;
using System.Collections.Generic;

namespace JsObusfactor.Strategies
{
    /// <summary>
    /// Context class that manages and applies obfuscation strategies
    /// </summary>
    public class ObfuscationContext
    {
        private readonly List<IObfuscationStrategy> _strategies = new List<IObfuscationStrategy>();

        /// <summary>
        /// Adds a strategy to the context
        /// </summary>
        /// <param name="strategy">The obfuscation strategy to add</param>
        public void AddStrategy(IObfuscationStrategy strategy)
        {
            _strategies.Add(strategy);
        }

        /// <summary>
        /// Removes all strategies from the context
        /// </summary>
        public void ClearStrategies()
        {
            _strategies.Clear();
        }

        /// <summary>
        /// Applies all added strategies to the provided code in sequence
        /// </summary>
        /// <param name="code">JavaScript code to be obfuscated</param>
        /// <returns>Obfuscated JavaScript code</returns>
        public string ApplyStrategies(string code)
        {
            string result = code;
            
            foreach (var strategy in _strategies)
            {
                result = strategy.Apply(result);
            }
            
            return result;
        }
    }
}