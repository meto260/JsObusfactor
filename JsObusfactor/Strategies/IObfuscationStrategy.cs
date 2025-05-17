using System;

namespace JsObusfactor.Strategies
{
    /// <summary>
    /// Interface for all obfuscation strategies
    /// </summary>
    public interface IObfuscationStrategy
    {
        /// <summary>
        /// Applies the obfuscation strategy to the provided code
        /// </summary>
        /// <param name="code">JavaScript code to be obfuscated</param>
        /// <returns>Obfuscated JavaScript code</returns>
        string Apply(string code);
    }
}