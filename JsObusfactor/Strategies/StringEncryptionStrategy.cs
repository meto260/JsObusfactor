using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JsObusfactor.Strategies
{
    /// <summary>
    /// Strategy for encrypting string literals in JavaScript code using Base64 encoding
    /// </summary>
    public class StringEncryptionStrategy : IObfuscationStrategy
    {
        /// <summary>
        /// Encrypts string literals in the code and adds a decoder function
        /// </summary>
        /// <param name="code">JavaScript code to be obfuscated</param>
        /// <returns>JavaScript code with encrypted strings</returns>
        public string Apply(string code)
        {
            // Find string literals (with a simple regex)
            var stringRegex = new Regex(@"([""'])(?:\\\1|.)*?\1", RegexOptions.Compiled);
            var matches = stringRegex.Matches(code);
            
            // Create a random variable name for the decoder
            string decoderVar = $"_$${Guid.NewGuid().ToString("N").Substring(0, 8)}";
            
            // For each string:
            foreach (Match match in matches.Cast<Match>().ToArray())
            {
                // Remove quotation marks
                string str = match.Value.Substring(1, match.Value.Length - 2);
                
                // Skip if empty string
                if (string.IsNullOrEmpty(str))
                    continue;
                    
                // Skip if contains special formats like regex, functions
                if (str.Contains("\\") || str.Contains("${"))
                    continue;
                
                // Encode the string to base64
                string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
                
                // Replace the code
                code = code.Replace(match.Value, $"{decoderVar}('{base64}')");
            }
            
            // Add the Base64 decode function
            string decoderFunc = $"function {decoderVar}(s){{return decodeURIComponent(atob(s).split('').map(function(c){{return '%'+('00'+c.charCodeAt(0).toString(16)).slice(-2)}}).join(''))}}";
            
            // Wrap the code with the decode function
            return $"{decoderFunc};{code}";
        }
    }
}