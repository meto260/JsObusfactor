using System;
using System.Text;

namespace JsObusfactor.Strategies
{
    /// <summary>
    /// Strategy for obfuscating control flow in JavaScript code
    /// </summary>
    public class ControlFlowStrategy : IObfuscationStrategy
    {
        /// <summary>
        /// Wraps code in self-invoking functions and shuffles execution order
        /// </summary>
        /// <param name="code">JavaScript code to be obfuscated</param>
        /// <returns>JavaScript code with obfuscated control flow</returns>
        public string Apply(string code)
        {
            // Create a random array
            Random rnd = new Random();
            int[] orders = { 0, 1, 2 };
            
            // Shuffle the array (Fisher-Yates shuffle)
            for (int i = orders.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(0, i + 1);
                int temp = orders[i];
                orders[i] = orders[j];
                orders[j] = temp;
            }
            
            // Split the code into 3 parts (simple approach)
            int partSize = code.Length / 3;
            string[] parts = {
                code.Substring(0, partSize),
                code.Substring(partSize, partSize),
                code.Substring(2 * partSize)
            };
            
            // Shuffled function names
            string[] funcNames = {
                $"_${Guid.NewGuid().ToString("N").Substring(0, 6)}",
                $"_${Guid.NewGuid().ToString("N").Substring(0, 6)}",
                $"_${Guid.NewGuid().ToString("N").Substring(0, 6)}"
            };
            
            // Define functions
            StringBuilder result = new StringBuilder();
            
            // Function definitions
            for (int i = 0; i < 3; i++)
            {
                result.AppendLine($"function {funcNames[i]}(){{\n");
                result.AppendLine($"  {parts[orders[i]]}\n");
                result.AppendLine("}\n");
            }
            
            // Call functions in correct order
            result.AppendLine("(function(){\n");
            
            // Find the correct execution order
            int[] executionOrder = new int[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (orders[j] == i)
                    {
                        executionOrder[i] = j;
                        break;
                    }
                }
            }
            
            foreach (int i in executionOrder)
            {
                result.AppendLine($"  {funcNames[i]}();\n");
            }
            
            result.AppendLine("})();\n");
            
            return result.ToString();
        }
    }
}